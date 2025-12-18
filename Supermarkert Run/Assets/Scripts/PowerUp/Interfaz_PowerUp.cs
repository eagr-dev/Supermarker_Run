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

    public void Animacion()
    {
        if (GetComponent<Transform>().position.magnitude > 5)
        {
            GetComponent<Transform>().localScale = new Vector3(0.4f, 1, 0.6f);
            GetComponent<Transform>().localPosition = new Vector3(GetComponent<Transform>().localPosition.x, 0, GetComponent<Transform>().localPosition.z);
        }
        else
        {
            GetComponent<Transform>().localScale = new Vector3(0.3f, 1, 0.5f);
            GetComponent<Transform>().localPosition = new Vector3(GetComponent<Transform>().localPosition.x, -0.72f, GetComponent<Transform>().localPosition.z);
        }
    }

    public string descripcion;
    public string nombre;
    public Material sprite;
    public Repartir_power RP;

    protected abstract void SetTextIdioma();
}
