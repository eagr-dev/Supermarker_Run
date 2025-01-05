using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Caja : MonoBehaviour
{
    private int porcentaje;
    private bool Is_corutina;
    private Player jugador;

    private void Start()
    {
        jugador = FindObjectOfType<Player>();
    }
    public void Visible_Objects(int cantidad, int cantidad_actual, Car carro, float tiempo, GameObject Imagen)
    {
        //Solucionar error de colliders y de este de tiempo
        porcentaje = (cantidad_actual + 1 / cantidad) * 100;
        porcentaje /= 100;
        tiempo *= porcentaje; 
        Is_corutina = true;
        StartCoroutine(Colocar_Objetos(tiempo,carro,Imagen));
    }

    private IEnumerator Colocar_Objetos(float tiempo, Car carro, GameObject imagen)
    {
        imagen.SetActive(true);
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
        imagen.SetActive(false);
        if (porcentaje == 10)
            jugador.Gano();
    }




    public int Get_Porcentaje() => porcentaje;
}
