using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocidad : Interfaz_PowerUp
{
    private const float porcentaje_velocidad = 0.20f;

    public override void Efecto()
    {
        RP = FindObjectOfType<Repartir_power>();
        RP.Set_Enum(Repartir_power.NULLENUM);
    }

    public override void Set_Descripcion_Nombre()
    {
        descripcion = "Get 20% speed.";
        nombre = "Speed";
    }

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

    public override T Get_Efecto<T>()
    {
        return (T)(object)porcentaje_velocidad;
    }
}
