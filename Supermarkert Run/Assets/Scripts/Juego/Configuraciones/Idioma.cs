using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Idioma : MonoBehaviour
{
    public enum TipoFormato
    {
        Estatico,
        Nivel,
        Dinero
    }

    [System.Serializable]
    public struct ContenIdioma
    {
        public TMP_Text Texto;
        public string Ingles;
        public string Espaniol;
        public string Portugues;
        public TipoFormato Formato;
    }

    public List<ContenIdioma> idiomas;

    public enum Lengua { INGLES, ESPANIOL, PORTUGUES};
    static Lengua lengua = Lengua.INGLES;
    
    private void Awake()
    {
        Debug.Log("Asignando lenguaje");
        int eleccion = PlayerPrefs.GetInt("idioma", 0);
        lengua = (Lengua)eleccion;
        AsignarLenguajeATextos();

        Debug.Log($"La lengua elegida es {lengua}");
    }

    private string AplicarFormato(string textoBase, TipoFormato formato)
    {
        return formato switch
        {
            TipoFormato.Nivel => textoBase + ":" + Nivel.nivel.ToString(),
            TipoFormato.Dinero => BuildStructs.Dinero.Get_Dinero().ToString(),
            _ => textoBase
        };
    }

    public void AsignarLenguajeATextos()
    {
        switch (lengua)
        {
            case Lengua.ESPANIOL:
                foreach (ContenIdioma i in idiomas)
                    i.Texto.text = AplicarFormato(i.Espaniol, i.Formato);
                break;
            case Lengua.INGLES:
                foreach (ContenIdioma i in idiomas)
                    i.Texto.text = AplicarFormato(i.Ingles, i.Formato);
                break;
            case Lengua.PORTUGUES:
                foreach (ContenIdioma i in idiomas)
                    i.Texto.text = AplicarFormato(i.Portugues, i.Formato);
                break;
        }
    }

    static public Lengua GetLengua()
    {
        return lengua;
    }

    public static event System.Action OnLenguaChanged;

    public static void SetLengua(Lengua nueva)
    {
        lengua = nueva;
        OnLenguaChanged?.Invoke();
    }
}
