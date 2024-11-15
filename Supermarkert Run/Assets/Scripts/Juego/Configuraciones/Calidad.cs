using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Calidad : MonoBehaviour
{
    [SerializeField] Toggle Sombras;
    [SerializeField] TMP_Dropdown calidad;
    [SerializeField] GameObject Sombra_Falsa;


    private void Start()
    {
        calidad.value = PlayerPrefs.GetInt("Calidad",QualitySettings.GetQualityLevel());
        Sombras.isOn = QualitySettings.shadows.Equals(ShadowQuality.All);
        Sombra_Falsa.SetActive(QualitySettings.shadows.Equals(ShadowQuality.Disable));
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
    }

}
