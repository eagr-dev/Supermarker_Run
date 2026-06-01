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
    //maximo
    public float peso_maximo;
    public float velocidad_maxima;
    public int maximo_a_cargar;
    public int maxima_resistencia;

    [Header("Español")]
    public string nombre_espaniol;
    [TextArea(2,3)]
    public string descripcion_espanio;
    [TextArea(2, 3)]
    public string requisitos_espaniol;
    [Header("Ingles")]
    public string nombre_ingles;
    [TextArea(2, 3)]
    public string descripcioningles;
    [TextArea(2, 3)]
    public string requisitos_ingles;
    [Header("Portugues")]
    public string nombre_portugues;
    [TextArea(2, 3)]
    public string descripcionportugues;
    [TextArea(2, 3)]
    public string requisitos_portugues;

    public string cantidad;
    public string name_mapa;
    public string Get_Juegos()
    {
        if (name_mapa == null || name_mapa == "") Debug.Log("no especifico requisitos");
        return BuildStructs.Dinero_Obtenido.Get_Mapa(name_mapa).cantidad_juegos.ToString();
    }

    public bool Get_Requisito()
    {
        return uint.Parse(cantidad) <= BuildStructs.Dinero_Obtenido.Get_Mapa(name_mapa).cantidad_juegos;
    }
    public Material skin_car;
    public uint precio;
    internal string descripcion_espaniol;
}
