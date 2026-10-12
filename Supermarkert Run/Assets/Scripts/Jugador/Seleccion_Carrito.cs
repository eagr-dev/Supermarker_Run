using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class Seleccion_Carrito : MonoBehaviour
{
    [Header("Objetos carro")]
    [SerializeField] private GameObject Carrito_pequeno;
    [SerializeField] private GameObject Carrito_mediano;
    [SerializeField] private GameObject Carrito_grande;
    [Header("Contenido Carro")]
    [SerializeField] private Get_Content_Car content_Car_pequenio;
    [SerializeField] private Get_Content_Car content_Car_mediano;
    [SerializeField] private Get_Content_Car content_Car_grande;
    [Header("Rig Carro")]
    [SerializeField] private RigBuilder Rigid_Animacion;

    private Pase_Conexion_Menu_Gameplay SMC;

    void Start()
    {
        SMC = BuildStructs.PCMG;
        Carrito_pequeno.SetActive(false);
        Carrito_mediano.SetActive(false);
        Carrito_grande.SetActive(false);
        switch (SMC.Get_Seleccion())
        {
            case Pase_Conexion_Menu_Gameplay.Tipo_Carro.PEQUEÑO:
                Carrito_pequeno.SetActive(true);
                content_Car_pequenio.Set_Car(BuildStructs.PCMG.Get_Eleccion());
                Rigid_Animacion.layers[0].active = true;
                break;
            case Pase_Conexion_Menu_Gameplay.Tipo_Carro.MEDIANO:
                Carrito_mediano.SetActive(true);
                content_Car_mediano.Set_Car(BuildStructs.PCMG.Get_Eleccion());
                Rigid_Animacion.layers[1].active = true;
                break;
            case Pase_Conexion_Menu_Gameplay.Tipo_Carro.GRANDE:
                content_Car_grande.Set_Car(BuildStructs.PCMG.Get_Eleccion());
                Carrito_grande.SetActive(true);
                Rigid_Animacion.layers[2].active = true;
                break;
            default:
                content_Car_pequenio.Set_Car(BuildStructs.PCMG.Get_Eleccion());
                Carrito_pequeno.SetActive(true);
                Rigid_Animacion.layers[0].active = true;
                break;
        }
    }


}
