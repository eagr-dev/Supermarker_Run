using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caja : MonoBehaviour
{
    private int porcentaje;
    public void Visible_Objects(int cantidad, int cantidad_actual, Car carro)
    {
        porcentaje = (cantidad_actual + 1 / cantidad) * 100;
        porcentaje /= 100;
        for (int i = 0; i < porcentaje; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
        carro.objetos_actuales = 0;
    }

    public int Get_Porcentaje() => porcentaje;
}
