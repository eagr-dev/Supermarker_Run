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
        calidad.value = QualitySettings.GetQualityLevel();
        Sombras.isOn = QualitySettings.shadows.Equals(ShadowQuality.All);
        Sombra_Falsa.SetActive(QualitySettings.shadows.Equals(ShadowQuality.Disable));
    }

    public  void Ajustar_Calidad()
    {
        QualitySettings.SetQualityLevel(calidad.value);
    }

    public void Activar_Sombras(bool isOn)
    {
        Sombras.isOn = isOn;
        QualitySettings.shadows = !Sombras.isOn ? ShadowQuality.Disable : ShadowQuality.All;
        Sombra_Falsa.SetActive(QualitySettings.shadows.Equals(ShadowQuality.Disable));
    }

}
