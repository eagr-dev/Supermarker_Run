using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float max_speed_H = 2, max_speed_V = 2, Vertical_Move = 0, Horizontal_Move = 0, speed = 0;
    public Joystick joystick;
    public GameObject player_object;
    [SerializeField]private new GameObject camera;
    Vector3 position_camera = new Vector3(0,4,-7);
    private Mision mision;

    private void Awake()
    {
        mision = FindObjectOfType<Mision>();   
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
        transform.position += new Vector3(Horizontal_Move, 0, Vertical_Move) * Time.deltaTime * speed;

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

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Estante"))
        {
           Estante estante = other.gameObject.GetComponent<Estante>();
           mision.New_Text_In_TextMesh(estante.Get_Object());
        }
    }
}
