using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Caja : MonoBehaviour
{
    private readonly int objetos_caja_mostrar = 10;
    private Player jugador;
    private int hijosActivos = 1;
    [SerializeField] Transform dejar_roducto;
    [SerializeField] Slider slider;

    private void Start()
    {
        jugador = FindObjectOfType<Player>();
    }

    public IEnumerator HacerObjetosCajaVisible(float tiempo, Mision mision)
    {
        var objetos = mision.Volver_Objetos_Caja();
        int hijosTotales = objetos_caja_mostrar;
        int porcentaje = Mathf.FloorToInt(mision.Porcentaje() * hijosTotales);

        slider.value = 0;
        slider.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);

        for (int i = 0; i < objetos.Count; i++)
        {
            string objeto = objetos[i];
            // Progreso real basado en número de objetos ya entregados
            float progresoActual = (float)(i + 1) / objetos.Count;
            float progresoAnterior = slider.value; // Valor actual del slider

            yield return StartCoroutine(AnimarSliderYLanzarObjeto(progresoAnterior, progresoActual, tiempo, objeto, mision));

            // Activar solo los nuevos hijos
            transform.GetChild(hijosActivos).gameObject.SetActive(true);

            //Aumentar en caso de que el porcentaje sea mayor
            if (hijosActivos <= porcentaje)
                hijosActivos++;
        }

        mision.Mostrar();

        yield return new WaitForSeconds(0.2f);
        slider.gameObject.SetActive(false);

        if (mision.Jugador_gano())
            jugador.Gano();
    }

    private IEnumerator AnimarProgresoSlider(float valorInicial, float valorFinal, float duracion)
    {
        float tiempoTranscurrido = 0f;

        while (tiempoTranscurrido < duracion)
        {
            tiempoTranscurrido += Time.deltaTime;
            float t = tiempoTranscurrido / duracion;

            // Interpolación suave (ease-out)
            float tSuave = 1f - Mathf.Pow(1f - t, 2f);

            // Actualizar slider
            slider.value = Mathf.Lerp(valorInicial, valorFinal, tSuave);

            yield return null;
        }

        // Asegurar valor final exacto
        slider.value = valorFinal;
    }

    private IEnumerator AnimarSliderYLanzarObjeto(float progresoAnterior, float progresoActual, float tiempo, string objeto, Mision mision)
    {
        Coroutine lanzar_Objeto = StartCoroutine(mision.AnimacionDejarObjetosCaja(dejar_roducto.position, objeto, tiempo));
        Coroutine animar_Slider = StartCoroutine(AnimarProgresoSlider(progresoAnterior, progresoActual, tiempo));
        yield return lanzar_Objeto;
        yield return animar_Slider;
    }

}
