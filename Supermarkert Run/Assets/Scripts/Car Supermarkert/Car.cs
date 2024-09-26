using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Car : ScriptableObject
{
    public float peso;
    public float velocidad_adicional;
    public int cant_limite_carga;
    //porcentaje necesario de velocidad para accidente
    public int resistencia_choque;

    public string nombre;
    [TextArea(2,3)]
    public string descripcion;
    public Sprite imagen;
}
