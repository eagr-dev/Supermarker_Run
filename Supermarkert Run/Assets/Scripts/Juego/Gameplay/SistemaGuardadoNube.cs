using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.SavedGame;
using System;
using System.Text;
using System.Collections.Generic;

public class SistemaGuardadoNube : MonoBehaviour
{
    private const string playerFile = "supermarket_run_player_file";
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
            
            Notificacion.MostrarAlertaNativa(new NotificacionInformacionStruct(
                "Error al subir", "Google Play Games no está disponible.",
                "Upload Error", "Google Play Games is not available.",
                "Erro ao enviar", "Google Play Games não está disponível."
            ));
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
            Notificacion.MostrarAlertaNativa(new NotificacionInformacionStruct(
            "Error al subir", "No se pudo autenticar el usuario.",
            "Upload Error", "Could not authenticate user.",
            "Erro ao enviar", "Não foi possível autenticar o usuário."
            ));
            return;
        }

        // 3. Verificar SavedGame disponible
        if (PlayGamesPlatform.Instance.SavedGame == null)
        {
            Notificacion.MostrarAlertaNativa(new NotificacionInformacionStruct(
            "Error al subir", "Actualmente no se encuentra disponible el guardado en la nube.",
            "Upload Error", "Cloud save is currently unavailable.",
            "Erro ao enviar", "O salvamento na nuvem não está disponível no momento."
            ));
            Debug.LogError("[Nube] SavedGame client no disponible.");
            return;
        }

        PlayerInformacionEstructura datos = new PlayerInformacionEstructura().Capturar(
            BuildStructs.Dinero, BuildStructs.PCMG);

        MapaEstructura mapas = new MapaEstructura().Capturar(
            BuildStructs.Dinero_Obtenido.mapas);

        SkinsEstructura skinsEstructura = new SkinsEstructura().Capturar(BuildStructs.PCMG);

        PersonalizadoEstructura personalizadoEstructura = new PersonalizadoEstructura().Capturar(BuildStructs.PCMG);

        CarroCompradoEstructura carroComprado = new CarroCompradoEstructura().Capturar(BuildStructs.PCMG);

        // TODO: serializar y subir con SavedGame API
        MasterSaveInformacion Saveinformacion = new(datos, skinsEstructura, mapas, personalizadoEstructura, carroComprado);
        string informacion = JsonUtility.ToJson(Saveinformacion);

        //Subir datos del player
        PlayGamesPlatform.Instance.SavedGame.OpenWithAutomaticConflictResolution(playerFile,
            DataSource.ReadCacheOrNetwork,
            ConflictResolutionStrategy.UseLongestPlaytime,
            (status, metadata) => OnArchivoAbiertoParaEscribir(status, metadata, informacion));
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
        (status, metadata) => OnArchivoAbiertoParaLeer(status, metadata));
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
            Debug.Log($"El archivo dice {datosParaGuardar}");

            // 1. Google solo entiende BYTES, así que convertimos tu String/JSON
            byte[] datosEnBytes = Encoding.UTF8.GetBytes(datosParaGuardar);

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
            Notificacion.MostrarAlertaNativa(new NotificacionInformacionStruct(
            "Éxito", "Se subieron los datos de manera exitosa.",
            "Success", "Data uploaded successfully.",
            "Sucesso", "Dados enviados com sucesso."
            ));
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

    private void OnArchivoAbiertoParaLeer(SavedGameRequestStatus status, ISavedGameMetadata metadata)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            Debug.Log("[Nube] Archivo abierto con éxito. Descargando bytes...");

            // Le pedimos a Google los bytes crudos del archivo
            PlayGamesPlatform.Instance.SavedGame.ReadBinaryData(metadata, (status, data) =>
            {
                OnDatosDescargados(status, data);
            });
        }
        else
        {
            Debug.LogError($"[Nube] Error al abrir el archivo para leer: {status}");
        }
    }

    private void OnDatosDescargados(SavedGameRequestStatus status, byte[] data)
    {
        if (status == SavedGameRequestStatus.Success)
        {
            Debug.Log("[Nube] Bytes descargados. Reconstruyendo progreso...");

            // 1. Convertimos los bytes devueltos por Google en el string JSON original
            string json = Encoding.UTF8.GetString(data);
            Debug.Log($"El tamanio de data es {data.Length}");
            Debug.Log($"el string dice {json}");

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
                MasterSaveInformacion datos = JsonUtility.FromJson<MasterSaveInformacion>(json);
                Debug.Log($"La clase a asignar es {datos}");

                SkinsEstructura skinsInfo = datos.skins;
                AplicarSkins(skinsInfo);

                PersonalizadoEstructura personalizadoEstructura = datos.personalizado;
                AplicarPersonalizaciones(personalizadoEstructura);

                MapaEstructura mapasInfo = datos.mapa;
                AplicarMapas(mapasInfo);

                PlayerInformacionEstructura playerInfo = datos.playerInformacion;
                AplicarDatosJugador(playerInfo);

                CarroCompradoEstructura carroComprado = datos.carroComprado;
                AplicarCarroComprado(carroComprado);

                FindFirstObjectByType<Sistema_Guardado>().GuardarLocal();

                FindFirstObjectByType<Idioma>().AsignarLenguajeATextos();

                Debug.Log("[Nube] ¡Progreso descargado y aplicado con éxito!");
            }
            catch (Exception e)
            {
                Debug.LogError($"[Nube] Error al deserializar el JSON de la nube: {e.Message}");
                Notificacion.MostrarAlertaNativa(new NotificacionInformacionStruct(
            "Error", "Hubo un error al extraer la información.",
            "Error", "There was an error extracting the data.",
            "Erro", "Houve um erro ao extrair as informações."
            ));
                return;
            }
            Notificacion.MostrarAlertaNativa(new NotificacionInformacionStruct(
            "Bajar información", "Se pudo bajar la información de manera correcta.",
            "Download Data", "Data downloaded successfully.",
            "Baixar dados", "Dados baixados com sucesso."
            ));
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

        Debug.Log("BuildStructs si esta listo");
        QualitySettings.SetQualityLevel(datos.calidad);
        Nivel.Set_Nivel(datos.nivel);
        BuildStructs.Dinero.Set_Dinero(datos.dinero);

        var tipoCarro = (Pase_Conexion_Menu_Gameplay.Tipo_Carro)datos.tipo_carro;
        BuildStructs.PCMG.Set_Seleccion_Carro(tipoCarro);
        BuildStructs.PCMG.Set_Seleccion_Skin(datos.posicion_skin);
        BuildStructs.SelCarro.Set_Car_Menu(tipoCarro, datos.posicion_skin);
    }

    private void AplicarSkins(SkinsEstructura skinsInfo)
    {
        Pase_Conexion_Menu_Gameplay pcmg = BuildStructs.PCMG;
        List<CarSkinData> listaSkins = pcmg.GetListSkins();

        for (int i = 0; i < listaSkins.Count; i++)
        {
            // Si el nombre de este carro real está en la lista descargada de la nube...
            if (skinsInfo.listaNombreSkins.Contains(listaSkins[i].id))
            {
                // 1. Sacamos el struct de la lista (esto crea una copia modificable)
                CarSkinData skinModificada = listaSkins[i];

                // 2. Cambiamos el precio en la copia
                skinModificada.precio = 0;

                // 3. Volvemos a guardar el struct modificado en la lista original
                listaSkins[i] = skinModificada;
            }
        }
    }

    private void AplicarMapas(MapaEstructura mapas)
    {
        foreach(string nameMapa in mapas.mapasDesbloqueados)
        {
            foreach(Mapa mapa in BuildStructs.Dinero_Obtenido.mapas)
            {
                if (mapa.nombre_espaniol == nameMapa)
                {
                    mapa.precio = 0;
                    Debug.Log($"el mapa {mapa.nombre_espaniol} se compro");
                }
            }
        }
    }

    private void AplicarPersonalizaciones(PersonalizadoEstructura personalizadoEstructura)
    {
        var orquestadores = BuildStructs.PCMG.GetOrquestadores();
        orquestadores.Item1.SetNivelStats(personalizadoEstructura.pequenio.level, personalizadoEstructura.pequenio.stats);
        orquestadores.Item2.SetNivelStats(personalizadoEstructura.mediano.level, personalizadoEstructura.mediano.stats);
        orquestadores.Item3.SetNivelStats(personalizadoEstructura.grande.level, personalizadoEstructura.grande.stats);
    }

    private void AplicarCarroComprado(CarroCompradoEstructura carroComprado)
    {
        if (carroComprado.pequenio.precio == 0) BuildStructs.PCMG.GetComprado(Pase_Conexion_Menu_Gameplay.Tipo_Carro.PEQUEÑO).precio = 0;
        if (carroComprado.mediano.precio == 0) BuildStructs.PCMG.GetComprado(Pase_Conexion_Menu_Gameplay.Tipo_Carro.MEDIANO).precio = 0;
        if (carroComprado.grande.precio == 0) BuildStructs.PCMG.GetComprado(Pase_Conexion_Menu_Gameplay.Tipo_Carro.GRANDE).precio = 0;
    }

}
