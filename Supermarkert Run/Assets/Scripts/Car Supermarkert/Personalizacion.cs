using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Personalizacion : MonoBehaviour
{
    [SerializeField] TMP_Text Peso;
    [SerializeField] TMP_Text Velocidad;
    [SerializeField] TMP_Text Carga;
    [SerializeField] TMP_Text Choque;
    [SerializeField] TMP_Text Agarre;
    [SerializeField] TMP_Text NoMoney;

    [SerializeField] Button BTN_peso;
    [SerializeField] Button BTN_velocidad;
    [SerializeField] Button BTN_carga;
    [SerializeField] Button BTN_choque;
    [SerializeField] Button BTN_agarre;

    [SerializeReference] Idioma idioma;

    [SerializeField] ParticleSystem aumento;

    bool isclickeable = true;

    private void Start()
    {
        MostrarUI();
        NoMoney.gameObject.SetActive(false);
        BTN_peso.onClick.AddListener(BTNPeso);
        BTN_velocidad.onClick.AddListener(BTNVelocidad);
        BTN_carga.onClick.AddListener(BTNCarga);
        BTN_choque.onClick.AddListener(BTNBlindaje);
        BTN_agarre.onClick.AddListener(BTNAgarre);
        
    }

    IEnumerator AnimacionNoDinero()
    {
        NoMoney.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        NoMoney.gameObject.SetActive(false);
    }

    void BTNPeso()
    {
        var actual = BuildStructs.PCMG.GetOrquestador();
        
        if (!actual.SePuedeMejorarPeso || !isclickeable) return;

        uint precioAnterior = actual.PrecioPeso();

        if (!BuildStructs.Dinero.Set_Compra(actual.PrecioPeso()))
        {
            StartCoroutine(AnimacionNoDinero());
            return;
        }

        actual.DisminuirPeso();
        uint precioActual = actual.PrecioPeso();
        aumento.Play();
        StartCoroutine(ActualizarUI(Peso, precioAnterior, precioActual, actual.SePuedeMejorarPeso));
    }

    void BTNVelocidad()
    {
        var actual = BuildStructs.PCMG.GetOrquestador();

        if (!actual.SePuedeMejorarVelocidad || !isclickeable) return;

        uint precioAnterior = actual.PrecioVelocidad();

        if (!BuildStructs.Dinero.Set_Compra(actual.PrecioVelocidad()))
        {
            StartCoroutine(AnimacionNoDinero());
            return;
        }

        actual.AumentarVelocidad();
        uint precioActual = actual.PrecioVelocidad();
        aumento.Play();
        StartCoroutine(ActualizarUI(Velocidad, precioAnterior, precioActual, actual.SePuedeMejorarVelocidad));
    }

    void BTNCarga()
    {
        var actual = BuildStructs.PCMG.GetOrquestador();

        if (!actual.SePuedeMejorarCapacidad || !isclickeable) return;

        uint precioAnterior = actual.PrecioCapacidad();

        if (!BuildStructs.Dinero.Set_Compra(actual.PrecioCapacidad()))
        {
            StartCoroutine(AnimacionNoDinero());
            return;
        }

        actual.AumentarCapacidad();

        uint precioActual = actual.PrecioCapacidad();
        aumento.Play();
        StartCoroutine(ActualizarUI(Carga, precioAnterior, precioActual, actual.SePuedeMejorarCapacidad));
    }

    void BTNBlindaje()
    {
        var actual = BuildStructs.PCMG.GetOrquestador();

        if (!actual.SePuedeMejorarBlindaje || !isclickeable) return;

        uint precioAnterior = actual.PrecioBlindaje();

        if (!BuildStructs.Dinero.Set_Compra(actual.PrecioBlindaje()))
        {
            StartCoroutine(AnimacionNoDinero());
            return;
        }

        actual.AumentarBlindaje();
        uint precioActual = actual.PrecioBlindaje();
        aumento.Play();
        StartCoroutine(ActualizarUI(Choque, precioAnterior, precioActual, actual.SePuedeMejorarBlindaje));
    }

    void BTNAgarre()
    {
        var actual = BuildStructs.PCMG.GetOrquestador();

        if (!actual.SePuedeMejorarAgarre || !isclickeable) return;

        uint precioAnterior = actual.PrecioAgarre();

        if (!BuildStructs.Dinero.Set_Compra(actual.PrecioAgarre()))
        {
            StartCoroutine(AnimacionNoDinero());
            return;
        }

        actual.AumentarAgarre();
        uint precioActual = actual.PrecioAgarre();
        aumento.Play();
        StartCoroutine(ActualizarUI(Agarre, precioAnterior, precioActual, actual.SePuedeMejorarAgarre));
    }

    void MostrarUI()
    {
        var actual = BuildStructs.PCMG.GetOrquestador();
        Peso.text = actual.SePuedeMejorarPeso ? actual.PrecioPeso().ToString() : "100%";
        Velocidad.text = actual.SePuedeMejorarVelocidad ? actual.PrecioVelocidad().ToString() : "100%";
        Carga.text = actual.SePuedeMejorarCapacidad ? actual.PrecioCapacidad().ToString() : "100%";
        Choque.text = actual.SePuedeMejorarBlindaje ? actual.PrecioBlindaje().ToString() : "100%";
        Agarre.text = actual.SePuedeMejorarAgarre ? actual.PrecioAgarre().ToString() : "100%";
        idioma.AsignarLenguajeATextos();
    }

    IEnumerator ActualizarUI(TMP_Text texto, uint antes, uint ahora, bool esMaximo)
    {
        isclickeable = false;
        // Guardamos la escala inicial para no perder el formato original
        Vector3 escalaOriginal = texto.transform.localScale;
        Vector3 escalaObjetivo = escalaOriginal * 1.25f; // Aumento del 25%

        float duracionAnimacion = 0.8f; // Tiempo total que durará todo el efecto
        float tiempoTranscurrido = 0f;

        // Velocidad del pulso (a mayor número, más rápido se infla y desinfla)
        // Con 3f, hará aproximadamente 3 ciclos completos de pulso.
        float velocidadPulso = 3f;

        while (tiempoTranscurrido < duracionAnimacion)
        {
            tiempoTranscurrido += Time.deltaTime;
            float progreso = tiempoTranscurrido / duracionAnimacion;

            // --- 1. MATEMÁTICAS DEL CONTEO NUMÉRICO ---
            // Suavizado sutil para el cambio de números
            float progresoSuave = progreso * progreso * (3f - 2f * progreso);
            uint valorActual = (uint)Mathf.Lerp(antes, ahora, progresoSuave);
            texto.text = valorActual.ToString();

            // --- 2. MATEMÁTICAS DEL PULSO CONTINUO ---
            // Usamos valor absoluto (Abs) sobre el Seno para que la escala fluctúe 
            // siempre en positivo entre escalaOriginal (0) y escalaObjetivo (1).
            float onda = Mathf.Abs(Mathf.Sin(progreso * Mathf.PI * velocidadPulso));

            // Interpolamos la escala usando la onda senoidal continua
            texto.transform.localScale = Vector3.Lerp(escalaOriginal, escalaObjetivo, onda);

            yield return null;
        }

        // --- 3. ESTADO FINAL ---
        // Nos aseguramos de que al terminar el bucle, todo quede en sus valores exactos
        texto.text = esMaximo ? ahora.ToString() : "100%";
        texto.transform.localScale = escalaOriginal;
        isclickeable = true;
    }
}
