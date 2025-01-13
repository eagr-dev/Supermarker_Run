using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animacion_Puerta : MonoBehaviour
{
    [SerializeField]int contador = 0;

    [System.Serializable]
    public struct Puerta
    {
        [SerializeField]GameObject Marco, Cristal;
        [Header("Marco")]
        [SerializeField] Transform TMA, TMD;
        [Header("Cristal")]
        [SerializeField]Transform TCA, TCD;

        public void Animacion_Abrir()
        {
            Marco.transform.position = Vector3.Slerp(Marco.transform.position, TMD.position, 0.5f);
            Cristal.transform.position = Vector3.Slerp(Cristal.transform.position, TCD.position, 0.5f);
        }

        public void Animacion_Cerrar()
        {
            Marco.transform.position = Vector3.Slerp(Marco.transform.position, TMA.position, 0.5f);
            Cristal.transform.position = Vector3.Slerp(Cristal.transform.position, TCA.position, 0.5f);
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
