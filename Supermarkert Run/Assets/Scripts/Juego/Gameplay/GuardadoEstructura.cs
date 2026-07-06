using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerInformacionEstructura
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

[System.Serializable]
public class SkinsEstructura
{
    public List<int> listaNombreSkins = new();
    //Aqui solo guardamos nombre y precio con eso sera mas que suficiente saber si la clase fue comprada o no y cual
    private void GuardarInformacionSkinsCarro(List<CarSkinData> cars, ref List<int> listaGuardar)
    {
        listaGuardar = new();
        foreach (CarSkinData car in cars)
        {
            if (car.precio == 0) // Si el precio es 0, asumimos que está comprado/desbloqueado
            {
                listaGuardar.Add(car.id);
            }
        }
    }

    public SkinsEstructura Capturar(Pase_Conexion_Menu_Gameplay arg1)
    {
        GuardarInformacionSkinsCarro(arg1.GetListSkins(), ref listaNombreSkins);

        return this;
    }
}

[System.Serializable]
public class MapaEstructura
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

[System.Serializable]
public class PersonalizadoEstructura
{
    [System.Serializable]
    public struct GuardarInformacionEstructura
    {
        public CarStats stats;
        public CarStatsLevel level;

        public GuardarInformacionEstructura(CarStats _stats, CarStatsLevel _level)
        {
            stats = _stats;
            level = _level;
        }
    }
    public GuardarInformacionEstructura pequenio, mediano, grande;

    public PersonalizadoEstructura Capturar(Pase_Conexion_Menu_Gameplay PCMG)
    {
        var orquestadores = PCMG.GetOrquestadores();
        var _pequenio = orquestadores.Item1;
        var _mediano = orquestadores.Item2;
        var _grande = orquestadores.Item3;
        pequenio = new(_pequenio.StatsActuales, _pequenio.CarStatsLevel);
        mediano = new(_mediano.StatsActuales, _mediano.CarStatsLevel);
        grande = new(_grande.StatsActuales, _grande.CarStatsLevel);
        return this;
    }
}

[System.Serializable]
public class CarroCompradoEstructura
{
    [System.Serializable]
    public struct Data
    {
        public Pase_Conexion_Menu_Gameplay.Tipo_Carro tipo_Carro;
        public uint precio;

        public void Asignacion(CarritoComprado carritoComprado)
        {
            tipo_Carro = carritoComprado.tipo_Carro;
            precio = carritoComprado.precio;
        }
    }
    public Data pequenio, mediano, grande;

    public CarroCompradoEstructura Capturar(Pase_Conexion_Menu_Gameplay PCMG)
    {
        pequenio.Asignacion(PCMG.GetComprado(Pase_Conexion_Menu_Gameplay.Tipo_Carro.PEQUEÑO));
        mediano.Asignacion(PCMG.GetComprado(Pase_Conexion_Menu_Gameplay.Tipo_Carro.MEDIANO));
        grande.Asignacion(PCMG.GetComprado(Pase_Conexion_Menu_Gameplay.Tipo_Carro.GRANDE));
        return this;
    }
}

[System.Serializable]
public class MasterSaveInformacion
{
    public PlayerInformacionEstructura playerInformacion = new();
    public SkinsEstructura skins = new();
    public MapaEstructura mapa = new();
    public PersonalizadoEstructura personalizado = new();
    public CarroCompradoEstructura carroComprado = new();

    public MasterSaveInformacion(PlayerInformacionEstructura _playerInformacion, SkinsEstructura _skins,
        MapaEstructura _mapa, PersonalizadoEstructura _personalizado, CarroCompradoEstructura _carroComprado)
    {
        playerInformacion = _playerInformacion;
        skins = _skins;
        mapa = _mapa;
        personalizado = _personalizado;
        carroComprado = _carroComprado;
    }
}

public static class BuildStructs
{
#if UNITY_EDITOR
    [UnityEditor.InitializeOnEnterPlayMode]
    static void ResetOnPlay(UnityEditor.EnterPlayModeOptions options)
    {
        Debug.Log("Hacer Listo en Falso");
        Listo = false;
    }
#endif
    public static DINERO Dinero { get; private set; }
    public static Pase_Conexion_Menu_Gameplay PCMG { get; private set; }
    public static Seleccion_Menu_Carrito SelCarro { get; private set; }
    public static Dinero_Obtenido Dinero_Obtenido { get; private set; }
    public static bool Listo { get; private set; }

    public static bool Inicializar(DINERO dinero,
                                   Pase_Conexion_Menu_Gameplay pcmg,
                                   Seleccion_Menu_Carrito selCarro, Dinero_Obtenido dinero_Obtenido)
    {
        if (Listo)
        {
            Debug.Log("SeleccionMenuCarrito");
            SelCarro = selCarro;
            var seleccion = PCMG.Get_Seleccion();
            var eleccion = PCMG.Get_Eleccion();
            Debug.Log($"seleccion: {seleccion}, eleccion : {eleccion}");
            SelCarro.Set_Car_Menu(seleccion, eleccion);
            SelCarro.Inicializador();
            return true;
        }
        Dinero = dinero;
        PCMG = pcmg;
        SelCarro = selCarro;
        Dinero_Obtenido = dinero_Obtenido;
        Listo = true;
        return false;
    }
}