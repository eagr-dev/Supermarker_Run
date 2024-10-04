using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proteccion : Interfaz_PowerUp
{
    private bool efecto = true;

    public override void Set_Descripcion_Nombre()
    {
        descripcion.Add("Proteccion durante toda la partida en caso de chocar");
        descripcion.Add("No se reinicia el nivel y te deja jugar.");
        descripcion.Add("Este power Up se activa viendo un anuncio.");
        nombre = "Proteccion";
    }

    public override void Efecto(params object[] parametros)
    {
        efecto = false;
    }

    public override void Animacion()
    {
        if (GetComponent<Transform>().position.magnitude < 2)
            GetComponent<Transform>().localScale = new Vector3(0.6f, 1, 0.6f);
        else
            GetComponent<Transform>().localScale = new Vector3(0.4f, 1, 0.4f);
    }

    public override object Get_Efecto() => efecto;
}
