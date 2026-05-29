using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Calidad : MonoBehaviour
{
    [SerializeField] Toggle Luces;
    [SerializeField] TMP_Dropdown calidad;
    [SerializeField] TMP_Dropdown Idioma;
    //[SerializeField] GameObject Sombra_Falsa;
    [SerializeField] Sombras Sombra;
    [SerializeField] GameObject Sol;
    [SerializeField] GameObject Luz_Dinamica;

    [SerializeField] Idioma idioma;

    [SerializeField] private AudioSource Click_Botones;


    private void Start()
    {
        calidad.value = PlayerPrefs.GetInt("Calidad",QualitySettings.GetQualityLevel());
        Idioma.value = PlayerPrefs.GetInt("idioma", 0);
        Modificacion_Idioma();
        QualitySettings.shadows = ShadowQuality.Disable;
    }

    public  void Ajustar_Calidad()
    {
        QualitySettings.SetQualityLevel(calidad.value);
        PlayerPrefs.SetInt("Calidad", QualitySettings.GetQualityLevel());
    }

    public void Eleccion_Idioma()
    {
        Click_Botones.Play();
        PlayerPrefs.SetInt("idioma", Idioma.value);
        Modificacion_Idioma();
    }

    public void Modificacion_Idioma()
    {
        List<string> Parametro = new();
        List<string> Idioma = idioma.Get_Idioma();
        Parametro.Add(Idioma[0] + ":" + Nivel.nivel.ToString());
        Parametro.Add("$" + BuildStructs.Dinero.Get_Dinero().ToString());

        Debug.Log(Idioma[0] + ":" + Nivel.nivel.ToString());
        Debug.Log(BuildStructs.Dinero.Get_Dinero());

        for(int i = 2; i < Idioma.Count; i++)
        {
            Parametro.Add(Idioma[i]);
        }

        idioma.Modificacion_Idioma(Parametro, false);
    }

}
