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

    [SerializeField]private CarStatsLevel maxLevel = new()
    {
        velocidad = 11,
        capacidad = 11,
        peso = 11,
        agarre = 11,
        blindaje = 11
    };
    [SerializeField]
    private CarStatsLevel actualLevel = new()
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
        minimo.velocidad += aumento.velocidad;
        actualLevel.velocidad++;
    }

    public void AumentarCapacidad()
    {
        minimo.capacidad += aumento.capacidad;
        actualLevel.capacidad++;
    }

    public void DisminuirPeso()
    {
        minimo.peso -= aumento.peso;
        actualLevel.peso++;
    }
    public void AumentarAgarre()
    {
        minimo.agarre += aumento.agarre;
        actualLevel.agarre++;
    }

    public void AumentarBlindaje()
    {
        minimo.blindaje += aumento.blindaje;
        actualLevel.blindaje++;
    }

    public bool SePuedeMejorarVelocidad => !(minimo.velocidad + aumento.velocidad > maximo.velocidad && actualLevel.velocidad + 1 > maxLevel.velocidad);
    public bool SePuedeMejorarCapacidad => !(minimo.capacidad + aumento.capacidad > maximo.capacidad && actualLevel.capacidad + 1 > maxLevel.capacidad);
    public bool SePuedeMejorarPeso => !(minimo.peso + aumento.peso > maximo.peso && actualLevel.peso + 1 > maxLevel.peso);
    public bool SePuedeMejorarAgarre => !(minimo.agarre + aumento.agarre > maximo.agarre && actualLevel.agarre + 1 > maxLevel.agarre);
    public bool SePuedeMejorarBlindaje => !(minimo.blindaje + aumento.blindaje > maximo.blindaje && actualLevel.blindaje + 1 > maxLevel.blindaje);

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
