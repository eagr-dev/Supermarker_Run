using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Seleccion : MonoBehaviour
{
    [SerializeField] private GameObject Menu_Canvas;
    [SerializeField] private GameObject PowerUp_Canvas;
    [SerializeField] private GameObject Mapas_Canvas;
    [SerializeField] private GameObject Carritos_Canvas;

    public void BTN_Regreso()
    {
        PowerUp_Canvas.SetActive(false);
        Mapas_Canvas.SetActive(false);
        Carritos_Canvas.SetActive(false);
        Menu_Canvas.SetActive(true);
    }

    public void BTN_Power_Up()
    {
        Menu_Canvas.SetActive(false);
        PowerUp_Canvas.SetActive(true);
    }

    public void BTN_Mapa()
    {
        Menu_Canvas.SetActive(false);
        Mapas_Canvas.SetActive(true);
    }

    public void BTN_Carro()
    {
        Menu_Canvas.SetActive(false);
        Carritos_Canvas.SetActive(true);
    }

    public void BTN_Jugar()
    {
        SceneManager.LoadScene(1);
    }

    public void BTN_Salida()
    {
        Debug.Log("Salida");
    }

}
