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
    //[SerializeField] GameObject Sombra_Falsa;
    [SerializeField] Sombras Sombra;
    [SerializeField] GameObject Sol;
    [SerializeField] GameObject Luz_Dinamica;

    [SerializeField] Idioma idioma;
    
    Pase_Conexion_Menu_Gameplay PCMG;

    [SerializeField] private AudioSource Click_Botones;


    private void Start()
    {
        calidad.value = PlayerPrefs.GetInt("Calidad",QualitySettings.GetQualityLevel());
        Idioma.value = PlayerPrefs.GetInt("idioma", 0);
        Modificacion_Idioma();
        Sombras.isOn = bool.Parse(PlayerPrefs.GetString("Sombras", "false"));
        QualitySettings.shadows = !Sombras.isOn ? ShadowQuality.Disable : ShadowQuality.All;
        //Sombra_Falsa.SetActive(QualitySettings.shadows.Equals(ShadowQuality.Disable));
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
            //Sombra_Falsa.SetActive(true);
            Sombra.Verificacion();
            QualitySettings.shadows = ShadowQuality.Disable;
        }
        else
        {
            Sombra.Verificacion();
            //Sombra_Falsa.SetActive(false);
            QualitySettings.shadows = ShadowQuality.All;
        }
        PlayerPrefs.SetInt("Calidad", QualitySettings.GetQualityLevel());
    }

    public void Activar_Sombras(bool isOn)
    {
        Click_Botones.Play();
        Sombras.isOn =  QualitySettings.GetQualityLevel() > 1 ? isOn : false;
        QualitySettings.shadows = !Sombras.isOn ? ShadowQuality.Disable : ShadowQuality.All;
        //Sombra_Falsa.SetActive(QualitySettings.shadows.Equals(ShadowQuality.Disable));
        Sombra.Verificacion();
        PlayerPrefs.SetString("Sombras", Sombras.isOn.ToString());
    }

    public void Activar_Luz_Dinamica(bool isOn)
    {
        Click_Botones.Play();
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
        Click_Botones.Play();
        PlayerPrefs.SetInt("idioma", Idioma.value);
        Modificacion_Idioma();
    }

    public void Modificacion_Idioma()
    {
        List<string> Parametro = new List<string>();
        Parametro.Add(idioma.Get_Idioma()[0] + ":" + Nivel.nivel.ToString());
        //Parametro.Add(idioma.Get_Idioma()[1] + ":" + FindObjectOfType<DINERO>().Get_Dinero().ToString());
        Parametro.Add("$" + FindObjectOfType<DINERO>().Get_Dinero().ToString());
        Parametro.Add(idioma.Get_Idioma()[2]);
        Parametro.Add(idioma.Get_Idioma()[3]);
        Parametro.Add(idioma.Get_Idioma()[4]);
        Parametro.Add(idioma.Get_Idioma()[5]);
        Parametro.Add(idioma.Get_Idioma()[6]);
        Parametro.Add(idioma.Get_Idioma()[7]);
        Parametro.Add(idioma.Get_Idioma()[8]);
        Parametro.Add(idioma.Get_Idioma()[9]);
        Parametro.Add(idioma.Get_Idioma()[10]);
        Parametro.Add(idioma.Get_Idioma()[11]);
        Parametro.Add(idioma.Get_Idioma()[12]);
        Parametro.Add(idioma.Get_Idioma()[13]);
        Parametro.Add(idioma.Get_Idioma()[14]);
        Parametro.Add(idioma.Get_Idioma()[15]);
        Parametro.Add(idioma.Get_Idioma()[16]);
        Parametro.Add(idioma.Get_Idioma()[17]);
        Parametro.Add(idioma.Get_Idioma()[18]);
        Parametro.Add(idioma.Get_Idioma()[19]);
        Parametro.Add(idioma.Get_Idioma()[20]);
        Parametro.Add(idioma.Get_Idioma()[21]);
        Parametro.Add(idioma.Get_Idioma()[22]);
        Parametro.Add(idioma.Get_Idioma()[23]);
        Parametro.Add(idioma.Get_Idioma()[24]);

        idioma.Modificacion_Idioma(Parametro, false);
    }

}
