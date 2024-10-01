using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]private float max_speed_H = 1, max_speed_V = 1, Vertical_Move = 0, Horizontal_Move = 0, speed = 1, resistencia_porcentual = 0,velocidad_porcentual = 0;
    Vector3 obtener_velocidad;
    public Joystick joystick;
    [SerializeField]private GameObject player_object;
    [SerializeField]private new GameObject camera;
    Vector3 position_camera = new Vector3(0,4,-7);
    private Mision mision;
    private Get_Content_Car carrito_contenido;
    private Car carrito;
    private new Rigidbody rigidbody;
    private Interfaz_PowerUp Efecto;
    [SerializeField] private GameObject Muerte_canvas;
    [SerializeField] private GameObject Ganar_canvas;


    private void Awake()
    {
        mision = FindObjectOfType<Mision>();  
        rigidbody = GetComponent<Rigidbody>();
        if (FindObjectOfType<Repartir_power>().Get_Power_Up() != null)
        {
            Efecto = FindObjectOfType<Repartir_power>().Get_Power_Up();
            Debug.Log("Poder");
        }
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

        if(Efecto != null)
        {
            if (Efecto.Get_Efecto() is float)
            {
                Efecto.Efecto(speed);
                speed = (float)Efecto.Get_Efecto();
                max_speed_H = (float)Efecto.Get_Efecto();
                max_speed_V = (float)Efecto.Get_Efecto();
            }
        }
    }

    private void New_Init()
    {
        speed = 1 + carrito.velocidad_adicional;
        max_speed_H = 1 + carrito.velocidad_adicional;
        max_speed_V = 1 + carrito.velocidad_adicional;
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

            caja.Visible_Objects(mision.Cantidad_Nivel(), mision.Get_Position());
            Ganador(caja);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!collision.gameObject.CompareTag("Piso") && !collision.gameObject.CompareTag("Caja"))
        {
            if (velocidad_porcentual >= resistencia_porcentual)
            {
                Debug.Log("Choque");
                if(Efecto != null)
                {
                    switch (Efecto.Get_Efecto())
                    {
                        case true:
                            Efecto.Efecto();
                            Debug.Log("Proteccion usada");
                            break;
                        case 2:
                        case 1:
                        case 0:
                            Efecto.Efecto(transform.position);
                            break;
                    }
                }
                else
                {
                    speed = 0;
                    Muerte_canvas.SetActive(true);
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
    public void Reiniciar()
    {
        SceneManager.LoadScene(1);
    }


    //Botones->Ganar

    private void Ganador(Caja caja)
    {
        Ganar_canvas.SetActive(caja.Get_Porcentaje() == 10);
    }

    public void Ganar_Button()
    {
        SceneManager.LoadScene(0);
    }



}
