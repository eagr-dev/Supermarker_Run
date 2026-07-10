using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Recibe la lista de rateros pre-creados por Obstaculos y gestiona
/// cuál está activo en cada momento durante la partida.
/// 
/// Señales que recibe de EnemigoRatero:
///   - OnEmpezaRobo   → no destruyas este ratero hasta que yo avise
///   - OnTerminoRobo  → ya terminé (escapé o me atraparon), puedes rotar
/// </summary>
public class RateroManager : MonoBehaviour
{
    public static RateroManager Instancia { get; private set; }

    // ── Eventos que EnemigoRatero publica ────────────────────────────────────
    // El parámetro es el GameObject del ratero que dispara el evento.
    public static event System.Action<GameObject> OnEmpezaRobo;
    public static event System.Action<GameObject> OnTerminoRobo;
    public static event System.Action<GameObject> OnRoboFrustrado;

    [SerializeField] private float tiempoEntreRotaciones = 10f; // segundos antes de enviar el siguiente
    [SerializeField] private float tiempoMatarRatero = 0f; // segundos antes de enviar el siguiente
    [SerializeField] private float tiempoTotalJuego = 600f;

    private List<GameObject> rateros = new();
    private List<int> indiceRaterosLogroraronRobo = new();
    private int indiceActual = 0;
    private bool robandoActualmente = false;
    private bool juegoActivo = false;
    private Coroutine corotinaRotacion;

    private void Awake()
    {
        if (Instancia != null && Instancia != this) { Destroy(gameObject); return; }
        Instancia = this;
    }

    private void OnEnable()
    {
        OnEmpezaRobo += ManejarEmpezaRobo;
        OnTerminoRobo += ManejarTerminoRobo;
        OnRoboFrustrado += ManejarRoboFrustrado;
    }

    private void OnDisable()
    {
        OnEmpezaRobo -= ManejarEmpezaRobo;
        OnTerminoRobo -= ManejarTerminoRobo;
        OnRoboFrustrado -= ManejarRoboFrustrado;
    }

    // ── API pública ──────────────────────────────────────────────────────────

    /// <summary>
    /// Obstaculos llama esto una vez pasándole todos los rateros ya instanciados.
    /// </summary>
    public void Inicializar(List<GameObject> raterosCreados, float duracionJuego = 600)
    {
        rateros = raterosCreados;
        tiempoTotalJuego = duracionJuego;

        // Ocultamos todos al inicio; el manager decide quién aparece
        foreach (var r in rateros)
            r.SetActive(false);

        juegoActivo = true;
        tiempoMatarRatero = (duracionJuego / raterosCreados.Count) - tiempoEntreRotaciones;
        Debug.Log($"El tiempo para los rateros es de {tiempoMatarRatero}");
        StartCoroutine(ContarTiempo());
        ActivarSiguiente();
    }

    // ── Handlers de eventos ──────────────────────────────────────────────────

    /// <summary>
    /// Ratero avisa: "estoy robando, no me quites".
    /// </summary>
    private void ManejarEmpezaRobo(GameObject ratero)
    {
        if (ratero != rateros[indiceActual]) return;
        robandoActualmente = true;

        // Pausamos cualquier rotación pendiente
        if (corotinaRotacion != null)
        {
            StopCoroutine(corotinaRotacion);
            corotinaRotacion = null;
        }

        Debug.Log("[MANAGER] Ratero robando — rotación pausada.");
    }

    /// <summary>
    /// Ratero avisa: "terminé".
    /// </summary>
    private void ManejarTerminoRobo(GameObject ratero)
    {
        if (ratero != rateros[indiceActual]) return;
        robandoActualmente = false;

        if (!juegoActivo) return;

        Debug.Log("[MANAGER] Lo Logro.");
        ratero.SetActive(false);

        //Agregamos el indice para ya jamas volver a usar este ratero 
        indiceRaterosLogroraronRobo.Add(indiceActual);

        corotinaRotacion = StartCoroutine(EsperarYRotar(0));
    }

    /// <summary>
    /// Ratero avisa: "me atraparon".
    /// </summary>
    private void ManejarRoboFrustrado(GameObject ratero)
    {
        if (ratero != rateros[indiceActual]) return;
        robandoActualmente = false;
        Debug.Log("[MANAGER] Lo frustraron.");

        float tiempo = Random.Range(60, tiempoMatarRatero);
        corotinaRotacion = StartCoroutine(EsperarYRotar(tiempo));
    }

    // ── Lógica interna ───────────────────────────────────────────────────────

    private void ActivarSiguiente()
    {
        if (!juegoActivo || rateros.Count == 0) return;

        rateros[indiceActual].SetActive(true);
        Debug.Log($"[MANAGER] Ratero {indiceActual + 1} activado.");

        // Programa la rotación automática si nadie está robando
        if (!robandoActualmente)
        {
            float tiempo = Random.Range(60, tiempoMatarRatero);
            corotinaRotacion = StartCoroutine(EsperarYRotar(tiempo));
        }
    }

    private IEnumerator EsperarYRotar(float tiempoMatar)
    {
        yield return new WaitForSeconds(tiempoMatar);


        if (!juegoActivo) yield break;

        // Ocultar el actual
        rateros[indiceActual].SetActive(false);

        yield return new WaitForSeconds(tiempoEntreRotaciones);

        bool todosIndicesUsados = true;
        // Avanzar al siguiente (cíclico, aleatorio dentro del rango)
        for (int i = 0; i < rateros.Count; i++)
        {
            indiceActual = (indiceActual + 1) % rateros.Count;
            if(!indiceRaterosLogroraronRobo.Contains(indiceActual))
            {
                todosIndicesUsados = false;
                break;
            }
        }
        
        if(!todosIndicesUsados)
            ActivarSiguiente();
    }

    private IEnumerator ContarTiempo()
    {
        yield return new WaitForSeconds(tiempoTotalJuego);
        juegoActivo = false;

        // Ocultar al ratero activo cuando se acaba el tiempo
        if (rateros.Count > 0)
            rateros[indiceActual].SetActive(false);

        Debug.Log("[MANAGER] Tiempo agotado. Todos los rateros retirados.");
    }

    // ── Métodos estáticos que EnemigoRatero invoca ───────────────────────────

    public static void PublicarEmpezaRobo(GameObject ratero) => OnEmpezaRobo?.Invoke(ratero);
    public static void PublicarTerminoRobo(GameObject ratero) => OnTerminoRobo?.Invoke(ratero);
    public static void PublicarRoboFrustrado(GameObject ratero) => OnRoboFrustrado?.Invoke(ratero);
}