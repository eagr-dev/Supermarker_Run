using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Personalizacion : MonoBehaviour
{
    [SerializeField] TMP_Text NoMoney, reintarMañana;

    [Header("Otros")]
    [SerializeField] Idioma idioma;
    [SerializeField] Sistema_Guardado guardado;

    [SerializeField] ParticleSystem aumento;
    [SerializeField] AudioSource audio, sonido_ruleta;

    [Header("Prefab")]
    [SerializeField] Prefab peso, velocidad, carga, choque, agarre;

    [SerializeField] private GameObject UIRoullete, incierto;
    [SerializeField] private Image[] images = new Image[5];
    [SerializeField] private Sprite[] sprites = new Sprite[5];
    const string NameIntentos = "intentosMejoras", NameHoraGuardada = "horaGuardada";
    System.DateTime date;

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

        string fechaGuardada = PlayerPrefs.GetString(NameHoraGuardada, "");

        if (string.IsNullOrEmpty(fechaGuardada))
        {
            incierto.SetActive(true);
        }
        else
        {
            date = System.DateTime.Parse(fechaGuardada);
            if (date.Date == System.DateTime.Today.Date)
            {
                incierto.SetActive(false);
            }
            else
            {
                incierto.SetActive(true);
            }
        }
        incierto.GetComponentInChildren<Button>().onClick.AddListener(BTNMejoraAleatoria);
        
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

    void BTNMejoraAleatoria()
    {
        Anuncios.Instancia.MostrarAnuncioRecompensa((bool exito) =>
        {
            const int mejoras = 5;
            int mejoraRandom = Random.Range(0, mejoras - 1);
            Debug.Log($"El indice seleccionado es el {mejoraRandom}");
            StartCoroutine(AnimacionUIConActualizacion(mejoraRandom));

            incierto.SetActive(false);
            PlayerPrefs.SetString(NameHoraGuardada, System.DateTime.Today.ToString());
            PlayerPrefs.Save();
        });
    }



    public void MostrarUI()
    {
        var actual = BuildStructs.PCMG.GetOrquestador();
        peso.costo.text = actual.SePuedeMejorarPeso ? $"${actual.PrecioPeso()}" : "100%";
        peso.porcentajeAvanzado.fillAmount = ((float)(actual.CarStatsLevel.peso - 1)/(float)(actual.CarStatsMaxLevel.peso - 1));

        velocidad.costo.text = actual.SePuedeMejorarVelocidad ? $"${actual.PrecioVelocidad()}" : "100%";
        velocidad.porcentajeAvanzado.fillAmount = ((float)(actual.CarStatsLevel.velocidad - 1) / (float)(actual.CarStatsMaxLevel.velocidad - 1));

        carga.costo.text = actual.SePuedeMejorarCapacidad ? $"${actual.PrecioCapacidad()}" : "100%";
        carga.porcentajeAvanzado.fillAmount = ((float)(actual.CarStatsLevel.capacidad - 1)/(float)(actual.CarStatsMaxLevel.capacidad - 1));

        choque.costo.text = actual.SePuedeMejorarBlindaje ? $"${actual.PrecioBlindaje()}" : "100%";
        choque.porcentajeAvanzado.fillAmount = ((float)(actual.CarStatsLevel.blindaje - 1)/(float)(actual.CarStatsMaxLevel.blindaje - 1));

        agarre.costo.text = actual.SePuedeMejorarAgarre ? $"${actual.PrecioAgarre()}" : "100%";
        agarre.porcentajeAvanzado.fillAmount = ((float)(actual.CarStatsLevel.agarre - 1)/(float)(actual.CarStatsMaxLevel.agarre - 1));

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
            animacion.texto.text = $"${valorActual}";

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
        animacion.texto.text = animacion.esMaximo ? $"${animacion.dineroAhora}" : "100%";
        animacion.texto.transform.localScale = escalaOriginal;
        //el 0.10f es el avance ya que 10 niveles si es 1 cada nivel aumentado es del 0.10 osea 10%
        animacion.slider.fillAmount = llenadoActual + 0.10f;
        isclickeable = true;
        idioma.AsignarLenguajeATextos();
    }

    private IEnumerator AnimacionNoMasIntentos()
    {
        reintarMañana.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        reintarMañana.gameObject.SetActive(false);
    }

    private IEnumerator AnimacionUIConActualizacion(int index)
    {
        yield return AnimacionUI(index);
        yield return null;
        var actual = BuildStructs.PCMG.GetOrquestador();
        uint precioAnterior = 0, precioActual = 0;
        int levelAnterior = 0, levelActual = 0, levelMax = 0;
        bool sePuedeMejorar = false;
        Image image = null;
        //0 peso, 1 velocidad, 2 carga, 3 blindaje, 4 agarre
        Debug.Log($"El indice seleccionado es el {index}");
        switch (index)
        {
            case 0:
                {
                    Debug.Log($"El mejorar es el peso");
                    if (!actual.SePuedeMejorarPeso) yield break;
                    precioAnterior = actual.PrecioPeso();
                    levelAnterior = actual.CarStatsLevel.peso;
                    actual.DisminuirPeso();
                    precioActual = actual.PrecioPeso();
                    sePuedeMejorar = actual.SePuedeMejorarPeso;
                    image = peso.porcentajeAvanzado;
                    levelActual = actual.CarStatsLevel.peso;
                    levelMax = actual.CarStatsMaxLevel.peso;
                }
                break;
            case 1:
                {
                    Debug.Log($"El mejorar es la velocidad");
                    if (!actual.SePuedeMejorarVelocidad) yield break;
                    precioAnterior = actual.PrecioVelocidad();
                    levelAnterior = actual.CarStatsLevel.velocidad;
                    actual.AumentarVelocidad();
                    precioActual = actual.PrecioVelocidad();
                    sePuedeMejorar = actual.SePuedeMejorarVelocidad;
                    image = peso.porcentajeAvanzado;
                    levelActual = actual.CarStatsLevel.velocidad;
                    levelMax = actual.CarStatsMaxLevel.velocidad;
                }
                break;
            case 2:
                {
                    Debug.Log($"El mejorar es la capacidad");
                    if (!actual.SePuedeMejorarCapacidad) yield break;
                    precioAnterior = actual.PrecioCapacidad();
                    levelAnterior = actual.CarStatsLevel.capacidad;
                    actual.AumentarCapacidad();
                    precioActual = actual.PrecioCapacidad();
                    sePuedeMejorar = actual.SePuedeMejorarCapacidad;
                    image = peso.porcentajeAvanzado;
                    levelActual = actual.CarStatsLevel.capacidad;
                    levelMax = actual.CarStatsMaxLevel.capacidad;
                }
                break;
            case 3:
                {
                    Debug.Log($"El mejorar es el blindaje");
                    if (!actual.SePuedeMejorarBlindaje) yield break;
                    precioAnterior = actual.PrecioBlindaje();
                    levelAnterior = actual.CarStatsLevel.blindaje;
                    actual.AumentarBlindaje();
                    precioActual = actual.PrecioBlindaje();
                    sePuedeMejorar = actual.SePuedeMejorarBlindaje;
                    image = peso.porcentajeAvanzado;
                    levelActual = actual.CarStatsLevel.blindaje;
                    levelMax = actual.CarStatsMaxLevel.blindaje;
                }
                break;
            case 4:
                {
                    Debug.Log($"El mejorar es el agarre");
                    if (!actual.SePuedeMejorarAgarre) yield break;
                    precioAnterior = actual.PrecioAgarre();
                    levelAnterior = actual.CarStatsLevel.agarre;
                    actual.AumentarAgarre();
                    precioActual = actual.PrecioAgarre();
                    sePuedeMejorar = actual.SePuedeMejorarAgarre;
                    image = peso.porcentajeAvanzado;
                    levelActual = actual.CarStatsLevel.agarre;
                    levelMax = actual.CarStatsMaxLevel.agarre;
                }
                break;
        }
        yield return null;

        aumento.Play();
        audio.Play();

        yield return null;

        yield return ActualizarUI(new PeticionAnimacion
        {
            texto = peso.costo,
            dineroAntes = precioAnterior,
            dineroAhora = precioActual,
            esMaximo = sePuedeMejorar,
            slider = image,
            levelAnterior = levelAnterior,
            levelActual = levelActual,
            levelMax = levelMax
        });

        guardado.Guardar_Personalizado();
    }

    public IEnumerator AnimacionUI(int indexTarget)
    {
        UIRoullete.SetActive(true);
        yield return null; // Pequeña espera para asegurar que la UI se ha activado
        sonido_ruleta.Play();

        // --- Configuración de la Ruleta ---
        int numSteps = 30; // Cantidad fija de "giros" o cambios que hará la ruleta.
        int indexPointer = 2; // Supongamos que la imagen CENTRAL es la que tiene el puntero (índice 2 para 5 imágenes).
        int maxS = sprites.Length; // 7, la cantidad total de sprites.

        // --- MATEMÁTICAS PARA EL ATERRIZAJE NATURAL ---
        // 1. Calculamos el offset final necesario para que el target sprite quede en el puntero.
        // La fórmula es: offsetFinal = (indexTarget - indexPointer) MOD maxSprites.
        // Esto asegura que la imagen en 'indexPointer' sea: sprites[(offsetFinal + indexPointer) % 7] -> sprites[indexTarget].
        // Usamos esta forma robusta del módulo para manejar resultados negativos.
        int finalOffset = ((indexTarget - indexPointer) % maxS + maxS) % maxS;

        // 2. Calculamos el offset inicial restando numSteps.
        // Esto nos da la posición inicial de "virtual" de la ruleta para que después de numSteps incrementos llegue a finalOffset.
        int currentOffset = ((finalOffset - numSteps) % maxS + maxS) % maxS;


        // --- Configuración de Desaceleración (Curva de frenado) ---
        //float totalTime = tiempo_animacion;
        float totalTime = sonido_ruleta.clip.length + 0.2f;
        float T_min = 0.005f; // Tiempo inicial muy rápido (sincronizado con Time.deltaTime es buena opción)

        float T_max = (2.0f * totalTime / numSteps) - T_min;
        if (T_max < T_min) T_max = T_min; // Seguridad

        float timeAccumulator = 0;
        for (int step = 0; step < numSteps; step++)
        {
            currentOffset = (currentOffset + 1) % maxS;

            for (int i = 0; i < 5; i++)
            {
                images[i].sprite = sprites[(currentOffset + i) % maxS];
            }

            float stepDuration = T_min + (float)step * (T_max - T_min) / (float)(numSteps - 1);
            timeAccumulator += stepDuration;
            yield return new WaitForSeconds(stepDuration);
        }

        yield return new WaitForSeconds(1);

        UIRoullete.SetActive(false);
        incierto.SetActive(false);
    }

}
