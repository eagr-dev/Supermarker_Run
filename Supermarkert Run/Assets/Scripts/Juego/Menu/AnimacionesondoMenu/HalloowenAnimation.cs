using UnityEngine;
using System.Collections;

public class HalloweebAnimation : MonoBehaviour, IBackgroundAnimation
{
    [SerializeField] private GameObject objetoAnimar;
    [SerializeField] private Vector3 posicionA;
    [SerializeField] private Vector3 posicionB;
    [SerializeField] private float tiempo = 5f;
    [SerializeField] private float altura = 3f;
    [SerializeField] private float tiempoMinimo = 1f;
    [SerializeField] private float tiempoMaximo = 5f;

    public bool ShouldRun() => true; // Este corre siempre en bucle

    public void Initialize()
    {
        // Configuración inicial opcional si se requiere
    }

    public IEnumerator PlayAnimation()
    {
        float tiempoRepetir;

        while (true)
        {
            objetoAnimar.transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
            tiempoRepetir = Random.Range(tiempoMinimo, tiempoMaximo);
            yield return new WaitForSeconds(tiempoRepetir);

            yield return StartCoroutine(AnimacionParabola(posicionA, posicionB));

            objetoAnimar.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            tiempoRepetir = Random.Range(tiempoMinimo, tiempoMaximo);
            yield return new WaitForSeconds(tiempoRepetir);

            yield return StartCoroutine(AnimacionParabola(posicionB, posicionA));
        }
    }

    private IEnumerator AnimacionParabola(Vector3 positionA, Vector3 positionB)
    {
        float tiempoTranscurrido = 0f;

        while (tiempoTranscurrido < tiempo)
        {
            tiempoTranscurrido += Time.deltaTime;
            float progreso = tiempoTranscurrido / tiempo;

            Vector3 posicionActual = Vector3.Lerp(positionA, positionB, progreso);
            float alturaParabola = -4f * altura * Mathf.Pow(progreso - 0.5f, 2f) + altura;
            float yInterpolada = Mathf.Lerp(positionA.y, positionB.y, progreso);
            posicionActual.y = yInterpolada + alturaParabola;

            objetoAnimar.transform.position = posicionActual;
            yield return null;
        }

        objetoAnimar.transform.position = positionB;
    }
}