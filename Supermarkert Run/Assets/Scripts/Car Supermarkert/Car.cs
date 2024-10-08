using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Car : ScriptableObject
{
    public float peso;
    public float velocidad_adicional;
    public int cant_limite_carga;
    public int objetos_actuales = 0;
    //porcentaje necesario de velocidad para accidente
    public int resistencia_choque;

    public string nombre;
    [TextArea(2,3)]
    public string descripcion;
    [TextArea(2, 3)]
    public string requisitos;
    public string cantidad;
    public string name_mapa;
    public string Get_Juegos()
    {
        if (name_mapa == null || name_mapa == "") Debug.Log("no especifico requisitos");
        return FindObjectOfType<Dinero_Obtenido>().Get_Mapa(name_mapa).cantidad_juegos.ToString();
    }

    public bool Get_Requisito()
    {
        return uint.Parse(cantidad) <= FindObjectOfType<Dinero_Obtenido>().Get_Mapa(name_mapa).cantidad_juegos;
    }
    public Material skin_car;
    public uint precio;
}
