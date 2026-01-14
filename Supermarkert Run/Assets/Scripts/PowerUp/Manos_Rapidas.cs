using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manos_Rapidas : Interfaz_PowerUp
{
    private readonly float porcentaje_velocidad_dejar_objetos = 0.50f;
    /*public override void Animacion()
    {
        if (GetComponent<Transform>().position.magnitude < 2)
        {
            GetComponent<Transform>().localScale = new Vector3(0.46f, 1, 0.7f);
            GetComponent<Transform>().localPosition = new Vector3(GetComponent<Transform>().localPosition.x, 0, GetComponent<Transform>().localPosition.z);
        }
        else
        {
            GetComponent<Transform>().localScale = new Vector3(0.4f, 1, 0.5f);
            GetComponent<Transform>().localPosition = new Vector3(GetComponent<Transform>().localPosition.x, -0.72f, GetComponent<Transform>().localPosition.z);
        }
    }*/

    public override void Efecto()
    {
        RP = FindFirstObjectByType<Repartir_power>();
        RP.Set_Enum(Repartir_power.NULLENUM);
    }

    public override T Get_Efecto<T>()
    {
        return (T)(object)porcentaje_velocidad_dejar_objetos;
    }

    public override void Set_Descripcion_Nombre()
    {
        SetTextIdioma();
    }

    protected override void SetTextIdioma()
    {
        switch(Idioma.GetLengua())
        {
            case Idioma.Lengua.INGLES:
                nombre = "Quick Hands";
                descripcion = "Place objects 50% faster.";
                break;
            case Idioma.Lengua.ESPANIOL:
                nombre = "Manos rapidas";
                descripcion = "Coloca objetos un 50% más rápido.";
                break;
            case Idioma.Lengua.PORTUGUES:
                nombre = "Manos está com pressa";
                descripcion = "Coloca objetos un 50% mais rápido.";
                break;
        }
    }
}
