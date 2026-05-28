using System.Collections.Generic;
using UnityEngine;


public interface IDatosNube { }

public interface ICapturable<TSelf, TArg1, TArg2> : IDatosNube
    //where TSelf : ICapturable<TSelf, TArg1, TArg2> 
{
    TSelf Capturar(TArg1 arg1, TArg2 arg2);
}

public interface ICapturable<TSelf, TArg1> : IDatosNube
    //where TSelf : ICapturable<TSelf, TArg1>
{
    TSelf Capturar(TArg1 arg1);
}

public class PlayerInformacionEstructura : ICapturable<PlayerInformacionEstructura, DINERO, Pase_Conexion_Menu_Gameplay>
{
    public int calidad;
    public uint nivel;
    public uint dinero;
    public int tipo_carro;
    public int posicion_skin;

    /// <summary>Se actualiza solo con el estado actual de escena.</summary>
    public PlayerInformacionEstructura Capturar(DINERO dinero, Pase_Conexion_Menu_Gameplay pcmg)
    {
        calidad = QualitySettings.GetQualityLevel();
        nivel = Nivel.nivel;
        this.dinero = dinero.Get_Dinero();
        tipo_carro = (int)pcmg.Get_Seleccion();
        posicion_skin = pcmg.Get_Eleccion();
        return this;
    }


}

public class SkinsEstructura : ICapturable<SkinsEstructura, Pase_Conexion_Menu_Gameplay>
{
    public List<Car> carroPequenio;
    public List<Car> carroMediano;
    public List<Car> carroGrande;

    public SkinsEstructura Capturar(Pase_Conexion_Menu_Gameplay arg1)
    {
        carroPequenio = arg1.cars_Peq;
        carroMediano = arg1.cars_Med;
        carroGrande = arg1.cars_Gra;

        return this;
    }
}

public class MapaEstructura : ICapturable<MapaEstructura, List<Mapa>>
{
    public List<string> mapasDesbloqueados;

    public MapaEstructura Capturar(List<Mapa> mapas)
    {
        var desbloqueados = new List<string>();
        foreach (Mapa m in mapas)
            if (m.precio == 0)
                desbloqueados.Add(m.nombre_espaniol);

        mapasDesbloqueados = desbloqueados;
        return this;
    }
}

public static class BuildStructs
{
    public static DINERO Dinero { get; private set; }
    public static Pase_Conexion_Menu_Gameplay PCMG { get; private set; }
    public static Seleccion_Menu_Carrito SelCarro { get; private set; }
    public static Dinero_Obtenido Dinero_Obtenido { get; private set; }
    public static bool Listo { get; private set; }

    public static void Inicializar(DINERO dinero,
                                   Pase_Conexion_Menu_Gameplay pcmg,
                                   Seleccion_Menu_Carrito selCarro, Dinero_Obtenido dinero_Obtenido)
    {
        Dinero = dinero;
        PCMG = pcmg;
        SelCarro = selCarro;
        Dinero_Obtenido = dinero_Obtenido;
        Listo = true;
    }
}