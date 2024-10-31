using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manos_Rapidas : Interfaz_PowerUp
{
    public override void Animacion()
    {
        if (GetComponent<Transform>().position.magnitude < 2)
            GetComponent<Transform>().localScale = new Vector3(0.6f, 1, 0.6f);
        else
            GetComponent<Transform>().localScale = new Vector3(0.4f, 1, 0.4f);
    }

    public override void Efecto(params object[] parametros){}

    public override object Get_Efecto()
    {
        return "0.5";
    }

    public override void Set_Descripcion_Nombre()
    {
        nombre = "Manos Rapidas";
        descripcion = "Coloca objetos 50% mas rapido.";
    }
}
