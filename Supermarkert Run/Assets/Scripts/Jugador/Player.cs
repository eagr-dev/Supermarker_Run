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
    [SerializeField] private float max_speed_H = 1, max_speed_V = 1, Vertical_Move = 0, Horizontal_Move = 0, speed = 1, resistencia_porcentual = 0, velocidad_porcentual = 0;
    //Vector3 obtener_velocidad;
    [SerializeField] private Joystick joystick;

    [Header("Camara")]
    [SerializeField] private GameObject player_object;
    [SerializeField] private GameObject camara;
    Vector3 position_camera = new(0, 7, -10);

    [Header("Otros")]
    public Vector3 position_Reset;
    //private Get_Content_Car carrito_contenido;
    private Rigidbody rigid;

    [Header("Carro")]
    private ContactPoint punto_choque;
    [SerializeField] private Rig[] rigs = new Rig[3];
    private bool resbalon = false;
    private bool choque = false;
    private bool choque_mayor = false;
    private Car carrito;

    [Header("Mision_Caja")]
    private Mision mision;
    [SerializeField] private GameObject Muerte_canvas;
    [SerializeField] private GameObject Ganar_canvas;
    [SerializeField] private Animator animacion;
    [SerializeField] private TMP_Text Dinero_Text;
    private float Tiempo_Dejar_Objeto = 1;
    [SerializeField] private Button obtener_Objeto_suelo;
    private Objeto_caido se_tomo_objeto;

    [Header("Particulas")]
    [SerializeField] private List<ParticleSystem> particulas;
    [SerializeField] private ParticleSystem Choque_P, Exclamacion;

    [Header("Power_UP")]
    private Repartir_power RP;
    private Repartir_power.Power_Up PU;
    private Interfaz_PowerUp Efecto;

    [Header("Sonido")]
    [SerializeField] private AudioSource Choque_sound;

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
        obtener_Objeto_suelo.onClick.AddListener(BTN_Agarrar_Objeto);
    }

    private void Start()
    {
        for (int i = 5; i < 8; i++)
        {
            ParticleSystem.EmissionModule emission = Ganar_canvas.transform.GetChild(i).GetComponent<ParticleSystem>().emission;
            emission.enabled = false;
        }
        NO_INICIAR_PARTICULAS();
        carrito = Get_Carro();
    }

    void Update()
    {
        Move_Player();
        Camera_Move();
        Condicionales();
        mision.posicion_carro = Get_transform_carro().position;
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
            Vector3 punto_retroceder = (transform.position - punto_choque.point).normalized;
            rigid.AddForce(punto_retroceder * 100, ForceMode.Impulse);
            //Hacer animacion de caida en la couritina
        }
        if (transform.position.y < 0) transform.position = position_Reset;
    }


    //Power UP

    private void Power_Respective()
    {
        switch (PU)
        {
            case Repartir_power.Power_Up.VELOCIDAD:
                Add_Velocidad();
                break;
            case Repartir_power.Power_Up.PROTECCION: break;
            case Repartir_power.Power_Up.MANOS_RAPIDAS:
                Eliminar_Tiempo_Dejar_Objetos();
                break;
            case Repartir_power.Power_Up.NINGUNO: break;
        }
    }

    public bool Esta_Protegido()
    {

        float velocidad = Velocidad_joystick();

        choque_mayor = velocidad > resistencia_porcentual;

        if (!choque_mayor)
        {
            Debug.Log($"El jugador no a chocado {velocidad}");
            return true;
        }

        if (Efecto == null)
            return false;

        bool retorno = PU == Repartir_power.Power_Up.PROTECCION;
        if(retorno)
            ConsumirProteccion();
        return retorno;
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
        float eliminar = Tiempo_Dejar_Objeto * Efecto.Get_Efecto<float>();
        Tiempo_Dejar_Objeto -= eliminar;
        Efecto = null;
    }

    private void Move_Player()
    {
        Vertical_Move = joystick.Vertical * max_speed_V;
        Horizontal_Move = joystick.Horizontal * max_speed_H;
        Vector3 Movimiento = new Vector3(Horizontal_Move, 0, Vertical_Move).normalized;
        //obtener_velocidad = new Vector3(Horizontal_Move, 0, Vertical_Move) * Time.deltaTime * speed;
        transform.position += new Vector3(Horizontal_Move, 0, Vertical_Move) * Time.deltaTime * speed;

        animacion.SetFloat("VelX", Horizontal_Move);
        animacion.SetFloat("VelY", Vertical_Move);

        if (Movimiento.magnitude >= 1)
        {
            float angle = Mathf.Atan2(Movimiento.x, Movimiento.z) * Mathf.Rad2Deg;
            Quaternion rotate = Quaternion.Euler(0, angle, 0);
            player_object.transform.rotation = Quaternion.Slerp(player_object.transform.rotation, rotate, speed * Time.deltaTime);
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
    public void Init(Car carro)
    {
        rigid.mass +=               carro.peso;
        speed +=                        carro.velocidad_adicional;
        max_speed_H +=                  carro.velocidad_adicional;
        max_speed_V +=                  carro.velocidad_adicional;
        resistencia_porcentual = (float)carro.resistencia_choque / 100;
        carrito = carro;
    }

    private void New_Init()
    {
        float velocidad = PU == Repartir_power.Power_Up.VELOCIDAD ?  Efecto.Get_Efecto<float>() : 1;
        speed       = velocidad + carrito.velocidad_adicional;
        max_speed_H = velocidad + carrito.velocidad_adicional;
        max_speed_V = velocidad + carrito.velocidad_adicional;
    }

    private void Set_Rigs(float valor)
    {
        foreach(Rig rig in rigs)
        {
            rig.weight = valor;
        }
    }

    private IEnumerator Resbalon()
    {
        resbalon = true;
        joystick.gameObject.SetActive(false);
        yield return new WaitForSeconds(1);
        joystick.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        resbalon = false;

    }

    private IEnumerator Animacion_Tiempo_Caja(Caja caja)
    {
        Set_Rigs(0);
        //Animacion colocar objetos
        joystick.DeadZone = 1000;
        yield return StartCoroutine(caja.HacerObjetosCajaVisible(Tiempo_Dejar_Objeto, mision));
        //yield return new WaitForSeconds(tiempo_total + 0.5f);
        Set_Rigs(1);
        joystick.DeadZone = 0;
        mision.Espacio_Disponible.text = carrito.objetos_actuales.ToString() + "/" +  carrito.cant_limite_carga.ToString();
    }

    IEnumerator Retroceder(Collision collision)
    {
        Set_Rigs(0);
        //Animacion caida
        joystick.DeadZone = 1000;
        punto_choque = collision.contacts[0];
        choque = true;
        yield return new WaitForSeconds(1);
        //Animacion levantarse
        Set_Rigs(1);
        joystick.DeadZone = 0;
        choque = false;
        choque_mayor = false;
    }

    public Car Get_Carro()
    {
        Car carro = null;
        Transform hijo = Get_transform_carro();
        carro = hijo.GetComponent<Get_Content_Car>().Get_Car();
        return carro;
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

    //Collisiones
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Estante") || other.CompareTag("Carro"))
        {
            var estante = other.gameObject.GetComponent<IGuardarObjeto>();
            if (!mision.Verificar_Objeto_este_mision(estante.Get_Object()))
                return;
            StartCoroutine(mision.AnimacionTomarObjeto(estante.Get_Object(), other.transform.position));
        }
        else if (other.CompareTag("Objeto"))
        {
            obtener_Objeto_suelo.gameObject.SetActive(true);
            se_tomo_objeto = other.gameObject.GetComponent<Objeto_caido>();
        }
        else if (other.CompareTag("Caja"))
        {
            Caja caja = other.gameObject.GetComponent<Caja>();
            StartCoroutine(Animacion_Tiempo_Caja(caja));
            //mision.Volver_Objetos_Caja();
            //Gano(caja);
        }
        else if (other.CompareTag("Mojado"))
        {
            Exclamacion.Play();
            Particula_Detener();
            StartCoroutine(Resbalon());
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Piso") && !collision.gameObject.CompareTag("Caja"))
        {
            StopCoroutine(Resbalon());
            Exclamacion.Play();

            resbalon = false;
            joystick.gameObject.SetActive(true);

            velocidad_porcentual = Velocidad_joystick();

            if (velocidad_porcentual > 0.10f)
            {
                Choque_P.Play();
                Choque_sound.Play();
                StartCoroutine(Retroceder(collision));
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
            obtener_Objeto_suelo.gameObject.SetActive(false);
        }
    }

    //Botones

    //Botones->Perder
    public void Perder()
    {
        SceneManager.LoadScene(0);
    }


    //Botones->Reiniciar

    public void Reinicio()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    //Botones->Ganar

    public void Gano()
    {
        joystick.DeadZone = 1000;
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

            Dinero_Obtenido DO = FindFirstObjectByType<Dinero_Obtenido>();
            Dinero_Text.text = $"$ {DO.Get_Dinero()}"; 
    }
    public void BTN_Ganar()
    {
        GameObject Boton_Presiono = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        Dinero_Obtenido DO = FindFirstObjectByType<Dinero_Obtenido>();
        DO.Get_Mapa(SceneManager.GetActiveScene().name).cantidad_juegos++;
        Nivel.Set_Nivel(Nivel.nivel + 1); // primero actualiza
        Debug.Log($"Nuevo nivel {Nivel.nivel}");

        if (Boton_Presiono.name != "X2")
            DO.Recompensa();
        else
            DO.Recompensa_X2();
    }

    private void BTN_Agarrar_Objeto()
    {
        if (se_tomo_objeto == null || !se_tomo_objeto.gameObject.activeSelf)
        {
            obtener_Objeto_suelo.gameObject.SetActive(false);
            return;
        }

        if(mision.Verificar_Objeto_este_mision(se_tomo_objeto.name))
            StartCoroutine(mision.AnimacionTomarObjeto(se_tomo_objeto.name, se_tomo_objeto.transform.position));

        obtener_Objeto_suelo.gameObject.SetActive(false);
        Destroy(se_tomo_objeto.gameObject, 1);
    }

}
