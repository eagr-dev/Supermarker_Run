using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoRatero : IA
{
    [Header("Configuración Ratero")]
    [SerializeField] private float distanciaSeguridad = 15f;
    [SerializeField] private float tiempoAntesDeDesaparecer = 15f;
    [SerializeField] private float velocidadHuida = 6f;
    [SerializeField] private float velocidadNormal = 5f;
    [SerializeField] private float tiempoAnimacion = 1f;
    [SerializeField] private float tiempoEsperaJugadorDetenerse = 0.5f;

    [Header("Sistema de Huida Inteligente")]
    [SerializeField] private float distanciaEscape = 10f;
    [SerializeField] private float tiempoEntreRecalculos = 0.35f;
    [SerializeField] private float margenEsquina = 1.5f;

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
    //private Vector3 posicion_carro = new();

    [Header("Informacion Jugador")]
    private Mision misionJugador;
    private Car carroJugador;

    protected override void Awake()
    {
        base.Awake();
        objetosRobados = new();

        if (indicadorRatero != null)
            indicadorRatero.SetActive(true);
    }

    protected override bool DebePuedeIrACaja()
    {
        return false;
    }

    protected override void Update()
    {
        base.Update();

        if (estaHuyendo && jugadorTransform != null)
        {
            float distanciaJugador = Vector3.Distance(transform.position, jugadorTransform.position);

            if (distanciaJugador >= distanciaSeguridad)
            {
                if (coroutinaDesaparicion == null)
                {
                    coroutinaDesaparicion = StartCoroutine(ContadorDesaparicion());
                }
            }
            else
            {
                if (coroutinaDesaparicion != null)
                {
                    if (efectoRobo != null) efectoRobo.Play();
                    if (sonidoRobo != null) sonidoRobo.Play();
                    StopCoroutine(coroutinaDesaparicion);
                    coroutinaDesaparicion = null;
                }

                // NUEVO SISTEMA DE HUIDA INTELIGENTE
                ContinuarHuida_PorEvaluacion();
            }
        }
    }

    protected override void OnColisionConJugador(Collision collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (misionJugador == null)
        {
            misionJugador = collision.gameObject.GetComponent<Mision>();
        }

        if(carroJugador == null)
        {
            carroJugador = player.Get_Carro();
        }

        if (carroJugador.objetos_actuales == 0 && !estaHuyendo)
            return;

        if (!haRobado)
        {
            StopCoroutine(nameof(EsperarYMoverse));
            estaDetenido = false;
            StartCoroutine(RobarTodosLosObjetos(player));
        }
        else if (estaHuyendo)
        {
            StartCoroutine(DevolverTodosLosObjetos(player));
        }
    }

    private IEnumerator RobarTodosLosObjetos(Player player)
    {
        if (efectoRobo != null) efectoRobo.Play();
        navegador.isStopped = true;
        player.SetDeadZoneJoystick(1000);
        DetenerMovimiento();

        yield return new WaitForSeconds(tiempoEsperaJugadorDetenerse);

        if (sonidoRobo != null) sonidoRobo.Play();

        yield return StartCoroutine(RotarAmbosDeFrente(player.transform));

        Vector3 vector3 = PositionCarroIA();
        misionJugador.Eliminar_Todo_Al_Chocar_Y_Dar(ref objetosRobados, vector3);

        haRobado = true;
        estaHuyendo = true;
        yield return new WaitForSeconds(tiempoAnimacion);
        Debug.Log("terminar de robar objetos");
        navegador.isStopped = false;
        
        player.SetDeadZoneJoystick(0);
        navegador.speed = velocidadHuida;
        ReanudarMovimiento();
        IniciarHuida();
    }

    private IEnumerator DevolverTodosLosObjetos(Player player)
    {
        Debug.Log("¡El jugador atrapó al ratero! Recupera sus objetos");
        if (efectoRobo != null) efectoRobo.Stop();
        navegador.speed = velocidadNormal;
        navegador.isStopped = true;
        player.SetDeadZoneJoystick(1000);
        DetenerMovimiento();

        yield return new WaitForSeconds(tiempoEsperaJugadorDetenerse);


        yield return StartCoroutine(RotarAmbosDeFrente(player.transform));

        Vector3 position = PositionCarroIA();
        misionJugador.Recuperar_Todos_Los_Objetos(objetosRobados, position);

        objetosRobados.Clear();
        haRobado = false;
        estaHuyendo = false;

        yield return new WaitForSeconds(tiempoAnimacion);

        navegador.isStopped = false;
        player.SetDeadZoneJoystick(0);

        if (coroutinaDesaparicion != null)
        {
            StopCoroutine(coroutinaDesaparicion);
            coroutinaDesaparicion = null;
        }
        ReanudarMovimiento();
        New_position(Random_position());
    }


    // ============================================================
    // MÉTODO PRINCIPAL: Rota ambos al mismo tiempo
    // ============================================================
    private IEnumerator RotarAmbosDeFrente(Transform jugador)
    {
        // Iniciar ambas rotaciones simultáneamente
        Coroutine rotacionEnemigo = StartCoroutine(RotarHaciaObjetivo(transform, jugador.position));
        Coroutine rotacionJugador = StartCoroutine(RotarHaciaObjetivo(jugador, transform.position));

        // Esperar a que ambas terminen
        yield return rotacionEnemigo;
        yield return rotacionJugador;
    }

    // ============================================================
    // Método genérico de rotación (reutilizable para ambos)
    // ============================================================
    private IEnumerator RotarHaciaObjetivo(Transform objeto, Vector3 posicionObjetivo)
    {
        // Calcular dirección hacia el objetivo
        Vector3 direccion = (posicionObjetivo - objeto.position).normalized;
        direccion.y = 0; // Solo rotación horizontal

        if (direccion == Vector3.zero)
            yield break;

        Quaternion rotacionObjetivo = Quaternion.LookRotation(direccion);
        Quaternion rotacionInicial = objeto.rotation;
        float tiempoTranscurrido = 0f;

        while (tiempoTranscurrido < duracionRotacion)
        {
            tiempoTranscurrido += Time.deltaTime;
            float t = tiempoTranscurrido / duracionRotacion;

            // Rotación esférica suave
            objeto.rotation = Quaternion.Slerp(rotacionInicial, rotacionObjetivo, t);

            yield return null;
        }

        // Asegurar rotación final exacta
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

    // ----------------------------------------------------------------------
    //  NUEVO SISTEMA DE HUIDA INTELIGENTE
    // ----------------------------------------------------------------------

    private void ContinuarHuida_PorEvaluacion()
    {
        if (jugadorTransform == null) return;

        if (Time.time - tiempoUltimoRecalculo < tiempoEntreRecalculos)
            return;

        tiempoUltimoRecalculo = Time.time;

        Vector3 mejorPunto = CalcularMejorPuntoDeEscape();
        New_position(mejorPunto);
    }

    private Vector3 CalcularMejorPuntoDeEscape()
    {
        Vector3 posRatero = transform.position;
        Vector3 posJugador = jugadorTransform.position;

        Vector3[] direcciones = new Vector3[]
        {
            Vector3.right,
            Vector3.left,
            Vector3.forward,
            Vector3.back,
            (Vector3.right + Vector3.forward).normalized,
            (Vector3.left + Vector3.forward).normalized,
            (Vector3.right + Vector3.back).normalized,
            (Vector3.left + Vector3.back).normalized
        };

        float mejorPuntuacion = float.MinValue;
        Vector3 mejorDireccion = Vector3.zero;

        foreach (Vector3 dir in direcciones)
        {
            Vector3 puntoDestino = posRatero + dir * distanciaEscape;

            puntoDestino.x = Mathf.Clamp(puntoDestino.x, mapa_content.X_minimo + margenEsquina, mapa_content.X_maximo - margenEsquina);
            puntoDestino.z = Mathf.Clamp(puntoDestino.z, mapa_content.Y_minimo + margenEsquina, mapa_content.Y_maximo - margenEsquina);
            puntoDestino.y = 0;

            float puntuacion = EvaluarDireccion(posRatero, puntoDestino, posJugador);

            if (puntuacion > mejorPuntuacion)
            {
                mejorPuntuacion = puntuacion;
                mejorDireccion = dir;
            }
        }

        Vector3 puntoFinal = posRatero + mejorDireccion * distanciaEscape;
        puntoFinal.x = Mathf.Clamp(puntoFinal.x, mapa_content.X_minimo + margenEsquina, mapa_content.X_maximo - margenEsquina);
        puntoFinal.z = Mathf.Clamp(puntoFinal.z, mapa_content.Y_minimo + margenEsquina, mapa_content.Y_maximo - margenEsquina);
        puntoFinal.y = 0;

        return puntoFinal;
    }

    private float EvaluarDireccion(Vector3 posRatero, Vector3 puntoDestino, Vector3 posJugador)
    {
        float puntuacion = 0;

        float distanciaAlJugador = Vector3.Distance(puntoDestino, posJugador);
        puntuacion += distanciaAlJugador * 5f;

        float distBordeX = Mathf.Min(
            Mathf.Abs(puntoDestino.x - mapa_content.X_minimo),
            Mathf.Abs(puntoDestino.x - mapa_content.X_maximo)
        );
        float distBordeZ = Mathf.Min(
            Mathf.Abs(puntoDestino.z - mapa_content.Y_minimo),
            Mathf.Abs(puntoDestino.z - mapa_content.Y_maximo)
        );
        puntuacion += Mathf.Min(distBordeX, distBordeZ) * 3f;

        Vector3 dirAlJugador = (posJugador - posRatero).normalized;
        Vector3 dirDestino = (puntoDestino - posRatero).normalized;

        float similaridad = Vector3.Dot(dirDestino, dirAlJugador);
        if (similaridad > 0)
            puntuacion -= similaridad * 20f;

        return puntuacion;
    }

    // ----------------------------------------------------------------------

    private IEnumerator ContadorDesaparicion()
    {
        if (efectoRobo != null) efectoRobo.Stop();

        yield return new WaitForSeconds(tiempoAntesDeDesaparecer);

        estaHuyendo = false;
        haRobado = false;
        navegador.speed = velocidadNormal;

        yield return new WaitForSeconds(Random.Range(3f, 8f));

        Debug.Log("El ratero desaparece con los objetos robados");
        Destroy(gameObject);
    }

    protected override void OnLlegarADestino()
    {
        if (estaHuyendo)
        {
            ContinuarHuida_PorEvaluacion();
        }
        else
        {
            base.OnLlegarADestino();
        }
    }
}
