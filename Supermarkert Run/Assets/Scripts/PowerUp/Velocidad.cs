using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocidad : Interfaz_PowerUp
{
    private const float porcentaje_velocidad = 1.20f;

    public override void Efecto()
    {
        RP = FindFirstObjectByType<Repartir_power>();
        RP.Set_Enum(Repartir_power.NULLENUM);
    }

    public override void Set_Descripcion_Nombre()
    {
        SetTextIdioma();
    }

    public override T Get_Efecto<T>()
    {
        return (T)(object)porcentaje_velocidad;
    }

    protected override void SetTextIdioma()
    {
        switch (Idioma.GetLengua())
        {
            case Idioma.Lengua.INGLES:
                nombre = "Speed";
                descripcion = "Get 20% speed.";
                break;
            case Idioma.Lengua.ESPANIOL:
                nombre = "Velocidad";
                descripcion = "Obten un 20% mas de velocidad.";
                break;
            case Idioma.Lengua.PORTUGUES:
                nombre = "Velocidade";
                descripcion = "Obtenha 20% mais velocidade.";
                break;
        }
    }
}
