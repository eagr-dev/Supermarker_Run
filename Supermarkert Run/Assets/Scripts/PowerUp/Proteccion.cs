using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proteccion : Interfaz_PowerUp
{
    private bool efecto = true;

    public override void Set_Descripcion_Nombre()
    {
        descripcion = "Protection throughout the game. If you crash, the level does not restart and you are allowed to play.";
        nombre = "Protection";
    }

    public override void Efecto()
    {
        RP = FindObjectOfType<Repartir_power>();
        if (efecto == true)
        {
            efecto = false;
            RP.Set_Enum(Repartir_power.NULLENUM);
        }
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
        return default;
    }
}
