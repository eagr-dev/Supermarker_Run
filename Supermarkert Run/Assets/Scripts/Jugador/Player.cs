using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]private float max_speed_H = 1, max_speed_V = 1, Vertical_Move = 0, Horizontal_Move = 0, speed = 1, resistencia_porcentual = 0,velocidad_porcentual = 0;
    Vector3 obtener_velocidad;
    public Joystick joystick;
    [SerializeField]private GameObject player_object;
    [SerializeField]private new GameObject camera;
    Vector3 position_camera = new Vector3(0,7,-10);
    private Mision mision;
    private Get_Content_Car carrito_contenido;
    private Car carrito;
    private new Rigidbody rigidbody;
    private Interfaz_PowerUp Efecto;
    [SerializeField] private GameObject Muerte_canvas;
    [SerializeField] private GameObject Ganar_canvas;
    [SerializeField] private Animator animacion;
    
    private Repartir_power RP;
    private Repartir_power.Power_Up PU;

    private bool resbalon = false;

    private float Tiempo_Dejar_Objeto = 1;

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
        carrito_contenido = FindObjectOfType<Get_Content_Car>();
        carrito = carrito_contenido.GetComponent<Get_Content_Car>().Get_Car();
        Init();
    }

    void Update()
    {
        Move_Player();
        Camera_Move();
        if(resbalon)
        {
            float vueltas = 3 * 360;
            transform.Rotate(0, vueltas * Time.deltaTime, 0);
        }
    }


    //Power UP

    private void  Power_Respective()
    {
        switch(PU)
        {
            case Repartir_power.Power_Up.VIDA: Debug.Log("Vida"); break;
            case Repartir_power.Power_Up.VELOCIDAD:
                speed *= Efecto.Get_Efecto<float>();
                max_speed_H *= Efecto.Get_Efecto<float>();
                max_speed_V *= Efecto.Get_Efecto<float>();
                Efecto = null;
                Debug.Log("Velocidad");
                break;
            case Repartir_power.Power_Up.PROTECCION: Debug.Log("Proteccion"); break;
            case Repartir_power.Power_Up.MANOS_RAPIDAS:
                float eliminar = Tiempo_Dejar_Objeto * Efecto.Get_Efecto<float>();
                Tiempo_Dejar_Objeto -= eliminar;
                Efecto = null;
                Debug.Log("Manos rapidas");
                break;
            case Repartir_power.Power_Up.NINGUNO: Debug.Log("Ninguno"); break;
        }
    }

    //Movimiento
    private void Move_Player()
    {
        if(joystick != null)
        {
            Vertical_Move = joystick.Vertical * max_speed_V;
            Horizontal_Move = joystick.Horizontal * max_speed_H;
            Vector3 Movimiento = new Vector3(Horizontal_Move, 0, Vertical_Move).normalized;
            obtener_velocidad = new Vector3(Horizontal_Move, 0, Vertical_Move) * Time.deltaTime * speed;
            velocidad_porcentual = (obtener_velocidad.magnitude * 100) / speed;
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
    }

    private void Camera_Move()
    {
        if(camera != null)
        camera.transform.position = transform.position + position_camera;
    }

    //Inicio
    private void Init()
    {
        rigidbody.mass += carrito.peso;
        speed += carrito.velocidad_adicional;
        max_speed_H += carrito.velocidad_adicional;
        max_speed_V += carrito.velocidad_adicional;
        resistencia_porcentual = ((float)carrito.resistencia_choque / 100) * speed;
    }

    private void New_Init()
    {
        speed = 1 + carrito.velocidad_adicional;
        max_speed_H = 1 + carrito.velocidad_adicional;
        max_speed_V = 1 + carrito.velocidad_adicional;
    }

    //Otros
    private void Retroceso(float dis_retroceso, float velocidad, Collision collision)
    {
        Vector3 Retroceso = (transform.position - collision.transform.position).normalized;
        Retroceso.y = 0;
        Vector3 resultado_retroceso = transform.position + Retroceso * dis_retroceso;
        transform.position = Vector3.Lerp(transform.position, resultado_retroceso, velocidad * Time.deltaTime);
    }

    private IEnumerator Resbalon()
    {
        resbalon = true;
        joystick.gameObject.SetActive(false);
        rigidbody.AddForce(transform.forward * 5, ForceMode.VelocityChange);
        yield return new WaitForSeconds(1);
        rigidbody.velocity = Vector3.zero;
        joystick.gameObject.SetActive(true);
        resbalon = false;
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
            caja.Visible_Objects(mision.Cantidad_Nivel(), mision.Get_Position(),carrito, Tiempo_Dejar_Objeto);
            Ganador(caja);
        }else if(other.CompareTag("Mojado"))
        {
            StartCoroutine(Resbalon());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!collision.gameObject.CompareTag("Piso") && !collision.gameObject.CompareTag("Caja"))
        {
            if (velocidad_porcentual >= resistencia_porcentual)
            {
                Debug.Log($"{velocidad_porcentual}\n{resistencia_porcentual}");
                if (Efecto != null)
                {
                    Debug.Log("Usar efecto");
                    Efecto.Efecto();
                    if (PU == Repartir_power.Power_Up.NINGUNO)
                        Efecto = null;
                }
                else
                {
                    speed = 0;
                    Muerte_canvas.SetActive(true);
                    Retroceso(20, speed, collision);
                    StopAllCoroutines();
                    return;
                }

            }
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

    private void Ganador(Caja caja)
    {
        Ganar_canvas.SetActive(caja.Get_Porcentaje() == 10);
        FindObjectOfType<Dinero_Obtenido>().Get_Mapa(SceneManager.GetActiveScene().name).cantidad_juegos++;
        FindObjectOfType<Nivel>().nivel++;
    }

}
