using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class Sistema_Guardado : MonoBehaviour
{
    [SerializeField] private string URL_PATH;
    [SerializeField] private string URL_PATH_PERSONALIZADA;
    [SerializeField] private List<Material> Material_Personalizada;
    [SerializeField] private TMP_Text Nivel;
    [SerializeField] private TMP_Text Dinero_Text;
    [SerializeField] private TMP_Text FileDir;
    private DINERO Dinero;
    private Nivel _Nivel;
    private Car carro;
    int _posicion;
    int _nivel_calidad = 0;
    Pase_Conexion_Menu_Gameplay PCMG;

    private void Awake()
    {
#if UNITY_EDITOR
        URL_PATH = Application.dataPath + "/datos.json";
        URL_PATH_PERSONALIZADA = Application.dataPath + "/personalizado.json";
        Debug.Log("En el editor");
#else
        URL_PATH = Application.persistentDataPath + "/datos.json";
        URL_PATH_PERSONALIZADA = Application.persistentDataPath + "/personalizado.json";
#endif
        
        Dinero = FindObjectOfType<DINERO>();
        _Nivel = FindObjectOfType<Nivel>();
        PCMG = FindObjectOfType<Pase_Conexion_Menu_Gameplay>();
        Cargar();
        Carga_Personalizada();
        FileDir.text = URL_PATH;
    }

    private void Start()
    {
        Cargar();
        Carga_Personalizada();
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
            Dinero_Text.text = "Money: " + contenido_Leido.dinero.ToString();

            /*Nivel*/
            _Nivel.nivel = contenido_Leido.nivel;
            Nivel.text = "Level: " + _Nivel.nivel.ToString();

            /*Calidad*/
            QualitySettings.SetQualityLevel(contenido_Leido.nivel_calidad);
            QualitySettings.shadows = contenido_Leido.Sombras;


            /*Carros*/
            PCMG.Set_Seleccion(contenido_Leido.Tipo_Carro);
            Seleccion_Menu_Carrito selec = FindObjectOfType<Seleccion_Menu_Carrito>();
            selec.Set_Car_Menu(PCMG.Get_Seleccion(), _posicion);
            selec.Inicializador();
            carro = selec.Get_Active().GetComponent<Get_Content_Car>().Get_Car();
            carro.skin_car = contenido_Leido.materia;
        }
        else
        {
            _Nivel.nivel = 1;
            Dinero.Set_Agregar(0);
            Dinero_Text.text = "Money: 0";
        }
    }

    public void Carga_Personalizada()
    {
        if(File.Exists(URL_PATH_PERSONALIZADA))
        {
            string leer = File.ReadAllText(URL_PATH_PERSONALIZADA);
            Contenido_Personalizado CP = JsonUtility.FromJson<Contenido_Personalizado>(leer);

            foreach(Material material in Material_Personalizada)
            material.color = CP.color;
        }
        else
        {
            foreach (Material material in Material_Personalizada)
                material.color = new Color(0, 0, 0, 0);
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
            nivel = _Nivel.nivel,
            materia = carro.skin_car,
            posicion = _posicion,
            Tipo_Carro = PCMG.Get_Seleccion(),
            nivel_calidad = _nivel_calidad,
            Sombras = QualitySettings.shadows
            
        };
        string contenido = JsonUtility.ToJson(conte);

        File.WriteAllText(URL_PATH,contenido);
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
}
