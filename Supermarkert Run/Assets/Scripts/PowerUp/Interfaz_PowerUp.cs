using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interfaz_PowerUp : MonoBehaviour
{
    public abstract void  Efecto(params object[] parametros);
    public abstract object Get_Efecto();
    public abstract void Set_Descripcion_Nombre();

    public abstract void Animacion();

    public List<string> descripcion;
    public string nombre;
}
