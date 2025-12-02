using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Caja : MonoBehaviour
{
    private int misiones_hechas;
    private Player jugador;
    [SerializeField] private GameObject imagen;

    private void Start()
    {
        jugador = FindObjectOfType<Player>();
    }
    public void Visible_Objects(Mision mision, Car carro, float tiempo)
    {
        //Solucionar error de colliders y de este de tiempo
        misiones_hechas = carro.objetos_actuales;
        if (tiempo > 0)
        {
            //tiempo *= misiones_hechas;
            StartCoroutine(Colocar_Objetos(tiempo, carro, mision));
        }
    }

    private IEnumerator Colocar_Objetos(float tiempo, Car carro, Mision mision)
    {
        imagen.SetActive(true);
        yield return new WaitForSeconds(tiempo);
        carro.objetos_actuales = 0;
        for (int i = 0; i < misiones_hechas; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
        imagen.SetActive(false);
        if (mision.Jugador_gano())
            jugador.Gano();
    }
}
