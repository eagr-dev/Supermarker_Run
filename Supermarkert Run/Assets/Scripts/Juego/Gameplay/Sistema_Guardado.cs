using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class Sistema_Guardado : MonoBehaviour
{
    [SerializeField] private string URL_PATH;
    [SerializeField] private TMP_Text Nivel;
    private DINERO Dinero;
    private Nivel _Nivel;
    private Car carro;
    int _posicion;
    Pase_Conexion_Menu_Gameplay PCMG;

    private void Awake()
    {
        URL_PATH = Application.dataPath + "/datos.json";
        Dinero = FindObjectOfType<DINERO>();
        _Nivel = FindObjectOfType<Nivel>();
        PCMG = FindObjectOfType<Pase_Conexion_Menu_Gameplay>();
    }

    private void Start()
    {
        carro = FindObjectOfType<Get_Content_Car>().Get_Car();
        Cargar();   
    }

    public void Cargar()
    {
        if(File.Exists(URL_PATH))
        {
            string contenido = File.ReadAllText(URL_PATH);
            Contenido contenido1 = JsonUtility.FromJson<Contenido>(contenido);
            Contenido contenido_Leido = contenido1;
            PCMG.Set_Seleccion(contenido_Leido.Tipo_Carro);
            _posicion = contenido_Leido.posicion;
            Dinero.Set_Agregar(contenido_Leido.dinero);
            _Nivel.nivel = contenido_Leido.nivel;
            Nivel.text = "Nivel: " + _Nivel.nivel.ToString();
            carro.skin_car = contenido_Leido.materia;
            FindObjectOfType<Seleccion_Menu_Carrito>().Set_Car_Menu(PCMG.Get_Seleccion(), _posicion);
        }
        else
        {
            _Nivel.nivel = 0;
        }
    }


    public void Guardar()
    {
        carro = FindObjectOfType<Get_Content_Car>().Get_Car();
        _posicion = PCMG.Get_Eleccion();
        Contenido conte = new Contenido()
        {
            dinero = Dinero.Get_Dinero(),
            nivel = _Nivel.nivel,
            materia = carro.skin_car,
            posicion = _posicion,
            Tipo_Carro = PCMG.Get_Seleccion()
        };
        string contenido = JsonUtility.ToJson(conte);

        File.WriteAllText(URL_PATH,contenido);
    }
}
