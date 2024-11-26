using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Caja : MonoBehaviour
{
    private int porcentaje;
    private bool Is_corutina;
    public void Visible_Objects(int cantidad, int cantidad_actual, Car carro, float tiempo)
    {
        //Solucionar error de colliders y de este de tiempo
        porcentaje = (cantidad_actual + 1 / cantidad) * 100;
        porcentaje /= 100;
        Debug.Log($"Porcentaje en la caja: {porcentaje}");
        Debug.Log($"Cantidad del carrito: {carro.objetos_actuales}");
        tiempo *= porcentaje; 
        Is_corutina = true;
        Debug.Log(tiempo);
        StartCoroutine(Colocar_Objetos(tiempo,carro));
        //StartCoroutine(Colocar_Objetos(porcentaje, tiempo, carro));
        //carro.objetos_actuales = 0;
        Debug.Log($"La cantidad de objetos Actuales: {carro.objetos_actuales}");
    }

    private IEnumerator Colocar_Objetos(float tiempo, Car carro)
    {
        yield return new WaitForSeconds(tiempo);
        Is_corutina = false;
        if (!Is_corutina)
        {
            carro.objetos_actuales = 0;
            for(int i = 0; i < porcentaje; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }




    public int Get_Porcentaje() => porcentaje;
}
