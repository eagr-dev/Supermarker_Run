using UnityEngine;
using System.Collections;

public class AnimacionFondoMenu : MonoBehaviour
{
    [SerializeField] GameObject objetoAnimar;
    [SerializeField] Vector3 posicionA;
    [SerializeField] Vector3 posicionB;
    [SerializeField] float tiempo = 5;
    [SerializeField] float altura = 3f;
    [SerializeField] float tiempoMinimo = 1f;
    [SerializeField] float tiempoMaximo = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(InicioBucle());
    }


    IEnumerator InicioBucle()
    {
        float tiempoRepetir;
        
        while(true)
        {
            objetoAnimar.transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
            tiempoRepetir = Random.Range(tiempoMinimo, tiempoMaximo);
            yield return new WaitForSeconds(tiempoRepetir);
            yield return StartCoroutine(Animacion(posicionA, posicionB));
            objetoAnimar.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            tiempoRepetir = Random.Range(tiempoMinimo, tiempoMaximo);
            yield return new WaitForSeconds(tiempoRepetir);
            yield return StartCoroutine(Animacion(posicionB, posicionA));
        }
    }

    IEnumerator Animacion(Vector3 positionA, Vector3 positionB)
    {
        float tiempoTranscurrido = 0f;

        while (tiempoTranscurrido < tiempo)
        {
            tiempoTranscurrido += Time.deltaTime;
            float progreso = tiempoTranscurrido / tiempo; // Va de 0 a 1

            // 1. Posición base en línea recta entre A y B (X, Y, Z)
            Vector3 posicionActual = Vector3.Lerp(positionA, positionB, progreso);

            // 2. Cálculo de la parábola (el arco)
            float alturaParabola = -4f * altura * Mathf.Pow(progreso - 0.5f, 2f) + altura;

            // 3. Aplicar la interpolación en Y + el arco de la parábola
            // Usamos Mathf.Lerp para que la altura inicial y final se conecten perfectamente con A y B
            float yInterpolada = Mathf.Lerp(positionA.y, positionB.y, progreso);
            posicionActual.y = yInterpolada + alturaParabola;

            // Asignar la posición final al objeto
            objetoAnimar.transform.position = posicionActual;

            yield return null;
        }

        // Asegurar que termine exactamente en la posición B
        objetoAnimar.transform.position = positionB;
    }
}
