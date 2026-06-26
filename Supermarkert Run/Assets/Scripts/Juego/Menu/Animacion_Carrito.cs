using System.Collections;
using UnityEngine;

public class Animacion_Carrito : MonoBehaviour
{
    [SerializeField] private Transform Posicion_Llegar, Posicion_Original;
    [SerializeField] private float Tiempo;
    private Coroutine corutinaCarrito;

    public void Iniciar_Animacion(bool regreso)
    {
        if (corutinaCarrito != null)
            StopCoroutine(corutinaCarrito);
        Transform posicion = !regreso ? Posicion_Llegar : Posicion_Original;
        corutinaCarrito = StartCoroutine(Animacion(posicion));
    }

    private IEnumerator Animacion(Transform llegar)
    {
        Vector3 inicio = transform.position;
        float timer = 0;
        while (timer < Tiempo)
        {
            transform.position = Vector3.Lerp(inicio, llegar.position, timer / Tiempo);
            timer += Time.deltaTime;
            yield return null;
        }
        transform.position = llegar.position; // garantiza llegada exacta
    }

}
