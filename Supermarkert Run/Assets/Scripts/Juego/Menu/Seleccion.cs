using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seleccion : MonoBehaviour
{
    [SerializeField] private GameObject Menu_Canvas;
    [SerializeField] private GameObject PowerUp_Canvas;
    [SerializeField] private GameObject Mapas_Canvas;
    [SerializeField] private GameObject Carritos_Canvas;
    [SerializeField] private GameObject Configuracion_Canvas;
    
    [SerializeField] private GameObject PU;
    [SerializeField] private GameObject Personaje;
    [SerializeField] private GameObject Animacion;
    [SerializeField] private Animacion_Carga AnimacionSP;
    private GameObject Carrito;
    public void BTN_Regreso()
    {
        Pase_Conexion_Menu_Gameplay conector = FindObjectOfType<Pase_Conexion_Menu_Gameplay>();
        FindObjectOfType<Seleccion_Menu_Carrito>().Set_Car_Menu(conector.Get_Seleccion(),conector.Get_Eleccion());
        Personaje.SetActive(true);
        PowerUp_Canvas.SetActive(false);
        Mapas_Canvas.SetActive(false);
        Carritos_Canvas.SetActive(false);
        Menu_Canvas.SetActive(true);
        PU.SetActive(false);
        Configuracion_Canvas.SetActive(false);
    }

    public void BTN_Power_Up()
    {
        Carrito = FindObjectOfType<Seleccion_Menu_Carrito>().Get_Active();
        Carrito.SetActive(false);
        Personaje.SetActive(false);
        Menu_Canvas.SetActive(false);
        PowerUp_Canvas.SetActive(true);
        PU.SetActive(true);
    }

    public void BTN_Mapa()
    {
        Carrito = FindObjectOfType<Seleccion_Menu_Carrito>().Get_Active();
        Carrito.SetActive(false);
        Personaje.SetActive(false);
        Menu_Canvas.SetActive(false);
        Mapas_Canvas.SetActive(true);
    }

    public void BTN_Carro()
    {
        Menu_Canvas.SetActive(false);
        Carritos_Canvas.SetActive(true);
        Personaje.SetActive(false);
        FindObjectOfType<Pase_Conexion_Menu_Gameplay>().Set_Seleccion(Pase_Conexion_Menu_Gameplay.Tipo_Carro.PEQUEÑO);
    }

    public void BTN_Configuraciones()
    {
        Menu_Canvas.SetActive(false);
        Configuracion_Canvas.SetActive(true);
    }

    public void BTN_Jugar()
    {
        StartCoroutine(Jugar());
    }

    IEnumerator Jugar()
    {
        yield return new WaitForSeconds(0.3f);
        string pos = FindObjectOfType<Seleccion_Mapa>().Get_Seleccion().nombre;
        Animacion.SetActive(true);
        AnimacionSP.Cambiar_Escena(pos);
        Menu_Canvas.SetActive(false);
    }

    public void BTN_Salida()
    {
        FindObjectOfType<Sistema_Guardado>().Guardar();
        Application.Quit(0);
    }

    private void OnApplicationQuit()
    {
        if(Mapas_Canvas.activeInHierarchy || PowerUp_Canvas.activeInHierarchy || Configuracion_Canvas.activeInHierarchy)
        {
            Pase_Conexion_Menu_Gameplay conector = FindObjectOfType<Pase_Conexion_Menu_Gameplay>();
            FindObjectOfType<Seleccion_Menu_Carrito>().Set_Car_Menu(conector.Get_Seleccion(), conector.Get_Eleccion());
        }
        FindObjectOfType<Sistema_Guardado>().Guardar();
    }

}
