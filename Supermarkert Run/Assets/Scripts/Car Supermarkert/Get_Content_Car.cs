using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_Content_Car : MonoBehaviour
{
    [SerializeField]private List<Car> car;
    [SerializeField]private List<Material> material;
    MeshRenderer r;
    public int posicion;
    public Car Get_Car() => car[posicion];

    private void Awake()
    {
        r = GetComponent<MeshRenderer>();
        r.material = material[posicion];    
    }
}
