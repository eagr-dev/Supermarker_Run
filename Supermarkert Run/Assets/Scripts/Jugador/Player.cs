using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Animations.Rigging;

public class Player : MonoBehaviour
{
    [Header("Joystick_Velocidad")]
    [SerializeField]private float max_speed_H = 1, max_speed_V = 1, Vertical_Move = 0, Horizontal_Move = 0, speed = 1, resistencia_porcentual = 0,velocidad_porcentual = 0;
    //Vector3 obtener_velocidad;
    public Joystick joystick;

    [Header("Camara")]
    [SerializeField]private GameObject player_object;
    [SerializeField]private new GameObject camera;
    Vector3 position_camera = new Vector3(0,7,-10);

    [Header("Otros")]
    public Vector3 position_Reset;
    //private Get_Content_Car carrito_contenido;
    private new Rigidbody rigidbody;

    [Header("Carro")]
    private ContactPoint punto_choque;
    [SerializeField] private Rig[] rigs = new Rig[3];
    private bool resbalon = false;
    private bool choque = false;
    private Car carrito;

    [Header("Mision_Caja")]
    private Mision mision;
    [SerializeField] private GameObject Muerte_canvas;
    [SerializeField] private GameObject Ganar_canvas;
    [SerializeField] private Animator animacion;
    [SerializeField] private TMP_Text Dinero_Text;
    [SerializeField] private GameObject Imagen_DejarObjetos;
    private float Tiempo_Dejar_Objeto = 1;

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
        mision = FindObjectOfType<Mision>();  
        rigidbody = GetComponent<Rigidbody>();
        if (FindObjectOfType<Repartir_power>() != null)
        {
            RP = FindObjectOfType<Repartir_power>();
            Efecto = RP.Get_Power_Up_Class();
            PU = RP.Get_Power_Up();
        }
        Power_Respective();
    }

    private void Start()
    {
        for (int i = 4; i < 7; i++)
        {
            ParticleSystem.EmissionModule emission = Ganar_canvas.transform.GetChild(i).GetComponent<ParticleSystem>().emission;
            emission.enabled = false;
        }
        NO_INICIAR_PARTICULAS();
        carrito = Get_Carro();
        //Init();

    }

    void Update()
    {
        Move_Player();
        Camera_Move();
        Condicionales();
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
            rigidbody.AddForce(punto_retroceder * 100, ForceMode.Impulse);
            //Hacer animacion de caida en la couritina
        }
        if (transform.position.y < 0) transform.position = position_Reset;
    }


    //Power UP

    private void  Power_Respective()
    {
        switch(PU)
        {
            case Repartir_power.Power_Up.VIDA: break;
            case Repartir_power.Power_Up.VELOCIDAD:
                speed *= Efecto.Get_Efecto<float>();
                max_speed_H *= Efecto.Get_Efecto<float>();
                max_speed_V *= Efecto.Get_Efecto<float>();
                Efecto = null;
                break;
            case Repartir_power.Power_Up.PROTECCION: break;
            case Repartir_power.Power_Up.MANOS_RAPIDAS:
                float eliminar = Tiempo_Dejar_Objeto * Efecto.Get_Efecto<float>();
                Tiempo_Dejar_Objeto -= eliminar;
                Efecto = null;
                break;
            case Repartir_power.Power_Up.NINGUNO: break;
        }
    }

    //Movimiento
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
        camera.transform.position = transform.position + position_camera;
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
        rigidbody.mass +=               carro.peso;
        speed +=                        carro.velocidad_adicional;
        max_speed_H +=                  carro.velocidad_adicional;
        max_speed_V +=                  carro.velocidad_adicional;
        resistencia_porcentual = (float)carro.resistencia_choque / 100;
        carrito = carro;
    }

    private void New_Init()
    {
        speed       = 1 + carrito.velocidad_adicional;
        max_speed_H = 1 + carrito.velocidad_adicional;
        max_speed_V = 1 + carrito.velocidad_adicional;
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
        float x = max_speed_H, y = max_speed_V;
        resbalon = true;
        joystick.gameObject.SetActive(false);
        //rigidbody.AddForce(transform.forward * 5, ForceMode.VelocityChange);
        yield return new WaitForSeconds(1);
        max_speed_H = 0;
        max_speed_V = 0;
        joystick.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        max_speed_H = x;
        max_speed_V = y;
        resbalon = false;
    }

    private IEnumerator Animacion_Tiempo_Caja(float tiempo_total)
    {
        Set_Rigs(0);
        //Animacion colocar objetos
        //float x = max_speed_H, y = max_speed_V;
        //max_speed_H = 0;
        //max_speed_V = 0;
        joystick.DeadZone = 1000;
        yield return new WaitForSeconds(tiempo_total + 0.5f);
        //max_speed_H = x;
        //max_speed_V = y;
        Set_Rigs(1);
        joystick.DeadZone = 0;
        mision.Espacio_Disponible.text = carrito.objetos_actuales.ToString() + " / " +  carrito.cant_limite_carga.ToString();
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
    }
    
    private void Choque_Mortal()
    {
        joystick.DeadZone = 1000;
        Set_Rigs(0);
        //Animacion caida
    }

    /*public Car Get_Carro(Transform padre)
    {
        Car carrito_principal = null;
        string URL_IDIOMA = "";
        foreach (Transform hijo in padre)
        {
            switch (hijo.name)
            {
                case "Carrito_Peq":
                case "Carrito_med":
                case "Carrito_gra":
                    if (hijo.gameObject.activeInHierarchy)
                    {
#if UNITY_EDITOR
                        URL_IDIOMA = Application.dataPath + "/SUPERMARKER/player_log.txt";
#else
        URL_IDIOMA = "/storage/emulated/0/Documents/SUPERMARKER/player_log.txt";
#endif
                        Velocidad_Operacion_T.text = (speed + hijo.GetComponent<Get_Content_Car>().Get_Car().velocidad_adicional).ToString();
                        string contenido = "nombre: " + hijo.GetComponent<Get_Content_Car>().Get_Car().nombre + "\nVelocidad total: " + (speed + hijo.GetComponent<Get_Content_Car>().Get_Car().velocidad_adicional).ToString() + "\ninstancia: " + hijo.GetComponent<Get_Content_Car>().Get_Car().GetInstanceID().ToString();
                        File.WriteAllText(URL_IDIOMA,contenido);
                        get_carrito = hijo.GetComponent<Get_Content_Car>();
                        carrito_principal = hijo.GetComponent<Get_Content_Car>().Get_Car();
                    }
                    break;
            }
        }
        return carrito_principal;
    }*/

    public Car Get_Carro()
    {
        Car carro = null;
        foreach (Transform hijo in transform)
        {
            switch (hijo.name)
            {
                case "Carrito_Peq":
                case "Carrito_med":
                case "Carrito_gra":
                    if (hijo.gameObject.activeInHierarchy)
                    {
                        carro = hijo.GetComponent<Get_Content_Car>().Get_Car();
                    }
                    break;
            }
        }
        return carro;
    }

    //Collisiones
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Estante"))
        {
           Estante estante = other.gameObject.GetComponent<Estante>();
           mision.New_Text_In_TextMesh(estante.Get_Object());
        }else if(other.CompareTag("Caja"))
        {
            Caja caja = other.gameObject.GetComponent<Caja>();
            StartCoroutine(Animacion_Tiempo_Caja(carrito.objetos_actuales * Tiempo_Dejar_Objeto));
            caja.Visible_Objects(mision.Cantidad_Nivel(), mision.Get_Position(),carrito, Tiempo_Dejar_Objeto,Imagen_DejarObjetos);
            //Gano(caja);
        }
        else if(other.CompareTag("Mojado"))
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
            //StopAllCoroutines();
            StopCoroutine(Resbalon());
            Exclamacion.Play();

            resbalon = false;
            joystick.gameObject.SetActive(true);
            velocidad_porcentual = Mathf.Abs(Mathf.Max(joystick.Horizontal, joystick.Vertical));

            Choque_P.Play();
            Choque_sound.Play();

            if (velocidad_porcentual > resistencia_porcentual)
            {
                if (Efecto != null)
                {
                    StartCoroutine(Retroceder(collision));
                    Efecto.Efecto();
                    PU = RP.Get_Power_Up();
                    if (PU == Repartir_power.Power_Up.NINGUNO)
                        Efecto = null;
                }
                else
                {
                    speed = 0;
                    Muerte_canvas.GetComponent<Transform>().GetChild(3).gameObject.SetActive(true);
                    Muerte_canvas.SetActive(true);
                    Choque_Mortal();
                    return;
                }

            }
            else if(velocidad_porcentual > (resistencia_porcentual * 0.20f))
            {
                StartCoroutine(Retroceder(collision));
            }
            if(max_speed_H <= 0)
                New_Init();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Estante"))
        {
            New_Init();
        }
    }

    //Botones

    //Botones->Perder
    public void Perder()
    {
        SceneManager.LoadScene(0);
    }


    //Botones->Ganar

    public void Gano()
    {
            Ganar_canvas.SetActive(true);

        for (int i = 4; i < 7; i++)
        {
            ParticleSystem.EmissionModule emission = Ganar_canvas.transform.GetChild(i).GetComponent<ParticleSystem>().emission;
            emission.enabled = true;
        }
        for (int i = 4; i < 7; i++)
        {
            Ganar_canvas.transform.GetChild(i).GetComponent<ParticleSystem>().Play();
        }

            Dinero_Obtenido DO = FindObjectOfType<Dinero_Obtenido>();
            Dinero_Text.text = $"$ {DO.Get_Dinero()}"; 
    }
    public void BTN_Ganar()
    {
        GameObject Boton_Presiono = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        Dinero_Obtenido DO = FindObjectOfType<Dinero_Obtenido>();
        DO.Get_Mapa(SceneManager.GetActiveScene().name).cantidad_juegos++;
        Nivel.Set_Nivel(Nivel.nivel + 1);

        if (Boton_Presiono.name != "X2")
            DO.Recompensa();
        else
            DO.Recompensa_X2();
    }

}
