using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoRatero : IA
{
    [Header("Configuración Ratero")]
    [SerializeField] private float distanciaSecurity = 15f;
    [SerializeField] private float distanciaSeguridad = 15f;
    [SerializeField] private float tiempoAntesDeDesaparecer = 15f;
    [SerializeField] private float velocidadHuida = 6f;
    [SerializeField] private float velocidadNormal = 5f;
    [SerializeField] private float tiempoAnimacion = 1f;
    [SerializeField] private float tiempoEsperaJugadorDetenerse = 0.5f;
    private Vector3 posicionPuerta;
    private bool puertaObtenida = false;

    [Header("Sistema de Huida Inteligente")]
    [SerializeField] private float distanciaEscape = 10f;
    [SerializeField] private float tiempoEntreRecalculos = 0.35f;
    [SerializeField] private float margenEsquina = 1.5f;
    [SerializeField] private float distanciaLlegadaPuerta = 2f;

    private float tiempoUltimoRecalculo = 0f;

    [Header("Efectos Visuales")]
    [SerializeField] private ParticleSystem efectoRobo;
    [SerializeField] private AudioSource sonidoRobo;
    [SerializeField] private GameObject indicadorRatero;
    [SerializeField] private float duracionRotacion;

    private bool haRobado = false;
    private bool estaHuyendo = false;
    private bool enAnimacion = false; // <--- NUEVA BANDERA DE CONTROL
    private Coroutine coroutinaDesaparicion;
    private List<string> objetosRobados;

    [Header("Informacion Jugador")]
    private Mision misionJugador;
    private CarRuntime carroJugador;
    Player player;

    private void OnEnable()
    {
        haRobado = false;
        estaHuyendo = false;
        enAnimacion = false;
        coroutinaDesaparicion = null;
        objetosRobados?.Clear();

        if (objecto_seguir != null && mapa_content != null)
        {
            estaDetenido = false;
            navegador.speed = velocidadNormal;
            ReanudarMovimiento();
            New_position(Random_position());
        }
    }

    protected override void Awake()
    {
        base.Awake();
        objetosRobados = new();

        if (indicadorRatero != null)
            indicadorRatero.SetActive(true);
    }

    protected override bool DebePuedeIrACaja() => false;

    protected override void Update()
    {
        if (estaHuyendo)
        {
            if (jugadorTransform == null && player != null)
            {
                jugadorTransform = player.transform;
            }

            if (jugadorTransform != null)
            {
                float distanciaJugador = Vector3.Distance(transform.position, jugadorTransform.position);

                if (distanciaJugador < distanciaSeguridad)
                {
                    if (efectoRobo != null && !efectoRobo.isPlaying) efectoRobo.Play();
                    if (sonidoRobo != null && !sonidoRobo.isPlaying) sonidoRobo.Play();
                }

                if (player != null)
                    player.AnimarSlider(distanciaJugador, distanciaSeguridad);
            }

            // CORRECCIÓN: Si está en animación de interacción, NO recalcular movimiento a la puerta
            if (!enAnimacion)
            {
                ContinuarHuida_PorEvaluacion();
            }
        }
        else
        {
            // CORRECCIÓN: Evita que el comportamiento base de la IA actúe durante la devolución de ítems
            if (!enAnimacion)
            {
                base.Update();
            }
        }
    }

    protected override void OnColisionConJugador(Collision collision)
    {
        player = collision.gameObject.GetComponent<Player>();
        jugadorTransform = player.transform;

        if (!puertaObtenida)
        {
            posicionPuerta = player.GetSpawnPlayer();
            puertaObtenida = true;
            Debug.LogWarning($"[RATERO ORIGEN] Coordenadas de la puerta guardadas: {posicionPuerta.ToString("F2")}");
        }

        if (misionJugador == null)
        {
            misionJugador = collision.gameObject.GetComponent<Mision>();
        }

        if (carroJugador == null)
        {
            carroJugador = player.Get_Carro();
        }

        if (carroJugador.objetos_actuales == 0 && !estaHuyendo)
            return;

        if (!haRobado)
        {
            estaHuyendo = true;
            StopAllCoroutines();
            estaDetenido = false;
            RateroManager.PublicarEmpezaRobo(gameObject); 
            StartCoroutine(RobarTodosLosObjetos(player));
            player.ActivarSlider();
        }
        else if (estaHuyendo)
        {
            StopAllCoroutines();
            StartCoroutine(DevolverTodosLosObjetos(player));
            player.DesactivarSlider();
        }
    }

    private IEnumerator RobarTodosLosObjetos(Player player)
    {
        enAnimacion = true; // <-- Bloqueamos el Update de huida
        Debug.Log("[RATERO LOG] Iniciando proceso de robo y rotaciones...");
        if (efectoRobo != null) efectoRobo.Play();

        navegador.isStopped = true;
        player.SetDeadZoneJoystick(1000);
        DetenerMovimiento();

        yield return new WaitForSeconds(tiempoEsperaJugadorDetenerse);

        if (sonidoRobo != null) sonidoRobo.Play();
        //RateroManager.PublicarEmpezaRobo(gameObject);

        yield return RotarAmbosDeFrente(player.transform);

        Vector3 vector3 = PositionCarroIA();
        misionJugador.Eliminar_Todo_Al_Chocar_Y_Dar(ref objetosRobados, vector3);

        haRobado = true;

        yield return new WaitForSeconds(tiempoAnimacion); // Espera la animación con seguridad

        Debug.Log("[RATERO LOG] Robo terminado. ¡A correr a la puerta!");

        enAnimacion = false; // <-- Desbloqueamos el movimiento justo antes de arrancar
        navegador.isStopped = false;
        player.SetDeadZoneJoystick(0);
        navegador.speed = velocidadHuida;
        ReanudarMovimiento();

        IniciarHuida();
    }

    private IEnumerator DevolverTodosLosObjetos(Player player)
    {
        enAnimacion = true; // <-- Bloqueamos cualquier movimiento de la IA base
        if (efectoRobo != null) efectoRobo.Stop();

        if (coroutinaDesaparicion != null)
        {
            StopCoroutine(coroutinaDesaparicion);
            coroutinaDesaparicion = null;
        }

        navegador.speed = velocidadNormal;
        navegador.isStopped = true;
        player.SetDeadZoneJoystick(1000);
        DetenerMovimiento();

        yield return new WaitForSeconds(tiempoEsperaJugadorDetenerse);

        yield return RotarAmbosDeFrente(player.transform);

        Vector3 position = PositionCarroIA();
        misionJugador.Recuperar_Todos_Los_Objetos(objetosRobados, position);

        objetosRobados.Clear();

        haRobado = false;
        estaHuyendo = false;

        yield return new WaitForSeconds(tiempoAnimacion);

        enAnimacion = false; // <-- Desbloqueamos al terminar por completo la escena
        navegador.isStopped = false;
        player.SetDeadZoneJoystick(0);

        RateroManager.PublicarRoboFrustrado(gameObject);

        ReanudarMovimiento();
        New_position(Random_position());
    }

    private IEnumerator RotarAmbosDeFrente(Transform jugador)
    {
        Coroutine rotacionEnemigo = StartCoroutine(RotarHaciaObjetivo(transform, jugador.position));
        Coroutine rotacionJugador = StartCoroutine(RotarHaciaObjetivo(jugador, transform.position));

        yield return rotacionEnemigo;
        yield return rotacionJugador;
    }

    private IEnumerator RotarHaciaObjetivo(Transform objeto, Vector3 posicionObjetivo)
    {
        Vector3 direccion = (posicionObjetivo - objeto.position).normalized;
        direccion.y = 0;

        if (direccion == Vector3.zero)
            yield break;

        Quaternion rotacionObjetivo = Quaternion.LookRotation(direccion);
        Quaternion rotacionInicial = objeto.rotation;
        float tiempoTranscurrido = 0f;

        while (tiempoTranscurrido < duracionRotacion)
        {
            tiempoTranscurrido += Time.deltaTime;
            float t = tiempoTranscurrido / duracionRotacion;
            objeto.rotation = Quaternion.Slerp(rotacionInicial, rotacionObjetivo, t);
            yield return null;
        }

        objeto.rotation = rotacionObjetivo;
    }

    private Vector3 PositionCarroIA()
    {
        Seleccion_Carrito_Ai carro_AI = GetComponent<Seleccion_Carrito_Ai>();
        int index = carro_AI.GetIndex();
        GameObject carro = carro_AI.Carritos[index];
        return carro.transform.position;
    }

    private void IniciarHuida()
    {
        ContinuarHuida_PorEvaluacion();
    }

    private void ContinuarHuida_PorEvaluacion()
    {
        if (jugadorTransform == null || !puertaObtenida) return;

        float distanciaPuerta = Vector3.Distance(transform.position, posicionPuerta);

        if (distanciaPuerta < distanciaLlegadaPuerta)
        {
            navegador.isStopped = true;

            if (coroutinaDesaparicion == null)
            {
                Debug.Log("[RATERO] Llegué a la puerta. Iniciando temporizador para desaparecer...");
                coroutinaDesaparicion = StartCoroutine(ContadorDesaparicion());
            }
            return;
        }

        if (Time.time - tiempoUltimoRecalculo < tiempoEntreRecalculos)
            return;

        tiempoUltimoRecalculo = Time.time;
        navegador.isStopped = false;
        New_position(posicionPuerta);
    }

    private IEnumerator ContadorDesaparicion()
    {
        if (efectoRobo != null) efectoRobo.Stop();

        yield return new WaitForSeconds(tiempoAntesDeDesaparecer);

        if (!estaHuyendo)
        {
            coroutinaDesaparicion = null;
            yield break;
        }

        estaHuyendo = false;
        haRobado = false;
        navegador.speed = velocidadNormal;

        if (player != null) player.DesactivarSlider();

        coroutinaDesaparicion = null;
        RateroManager.PublicarTerminoRobo(gameObject);
    }

    protected override void OnLlegarADestino()
    {
        if (estaHuyendo)
        {
            float distanciaPuerta = Vector3.Distance(transform.position, posicionPuerta);
            if (distanciaPuerta <= distanciaLlegadaPuerta)
            {
                navegador.isStopped = true;
                Debug.LogWarning("[RATERO] ¡Llegué con éxito a la puerta y me detengo de verdad!");
            }
        }
        else
        {
            base.OnLlegarADestino();
        }
    }


    protected override void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;
        if (haRobado && estaHuyendo)
        {
            OnColisionConJugador(collision);
            return;
        }

        base.OnCollisionEnter(collision);
    }
}