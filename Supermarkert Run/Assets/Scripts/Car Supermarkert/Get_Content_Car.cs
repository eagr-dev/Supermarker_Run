using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_Content_Car : MonoBehaviour
{
    [SerializeField]private List<Car> car;
    [SerializeField]MeshRenderer r;
    public int posicion;
    public Car Get_Car() => car[posicion];

    public int Get_Counts_Car() => car.Count;

    public void Set_Car(int new_posicion)
    {
        posicion = new_posicion;
        r.material = car[posicion].skin_car;
    }

    private void Awake()
    {
        posicion = FindObjectOfType<Pase_Conexion_Menu_Gameplay>().Get_Eleccion();
        r.material = car[posicion].skin_car;    
    }
}
