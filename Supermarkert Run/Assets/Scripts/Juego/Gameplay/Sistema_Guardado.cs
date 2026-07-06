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
    const string CCARRO_PEQUENIO = "CarroPequenio", CCARRO_MEDIANO = "CarroMediano", CCARRO_GRANDE = "CarroGrande";

    private string RutaPersonalizado =>
        $"{Application.persistentDataPath}/personalizado.json";

    // ── Unity ──────────────────────────────────────────────────────────────
    private void Awake()
    {
        bool yaEstabaListo = BuildStructs.Inicializar(
            FindFirstObjectByType<DINERO>(),
            FindFirstObjectByType<Pase_Conexion_Menu_Gameplay>(),
            FindFirstObjectByType<Seleccion_Menu_Carrito>(),
            FindFirstObjectByType<Dinero_Obtenido>()
        );
        if(!yaEstabaListo)
            CargarLocal();
    }

    private void Start()
    {
        BuildStructs.SelCarro.Inicializador();
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

        CargarSkinsCompradas();
        Cargar_Carros_Comprados();

        var tipoCarro_Enum = (Pase_Conexion_Menu_Gameplay.Tipo_Carro)tipoCarro;
        BuildStructs.PCMG.Set_Seleccion_Carro(tipoCarro_Enum);
        BuildStructs.PCMG.Set_Seleccion_Skin(posicionSkin);
        BuildStructs.SelCarro.Set_Car_Menu(tipoCarro_Enum, posicionSkin);

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

    public void CargarCarros(OrquestadorAumentadorNivelCarro pequenio,
        OrquestadorAumentadorNivelCarro mediano, OrquestadorAumentadorNivelCarro grande)
    {
        if (PlayerPrefs.HasKey(CCARRO_PEQUENIO))
        {
            string jsonP = PlayerPrefs.GetString(CCARRO_PEQUENIO);
            var json = JsonUtility.FromJson<PersonalizadoEstructura.GuardarInformacionEstructura>(jsonP);
            pequenio.SetNivelStats(json.level, json.stats);

        }

        if (PlayerPrefs.HasKey(CCARRO_MEDIANO))
        {
            string jsonM = PlayerPrefs.GetString(CCARRO_MEDIANO);
            var json = JsonUtility.FromJson<PersonalizadoEstructura.GuardarInformacionEstructura>(jsonM);
            mediano.SetNivelStats(json.level, json.stats);
        }

        if (PlayerPrefs.HasKey(CCARRO_GRANDE))
        {
            string jsonG = PlayerPrefs.GetString(CCARRO_GRANDE);
            var json = JsonUtility.FromJson<PersonalizadoEstructura.GuardarInformacionEstructura>(jsonG);
            grande.SetNivelStats(json.level, json.stats);
        }
    }

    void CargarSkinsCompradas()
    {
        for (int i = 0; i < BuildStructs.PCMG.GetCountSkins(); i++)
        {
            if (!PlayerPrefs.HasKey(i.ToString())) continue;
            var skin = BuildStructs.PCMG.GetSkin(i);
            skin.precio = 0;
            BuildStructs.PCMG.SetSkin(i, skin);
        }
    }

    public void Cargar_Carros_Comprados()
    {
        CarroCompradoEstructura carroComprado = new CarroCompradoEstructura().Capturar(BuildStructs.PCMG);

        carroComprado.pequenio.precio = (uint)PlayerPrefs.GetInt(carroComprado.pequenio.tipo_Carro.ToString());

        if (PlayerPrefs.HasKey(carroComprado.mediano.tipo_Carro.ToString()))
            carroComprado.mediano.precio = (uint)PlayerPrefs.GetInt(carroComprado.mediano.tipo_Carro.ToString());

        if (PlayerPrefs.HasKey(carroComprado.grande.tipo_Carro.ToString()))
            carroComprado.grande.precio = (uint)PlayerPrefs.GetInt(carroComprado.grande.tipo_Carro.ToString());
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
        GuardarSkins();
        Guardar_Carros_Comprados();
        PlayerPrefs.Save();
    }

    public void AgregarMapa(string nombreMapa)
    {
        PlayerPrefs.SetString(nombreMapa, "true");
        PlayerPrefs.Save();
    }

    public void GuardarSkins()
    {
        var PCMG = BuildStructs.PCMG;
        for (int i = 0; i < PCMG.GetCountSkins(); i++)
        {
            if (PCMG.GetSkin(i).precio != 0) continue;
            PlayerPrefs.SetInt(i.ToString(), 0);
        }
    }

    public void Guardar_Personalizado()
    {
        PersonalizadoEstructura estructura = new PersonalizadoEstructura().Capturar(BuildStructs.PCMG);

        string jsonP = JsonUtility.ToJson(estructura.pequenio);
        string jsonM = JsonUtility.ToJson(estructura.mediano);
        string jsonG = JsonUtility.ToJson(estructura.grande);
        Debug.Log(jsonP);
        PlayerPrefs.SetString(CCARRO_PEQUENIO, jsonP);
        PlayerPrefs.SetString(CCARRO_MEDIANO, jsonM);
        PlayerPrefs.SetString(CCARRO_GRANDE, jsonG);
        PlayerPrefs.Save();
    }

    public void Guardar_Carros_Comprados()
    {
        CarroCompradoEstructura carroComprado = new CarroCompradoEstructura().Capturar(BuildStructs.PCMG);

        PlayerPrefs.SetInt(carroComprado.pequenio.tipo_Carro.ToString(), (int)carroComprado.pequenio.precio);
        PlayerPrefs.SetInt(carroComprado.mediano.tipo_Carro.ToString(), (int)carroComprado.mediano.precio);
        PlayerPrefs.SetInt(carroComprado.grande.tipo_Carro.ToString(), (int)carroComprado.grande.precio);
        PlayerPrefs.Save();
    }

    public void BTN_Reinicio()
    {
        GuardarLocal();
        Application.Quit(0);
    }
}