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

    private void Awake()
    {
        Pase_Conexion_Menu_Gameplay SMC = FindObjectOfType<Pase_Conexion_Menu_Gameplay>();
        Carrito = (Seleccion_carrito)SMC.Get_Seleccion();
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


}
