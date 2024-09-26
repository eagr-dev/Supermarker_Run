using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_Content_Car : MonoBehaviour
{
    [SerializeField]private List<Car> car;
    [SerializeField]private List<Material> material;
    private Renderer renderizado = new Renderer();
    public int posicion;
    public Car Get_Car() => car[posicion];


    private void Awake()
    {
        renderizado = GetComponent<Renderer>();
        renderizado.material = material[posicion];
    }
}
