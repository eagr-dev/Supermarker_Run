using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dinero_Obtenido : MonoBehaviour
{
    private const int X2 = 2;
    DINERO Dinero;
    public List<Mapa> mapas;
    private int Pos;

    private void Awake()
    {
        Dinero = GetComponent<DINERO>();
    }

    public int Get_Dinero()
    {
        Mision mision = FindObjectOfType<Mision>();
        return mapas[Pos].Valor_mapa + Mision.Cantidad_Nivel();
    }

    public void Recompensa_X2()
    {
        Dinero.Set_Agregar((uint)(Get_Dinero() * X2));
        SceneManager.LoadScene(0);
    }

    public void Recompensa()
    {
        Dinero.Set_Agregar((uint)Get_Dinero());
        SceneManager.LoadScene(0);
    }

    public void Set_Posicion(int pos) => Pos = pos;

    public Mapa Get_Mapa(int pos)
    {
        if (mapas.Count <= pos || pos < 0) return null;
        return mapas[pos];
    }
    
    public Mapa Get_Mapa(string name)
    {
        foreach(Mapa map in mapas)
        {
            if (map.nombre_espaniol == name) return map;
        }
        return null;
    }

}
