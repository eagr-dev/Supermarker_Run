using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class Sistema_Guardado : MonoBehaviour
{
    [SerializeField] private string URL_PATH;
    [SerializeField] private string URL_PATH_PERSONALIZADA;
    [SerializeField] private string URL_PATH_MAPA;
    [SerializeField] private List<Material> Material_Personalizada;
    [SerializeField] private List<Car> carritos_personalizados;
    [SerializeField] private GameObject Reinicio, UI_Principal;
    private DINERO Dinero;
    private Nivel _Nivel;
    private Car carro;
    int _posicion;
    int _nivel_calidad = 0;
    string ruta = "";
    Pase_Conexion_Menu_Gameplay PCMG;

    private void Awake()
    {
#if UNITY_EDITOR
        ruta = Application.dataPath + "/SUPERMARKER";
#else
        ruta = "/storage/emulated/0/Documents/SUPERMARKER";
#endif
        URL_PATH = $"{ruta}/datos.json";
        URL_PATH_PERSONALIZADA = $"{ruta}/personalizado.json";
        URL_PATH_MAPA = $"{ruta}/mapa.txt";
        Dinero = FindObjectOfType<DINERO>();
        _Nivel = FindObjectOfType<Nivel>();
        PCMG = FindObjectOfType<Pase_Conexion_Menu_Gameplay>();
        Cargar();
        Carga_Personalizada();
        Carga_Mapa();
    }

    private void Start()
    {
        Cargar();
        Carga_Personalizada();
        Carga_Mapa();
    }

    public void Cargar()
    {
        if(File.Exists(URL_PATH))
        {
            /*Lectura de archivo*/
            string contenido = File.ReadAllText(URL_PATH);
            Contenido contenido1 = JsonUtility.FromJson<Contenido>(contenido);
            Contenido contenido_Leido = contenido1;

            /*Posicion de calidad*/
            _posicion = contenido_Leido.posicion;

            /*Dinero*/
            if(Dinero.Get_Dinero() <= 0)
                Dinero.Set_Agregar(contenido_Leido.dinero);

            /*Nivel*/
            if(Nivel.nivel <= 1)
                Nivel.Set_Nivel(contenido_Leido.nivel);

            /*Calidad*/
            QualitySettings.SetQualityLevel(contenido_Leido.nivel_calidad);
            QualitySettings.shadows = contenido_Leido.Sombras;


            /*Carros*/
            if(PCMG.Get_Seleccion() == Pase_Conexion_Menu_Gameplay.Tipo_Carro.PEQUEÑO)
                PCMG.Set_Seleccion(contenido_Leido.Tipo_Carro);
            
            Seleccion_Menu_Carrito selec = FindObjectOfType<Seleccion_Menu_Carrito>();
            selec.Set_Car_Menu(PCMG.Get_Seleccion(), _posicion);
            selec.Inicializador();
            carro = selec.Get_Active().GetComponent<Get_Content_Car>().Get_Car();
            carro.skin_car = contenido_Leido.materia;
        }
        else
        {
            Directory.CreateDirectory(ruta);
            Nivel.Set_Nivel(1);
            UI_Principal.SetActive(false);
            Reinicio.SetActive(true);
        }
    }

    public void Carga_Personalizada()
    {
        if(File.Exists(URL_PATH_PERSONALIZADA))
        {
            string leer = File.ReadAllText(URL_PATH_PERSONALIZADA);
            Contenido_Personalizado CP = JsonUtility.FromJson<Contenido_Personalizado>(leer);

            foreach (Material material in Material_Personalizada)
            {
                material.color = CP.color;
            }

            foreach(Car carro in carritos_personalizados)
            {
                carro.peso                  = CP.color.r        * carro.peso_maximo;
                carro.velocidad_adicional   = CP.color.g        * carro.velocidad_maxima;
                carro.cant_limite_carga     = (int)CP.color.b   * carro.maximo_a_cargar;
                carro.resistencia_choque    = (int)CP.color.a   * carro.maxima_resistencia;
            }
        }
        else
        {
            foreach (Material material in Material_Personalizada)
                material.color = new Color(0, 0, 0, 0);
            Guardar_Personalizado(0, 0, 0, 0);
        }
    }

    public void Carga_Mapa()
    {
        if(File.Exists(URL_PATH_MAPA))
        {
            string[] lineas = File.ReadAllLines(URL_PATH_MAPA);
            List<Mapa> mapas = FindObjectOfType<Dinero_Obtenido>().mapas;

            foreach(Mapa mapa in mapas)
            {
                foreach (string linea in lineas)
                {
                    if(mapa.nombre_espaniol == linea)
                        mapa.precio = 0;
                }
            }
        }
    }


    public void Guardar()
    {
        carro = FindObjectOfType<Get_Content_Car>().Get_Car();
        _posicion = PCMG.Get_Eleccion();
        _nivel_calidad = QualitySettings.GetQualityLevel();
        Contenido conte = new Contenido()
        {
            dinero = Dinero.Get_Dinero(),
            nivel = Nivel.nivel,
            materia = carro.skin_car,
            posicion = _posicion,
            Tipo_Carro = PCMG.Get_Seleccion(),
            nivel_calidad = _nivel_calidad,
            Sombras = QualitySettings.shadows
            
        };
        string contenido = JsonUtility.ToJson(conte);

        File.WriteAllText(URL_PATH,contenido + "\n");
    }

    public void Guardar_Personalizado(float r, float g, float b, float a)
    {
        Contenido_Personalizado contenido = new Contenido_Personalizado()
        {
            color = new Color(r, g, b, a)
        };

        string conte = JsonUtility.ToJson(contenido);

        File.WriteAllText(URL_PATH_PERSONALIZADA, conte);

    }

    public void ADD_MAPA(string nombre_mapa)
    {
        File.AppendAllText(URL_PATH_MAPA, nombre_mapa + "\n");
    }

    public void BTN_REINICIO()
    {
        FindObjectOfType<Sistema_Guardado>().Guardar();
        Application.Quit(0);
    }
}
