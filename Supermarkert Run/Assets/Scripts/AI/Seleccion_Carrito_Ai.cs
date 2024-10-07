using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seleccion_Carrito_Ai : MonoBehaviour
{
    public GameObject[] Carritos = new GameObject[3];
    List<Car> car = new List<Car>();
    private void Awake()
    {
        Pase_Conexion_Menu_Gameplay PCMG = FindObjectOfType<Pase_Conexion_Menu_Gameplay>();
        int pos = Random.Range(0, 2);
        PCMG.Set_List_All(car, PCMG.Get_Seleccion());
        Carritos[pos].SetActive(true);
        Carritos[pos].GetComponent<MeshRenderer>().material = car[Random.Range(0, car.Count)].skin_car;    
    }
}
