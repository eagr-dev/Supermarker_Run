using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using System;
using System.Text;
using System.Collections.Generic;

public class SistemaGuardadoNube : MonoBehaviour
{
    private const string playerFile = "supermarket_run_player_file", mapaFile = "supermarket_run_mapas_file", carrosFile = "supermarket_run_carros_file";
    private void Start() => InicializarGooglePlay();

    // ── Autenticación ──────────────────────────────────────────────────────
    private void InicializarGooglePlay()
    {
        PlayGamesPlatform.Activate();
        PlayGamesPlatform.Instance.Authenticate(OnAutenticacion);
    }

    public void BTNSubirProgreso() => SubirProgreso();

    public void BTNBajarProgreso() => BajarProgreso();

    private void OnAutenticacion(SignInStatus status)
    {
        if (status == SignInStatus.Success)
            Debug.Log("[Nube] Autenticado.");
        else
            Debug.LogWarning($"[Nube] Fallo: {status}. Solo guardado local activo.");
    }

    // ── API pública ────────────────────────────────────────────────────────

    /// <summary>Usuario sube su progreso: pide el struct actual y lo envía.</summary>
    public void SubirProgreso()
    {

        // 1. Verificar que la plataforma esté lista
        if (PlayGamesPlatform.Instance == null)
        {
            Debug.LogError("[Nube] PlayGamesPlatform no inicializado.");
            return;
        }

        // 2. Verificar que el usuario esté autenticado
        if (!PlayGamesPlatform.Instance.IsAuthenticated())
        {
            Debug.LogWarning("[Nube] Usuario no autenticado. Intentando login...");
            PlayGamesPlatform.Instance.Authenticate(success =>
            {
                if (success == SignInStatus.Success)
                    SubirProgreso(); // reintentar tras login exitoso
                else
                    Debug.LogError("[Nube] Login fallido. No se puede subir.");
            });
            return;
        }

        // 3. Verificar SavedGame disponible
        if (PlayGamesPlatform.Instance.SavedGame == null)
        {
            Debug.LogError("[Nube] SavedGame client no disponible.");
            return;
        }

        PlayerInformacionEstructura datos = new PlayerInformacionEstructura().Capturar(
            BuildStructs.Dinero, BuildStructs.PCMG);

        MapaEstructura mapas = new MapaEstructura().Capturar(
            BuildStructs.Dinero_Obtenido.mapas);

        SkinsEstructura skinsEstructura = new SkinsEstructura().Capturar(BuildStructs.PCMG);

        Debug.Log($"[Nube] Subiendo — Nivel:{datos.nivel} Dinero:{datos.dinero}");

        // TODO: serializar y subir con SavedGame API
        string player = JsonUtility.ToJson(datos);
        string mapa = JsonUtility.ToJson(mapas);
        string skins = JsonUtility.ToJson(skinsEstructura);

        //Subir datos del player
        PlayGamesPlatform.Instance.SavedGame.OpenWithAutomaticConflictResolution(playerFile,
            DataSource.ReadCacheOrNetwork,
            ConflictResolutionStrategy.UseLongestPlaytime,
            (status, metadata) => OnArchivoAbiertoParaEscribir(status, metadata, player));

        //Subir datos de los mapas comprados
        PlayGamesPlatform.Instance.SavedGame.OpenWithAutomaticConflictResolution(mapaFile,
            DataSource.ReadCacheOrNetwork,
            ConflictResolutionStrategy.UseLongestPlaytime,
            (status, metadata) => OnArchivoAbiertoParaEscribir(status, metadata, mapa));

        //Subir datos de las skins obtenidas
        PlayGamesPlatform.Instance.SavedGame.OpenWithAutomaticConflictResolution(carrosFile,
            DataSource.ReadCacheOrNetwork,
            ConflictResolutionStrategy.UseLongestPlaytime,
            (status, metadata) => OnArchivoAbiertoParaEscribir(status, metadata, skins));
    }

    /// <summary>Usuario baja su progreso: recibe datos y los aplica a escena.</summary>
    public void BajarProgreso()
    {
        if (!PlayGamesPlatform.Instance.localUser.authenticated)
        {
            Debug.LogError("[Nube] No se puede bajar progreso: Usuario no autenticado.");
            return;
        }

        Debug.Log("[Nube] Bajando progreso...");

        PlayGamesPlatform.Instance.SavedGame.OpenWithAutomaticConflictResolution(
        playerFile,
        DataSource.ReadCacheOrNetwork,
        ConflictResolutionStrategy.UseLongestPlaytime,
        (status, metadata) => OnArchivoAbiertoParaLeer<SkinsEstructura>(status, metadata));

        PlayGamesPlatform.Instance.SavedGame.OpenWithAutomaticConflictResolution(
        playerFile,
        DataSource.ReadCacheOrNetwork,
        ConflictResolutionStrategy.UseLongestPlaytime,
        (status, metadata) => OnArchivoAbiertoParaLeer<MapaEstructura>(status, metadata));

        PlayGamesPlatform.Instance.SavedGame.OpenWithAutomaticConflictResolution(
        playerFile, 
        DataSource.ReadCacheOrNetwork,
        ConflictResolutionStrategy.UseLongestPlaytime, 
        (status, metadata) => OnArchivoAbiertoParaLeer<PlayerInformacionEstructura>(status, metadata)
    );

    }

    /****************************/
    /*                          */
    /*      SUBIR ARCHIVOS      */
    /*                          */
    /****************************/
    
    private void OnArchivoAbiertoParaEscribir(SavedGameRequestStatus status, ISavedGameMetadata metadata, string datosParaGuardar)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            Debug.Log("Paso 2: Archivo abierto. Convirtiendo datos a bytes...");

            // 1. Google solo entiende BYTES, así que convertimos tu String/JSON
            byte[] datosEnBytes = System.Text.Encoding.UTF8.GetBytes(datosParaGuardar);

            // 2. Creamos los metadatos (información sobre el archivo que verá Google)
            SavedGameMetadataUpdate metadataUpdate = new SavedGameMetadataUpdate.Builder()
                .WithUpdatedDescription($"Progreso guardado el: {DateTime.Now}")
                .Build();

            // 3. ¡AQUÍ SE ENVÍA LA INFORMACIÓN REAL!
            PlayGamesPlatform.Instance.SavedGame.CommitUpdate(
                metadata,
                metadataUpdate,
                datosEnBytes,
                (status, metadata) => { Debug.Log($"El estado de guardado fue {status}"); }
            );
        }
        else
        {
            Debug.LogError($"Error al intentar abrir el archivo en la nube: {status}");
        }
    }


    /****************************/
    /*                          */
    /*      BAJAR ARCHIVOS      */
    /*                          */
    /****************************/

    private void OnArchivoAbiertoParaLeer<T>(SavedGameRequestStatus status, ISavedGameMetadata metadata) where T : IDatosNube, new()
    {
        if (status == SavedGameRequestStatus.Success)
        {
            Debug.Log("[Nube] Archivo abierto con éxito. Descargando bytes...");

            // Le pedimos a Google los bytes crudos del archivo
            PlayGamesPlatform.Instance.SavedGame.ReadBinaryData(metadata, (status, data) => OnDatosDescargados<T>(status, data));
        }
        else
        {
            Debug.LogError($"[Nube] Error al abrir el archivo para leer: {status}");
        }
    }

    private void OnDatosDescargados<T>(SavedGameRequestStatus status, byte[] data) where T : IDatosNube, new()
    {
        if (status == SavedGameRequestStatus.Success)
        {
            Debug.Log("[Nube] Bytes descargados. Reconstruyendo progreso...");

            // 1. Convertimos los bytes devueltos por Google en el string JSON original
            string json = Encoding.UTF8.GetString(data);

            // Control de seguridad: Si el archivo existe pero está vacío (usuario nuevo)
            if (string.IsNullOrEmpty(json) || data.Length == 0)
            {
                Debug.LogWarning("[Nube] El archivo en la nube está vacío. ¿Es un usuario nuevo?");
                // Aquí podrías inicializar un progreso por defecto si quieres
                return;
            }

            try
            {
                // 2. Deserializamos el JSON usando tu estructura exacta
                T datos = JsonUtility.FromJson<T>(json);

                // 3. ¡Magia! Enviamos los datos a tu método para actualizar el supermercado
                switch (datos)
                {
                    case PlayerInformacionEstructura playerInfo:
                        // Tu método específico que acepta esta clase
                        AplicarDatosJugador(playerInfo);
                        break;

                    case SkinsEstructura skinsInfo:
                        AplicarSkins(skinsInfo);
                        break;

                    case MapaEstructura mapasInfo:
                        AplicarMapas(mapasInfo);
                        break;
                }

                Debug.Log("[Nube] ¡Progreso descargado y aplicado con éxito!");
            }
            catch (Exception e)
            {
                Debug.LogError($"[Nube] Error al deserializar el JSON de la nube: {e.Message}");
            }
        }
        else
        {
            Debug.LogError($"[Nube] Error crítico al leer los datos binarios de Google: {status}");
        }
    }


    /****************************/
    /*                          */
    /*      CONFIGURACION       */
    /*                          */
    /****************************/
    private void AplicarDatosJugador(PlayerInformacionEstructura datos)
    {
        if (!BuildStructs.Listo) return;

        QualitySettings.SetQualityLevel(datos.calidad);
        Nivel.Set_Nivel(datos.nivel);
        BuildStructs.Dinero.Set_Dinero(datos.dinero);

        var tipoCarro = (Pase_Conexion_Menu_Gameplay.Tipo_Carro)datos.tipo_carro;
        BuildStructs.PCMG.Set_Seleccion(tipoCarro);
        BuildStructs.PCMG.Set_Eleccion(datos.posicion_skin);
        BuildStructs.SelCarro.Set_Car_Menu(tipoCarro, datos.posicion_skin);
    }

    private void AplicarSkins(SkinsEstructura skins)
    {
        var pcmg = BuildStructs.PCMG;

        // Control de seguridad por si las listas de la escena vienen nulas por defecto
        if (pcmg.cars_Peq is null) pcmg.cars_Peq = new List<Car>();
        if (pcmg.cars_Med is null) pcmg.cars_Med = new List<Car>();
        if (pcmg.cars_Gra is null) pcmg.cars_Gra = new List<Car>();

        // 1. Procesar Carros Pequeños
        pcmg.cars_Peq.Clear(); // Borramos lo que sea que tenga la escena por defecto
        if (skins.carroPequenio != null)
            pcmg.cars_Peq.AddRange(skins.carroPequenio); // Copiamos los elementos de la nube

        // 2. Procesar Carros Medianos
        pcmg.cars_Med.Clear();
        if (skins.carroMediano != null)
            pcmg.cars_Med.AddRange(skins.carroMediano);

        // 3. Procesar Carros Grandes
        pcmg.cars_Gra.Clear();
        if (skins.carroGrande != null)
            pcmg.cars_Gra.AddRange(skins.carroGrande);
    }

    private void AplicarMapas(MapaEstructura mapas)
    {
        foreach(string nameMapa in mapas.mapasDesbloqueados)
        {
            foreach(Mapa mapa in BuildStructs.Dinero_Obtenido.mapas)
            {
                if (mapa.nombre_espaniol == nameMapa)
                    mapa.precio = 0;
            }
        }
    }
}
