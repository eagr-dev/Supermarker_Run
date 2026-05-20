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
        RP = FindFirstObjectByType<Repartir_power>();
        if (efecto == true)
        {
            efecto = false;
            RP.Set_Enum(Repartir_power.NULLENUM);
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
