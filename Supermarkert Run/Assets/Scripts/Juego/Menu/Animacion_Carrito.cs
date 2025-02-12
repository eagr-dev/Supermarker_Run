using System.Collections;
using UnityEngine;

public class Animacion_Carrito : MonoBehaviour
{
    [SerializeField] private Transform Posicion_Llegar, Posicion_Original;
    [SerializeField] private float Tiempo;


    public void Iniciar_Animacion(bool regreso)
    {
        Transform posicion = !regreso ? Posicion_Llegar : Posicion_Original;
        StopCoroutine(Animacion(posicion));
        StartCoroutine(Animacion(posicion));
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
