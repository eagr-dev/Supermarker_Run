using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interfaz_PowerUp : MonoBehaviour
{
    //Hacer lo necesario consigo mismo y cambiar el power a nulo
    public abstract void  Efecto();

    //En caso de enviar algo mandar el objeto
    public abstract T Get_Efecto<T>();

    public abstract void Set_Descripcion_Nombre();

    public abstract void Animacion();

    public string descripcion;
    public string nombre;
    public Material sprite;
    public Repartir_power RP;

    protected abstract void SetTextIdioma();
}
