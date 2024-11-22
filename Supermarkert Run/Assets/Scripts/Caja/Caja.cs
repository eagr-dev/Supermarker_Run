using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caja : MonoBehaviour
{
    private int porcentaje;
    public void Visible_Objects(int cantidad, int cantidad_actual, Car carro, float tiempo)
    {
        porcentaje = (cantidad_actual + 1 / cantidad) * 100;
        porcentaje /= 100;
        StartCoroutine(Colocar_Objetos(porcentaje, tiempo, carro));
        carro.objetos_actuales = 0;
    }

    private IEnumerator Colocar_Objetos(int porcentaje, float tiempo, Car carro)
    {
        for (int i = 0; i < porcentaje; i++)
        {
            yield return new WaitForSeconds(tiempo);
            transform.GetChild(i).gameObject.SetActive(true);
            carro.objetos_actuales--;
            Debug.Log(carro.objetos_actuales);
            if (carro.objetos_actuales <= 0) break;
        }
    }

    public int Get_Porcentaje() => porcentaje;
}
