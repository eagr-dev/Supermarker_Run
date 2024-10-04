using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocidad : Interfaz_PowerUp
{
    private float velocidad = 0;
    private const float porcentaje_velocidad = 0.20f;

    public override void Efecto(params object[] parametros)
    {
        if(parametros[0] is float)
        {
            float aux = (float)parametros[0] * porcentaje_velocidad;
            velocidad = aux + (float)parametros[0];
        }
    }

    public override void Set_Descripcion_Nombre()
    {
        descripcion.Add("Te da un 20% de velocidad, idea para supermercados espacioso");
        descripcion.Add("o para hacer menos tiempo, cuidado como manejas porque sera mas facil chocar.");
        descripcion.Add("Este power Up se activa viendo un anuncio.");
        nombre = "Velocidad";
    }

    public override void Animacion()
    {
        if (GetComponent<Transform>().position.magnitude < 2)
            GetComponent<Transform>().localScale = new Vector3(0.6f, 1, 0.6f);
        else
            GetComponent<Transform>().localScale = new Vector3(0.4f, 1, 0.4f);
    }

    public override object Get_Efecto() => velocidad;
}
