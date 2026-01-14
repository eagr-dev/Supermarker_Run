using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animacion_Puerta : MonoBehaviour
{
    [SerializeField]int contador = 0;

    [System.Serializable]
    public struct Puerta
    {
        [SerializeField]GameObject puerta;
        [Header("Posicion del marco")]
        [SerializeField] Transform TMA, TMD;
        [SerializeField] float interpolacion;//0.5

        public void Animacion_Abrir()
        {
            puerta.transform.position = Vector3.Slerp(puerta.transform.position, TMD.position, interpolacion);
        }

        public void Animacion_Cerrar()
        {
            puerta.transform.position = Vector3.Slerp(puerta.transform.position, TMA.position, interpolacion);
        }
    }

    [SerializeField]List<Puerta> Puertas;

    private void FixedUpdate()
    {
        if(contador != 0)
        {
            StopAllCoroutines();
            foreach (Puerta P in Puertas)
            {
                P.Animacion_Abrir();
            }
        }
        else
        {
            StartCoroutine(Espera());
        }
    }

    IEnumerator Espera()
    {
        yield return new WaitForSeconds(1);
        foreach (Puerta P in Puertas)
        {
            P.Animacion_Cerrar();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        contador++;
    }

    private void OnTriggerExit(Collider other)
    {
        contador--;
    }
}
