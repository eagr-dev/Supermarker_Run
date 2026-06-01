using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Sistema_Guardado : MonoBehaviour
{
    [SerializeField] private GameObject Reinicio, UI_Principal;

    const string CDINERO = "Dinero";
    const string CNIVEL = "Nivel";
    const string CCALIDAD = "Calidad";
    const string CPOSICION_MATERIAL = "Material";
    const string CTIPO_CARRO = "Carro";

    private string RutaPersonalizado =>
        $"{Application.persistentDataPath}/personalizado.json";

    // ── Unity ──────────────────────────────────────────────────────────────
    private void Awake()
    {
        BuildStructs.Inicializar(
            FindFirstObjectByType<DINERO>(),
            FindFirstObjectByType<Pase_Conexion_Menu_Gameplay>(),
            FindFirstObjectByType<Seleccion_Menu_Carrito>(),
            FindFirstObjectByType<Dinero_Obtenido>()
        );
        CargarLocal();
    }

    private void Start()
    {
        CargarMapas();
    }

    // ── Carga ──────────────────────────────────────────────────────────────
    private void CargarLocal()
    {
        // 1. Leer PlayerPrefs
        int calidad = PlayerPrefs.GetInt(CCALIDAD, 2);
        uint nivel = uint.Parse(PlayerPrefs.GetString(CNIVEL, "1"));
        uint dinero = uint.Parse(PlayerPrefs.GetString(CDINERO, "0"));
        int tipoCarro = PlayerPrefs.GetInt(CTIPO_CARRO, 0);
        int posicionSkin = PlayerPrefs.GetInt(CPOSICION_MATERIAL, 0);

        // 2. Aplicar a escena
        QualitySettings.SetQualityLevel(calidad);

        if (nivel >= Nivel.nivel)
            Nivel.Set_Nivel(nivel);

        BuildStructs.Dinero.Set_Dinero(dinero);

        var tipoCarro_Enum = (Pase_Conexion_Menu_Gameplay.Tipo_Carro)tipoCarro;
        BuildStructs.PCMG.Set_Seleccion(tipoCarro_Enum);
        BuildStructs.PCMG.Set_Eleccion(posicionSkin);
        BuildStructs.SelCarro.Set_Car_Menu(tipoCarro_Enum, posicionSkin);
        BuildStructs.SelCarro.Inicializador();

        // 3. El struct se actualiza solo con la escena ya aplicada
        _ = new PlayerInformacionEstructura().Capturar(BuildStructs.Dinero, BuildStructs.PCMG);
    }

    private void CargarMapas()
    {
        List<Mapa> mapas = BuildStructs.Dinero_Obtenido.mapas;

        foreach (Mapa mapa in mapas)
            if (PlayerPrefs.GetString(mapa.nombre_espaniol) == "true")
                mapa.precio = 0;

        // El struct de mapas se actualiza solo
        _ = new MapaEstructura().Capturar(mapas);
    }

    // ── Guardado ───────────────────────────────────────────────────────────
    public void GuardarLocal()
    {
        // Pide el struct con la información actual y guarda
        PlayerInformacionEstructura datos = new PlayerInformacionEstructura().Capturar(
            BuildStructs.Dinero, BuildStructs.PCMG);

        PlayerPrefs.SetString(CNIVEL, datos.nivel.ToString());
        PlayerPrefs.SetString(CDINERO, datos.dinero.ToString());
        PlayerPrefs.SetInt(CCALIDAD, datos.calidad);
        PlayerPrefs.SetInt(CPOSICION_MATERIAL, datos.posicion_skin);
        PlayerPrefs.SetInt(CTIPO_CARRO, datos.tipo_carro);
        PlayerPrefs.Save();
    }

    public void AgregarMapa(string nombreMapa)
    {
        PlayerPrefs.SetString(nombreMapa, "true");
    }

    [System.Obsolete("Sistema Bugueado — Revisar Próximamente.")]
    public void Guardar_Personalizado(float r, float g, float b, float a)
    {
        var contenido = new Contenido_Personalizado { color = new Color(r, g, b, a) };
        File.WriteAllText(RutaPersonalizado, JsonUtility.ToJson(contenido));
    }

    public void BTN_Reinicio()
    {
        GuardarLocal();
        Application.Quit(0);
    }
}