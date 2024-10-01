using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seleccion_Menu_Carrito : MonoBehaviour
{

    static Seleccion_Menu_Carrito SMC;
    int Seleccion;
    [SerializeField] private GameObject Carrito_pequeno;
    [SerializeField] private GameObject Carrito_mediano;
    [SerializeField] private GameObject Carrito_grande;

    private void Awake()
    {
        if(Seleccion_Menu_Carrito.SMC != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Seleccion_Menu_Carrito.SMC = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public int Get_Seleccion() => Seleccion;

    public void BTN_Chico()
    {
        Carrito_grande.SetActive(false);
        Carrito_mediano.SetActive(false);
        Carrito_pequeno.SetActive(true);
        Seleccion = 0;
    }

    public void BTN_Mediante()
    {
        Carrito_grande.SetActive(false);
        Carrito_mediano.SetActive(true);
        Carrito_pequeno.SetActive(false);
        Seleccion = 1;
    }

    public void BTN_Grande()
    {
        Carrito_grande.SetActive(true);
        Carrito_mediano.SetActive(false);
        Carrito_pequeno.SetActive(false);
        Seleccion = 2;
    }

}
