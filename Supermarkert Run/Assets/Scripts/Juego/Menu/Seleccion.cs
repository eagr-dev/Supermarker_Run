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
    
    [SerializeField] private GameObject PU;
    private GameObject Carrito;
    public void BTN_Regreso()
    {
        Carrito = FindObjectOfType<Seleccion_Menu_Carrito>().Get_Active();
        Carrito.SetActive(true);
        PowerUp_Canvas.SetActive(false);
        Mapas_Canvas.SetActive(false);
        Carritos_Canvas.SetActive(false);
        Menu_Canvas.SetActive(true);
        PU.SetActive(false);
    }

    public void BTN_Power_Up()
    {
        Carrito = FindObjectOfType<Seleccion_Menu_Carrito>().Get_Active();
        Carrito.SetActive(false);
        Menu_Canvas.SetActive(false);
        PowerUp_Canvas.SetActive(true);
        PU.SetActive(true);
    }

    public void BTN_Mapa()
    {
        Carrito = FindObjectOfType<Seleccion_Menu_Carrito>().Get_Active();
        Carrito.SetActive(false);
        Menu_Canvas.SetActive(false);
        Mapas_Canvas.SetActive(true);
    }

    public void BTN_Carro()
    {
        Menu_Canvas.SetActive(false);
        Carritos_Canvas.SetActive(true);
        FindObjectOfType<Pase_Conexion_Menu_Gameplay>().Set_Seleccion(Pase_Conexion_Menu_Gameplay.Tipo_Carro.PEQUEÑO);
    }

    public void BTN_Jugar()
    {
        int pos = FindObjectOfType<Seleccion_Mapa>().Get_Seleccion().posicion_mapa;
        SceneManager.LoadScene(pos);
    }

    public void BTN_Salida()
    {
        Debug.Log("Salida");
    }

}
