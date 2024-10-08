using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Mapa : ScriptableObject
{
    public int posicion_mapa;
    public string nombre;
    [TextArea(2, 3)]
    public string descripcion;
    public Sprite screen_map;
    public int precio;
    public int Valor_mapa;
    public uint cantidad_juegos;
}
