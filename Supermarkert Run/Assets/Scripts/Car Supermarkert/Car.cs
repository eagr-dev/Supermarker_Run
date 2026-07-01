using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct CarStats
{
    public float velocidad;//3
    public int capacidad;// 15
    public float peso; // 10
    public float agarre;// 2
    public int blindaje;// 40
}

[System.Serializable]
public struct CarStatsLevel
{
    public int velocidad, capacidad, peso, agarre, blindaje;
}

[CreateAssetMenu(fileName = "Car", menuName = "Juego/Carro")]
public class OrquestadorAumentadorNivelCarro : ScriptableObject
{
    [SerializeField] private CarStats minimo, maximo, aumento;

    private CarStatsLevel maxLevel = new()
    {
        velocidad = 10,
        capacidad = 10,
        peso = 10,
        agarre = 10,
        blindaje = 10
    };
    [SerializeField] private CarStatsLevel actualLevel = new()
    {
        velocidad = 1,
        capacidad = 1,
        peso = 1,
        agarre = 1,
        blindaje = 1
    };

    private const double porcentajeAumentarPrecio = 1.35f, precio = 25f;

    public void SetNivelStats(CarStatsLevel level, CarStats stats)
    {
        actualLevel = level;
        minimo = stats;
    }

    public CarStats StatsActuales => minimo;
    public CarStatsLevel CarStatsLevel => actualLevel;
    public void AumentarVelocidad()
    {
        if (minimo.velocidad + aumento.velocidad > maximo.velocidad &&  actualLevel.velocidad + 1 > maxLevel.velocidad) return;
        minimo.velocidad += aumento.velocidad;
        actualLevel.velocidad++;
    }

    public void AumentarCapacidad()
    {
        if (minimo.capacidad + aumento.capacidad > maximo.capacidad && actualLevel.capacidad + 1 > maxLevel.capacidad) return;
        minimo.capacidad += aumento.capacidad;
        actualLevel.capacidad++;
    }

    public void DisminuirPeso()
    {
        if (minimo.peso + aumento.peso > maximo.peso && actualLevel.peso + 1 > maxLevel.peso) return;
        minimo.peso -= aumento.peso;
        actualLevel.peso++;
    }
    public void AumentarAgarre()
    {
        if (minimo.agarre + aumento.agarre > maximo.agarre && actualLevel.agarre + 1 > maxLevel.agarre) return;
        minimo.agarre += aumento.agarre;
        actualLevel.agarre++;
    }

    public void AumentarBlindaje()
    {
        if (minimo.blindaje + aumento.blindaje > maximo.blindaje && actualLevel.blindaje + 1 > maxLevel.blindaje) return;
        minimo.blindaje += aumento.blindaje;
        actualLevel.blindaje++;
    }

    public uint PrecioVelocidad()
    {
        uint precio = (uint)Precio(actualLevel.velocidad);
        return precio;
    }
    public uint PrecioCapacidad() 
    {
        uint precio = (uint)Precio(actualLevel.capacidad);
        return precio;
    }
    public uint PrecioPeso() 
    {
        uint precio = (uint)Precio(actualLevel.peso);
        return precio;
    }
    public uint PrecioAgarre()
    {
        uint precio = (uint)Precio(actualLevel.agarre);
        return precio;
    }
    public uint PrecioBlindaje()
    {
        uint precio = (uint)Precio(actualLevel.blindaje);
        return precio;
    }

    private double Precio(int nivel)
    {
        double _precio = precio;
        double resultado = _precio * System.Math.Pow(porcentajeAumentarPrecio, nivel - 1);
        double final = System.Math.Round(resultado / 5.0, System.MidpointRounding.AwayFromZero) * 5.0;
        return final;
    }

    public static OrquestadorAumentadorNivelCarro operator ++(OrquestadorAumentadorNivelCarro objeto)
    {
        objeto.AumentarAgarre();
        objeto.AumentarBlindaje();
        objeto.AumentarCapacidad();
        objeto.AumentarVelocidad();
        objeto.DisminuirPeso();
        return objeto;
    }
}

[System.Obsolete("Ya no se usa esta clase ahora se usa CarStats")]
[CreateAssetMenu(fileName = "Car", menuName = "Juego/Car")]
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
