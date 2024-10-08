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

    private void Awake()
    {
        URL_PATH = Application.dataPath + "/datos.json";
        Dinero = FindObjectOfType<DINERO>();
        _Nivel = FindObjectOfType<Nivel>();
    }

    private void Start()
    {
        Cargar();   
    }

    public void Cargar()
    {
        if(File.Exists(URL_PATH))
        {
            string contenido = File.ReadAllText(URL_PATH);
            Contenido contenido1 = JsonUtility.FromJson<Contenido>(contenido);
            Contenido contenido_Leido = contenido1;
            Dinero.Set_Agregar(contenido_Leido.dinero);
            _Nivel.nivel = contenido_Leido.nivel;
            Nivel.text = "Nivel: " + _Nivel.nivel.ToString();
        }
        else
        {
            _Nivel.nivel = 0;
        }
    }


    public void Guardar()
    {
        Contenido conte = new Contenido()
        {
            dinero = Dinero.Get_Dinero(),
            nivel = _Nivel.nivel
        };
        string contenido = JsonUtility.ToJson(conte);

        File.WriteAllText(URL_PATH,contenido);
    }
}
