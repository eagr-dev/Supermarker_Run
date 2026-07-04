using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Personalizacion : MonoBehaviour
{
    [Header("Costos")]
    [SerializeField] TMP_Text Peso;
    [SerializeField] TMP_Text Velocidad;
    [SerializeField] TMP_Text Carga;
    [SerializeField] TMP_Text Choque;
    [SerializeField] TMP_Text Agarre;
    [SerializeField] TMP_Text NoMoney;

    [Header("Limites")]
    [SerializeField] TMP_Text PesoLimite;
    [SerializeField] TMP_Text VelocidadLimite;
    [SerializeField] TMP_Text CargaLimite;
    [SerializeField] TMP_Text ChoqueLimite;
    [SerializeField] TMP_Text AgarreLimite;

    [Header("Botones")]
    [SerializeField] Button BTN_peso;
    [SerializeField] Button BTN_velocidad;
    [SerializeField] Button BTN_carga;
    [SerializeField] Button BTN_choque;
    [SerializeField] Button BTN_agarre;

    [Header("Otros")]
    [SerializeReference] Idioma idioma;

    [SerializeField] ParticleSystem aumento;
    [SerializeField] AudioSource audio;

    bool isclickeable = true;

    internal struct PeticionAnimacion
    {
        public TMP_Text texto;
        public TMP_Text textoLimite; 
        public uint dineroAntes;
        public uint dineroAhora;
        public double statAnterior;
        public double statActual;
        public double statMaxima;
        public bool esMaximo;
    }

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
        float statAnterior = actual.StatsActuales.peso;

        if (!BuildStructs.Dinero.Set_Compra(actual.PrecioPeso()))
        {
            StartCoroutine(AnimacionNoDinero());
            return;
        }

        actual.DisminuirPeso();
        uint precioActual = actual.PrecioPeso();
        aumento.Play();
        audio.Play();
        StartCoroutine(ActualizarUI(new PeticionAnimacion
        {
            texto = Peso,
            dineroAntes = precioAnterior,
            dineroAhora = precioActual,
            esMaximo = actual.SePuedeMejorarPeso,
            textoLimite = PesoLimite,
            statAnterior = statAnterior,
            statActual = actual.StatsActuales.peso,
            statMaxima = actual.StatsMaximas.peso
        }));
    }

    void BTNVelocidad()
    {
        var actual = BuildStructs.PCMG.GetOrquestador();

        if (!actual.SePuedeMejorarVelocidad || !isclickeable) return;

        uint precioAnterior = actual.PrecioVelocidad();
        float statAnterior = actual.StatsActuales.velocidad;

        if (!BuildStructs.Dinero.Set_Compra(precioAnterior))
        {
            StartCoroutine(AnimacionNoDinero());
            return;
        }

        actual.AumentarVelocidad();
        uint precioActual = actual.PrecioVelocidad();
        aumento.Play();
        audio.Play();
        StartCoroutine(ActualizarUI(new PeticionAnimacion
        {
            texto = Velocidad,
            dineroAntes = precioAnterior,
            dineroAhora = precioActual,
            esMaximo = actual.SePuedeMejorarVelocidad,
            textoLimite = VelocidadLimite,
            statAnterior = statAnterior,
            statActual = actual.StatsActuales.velocidad,
            statMaxima = actual.StatsMaximas.velocidad
        }));
    }

    void BTNCarga()
    {
        var actual = BuildStructs.PCMG.GetOrquestador();

        if (!actual.SePuedeMejorarCapacidad || !isclickeable) return;

        uint precioAnterior = actual.PrecioCapacidad();
        int statAnterior = actual.StatsActuales.capacidad;

        if (!BuildStructs.Dinero.Set_Compra(precioAnterior))
        {
            StartCoroutine(AnimacionNoDinero());
            return;
        }

        actual.AumentarCapacidad();

        uint precioActual = actual.PrecioCapacidad();
        aumento.Play();
        audio.Play();
        StartCoroutine(ActualizarUI(new PeticionAnimacion
        {
            texto = Carga,
            dineroAntes = precioAnterior,
            dineroAhora = precioActual,
            esMaximo = actual.SePuedeMejorarCapacidad,
            textoLimite = CargaLimite,
            statAnterior = statAnterior,
            statActual = actual.StatsActuales.capacidad,
            statMaxima = actual.StatsMaximas.capacidad
        }));
    }

    void BTNBlindaje()
    {
        var actual = BuildStructs.PCMG.GetOrquestador();

        if (!actual.SePuedeMejorarBlindaje || !isclickeable) return;

        uint precioAnterior = actual.PrecioBlindaje();
        int statAnterior = actual.StatsActuales.blindaje;

        if (!BuildStructs.Dinero.Set_Compra(precioAnterior))
        {
            StartCoroutine(AnimacionNoDinero());
            return;
        }

        actual.AumentarBlindaje();
        uint precioActual = actual.PrecioBlindaje();
        aumento.Play();
        audio.Play();
        StartCoroutine(ActualizarUI(new PeticionAnimacion
        {
            texto = Choque,
            dineroAntes = precioAnterior,
            dineroAhora = precioActual,
            esMaximo = actual.SePuedeMejorarBlindaje,
            textoLimite = ChoqueLimite,
            statAnterior = statAnterior,
            statActual = actual.StatsActuales.blindaje,
            statMaxima = actual.StatsMaximas.blindaje
        }));
    }

    void BTNAgarre()
    {
        var actual = BuildStructs.PCMG.GetOrquestador();

        if (!actual.SePuedeMejorarAgarre || !isclickeable) return;

        uint precioAnterior = actual.PrecioAgarre();
        float statAnterior = actual.StatsActuales.agarre;

        if (!BuildStructs.Dinero.Set_Compra(precioAnterior))
        {
            StartCoroutine(AnimacionNoDinero());
            return;
        }

        actual.AumentarAgarre();
        uint precioActual = actual.PrecioAgarre();
        aumento.Play();
        audio.Play();
        StartCoroutine(ActualizarUI(new PeticionAnimacion{ 
            texto = Agarre,
            dineroAntes = precioAnterior, 
            dineroAhora = precioActual, 
            esMaximo = actual.SePuedeMejorarAgarre,
            textoLimite = AgarreLimite,
            statAnterior = statAnterior,
            statActual = actual.StatsActuales.agarre,
            statMaxima = actual.StatsMaximas.agarre
        }));
    }

    public void MostrarUI()
    {
        var actual = BuildStructs.PCMG.GetOrquestador();
        Peso.text = actual.SePuedeMejorarPeso ? actual.PrecioPeso().ToString() : "100%";
        Velocidad.text = actual.SePuedeMejorarVelocidad ? actual.PrecioVelocidad().ToString() : "100%";
        Carga.text = actual.SePuedeMejorarCapacidad ? actual.PrecioCapacidad().ToString() : "100%";
        Choque.text = actual.SePuedeMejorarBlindaje ? actual.PrecioBlindaje().ToString() : "100%";
        Agarre.text = actual.SePuedeMejorarAgarre ? actual.PrecioAgarre().ToString() : "100%";
        PesoLimite.text = $"{System.Math.Round(actual.StatsActuales.peso, 2)}/{actual.StatsMaximas.peso}";
        VelocidadLimite.text = $"{System.Math.Round(actual.StatsActuales.velocidad, 2)}/{actual.StatsMaximas.velocidad}";
        CargaLimite.text = $"{actual.StatsActuales.capacidad}/{actual.StatsMaximas.capacidad}";
        ChoqueLimite.text = $"{actual.StatsActuales.blindaje}/{actual.StatsMaximas.blindaje}";
        AgarreLimite.text = $"{System.Math.Round(actual.StatsActuales.agarre, 2)}/{actual.StatsMaximas.agarre}";
        idioma.AsignarLenguajeATextos();
    }

    IEnumerator ActualizarUI(PeticionAnimacion animacion)
    {
        isclickeable = false;
        // Guardamos la escala inicial para no perder el formato original
        Vector3 escalaOriginal = animacion.texto.transform.localScale;
        Vector3 escalaObjetivo = escalaOriginal * 1.25f; // Aumento del 25%

        Vector3 escalaOriginalLimite = animacion.textoLimite.transform.localScale;
        Vector3 escalaObjetivoLimite = escalaOriginal * 1.25f; // Aumento del 25%

        float duracionAnimacion = 1.5f; // Tiempo total que durará todo el efecto
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
            uint valorActual = (uint)Mathf.Lerp(animacion.dineroAntes, animacion.dineroAhora, progresoSuave);
            animacion.texto.text = valorActual.ToString();

            float valorActualLimite = Mathf.Lerp((float)animacion.statAnterior, (float)animacion.statActual, progresoSuave);
            animacion.textoLimite.text = $"{System.Math.Round(valorActualLimite, 2)}/{animacion.statMaxima}";

            // --- 2. MATEMÁTICAS DEL PULSO CONTINUO ---
            // Usamos valor absoluto (Abs) sobre el Seno para que la escala fluctúe 
            // siempre en positivo entre escalaOriginal (0) y escalaObjetivo (1).
            float onda = Mathf.Abs(Mathf.Sin(progreso * Mathf.PI * velocidadPulso));

            // Interpolamos la escala usando la onda senoidal continua
            animacion.texto.transform.localScale = Vector3.Lerp(escalaOriginal, escalaObjetivo, onda);
            animacion.textoLimite.transform.localScale = Vector3.Lerp(escalaOriginalLimite, escalaObjetivoLimite, onda);


            yield return null;
        }

        // --- 3. ESTADO FINAL ---
        // Nos aseguramos de que al terminar el bucle, todo quede en sus valores exactos
        animacion.texto.text = animacion.esMaximo ? animacion.dineroAhora.ToString() : "100%";
        animacion.texto.transform.localScale = escalaOriginal;
        animacion.textoLimite.text = $"{System.Math.Round(animacion.statActual, 2)}/{animacion.statMaxima}";
        animacion.textoLimite.transform.localScale = escalaOriginalLimite;
        isclickeable = true;
    }
}
