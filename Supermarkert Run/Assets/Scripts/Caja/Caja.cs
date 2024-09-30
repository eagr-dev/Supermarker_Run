using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caja : MonoBehaviour
{
    public void Visible_Objects(int cantidad, int cantidad_actual)
    {
        int porcentaje = (cantidad_actual + 1 / cantidad) * 100;
        porcentaje /= 100;
        Debug.Log($"el porcentaje es: {porcentaje}");
        for (int i = 0; i < porcentaje; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
