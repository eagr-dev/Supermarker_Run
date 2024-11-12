using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manos_Rapidas : Interfaz_PowerUp
{
    public override void Animacion()
    {
        if (GetComponent<Transform>().position.magnitude < 2)
        {
            GetComponent<Transform>().localScale = new Vector3(0.6f, 1, 0.6f);
            GetComponent<Transform>().localPosition = new Vector3(GetComponent<Transform>().localPosition.x, 0, GetComponent<Transform>().localPosition.z);
        }
        else
        {
            GetComponent<Transform>().localScale = new Vector3(0.4f, 1, 0.4f);
            GetComponent<Transform>().localPosition = new Vector3(GetComponent<Transform>().localPosition.x, -0.72f, GetComponent<Transform>().localPosition.z);
        }
    }

    public override void Efecto(params object[] parametros){}

    public override object Get_Efecto()
    {
        return "0.5";
    }

    public override void Set_Descripcion_Nombre()
    {
        nombre = "Quick Hands";
        descripcion = "Place objects 50% faster.";
    }
}
