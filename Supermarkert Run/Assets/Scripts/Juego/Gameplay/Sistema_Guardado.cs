using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class Sistema_Guardado : MonoBehaviour
{
    [SerializeField] private string URL_PATH_PERSONALIZADA;
    [SerializeField] private List<Material> Material_Personalizada;
    [SerializeField] private List<Car> carritos_personalizados;
    [SerializeField] private GameObject Reinicio, UI_Principal;
    private DINERO Dinero;
    private Seleccion_Menu_Carrito seleccion_carro;
    string ruta = "";
    Pase_Conexion_Menu_Gameplay PCMG;
    const string CDINERO = "Dinero", CNIVEL = "Nivel", CCALIDAD = "Calidad", CPOSICION_MATERIAL = "Material", CTIPO_CARRO = "Carro", CCALIDAD_SOMBRAS = "Sombras";

    private void Awake()
    {
        URL_PATH_PERSONALIZADA = $"{ruta}/personalizado.json";
        Dinero = FindFirstObjectByType<DINERO>();
        PCMG = FindFirstObjectByType<Pase_Conexion_Menu_Gameplay>();
        seleccion_carro = FindFirstObjectByType<Seleccion_Menu_Carrito>();
    }

    private void Start()
    {
        NewLoad();
        NewLoadMaps();
    }

    private void NewLoad()
    {
        int calidad_graficos = PlayerPrefs.GetInt(CCALIDAD, 2);
        QualitySettings.SetQualityLevel(calidad_graficos);

        uint nivel = uint.Parse(PlayerPrefs.GetString(CNIVEL, "1"));
        if (nivel >= Nivel.nivel)
        {
            Debug.Log($"Nivel guardado {nivel} -Nivel actual {Nivel.nivel}");
            Nivel.Set_Nivel(nivel);
        }

        uint dinero = uint.Parse(PlayerPrefs.GetString(CDINERO, "0"));
        Dinero.Set_Dinero(dinero);

        Pase_Conexion_Menu_Gameplay.Tipo_Carro tipo_Carro = (Pase_Conexion_Menu_Gameplay.Tipo_Carro)PlayerPrefs.GetInt(CTIPO_CARRO, 0);
        PCMG.Set_Seleccion(tipo_Carro);
        int posicion_skin = PlayerPrefs.GetInt(CPOSICION_MATERIAL, 0);
        seleccion_carro.Set_Car_Menu(tipo_Carro, posicion_skin);
        seleccion_carro.Inicializador();
        PCMG.Set_Eleccion(posicion_skin);
        seleccion_carro.Set_Car_Menu(tipo_Carro, posicion_skin);

    }

    private void NewLoadMaps()
    {
        List<Mapa> mapas = FindFirstObjectByType<Dinero_Obtenido>().mapas;
        foreach (Mapa mapa in mapas)
        {
            if(PlayerPrefs.GetString(mapa.nombre_espaniol) == "true")
            {
                mapa.precio = 0;
            }
        }
    }

    public void NewSaved()
    {
        PlayerPrefs.SetString(CNIVEL, Nivel.nivel.ToString());
        PlayerPrefs.SetString(CDINERO, Dinero.Get_Dinero().ToString());
        PlayerPrefs.SetInt(CCALIDAD, QualitySettings.GetQualityLevel());

        PlayerPrefs.SetInt(CPOSICION_MATERIAL, PCMG.Get_Eleccion());
        PlayerPrefs.SetInt(CTIPO_CARRO, (int)PCMG.Get_Seleccion());

        PlayerPrefs.SetInt(CCALIDAD_SOMBRAS, (int)QualitySettings.shadows);
        PlayerPrefs.Save();
    }

    [System.Obsolete("Sistema Bugueado Revisar Proximamente.")]
    public void Guardar_Personalizado(float r, float g, float b, float a)
    {
        Contenido_Personalizado contenido = new Contenido_Personalizado()
        {
            color = new Color(r, g, b, a)
        };

        string conte = JsonUtility.ToJson(contenido);

        File.WriteAllText(URL_PATH_PERSONALIZADA, conte);

    }

    public void NEW_ADD_MAPA(string name_map)
    {
        PlayerPrefs.SetString(name_map, "true");
    }

    public void BTN_REINICIO()
    {
        FindFirstObjectByType<Sistema_Guardado>().NewSaved();
        Application.Quit(0);
    }
}
