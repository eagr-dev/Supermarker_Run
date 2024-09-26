using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float max_speed_H = 2, max_speed_V = 2, Vertical_Move = 0, Horizontal_Move = 0, speed = 2, resistencia_porcentual = 0;
    Vector3 obtener_velocidad;
    public Joystick joystick;
    public GameObject player_object;
    [SerializeField]private new GameObject camera;
    Vector3 position_camera = new Vector3(0,4,-7);
    private Mision mision;
    private Get_Content_Car carrito_contenido;
    private Car carrito;
    private new Rigidbody rigidbody;


    private void Awake()
    {
        mision = FindObjectOfType<Mision>();  
        rigidbody = GetComponent<Rigidbody>();
        carrito_contenido = FindObjectOfType<Get_Content_Car>();
        carrito = carrito_contenido.GetComponent<Get_Content_Car>().Get_Car();
        Init();
    }

    void Update()
    {
        Move_Player();
        Camera_Move();
        
    }
    private void Move_Player()
    {

        Vertical_Move = joystick.Vertical * max_speed_V;
        Horizontal_Move = joystick.Horizontal * max_speed_H;
        Vector3 Movimiento = new Vector3(Horizontal_Move, 0, Vertical_Move).normalized;
        obtener_velocidad = new Vector3(Horizontal_Move, 0, Vertical_Move) * Time.deltaTime * speed;
        float velocidad_porcentual = (obtener_velocidad.magnitude * 100) / speed;
        transform.position += new Vector3(Horizontal_Move, 0, Vertical_Move) * Time.deltaTime * speed;
        
        if(velocidad_porcentual >= resistencia_porcentual)
        {
            Debug.Log("velocidad maxima pasada");
        }
        if(Movimiento.magnitude >= 1)
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

    private void Init()
    {
        rigidbody.mass += carrito.peso;
        speed += carrito.velocidad_adicional;
        max_speed_H += carrito.velocidad_adicional;
        max_speed_V += carrito.velocidad_adicional;
        resistencia_porcentual = ((float)carrito.resistencia_choque / 100) * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Estante"))
        {
           Estante estante = other.gameObject.GetComponent<Estante>();
           mision.New_Text_In_TextMesh(estante.Get_Object());
        }
    }
}
