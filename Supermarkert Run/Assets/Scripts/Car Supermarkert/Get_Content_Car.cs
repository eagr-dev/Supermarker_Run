using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Get_Content_Car : MonoBehaviour
{
    private List<Car> car = new List<Car>();
    [SerializeField]MeshRenderer r;
    public Pase_Conexion_Menu_Gameplay.Tipo_Carro TC;
    public int posicion;
    public Car Get_Car() => car[posicion];

    public int Get_Counts_Car() => car.Count;

    public void Set_Car(int new_posicion)
    {
        posicion = new_posicion;
        if(posicion < car.Count)
        r.material = car[posicion].skin_car;
    }

    private void Awake()
    {
        Pase_Conexion_Menu_Gameplay PCMG = FindObjectOfType<Pase_Conexion_Menu_Gameplay>();
        posicion = PCMG.Get_Eleccion();
        PCMG.Set_List_All(ref car, TC);
        r.material = car[posicion].skin_car;
    }
}
