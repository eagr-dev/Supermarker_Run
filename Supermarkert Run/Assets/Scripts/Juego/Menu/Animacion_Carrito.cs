using System.Collections;
using UnityEngine;

public class Animacion_Carrito : MonoBehaviour
{
    [SerializeField] private Transform Posicion_Llegar, Posicion_Original;
    [SerializeField] private float Tiempo;


    public void Iniciar_Animacion()
    {
        if((transform.position - Posicion_Original.position).magnitude <= 2)
        {
            StartCoroutine(Animacion(Posicion_Llegar));
        }
        else
        {
            StartCoroutine(Animacion(Posicion_Original));
        }
    }

    private IEnumerator Animacion(Transform llegar)
    {
        float timer = 0;
        while(timer < Tiempo)
        {
            transform.position = Vector3.Lerp(transform.position, llegar.position, timer / Tiempo);
            timer += Time.deltaTime;
            yield return null;
        }
    }

}
