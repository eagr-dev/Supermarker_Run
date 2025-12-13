using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Mapa : ScriptableObject
{
    public int posicion_mapa;
    [Header("Español")]
    public string nombre_espaniol;
    [TextArea(2, 3)]
    public string descripcion_espaniol;
    [Header("Ingles")]
    public string nombre_ingles;
    [TextArea(2, 3)]
    public string descripcion_ingles;
    [Header("Portugues")]
    public string nombre_portugues;
    [TextArea(2, 3)]
    public string descripcion_portugues;
    public Sprite screen_map;
    public int precio;
    public int Valor_mapa;
    public uint cantidad_juegos;
    public float X_minimo, X_maximo, Y_minimo, Y_maximo;
    public int cantidad_enemigos, cantidad_rateros, cantidad_minima_obstaculos, cantidad_maxima_obstaculos;
    public int cantidad_minina_carritos, cantidad_maxima_carritos;
    public SpawnPointsData spawn;
}
