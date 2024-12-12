using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Idioma : MonoBehaviour
{
    public List<TMP_Text> Textos_UI;
    public List<string> Ingles;
    public List<string> Espaniol;
    public List<string> Portugues;
    private Get_Content_Car Contenido_Carro;
    
    
    private void Start()
    {
        int eleccion = PlayerPrefs.GetInt("idioma", 0);
        Contenido_Carro = FindObjectOfType<Get_Content_Car>();

        if(SceneManager.GetActiveScene().name != "Menu_principal")
        {
            switch (eleccion)
            {
                case 0:
                    Modificacion_Idioma(Ingles, true);
                    break;
                case 1:
                    Modificacion_Idioma(Espaniol, true);
                    break;
                case 2:
                    Modificacion_Idioma(Portugues, true);
                    break;
            }
        }
      
    }

    public List<string> Get_Idioma()
    {
        List<string> retorno = Ingles;
        switch (PlayerPrefs.GetInt("idioma",0))
        {
            case 0:
                retorno = Ingles;
                break;
            case 1:
                retorno = Espaniol;
                break;
            case 2:
                retorno = Portugues;
                break;
        }

        return retorno;
    }



    public void Modificacion_Idioma(List<string> Idioma, bool Mapa)
    {
        if (!Mapa)
        {
            for(int i = 0; i < Textos_UI.Count; i++)
            {
                Textos_UI[i].text = Idioma[i];
            }
        }
        /*else
        {
            for (int i = 0; i < Textos_UI.Count; i++)
            {
                Textos_UI[i].text = Idioma[i] + ":\n" + "0/" + Contenido_Carro.Get_Car().cant_limite_carga.ToString();
            }
        }*/
    }

    public static string Espacio_Idioma()
    {
        string texto = "";

        switch (PlayerPrefs.GetInt("idioma",0))
        {
            case 0:
                texto = "Available space";
                break;
            case 1:
                texto = "Espacio disponible";
                break;
            case 2:
                texto = "Espaço disponível";
                break;
        }

        return texto;
    }
}
