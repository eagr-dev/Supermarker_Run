using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto_random_carro : MonoBehaviour, IGuardarObjeto
{
    [SerializeField] private Areas.Area_product area;
    [SerializeField] private string objeto;

    public string Get_Object() => objeto;

    // Start is called before the first frame update
    void Start()
    {
        int producto = Random.Range(0, 9);
        objeto = Areas.Objetos[(int)area][producto];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
