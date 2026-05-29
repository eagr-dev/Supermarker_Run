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

    //Aqui solo guardamos nombre y precio con eso sera mas que suficiente saber si la clase fue comprada o no y cual
    private void GuardarInformacionNecesaria(List<Car> cars, ref List<Car> listaGuardar)
    {
        listaGuardar = new();//por si se me olvida inicializarlo antes
        foreach(Car car in cars)
        {
            if(car.precio == 0)
            {
                Car aux = new();
                aux.precio = 0;
                aux.nombre_espaniol = car.nombre_espaniol;
                aux.nombre_ingles = car.nombre_ingles;
                aux.nombre_portugues = car.nombre_portugues;//Coloco tres para validar que realmente los nombres coincidan
                listaGuardar.Add(aux);
            }
        }
    }

    public SkinsEstructura Capturar(Pase_Conexion_Menu_Gameplay arg1)
    {
        GuardarInformacionNecesaria(arg1.cars_Peq, ref carroPequenio);
        GuardarInformacionNecesaria(arg1.cars_Med, ref carroMediano);
        GuardarInformacionNecesaria(arg1.cars_Gra, ref carroGrande);

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