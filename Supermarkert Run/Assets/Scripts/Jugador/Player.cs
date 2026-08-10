using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Animations.Rigging;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Joystick_Velocidad")]
    [SerializeField] private float max_speed_H = 1, max_speed_V = 1, Vertical_Move = 0, Horizontal_Move = 0, speed = 1, resistencia_porcentual = 0.10f, velocidad_porcentual = 0;    private float velocidadResbalon;
    [SerializeField] private Joystick joystick;

    [Header("Camara")]
    [SerializeField] private GameObject player_object;
    [SerializeField] private GameObject camara;
    Vector3 position_camera = new(0, 7, -10);
    [SerializeField] private float distanciaEstante = 3f;

    [Header("Otros")]
    public Vector3 position_Reset;
    //private Get_Content_Car carrito_contenido;
    private Rigidbody rigid;
    [SerializeField] Slider sliderDistanciaRatero;

    [Header("Carro")]
    private ContactPoint punto_choque;
    [SerializeField] private Rig[] rigs = new Rig[3];
    private bool resbalon = false;
    private bool choque = false;
    private bool choque_mayor = false;
    private CarRuntime carrito;
    //private CarSkinData skinData;

    [Header("Mision_Caja")]
    private Mision mision;
    [SerializeField] private GameObject Muerte_canvas;
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject Ganar_canvas;
    [SerializeField] private Animator animacion;
    [SerializeField] private TMP_Text Dinero_Text;
    private float Tiempo_Dejar_Objeto = 1;
    [SerializeField] private Button obtener_Objeto_suelo;
    [SerializeField] private Button obtener_Objeto_carro;
    private Objeto_caido se_tomo_objeto_suelo;
    private Objeto_random_carro se_tomo_objeto_carro;
    private HashSet<Objeto_caido> objetosEnRango = new();
    private bool estaEnCaja = false;

    [Header("Particulas")]
    [SerializeField] private List<ParticleSystem> particulas;
    [SerializeField] private ParticleSystem Choque_P, Exclamacion;

    [Header("Power_UP")]
    private Repartir_power RP;
    private Repartir_power.Power_Up PU;
    private Interfaz_PowerUp Efecto;
    private float tiempoEliminar = 1;

    [Header("Sonido")]
    [SerializeField] private AudioSource Choque_sound;

    [Header("Efecto Visual Velocidad")]
    [SerializeField] private Material speedLinesMaterial;
    [SerializeField] private float normalFOV = 60f;
    [SerializeField] private float speedFOV = 75f;
    [SerializeField] private float suavizadoEfecto = 5f;
    private float intensidadEfectoActual = 0f;

    [Header("Efecto Visual Proteccion")]
    [SerializeField] GameObject proteccion_visual;

    private void OnEnable()
    {
        Objeto_caido.OnObjetoDestruido += ManejarObjetoDestruido;
    }

    private void OnDisable()
    {
        Objeto_caido.OnObjetoDestruido -= ManejarObjetoDestruido;
    }

    private void Awake()
    {
        mision = FindFirstObjectByType<Mision>();
        rigid = GetComponent<Rigidbody>();
        if (FindFirstObjectByType<Repartir_power>() != null)
        {
            RP = FindFirstObjectByType<Repartir_power>();
            Efecto = RP.Get_Power_Up_Class();
            PU = RP.Get_Power_Up();
            Debug.Log(PU);
        }
        Power_Respective();
        obtener_Objeto_suelo.onClick.AddListener(BTN_Agarrar_Objeto_Suelo);
        obtener_Objeto_carro.onClick.AddListener(BTN_Agarrar_Objeto_Carro);
        speedLinesMaterial.SetFloat("_Intensity", 0f);
    }

    private void Start()
    {
        if (sliderDistanciaRatero == null) throw new Exception("Pendejo agrega el pinche slider");

        for (int i = 5; i < 8; i++)
        {
            ParticleSystem.EmissionModule emission = Ganar_canvas.transform.GetChild(i).GetComponent<ParticleSystem>().emission;
            emission.enabled = false;
        }
        NO_INICIAR_PARTICULAS();
        carrito = GetComponent<CarRuntime>();
        carrito.Inicializar(BuildStructs.PCMG.GetOrquestador());
        Init(carrito);
        mision.SetTiempo(Tiempo_Dejar_Objeto);
    }

    void Update()
    {
        Camera_Move();
        Condicionales();
        ActualizarEfectoVelocidad();
        mision.posicion_carro = Get_transform_carro().position;
    }

    private void FixedUpdate()
    {
        Mover_Player();
    }

    private void ActualizarEfectoVelocidad()
    {
        bool tienePowerUp = (PU == Repartir_power.Power_Up.VELOCIDAD);
        float factorVelocidad = Velocidad_joystick();

        float targetIntensidad = tienePowerUp ? factorVelocidad : 0f;

        intensidadEfectoActual = Mathf.Lerp(intensidadEfectoActual, targetIntensidad, Time.deltaTime * suavizadoEfecto);

        speedLinesMaterial.SetFloat("_Intensity", intensidadEfectoActual);

        camara.GetComponent<Camera>().fieldOfView = Mathf.Lerp(normalFOV, speedFOV, intensidadEfectoActual);
    }

    public void SetDeadZoneJoystick(float deadzone)
    {
        joystick.DeadZone = deadzone;
    }
    private void Condicionales()
    {
        if (resbalon)
        {
            float vueltas = 3 * 360;
            transform.Rotate(0, vueltas * Time.deltaTime, 0);
        }
        else
        {
            Velocidad_Particula();
        }
        if (choque)
        {
            Vector3 punto_retroceder = (transform.position - punto_choque.point);
            punto_retroceder.y = 0;
            punto_retroceder = punto_retroceder.normalized;
            rigid.AddForce(punto_retroceder * 100f, ForceMode.Impulse);
            /*Vector3 punto_retroceder = (transform.position - punto_choque.point).normalized;
            rigid.AddForce(punto_retroceder * 100, ForceMode.Impulse);
            //Hacer animacion de caida en la couritina*/

        }
        if (transform.position.y < -1) transform.position = position_Reset;
    }


    //Power UP

    private void Power_Respective()
    {
        switch (PU)
        {
            case Repartir_power.Power_Up.VELOCIDAD:
                Add_Velocidad();
                break;
            case Repartir_power.Power_Up.PROTECCION:
                proteccion_visual.SetActive(true);
                break;
            case Repartir_power.Power_Up.MANOS_RAPIDAS:
                tiempoEliminar = Efecto.Get_Efecto<float>();
                Eliminar_Tiempo_Dejar_Objetos();
                break;
            case Repartir_power.Power_Up.NINGUNO: break;
        }
    }

    public bool Esta_Protegido()
    {

        float velocidad = Velocidad_joystick();
        choque_mayor = velocidad >= resistencia_porcentual;
        bool retorno = PU == Repartir_power.Power_Up.PROTECCION;

        if (retorno && (choque_mayor || resbalon))
        {
            ConsumirProteccion();
            return true;
        }
        else if (carrito.objetos_actuales == 0) return true;
        else if (choque_mayor || resbalon)
        {
            Debug.Log($"El jugador choco sin control");
            return false;
        }

        return true;
    }

    private void ConsumirProteccion()
    {
        if (!choque_mayor)
            return;
        if (Efecto == null || carrito.objetos_actuales == 0)
            return;
        if (RP.Get_Power_Up() != Repartir_power.Power_Up.PROTECCION)
            return;
        
        Efecto.Efecto();
        RP.Set_Enum(Repartir_power.Power_Up.NINGUNO);
        Efecto = null;
        proteccion_visual.SetActive(false);
        PU = Repartir_power.Power_Up.NINGUNO;
        Debug.Log($"Se protegio la caida de objetos");
        
    }

    //Movimiento

    private void Add_Velocidad()
    {
        speed *= Efecto.Get_Efecto<float>();
        max_speed_H *= Efecto.Get_Efecto<float>();
        max_speed_V *= Efecto.Get_Efecto<float>();
        //Efecto = null;
    }

    private void Eliminar_Tiempo_Dejar_Objetos()
    {
        float eliminar = Tiempo_Dejar_Objeto * tiempoEliminar;//Efecto.Get_Efecto<float>();
        Tiempo_Dejar_Objeto -= eliminar;
        Efecto = null;
    }
    private void Mover_Player()
    {
        if (choque || resbalon) return;

        Vertical_Move = joystick.Vertical * max_speed_V;
        Horizontal_Move = joystick.Horizontal * max_speed_H;

        Vector3 Movimiento = new Vector3(Horizontal_Move, 0, Vertical_Move).normalized;
        Vector3 obtener_velocidad = new Vector3(Horizontal_Move, 0, Vertical_Move) * speed;

        //rigid.MovePosition(rigid.position + obtener_velocidad * Time.fixedDeltaTime);
        rigid.linearVelocity = new Vector3(obtener_velocidad.x, rigid.linearVelocity.y, obtener_velocidad.z);

        animacion.SetFloat("VelX", Horizontal_Move);
        animacion.SetFloat("VelY", Vertical_Move);

        if (Movimiento.magnitude >= 0.1f)
        {
            float angle = Mathf.Atan2(Movimiento.x, Movimiento.z) * Mathf.Rad2Deg;
            Quaternion rotate = Quaternion.Euler(0, angle, 0);
            player_object.transform.rotation = Quaternion.Slerp(
                player_object.transform.rotation,
                rotate,
                speed * Time.fixedDeltaTime
            );
        }
    }
    private void Camera_Move()
    {
        camara.transform.position = transform.position + position_camera;
    }

    private void Velocidad_Particula()
    {
        //iniciar particulas al tomar cosas pasar cosas y ganar cosas
        float velocidad = MathF.Max(MathF.Abs(joystick.Vertical), MathF.Abs(joystick.Horizontal)) * speed;
        int cant_particulas = UnityEngine.Random.Range(2,4);

        foreach (ParticleSystem particula in particulas)
        {
            ParticleSystem.MainModule parmain = particula.main;
            if(velocidad != 0)
            {
                parmain.maxParticles = cant_particulas;
            }
            else
            {
                parmain.maxParticles = 0;
            }
        }
    }

    private void Particula_Detener()
    {
        foreach (ParticleSystem particula in particulas)
        {
            ParticleSystem.MainModule parmain = particula.main;
            parmain.maxParticles = 0;
        }
    }

    private void NO_INICIAR_PARTICULAS()
    {
        Choque_P.Stop();
        Exclamacion.Stop();
    }

    //Inicio
    public void Init(CarRuntime carro)
    {
        rigid.mass +=               carro.Peso;
        speed +=                        carro.VelocidadAdicional;
        max_speed_H +=                  carro.VelocidadAdicional;
        max_speed_V +=                  carro.VelocidadAdicional;
        resistencia_porcentual = (float)carro.Blindaje / 100;
        carrito = carro;
    }

    private void New_Init()
    {
        float velocidad = PU == Repartir_power.Power_Up.VELOCIDAD ?  Efecto.Get_Efecto<float>() : 1;
        speed       = velocidad + carrito.VelocidadAdicional;
        max_speed_H = velocidad + carrito.VelocidadAdicional;
        max_speed_V = velocidad + carrito.VelocidadAdicional;
    }

    private void Set_Rigs(float valor)
    {
        foreach(Rig rig in rigs)
        {
            rig.weight = valor;
        }
    }

    private IEnumerator Resbalon(Vector3 direccion, float velocidadInicial)
    {
        resbalon = true;
        joystick.gameObject.SetActive(false);

        direccion = direccion.normalized;
        velocidadResbalon = velocidadInicial;

        while (velocidadResbalon > 0.1f && resbalon)
        {
            rigid.MovePosition(rigid.position + direccion * velocidadResbalon * Time.fixedDeltaTime);
            velocidadResbalon -= carrito.Agarre * Time.fixedDeltaTime; // frenado lineal por fricción
            yield return new WaitForFixedUpdate();
        }

        yield return new WaitForSeconds(0.5f);
        resbalon = false;
        joystick.gameObject.SetActive(true);
    }

    private IEnumerator Animacion_Tiempo_Caja(Caja caja)
    {
        estaEnCaja = true;
        Set_Rigs(0);
        //Animacion colocar objetos
        joystick.DeadZone = 1000;
        yield return StartCoroutine(caja.HacerObjetosCajaVisible(Tiempo_Dejar_Objeto, mision));
        Set_Rigs(1);
        joystick.DeadZone = 0;
        mision.Espacio_Disponible.text = carrito.objetos_actuales.ToString() + "/" +  carrito.Capacidad.ToString();
        estaEnCaja = false;
    }

    IEnumerator Retroceder(Collision collision)
    {
        Set_Rigs(0);
        //Animacion caida
        joystick.DeadZone = 1000;
        punto_choque = collision.contacts[0];
        rigid.linearVelocity = Vector3.zero;
        choque = true;
        yield return new WaitForSeconds(1);
        //Animacion levantarse
        rigid.linearVelocity = Vector3.zero;
        Set_Rigs(1);
        joystick.DeadZone = 0;
        choque = false;
        choque_mayor = false;
    }

    private IEnumerator Bloquear_Movimiento_Breve()
    {
        choque = true;
        joystick.DeadZone = 1000;
        rigid.linearVelocity = Vector3.zero;  // frena en seco
        yield return new WaitForSeconds(0.2f);
        choque = false;
        joystick.DeadZone = 0;
    }

    public CarRuntime Get_Carro()
    {
        return carrito;
    }

    public Transform Get_transform_carro()
    {
        foreach (Transform hijo in transform)
        {
            switch (hijo.name)
            {
                case "Carrito_Peq":
                case "Carrito_med":
                case "Carrito_gra":
                    if (hijo.gameObject.activeInHierarchy)
                    {
                        return hijo;
                    }
                    break;
            }
        }
        return null;
    }

    private float Velocidad_joystick()
    {
        Vector2 velocidad_joystick = new(joystick.Horizontal, joystick.Vertical);
        float velocidad_porcentual = velocidad_joystick.magnitude; // Va de 0 a ~1.41 (diagonal máxima)

        // Normalizar para que vaya de 0 a 1
        velocidad_porcentual = Mathf.Clamp01(velocidad_porcentual);
        return velocidad_porcentual;
    }

    private void ProcesarObjetoEncontrado(string nombreObjeto, Vector3 posicion, Action<string, Vector3> iniciarAnimacion)
    {
        //if (!mision.Verificar_Objeto_este_mision(nombreObjeto))
            //return;
        //SetDeadZoneJoystick(1000);
        iniciarAnimacion(nombreObjeto, posicion);
    }

    private Coroutine corutinaRuleta;
    IEnumerator AnimacionRuleta(Objeto_random_carro carro, string nombreObjeto, Vector3 posicion)
    {
        if (carro is null) yield break;
        SetDeadZoneJoystick(10000);
        obtener_Objeto_carro.gameObject.SetActive(false);

        yield return carro.AnimacionUI(mision.Verificar_Objeto_este_mision(nombreObjeto)); // sin StartCoroutine
        yield return new WaitForSeconds(0.5f);
        yield return mision.AnimacionTomarObjeto(nombreObjeto, posicion); // sin StartCoroutine

        obtener_Objeto_carro.gameObject.SetActive(true);
        corutinaRuleta = null;
        SetDeadZoneJoystick(0);
    }

    //Collisiones
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Estante") && (!resbalon && !choque))
        {
            var estante = other.gameObject.GetComponent<Estante>();
            ProcesarObjetoEncontrado(estante.Get_Object(), other.transform.position,
                (nombre, pos) => StartCoroutine(mision.AnimacionTomarObjeto(nombre, pos)));
        }
        else if (other.CompareTag("Carro") && (!resbalon && !choque))
        {
            obtener_Objeto_carro.gameObject.SetActive(true);
            se_tomo_objeto_carro = other.gameObject.GetComponent<Objeto_random_carro>();
        }
        else if (other.CompareTag("Objeto") && (!resbalon && !choque))
        {
            se_tomo_objeto_suelo = other.gameObject.GetComponent<Objeto_caido>();
            objetosEnRango.Add(se_tomo_objeto_suelo);
            obtener_Objeto_suelo.gameObject.SetActive(true);
        }
        else if (other.CompareTag("Caja") && (!resbalon && !choque))
        {
            Caja caja = other.gameObject.GetComponent<Caja>();
            StartCoroutine(Animacion_Tiempo_Caja(caja));
        }
        else if (other.CompareTag("Mojado") && !resbalon)
        {
            Exclamacion.Play();
            Particula_Detener();
            Vector3 velocidadHorizontal = new(rigid.linearVelocity.x, rigid.linearVelocity.y, rigid.linearVelocity.z);
            Vector3 direccion = velocidadHorizontal.sqrMagnitude > 0.01f
                ? velocidadHorizontal.normalized
                : transform.forward;
            float velocidadInicial = velocidadHorizontal.magnitude;
            StartCoroutine(Resbalon(direccion, velocidadInicial));
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Piso") && !collision.gameObject.CompareTag("Caja"))
        {
            //StopCoroutine(Resbalon(transform.forward, 0f));
            resbalon = false;
            joystick.gameObject.SetActive(true);

            if (estaEnCaja)
                return;

            Exclamacion.Play();

            velocidad_porcentual = Velocidad_joystick();

            if (velocidad_porcentual > 0.10f)
            {
                Choque_P.Play();
                Choque_sound.Play();
                StartCoroutine(Retroceder(collision));
            }
            else
            {
                StartCoroutine(Bloquear_Movimiento_Breve());
            }

            if (max_speed_H <= 0 || max_speed_V <= 0)
                New_Init();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Estante"))
        {
            //New_Init();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Objeto"))
        {
            objetosEnRango.Remove(other.GetComponent<Objeto_caido>());
            ActualizarBoton();
        }
        else if (other.CompareTag("Carro"))
        {
            if (corutinaRuleta != null)
            {
                StopCoroutine(corutinaRuleta);
                corutinaRuleta = null;
            }
            se_tomo_objeto_carro?.CancelarAnimacionUI(); // método nuevo que tú agregas
            SetDeadZoneJoystick(0);
            se_tomo_objeto_carro = null;
            obtener_Objeto_carro.gameObject.SetActive(false);
        }
    }

    public void AnimarSlider(float distanciaJugadoYRatero, float distanciaSegura)
    {
        sliderDistanciaRatero.value = distanciaJugadoYRatero / distanciaSegura;
    }

    public void ActivarSlider() => sliderDistanciaRatero.gameObject.SetActive(true);
    public void DesactivarSlider() => sliderDistanciaRatero.gameObject.SetActive(false);

    public Vector3 GetSpawnPlayer() => position_Reset;

    //Boton de tomar objeto
    private void ManejarObjetoDestruido(Objeto_caido obj)
    {
        if (!objetosEnRango.Remove(obj)) return;

        if (se_tomo_objeto_suelo != null && se_tomo_objeto_suelo.gameObject == obj)
            se_tomo_objeto_suelo = null;

        ActualizarBoton();
    }

    private void ActualizarBoton()
    {
        obtener_Objeto_suelo.gameObject.SetActive(objetosEnRango.Count > 0);

        if (objetosEnRango.Count > 0 && se_tomo_objeto_suelo == null)
        {
            foreach (var obj in objetosEnRango)
            {
                se_tomo_objeto_suelo = obj;
                break;
            }
        }
    }

    //Botones

    //Botones->Perder
    public void Perder()
    {
        Anuncios.Instancia.MostrarAnuncioIntersticial(() => SceneManager.LoadScene(0));
    }


    //Botones->Reiniciar

    public void Reinicio()
    {
        Anuncios.Instancia.MostrarAnuncioIntersticial( () => 
        { 
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });
    }


    //Botones->Ganar

    public void Gano()
    {
        joystick.DeadZone = 1000;
        UI.SetActive(false);
        Ganar_canvas.SetActive(true);
        FindFirstObjectByType<Tiempo>().gano = true;

        for (int i = 5; i < 8; i++)
        {
            ParticleSystem.EmissionModule emission = Ganar_canvas.transform.GetChild(i).GetComponent<ParticleSystem>().emission;
            emission.enabled = true;
        }
        for (int i = 5; i < 7; i++)
        {
            Ganar_canvas.transform.GetChild(i).GetComponent<ParticleSystem>().Play();
        }

            Dinero_Obtenido DO = BuildStructs.Dinero_Obtenido;
            Dinero_Text.text = $"{DO.Get_Dinero()}"; 
    }
    public void BTN_Ganar()
    {
        GameObject Boton_Presiono = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        Dinero_Obtenido DO = BuildStructs.Dinero_Obtenido;
        DO.Get_Mapa(SceneManager.GetActiveScene().name).cantidad_juegos++;
        Nivel.Set_Nivel(Nivel.nivel + 1);
        PlayerPrefs.SetString("Nivel", Nivel.nivel.ToString()); 
        PlayerPrefs.Save();
        Debug.Log($"Nuevo nivel {Nivel.nivel}");

        if (Boton_Presiono.name != "X2")
        {
            Anuncios.Instancia.AumentarConteoPartidas(() =>
            {
                DO.Recompensa();
            });
        }
        else
            Anuncios.Instancia.MostrarAnuncioRecompensa((bool exito) =>
            {
                if (!exito)
                {
                    Debug.Log("El jugador no completo su anuncio");
                    Notificacion.MostrarAlertaNativa(new NotificacionInformacionStruct(
                    "Aviso", "No se pudo otorgar la recompensa. Asegúrate de ver el video completo.",
                    "Notice", "Could not grant reward. Make sure to watch the full video.",
                    "Aviso", "Não foi possível conceder a recompensa. Certifique-se de assistir ao vídeo completo."
                    ));
                    
                    DO.Recompensa();
                    return;
                }
                DO.Recompensa_X2();
            });
        
    }

    private void BTN_Agarrar_Objeto_Suelo()
    {
        if (se_tomo_objeto_suelo == null || !se_tomo_objeto_suelo.gameObject.activeSelf)
        {
            obtener_Objeto_suelo.gameObject.SetActive(false);
            return;
        }

        StartCoroutine(mision.AnimacionTomarObjeto(se_tomo_objeto_suelo.name, se_tomo_objeto_suelo.transform.position));

        obtener_Objeto_suelo.gameObject.SetActive(false);
        Destroy(se_tomo_objeto_suelo.gameObject, 1);
    }


    private void BTN_Agarrar_Objeto_Carro()
    {
        ProcesarObjetoEncontrado(se_tomo_objeto_carro.Get_Object(), se_tomo_objeto_carro.transform.position,
            (nombre, pos) => corutinaRuleta = StartCoroutine(AnimacionRuleta(se_tomo_objeto_carro, nombre, pos)));
    }
}
