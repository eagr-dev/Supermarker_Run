using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Calidad : MonoBehaviour
{
    [SerializeField] Toggle Sombras;
    [SerializeField] Toggle Luces;
    [SerializeField] TMP_Dropdown calidad;
    [SerializeField] TMP_Dropdown Idioma;
    [SerializeField] GameObject Sombra_Falsa;
    [SerializeField] GameObject Sol;
    [SerializeField] GameObject Luz_Dinamica;
    Pase_Conexion_Menu_Gameplay PCMG;


    private void Start()
    {
        calidad.value = PlayerPrefs.GetInt("Calidad",QualitySettings.GetQualityLevel());
        Idioma.value = PlayerPrefs.GetInt("idioma", 1);
        Sombras.isOn = bool.Parse(PlayerPrefs.GetString("Sombras", "false"));
        QualitySettings.shadows = !Sombras.isOn ? ShadowQuality.Disable : ShadowQuality.All;
        Sombra_Falsa.SetActive(QualitySettings.shadows.Equals(ShadowQuality.Disable));
        PCMG = FindObjectOfType<Pase_Conexion_Menu_Gameplay>();
        Luces.isOn = bool.Parse(PlayerPrefs.GetString("Dinamica", "false"));
        PCMG.dinamica = Luces.isOn;
        Luz_Encender();
    }

    public  void Ajustar_Calidad()
    {
        QualitySettings.SetQualityLevel(calidad.value);
        if (calidad.value <= 1)
        {
            Sombra_Falsa.SetActive(true);
            QualitySettings.shadows = ShadowQuality.Disable;
        }
        else
        {
            Sombra_Falsa.SetActive(false);
            QualitySettings.shadows = ShadowQuality.All;
        }
        PlayerPrefs.SetInt("Calidad", QualitySettings.GetQualityLevel());
    }

    public void Activar_Sombras(bool isOn)
    {
        Sombras.isOn =  QualitySettings.GetQualityLevel() > 1 ? isOn : false;
        QualitySettings.shadows = !Sombras.isOn ? ShadowQuality.Disable : ShadowQuality.All;
        Sombra_Falsa.SetActive(QualitySettings.shadows.Equals(ShadowQuality.Disable));
        PlayerPrefs.SetString("Sombras", Sombras.isOn.ToString());
    }

    public void Activar_Luz_Dinamica(bool isOn)
    {
        Luces.isOn = isOn;
        PCMG.dinamica = Luces.isOn;
        PlayerPrefs.SetString("Dinamica", Luces.isOn.ToString());
        Luz_Encender();
    }

    private void Luz_Encender()
    {
        if (!Luces.isOn)
        {
            Luz_Dinamica.SetActive(false);
            Sol.SetActive(true);
        }
        else
        {
            Sol.SetActive(false);
            Luz_Dinamica.SetActive(true);
        }
    }

    public void Eleccion_Idioma()
    {
        PlayerPrefs.SetInt("idioma", Idioma.value);
    }

}
