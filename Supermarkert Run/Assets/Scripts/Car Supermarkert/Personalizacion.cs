using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Personalizacion : MonoBehaviour
{
    [SerializeField] TMP_Text NoMoney;

    [Header("Otros")]
    [SerializeField] Idioma idioma;
    [SerializeField] Sistema_Guardado guardado;

    [SerializeField] ParticleSystem aumento;
    [SerializeField] AudioSource audio;

    [Header("Prefab")]
    [SerializeField]Prefab peso, velocidad, carga, choque, agarre;

    [System.Serializable]
    struct Prefab
    {
        public TMP_Text costo;
        public Image porcentajeAvanzado;
        public Button button;
    }

    bool isclickeable = true;

    internal struct PeticionAnimacion
    {
        public TMP_Text texto;
        [System.Obsolete]
        public TMP_Text textoLimite;
        public Image slider;
        public uint dineroAntes;
        public uint dineroAhora;
        [System.Obsolete("Ahora se usa nivel")]
        public double statAnterior;
        [System.Obsolete("Ahora se usa nivel")]
        public double statActual;
        [System.Obsolete("Ahora se usa nivel")]
        public double statMaxima;

        public int levelAnterior;
        public int levelActual;
        public int levelMax;
        public bool esMaximo;
    }

    private void Start()
    {
        MostrarUI();
        NoMoney.gameObject.SetActive(false);
        peso.button.onClick.AddListener(BTNPeso);
        velocidad.button.onClick.AddListener(BTNVelocidad);
        carga.button.onClick.AddListener(BTNCarga);
        choque.button.onClick.AddListener(BTNBlindaje);
        agarre.button.onClick.AddListener(BTNAgarre);
        
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
        int levelAnterior = actual.CarStatsLevel.peso;

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
            texto = peso.costo,
            dineroAntes = precioAnterior,
            dineroAhora = precioActual,
            esMaximo = actual.SePuedeMejorarPeso,
            slider = peso.porcentajeAvanzado,
            levelAnterior = levelAnterior,
            levelActual = actual.CarStatsLevel.peso,
            levelMax = actual.CarStatsMaxLevel.peso
        }));
        guardado.Guardar_Personalizado();
    }

    void BTNVelocidad()
    {
        var actual = BuildStructs.PCMG.GetOrquestador();

        if (!actual.SePuedeMejorarVelocidad || !isclickeable) return;

        uint precioAnterior = actual.PrecioVelocidad();
        int levelAnterior = actual.CarStatsLevel.velocidad;

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
            texto = velocidad.costo,
            dineroAntes = precioAnterior,
            dineroAhora = precioActual,
            esMaximo = actual.SePuedeMejorarVelocidad,
            slider = velocidad.porcentajeAvanzado,
            levelAnterior = levelAnterior,
            levelActual = actual.CarStatsLevel.velocidad,
            levelMax = actual.CarStatsMaxLevel.velocidad
        }));
        guardado.Guardar_Personalizado();
    }

    void BTNCarga()
    {
        var actual = BuildStructs.PCMG.GetOrquestador();

        if (!actual.SePuedeMejorarCapacidad || !isclickeable) return;

        uint precioAnterior = actual.PrecioCapacidad();
        int levelAnterior = actual.CarStatsLevel.capacidad;

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
            texto = carga.costo,
            dineroAntes = precioAnterior,
            dineroAhora = precioActual,
            esMaximo = actual.SePuedeMejorarCapacidad,
            slider = carga.porcentajeAvanzado,
            levelAnterior = levelAnterior,
            levelActual = actual.CarStatsLevel.capacidad,
            levelMax = actual.CarStatsMaxLevel.capacidad
        }));
        guardado.Guardar_Personalizado();
    }

    void BTNBlindaje()
    {
        var actual = BuildStructs.PCMG.GetOrquestador();

        if (!actual.SePuedeMejorarBlindaje || !isclickeable) return;

        uint precioAnterior = actual.PrecioBlindaje();

        int levelAnterior = actual.CarStatsLevel.blindaje;

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
            texto = choque.costo,
            dineroAntes = precioAnterior,
            dineroAhora = precioActual,
            esMaximo = actual.SePuedeMejorarBlindaje,
            slider = choque.porcentajeAvanzado,
            levelAnterior = levelAnterior,
            levelActual = actual.CarStatsLevel.blindaje,
            levelMax = actual.CarStatsMaxLevel.blindaje
        }));
        guardado.Guardar_Personalizado();
    }

    void BTNAgarre()
    {
        var actual = BuildStructs.PCMG.GetOrquestador();

        if (!actual.SePuedeMejorarAgarre || !isclickeable) return;

        uint precioAnterior = actual.PrecioAgarre();
        int levelAnterior = actual.CarStatsLevel.agarre;

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
            texto = agarre.costo,
            dineroAntes = precioAnterior, 
            dineroAhora = precioActual, 
            esMaximo = actual.SePuedeMejorarAgarre,
            slider = agarre.porcentajeAvanzado,
            levelAnterior = levelAnterior,
            levelActual = actual.CarStatsLevel.agarre,
            levelMax = actual.CarStatsMaxLevel.agarre
    }));
        guardado.Guardar_Personalizado();
    }

    public void MostrarUI()
    {
        var actual = BuildStructs.PCMG.GetOrquestador();
        peso.costo.text = actual.SePuedeMejorarPeso ? actual.PrecioPeso().ToString() : "100%";
        peso.porcentajeAvanzado.fillAmount = (actual.CarStatsLevel.peso - 1/actual.CarStatsMaxLevel.peso - 1);

        velocidad.costo.text = actual.SePuedeMejorarVelocidad ? actual.PrecioVelocidad().ToString() : "100%";
        velocidad.porcentajeAvanzado.fillAmount = (actual.CarStatsLevel.velocidad - 1 / actual.CarStatsMaxLevel.velocidad - 1);

        carga.costo.text = actual.SePuedeMejorarCapacidad ? actual.PrecioCapacidad().ToString() : "100%";
        carga.porcentajeAvanzado.fillAmount = (actual.CarStatsLevel.capacidad - 1/actual.CarStatsMaxLevel.capacidad - 1);

        choque.costo.text = actual.SePuedeMejorarBlindaje ? actual.PrecioBlindaje().ToString() : "100%";
        choque.porcentajeAvanzado.fillAmount = (actual.CarStatsLevel.blindaje - 1/actual.CarStatsMaxLevel.blindaje - 1);

        agarre.costo.text = actual.SePuedeMejorarAgarre ? actual.PrecioAgarre().ToString() : "100%";
        agarre.porcentajeAvanzado.fillAmount = (actual.CarStatsLevel.agarre - 1/actual.CarStatsMaxLevel.agarre - 1);
        idioma.AsignarLenguajeATextos();
    }

    IEnumerator ActualizarUI(PeticionAnimacion animacion)
    {
        isclickeable = false;
        // Guardamos la escala inicial para no perder el formato original
        Vector3 escalaOriginal = animacion.texto.transform.localScale;
        Vector3 escalaObjetivo = escalaOriginal * 1.25f; // Aumento del 25%

        float duracionAnimacion = 1.5f; // Tiempo total que durará todo el efecto
        float tiempoTranscurrido = 0f;

        // Velocidad del pulso (a mayor número, más rápido se infla y desinfla)
        // Con 3f, hará aproximadamente 3 ciclos completos de pulso.
        float velocidadPulso = 3f;
        float llenadoActual = animacion.slider.fillAmount;

        while (tiempoTranscurrido < duracionAnimacion)
        {
            tiempoTranscurrido += Time.deltaTime;
            float progreso = tiempoTranscurrido / duracionAnimacion;

            // --- 1. MATEMÁTICAS DEL CONTEO NUMÉRICO ---
            // Suavizado sutil para el cambio de números
            float progresoSuave = progreso * progreso * (3f - 2f * progreso);
            uint valorActual = (uint)Mathf.Lerp(animacion.dineroAntes, animacion.dineroAhora, progresoSuave);
            animacion.texto.text = valorActual.ToString();

            //0 es el nivel anterior y 1 es el actual
            float valorActualLimite = Mathf.Lerp(0, 1, progresoSuave);

            //el 0.10 es el avance ya que significa que avanzamos hasta el 10% a su valor actual
            animacion.slider.fillAmount =  llenadoActual + (valorActualLimite * 0.10f);
            
            // --- 2. MATEMÁTICAS DEL PULSO CONTINUO ---
            // Usamos valor absoluto (Abs) sobre el Seno para que la escala fluctúe 
            // siempre en positivo entre escalaOriginal (0) y escalaObjetivo (1).
            float onda = Mathf.Abs(Mathf.Sin(progreso * Mathf.PI * velocidadPulso));

            // Interpolamos la escala usando la onda senoidal continua
            animacion.texto.transform.localScale = Vector3.Lerp(escalaOriginal, escalaObjetivo, onda);

            yield return null;
        }

        // --- 3. ESTADO FINAL ---
        // Nos aseguramos de que al terminar el bucle, todo quede en sus valores exactos
        animacion.texto.text = animacion.esMaximo ? animacion.dineroAhora.ToString() : "100%";
        animacion.texto.transform.localScale = escalaOriginal;
        //el 0.10f es el avance ya que 10 niveles si es 1 cada nivel aumentado es del 0.10 osea 10%
        animacion.slider.fillAmount = llenadoActual + 0.10f;
        isclickeable = true;
        idioma.AsignarLenguajeATextos();
    }
}
