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

    public enum Lengua { INGLES, ESPANIOL, PORTUGUES};
    static Lengua lengua = Lengua.INGLES;
    
    private void Start()
    {
        int eleccion = PlayerPrefs.GetInt("idioma", 0);

        if(SceneManager.GetActiveScene().name != "Menu_principal")
        {
            switch (eleccion)
            {
                case 0:
                    lengua = Lengua.INGLES;
                    Modificacion_Idioma(Ingles, true);
                    break;
                case 1:
                    lengua = Lengua.ESPANIOL;
                    Modificacion_Idioma(Espaniol, true);
                    break;
                case 2:
                    lengua = Lengua.PORTUGUES;
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
                lengua = Lengua.INGLES;
                retorno = Ingles;
                break;
            case 1:
                lengua = Lengua.ESPANIOL;
                retorno = Espaniol;
                break;
            case 2:
                lengua = Lengua.PORTUGUES;
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

    static public Lengua GetLengua()
    {
        return lengua;
    }
}
