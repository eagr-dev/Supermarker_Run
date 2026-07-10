using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoRatero : IA
{
    [Header("Configuración Ratero")]
    [SerializeField] private float distanciaSecurity = 15f; // renombrada internamente por claridad o mantén distanciaSeguridad
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
    private Coroutine coroutinaDesaparicion;
    private List<string> objetosRobados;

    [Header("Informacion Jugador")]
    private Mision misionJugador;
    private CarRuntime carroJugador;
    Player player;

    private void OnEnable()
    {
        // Cuando el RateroManager activa este enemigo con SetActive(true), el NavMeshAgent
        // pierde su destino previo. Si aún no está huyendo, le ordenamos patrullar inmediatamente.
        if (!estaHuyendo && objecto_seguir != null && mapa_content != null)
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

                // Mantenemos los efectos si el jugador está cerca
                if (distanciaJugador < distanciaSeguridad)
                {
                    if (efectoRobo != null && !efectoRobo.isPlaying) efectoRobo.Play();
                    if (sonidoRobo != null && !sonidoRobo.isPlaying) sonidoRobo.Play();
                }

                // El slider sigue mostrando la distancia real al jugador
                if (player != null)
                    player.AnimarSlider(distanciaJugador, distanciaSeguridad);
            }

            ContinuarHuida_PorEvaluacion();
        }
        else
        {
            base.Update();
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
            // CAMBIO CLAVE 1: Declaramos que está huyendo e interrumpe a la IA inmediatamente
            estaHuyendo = true;
            StopAllCoroutines();
            estaDetenido = false;
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
        Debug.Log("[RATERO LOG] Iniciando proceso de robo y rotaciones...");
        if (efectoRobo != null) efectoRobo.Play();

        navegador.isStopped = true;
        player.SetDeadZoneJoystick(1000);
        DetenerMovimiento();

        yield return new WaitForSeconds(tiempoEsperaJugadorDetenerse);

        if (sonidoRobo != null) sonidoRobo.Play();
        RateroManager.PublicarEmpezaRobo(gameObject);

        yield return RotarAmbosDeFrente(player.transform);

        Vector3 vector3 = PositionCarroIA();
        misionJugador.Eliminar_Todo_Al_Chocar_Y_Dar(ref objetosRobados, vector3);

        haRobado = true;

        yield return new WaitForSeconds(tiempoAnimacion);

        Debug.Log("[RATERO LOG] Robo terminado. ¡A correr a la puerta!");
        navegador.isStopped = false;
        player.SetDeadZoneJoystick(0);
        navegador.speed = velocidadHuida;
        ReanudarMovimiento();

        // Iniciamos el movimiento inteligente a la puerta
        IniciarHuida();
    }

    private IEnumerator DevolverTodosLosObjetos(Player player)
    {
        if (efectoRobo != null) efectoRobo.Stop();

        // ── CLAVE: Detener el contador de la puerta si estaba corriendo ──
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

        // Volvemos a sus estados normales para que siga en el mapa
        haRobado = false;
        estaHuyendo = false;

        yield return new WaitForSeconds(tiempoAnimacion);

        navegador.isStopped = false;
        player.SetDeadZoneJoystick(0);

        // Le avisa al manager que el robo se frustró (el manager NO lo desactivará, 
        // gracias al cambio que hicimos antes en el RateroManager)
        RateroManager.PublicarRoboFrustrado(gameObject);

        // Reanuda su caminata/patrulla normal por el mapa
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

        // CUANDO LLEGA A LA PUERTA:
        if (distanciaPuerta < distanciaLlegadaPuerta)
        {
            navegador.isStopped = true; // Se detiene en la puerta

            // Si el contador no ha empezado a correr, lo iniciamos aquí
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

    private Vector3 CalcularMejorPuntoDeEscape()
    {
        Vector3 posRatero = transform.position;
        Vector3 posJugador = jugadorTransform.position;
        Vector3 posPuerta = posicionPuerta;

        float distanciaAPuertaReal = Vector3.Distance(posRatero, posPuerta);

        if (distanciaAPuertaReal <= distanciaEscape * 1.5f)
        {
            Vector3 puntoPuerta = ObtenerPuntoNavMesh(posPuerta);
            if (puntoPuerta != Vector3.zero)
                return puntoPuerta;
        }

        Vector3 dirDirectaMeta = (posPuerta - posRatero).normalized;

        Vector3[] direcciones = new Vector3[]
        {
            dirDirectaMeta,
            Vector3.right,
            Vector3.left,
            Vector3.forward,
            Vector3.back,
            (Vector3.right  + Vector3.forward).normalized,
            (Vector3.left   + Vector3.forward).normalized,
            (Vector3.right  + Vector3.back).normalized,
            (Vector3.left   + Vector3.back).normalized
        };

        float mejorPuntuacion = float.MinValue;
        Vector3 mejorPunto = posRatero;

        foreach (Vector3 dir in direcciones)
        {
            Vector3 candidato = posRatero + dir * distanciaEscape;

            candidato.x = Mathf.Clamp(candidato.x, mapa_content.X_minimo + margenEsquina, mapa_content.X_maximo - margenEsquina);
            candidato.z = Mathf.Clamp(candidato.z, mapa_content.Y_minimo + margenEsquina, mapa_content.Y_maximo - margenEsquina);
            candidato.y = posRatero.y;

            Vector3 puntoValido = ObtenerPuntoNavMesh(candidato);
            if (puntoValido == Vector3.zero)
                continue;

            float puntuacion = EvaluarDireccionHaciaPuerta(puntoValido, posJugador, posPuerta, dir);

            if (puntuacion > mejorPuntuacion)
            {
                mejorPuntuacion = puntuacion;
                mejorPunto = puntoValido;
            }
        }

        return mejorPunto;
    }

    private Vector3 ObtenerPuntoNavMesh(Vector3 punto)
    {
        if (UnityEngine.AI.NavMesh.SamplePosition(punto, out UnityEngine.AI.NavMeshHit hit, 2f, UnityEngine.AI.NavMesh.AllAreas))
            return hit.position;

        return Vector3.zero;
    }

    private float EvaluarDireccionHaciaPuerta(Vector3 puntoDestino, Vector3 posJugador, Vector3 posPuerta, Vector3 direccionEvaluada)
    {
        float puntuacion = 0;

        float distanciaAPuerta = Vector3.Distance(puntoDestino, posPuerta);
        puntuacion -= distanciaAPuerta * 5f;

        Vector3 dirHaciaPuerta = (posPuerta - transform.position).normalized;
        float alineacionConPuerta = Vector3.Dot(direccionEvaluada, dirHaciaPuerta);
        if (alineacionConPuerta > 0)
        {
            puntuacion += alineacionConPuerta * 50f;
        }

        float distanciaAlJugador = Vector3.Distance(puntoDestino, posJugador);
        if (distanciaAlJugador < distanciaSeguridad)
        {
            puntuacion -= (distanciaSeguridad - distanciaAlJugador) * 8f;
        }

        return puntuacion;
    }

    private IEnumerator ContadorDesaparicion()
    {
        if (efectoRobo != null) efectoRobo.Stop();

        // Espera parado en la puerta
        yield return new WaitForSeconds(tiempoAntesDeDesaparecer);

        // DOBLE CHECK: Si ya no está huyendo significa que el robo se frustró 
        // mientras esperaba en la puerta. ¡No lo desactives!
        if (!estaHuyendo)
        {
            coroutinaDesaparicion = null;
            yield break;
        }

        // Si sigue huyendo (el robo NO fue frustrado), entonces sí tuvo éxito y se va:
        estaHuyendo = false;
        haRobado = false;
        navegador.speed = velocidadNormal;

        if (player != null) player.DesactivarSlider();

        coroutinaDesaparicion = null;

        // Avisa al manager para que haga el SetActive(false) y mande al siguiente
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
}