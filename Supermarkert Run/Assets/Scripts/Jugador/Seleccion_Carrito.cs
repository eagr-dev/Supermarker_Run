using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seleccion_Carrito : MonoBehaviour
{
    [SerializeField] private GameObject Carrito_pequeno;
    [SerializeField] private GameObject Carrito_mediano;
    [SerializeField] private GameObject Carrito_grande;

    public enum Seleccion_carrito { PEQUEÑO, MEDIANO, GRANDE, NINGUNO};

    public Seleccion_carrito Carrito = Seleccion_carrito.NINGUNO;

    static Seleccion_Carrito instancia;

    private void Awake()
    {
        if(instancia != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        Carrito_pequeno.SetActive(false);
        Carrito_mediano.SetActive(false);
        Carrito_grande.SetActive(false);
        switch (Carrito)
        {
            case Seleccion_carrito.PEQUEÑO:
                Carrito_pequeno.SetActive(true);
                break;
            case Seleccion_carrito.MEDIANO:
                Carrito_mediano.SetActive(true);
                break;
            case Seleccion_carrito.GRANDE:
                Carrito_grande.SetActive(true);
                break;
            default:
                Carrito_pequeno.SetActive(true);
                break;
        }
    }

    public void BTN_Chico()
    {
        Carrito_grande.SetActive(false);
        Carrito_mediano.SetActive(false);
        Carrito_pequeno.SetActive(true);
    }

    public void BTN_Mediante()
    {
        Carrito_grande.SetActive(false);
        Carrito_mediano.SetActive(true);
        Carrito_pequeno.SetActive(false);
    }

    public void BTN_Grande()
    {
        Carrito_grande.SetActive(true);
        Carrito_mediano.SetActive(false);
        Carrito_pequeno.SetActive(false);
    }

}
