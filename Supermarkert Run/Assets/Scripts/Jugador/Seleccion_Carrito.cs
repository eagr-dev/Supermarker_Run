using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seleccion_Carrito : MonoBehaviour
{
    [SerializeField] private GameObject Carrito_pequeno;
    [SerializeField] private GameObject Carrito_mediano;
    [SerializeField] private GameObject Carrito_grande;

    

    private Pase_Conexion_Menu_Gameplay SMC;

    private void Awake()
    {
        SMC = FindObjectOfType<Pase_Conexion_Menu_Gameplay>();
    }

    void Start()
    {
        Carrito_pequeno.SetActive(false);
        Carrito_mediano.SetActive(false);
        Carrito_grande.SetActive(false);
        switch (SMC.Get_Seleccion())
        {
            case Pase_Conexion_Menu_Gameplay.Tipo_Carro.PEQUEÑO:
                Carrito_pequeno.SetActive(true);
                break;
            case Pase_Conexion_Menu_Gameplay.Tipo_Carro.MEDIANO:
                Carrito_mediano.SetActive(true);
                break;
            case Pase_Conexion_Menu_Gameplay.Tipo_Carro.GRANDE:
                Carrito_grande.SetActive(true);
                break;
            default:
                Carrito_pequeno.SetActive(true);
                break;
        }
    }


}
