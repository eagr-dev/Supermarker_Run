using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Calidad : MonoBehaviour
{
    [SerializeField] Toggle Luces;
    [SerializeField] TMP_Dropdown calidad;
    [SerializeField] TMP_Dropdown TMPIdioma;
    //[SerializeField] GameObject Sombra_Falsa;
    [SerializeField] Sombras Sombra;
    [SerializeField] GameObject Sol;
    [SerializeField] GameObject Luz_Dinamica;

    [SerializeField] Idioma idioma;

    [SerializeField] private AudioSource Click_Botones;


    private void Start()
    {
        calidad.value = PlayerPrefs.GetInt("Calidad",QualitySettings.GetQualityLevel());
        TMPIdioma.value = PlayerPrefs.GetInt("idioma", 0);
        idioma.AsignarLenguajeATextos();
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
        PlayerPrefs.SetInt("idioma", TMPIdioma.value);
        Idioma.SetLengua((Idioma.Lengua)TMPIdioma.value);
        idioma.AsignarLenguajeATextos();
    }

}
