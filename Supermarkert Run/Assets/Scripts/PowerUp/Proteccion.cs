using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proteccion : Interfaz_PowerUp
{
    private bool efecto = true;

    public override void Set_Descripcion_Nombre()
    {
        SetTextIdioma();
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
        return (T)(object)efecto;
    }

    protected override void SetTextIdioma()
    {
        switch (Idioma.GetLengua())
        {
            case Idioma.Lengua.INGLES:
                nombre = "Protection";
                descripcion = "Avoid losing an object when colliding, it can only be used once.";
                break;
            case Idioma.Lengua.ESPANIOL:
                nombre = "Proteccion";
                descripcion = "Evita perder un objeto al chocar, solo se puede usar una vez.";
                break;
            case Idioma.Lengua.PORTUGUES:
                nombre = "Proteção";
                descripcion = "Evite perder um objeto ao colidir, ele só pode ser usado uma vez.";
                break;
        }
    }
}
