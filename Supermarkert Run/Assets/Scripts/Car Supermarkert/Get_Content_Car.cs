using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_Content_Car : MonoBehaviour
{
    [SerializeField]private List<Car> car;
    [SerializeField]private List<Material> material;
    public int posicion;
    public Car Get_Car() => car[posicion];
    static Get_Content_Car instancia;

    private void Awake()
    {
        if(instancia != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        MeshRenderer r = GetComponent<MeshRenderer>();
        r.material = material[posicion];    
    }
}
