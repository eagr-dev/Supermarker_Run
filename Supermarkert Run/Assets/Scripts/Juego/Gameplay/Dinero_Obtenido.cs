using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dinero_Obtenido : MonoBehaviour
{
    private int dinero = 0;
    public int Valor_mapa;
    private const int X2 = 2;
    DINERO Dinero;

    private void Awake()
    {
        Dinero = FindObjectOfType<DINERO>();
    }

    private int Get_Dinero()
    {
        Mision mision = FindObjectOfType<Mision>();
        return dinero + Valor_mapa + mision.Cantidad_Nivel();
    }

    public void BTN_X2()
    {
        Dinero.Set_Agregar((uint)(Get_Dinero() * X2));
        SceneManager.LoadScene(0);
    }

    public void BTN_Money()
    {
        Dinero.Set_Agregar((uint)Get_Dinero());
        SceneManager.LoadScene(0);
    }

}
