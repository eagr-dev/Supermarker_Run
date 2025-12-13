using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class IA : BehaviorEnemy
{
    [Header("Componentes Base")]
    [SerializeField] protected NavMeshAgent navegador;
    [SerializeField] protected Animator animacion;
    [SerializeField] protected GameObject objecto_seguir;

    [Header("Navegación")]
    [SerializeField] protected float distanciaLlegada = 2f;
    [SerializeField] protected float tiempoSinMovimiento = 0.5f;

    protected List<GameObject> posicion_cajas;
    protected Mapa mapa_content;
    protected bool estaDetenido = false;
    protected Transform jugadorTransform;

    // Detección de atascos
   // private Vector3 posicionAnterior;
    //private float tiempoAtascado = 0f;

    protected virtual void Awake()
    {
        navegador = GetComponent<NavMeshAgent>();
        animacion = GetComponent<Animator>();

        if (navegador == null)
            Debug.LogError("navegador no asignado");

        if (animacion == null)
            Debug.LogError("animacion no asignada");

        InicializarAnimacion();
        New_Color();
    }

    public virtual void Set(Mapa mapa, GameObject objeto, List<GameObject> cajas, Transform jugador)
    {
        mapa_content = mapa;
        objecto_seguir = objeto;
        posicion_cajas = cajas;
        jugadorTransform = jugador;

        if (objecto_seguir != null)
            New_position(Random_position());
        else
            Destroy(gameObject);
    }

    // ============================================================
    // NUEVO UPDATE (usa HaLlegadoADestino)
    // ============================================================
    protected virtual void Update()
    {
        if (estaDetenido) return;

        if (HaLlegadoADestino())
        {
            OnLlegarADestino();
        }
    }

    // ============================================================
    // NUEVA FUNCIÓN DE DETECCIÓN DE LLEGADA
    // ============================================================
    protected bool HaLlegadoADestino()
    {
        // Si no tiene path, todavía no llegó
        if (!navegador.hasPath && !navegador.pathPending)
            return false;

        float distancia = Vector3.Distance(transform.position, navegador.destination);

        // Llegó si está suficientemente cerca
        if (distancia <= distanciaLlegada)
            return true;

        // Backup: NavMeshAgent dice que ya llegó
        if (!navegador.pathPending && navegador.remainingDistance <= navegador.stoppingDistance + 1f)
        {
            if (!navegador.hasPath || navegador.velocity.sqrMagnitude < 0.1f)
                return true;
        }

        return false;
    }

    // ============================================================
    // Al llegar al destino
    // ============================================================
    protected virtual void OnLlegarADestino()
    {
        StartCoroutine(EsperarYMoverse(1f, 10f, DebePuedeIrACaja()));
    }

    protected abstract bool DebePuedeIrACaja();

    // ============================================================
    // Métodos comunes
    // ============================================================
    protected void InicializarAnimacion()
    {
        animacion.SetFloat("VelX", 1);
        animacion.SetFloat("VelY", 1);
    }

    protected void DetenerMovimiento()
    {
        navegador.isStopped = true;
        animacion.SetFloat("VelX", 0);
        animacion.SetFloat("VelY", 0);
    }

    protected void ReanudarMovimiento()
    {
        navegador.isStopped = false;
        animacion.SetFloat("VelX", 1);
        animacion.SetFloat("VelY", 1);
    }

    protected void New_position(Vector3 position)
    {
        objecto_seguir.transform.position = position;
        navegador.destination = objecto_seguir.transform.position;
    }

    protected Vector3 Ir_Caja()
    {
        int index = Random.Range(0, posicion_cajas.Count);
        if (posicion_cajas[index].GetComponent<CajaEnemigo>().GetOcupado())
            return Random_position();

        Vector3 vector3 = posicion_cajas[index].transform.position;
        vector3.y = 0;
        return vector3;
    }

    protected Vector3 Random_position()
    {
        float resultadoX = Random.Range(mapa_content.X_minimo, mapa_content.X_maximo);
        float resultadoY = Random.Range(mapa_content.Y_minimo, mapa_content.Y_maximo);
        return new Vector3(resultadoX, 0, resultadoY);
    }

    protected void New_Color()
    {
        transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material.color = Random.ColorHSV();
    }

    protected IEnumerator EsperarYMoverse(float tiempoMin, float tiempoMax, bool incluirCajas)
    {
        estaDetenido = true;
        DetenerMovimiento();

        float tiempo = Random.Range(tiempoMin, tiempoMax);
        yield return new WaitForSeconds(tiempo);

        estaDetenido = false;
        ReanudarMovimiento();

        Vector3 nuevaPosicion = incluirCajas && Random.value > 0.5f
            ? Ir_Caja()
            : Random_position();

        New_position(nuevaPosicion);
    }

    protected void AplicarEmpuje(Vector3 direccion, float fuerza = 3f)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(direccion * fuerza, ForceMode.Impulse);
        }
    }
}
