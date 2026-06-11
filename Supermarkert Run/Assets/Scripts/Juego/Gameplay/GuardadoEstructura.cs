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
    public List<string> carroPequenio = new();
    public List<string> carroMediano = new();
    public List<string> carroGrande = new();

    //Aqui solo guardamos nombre y precio con eso sera mas que suficiente saber si la clase fue comprada o no y cual
    private void GuardarInformacionNecesaria(List<Car> cars, ref List<string> listaGuardar)
    {
        listaGuardar = new();
        foreach (Car car in cars)
        {
            if (car.precio == 0) // Si el precio es 0, asumimos que está comprado/desbloqueado
            {
                listaGuardar.Add(car.nombre_espaniol);
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
public class MasterSaveInformacion
{
    public PlayerInformacionEstructura playerInformacion = new();
    public SkinsEstructura skins = new();
    public MapaEstructura mapa = new();

    public MasterSaveInformacion(PlayerInformacionEstructura _playerInformacion, SkinsEstructura _skins,
        MapaEstructura _mapa)
    {
        playerInformacion = _playerInformacion;
        skins = _skins;
        mapa = _mapa;
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