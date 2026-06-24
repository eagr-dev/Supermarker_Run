using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto_random_carro : MonoBehaviour, IGuardarObjeto
{
    [SerializeField] private string objeto;

    public string Get_Object() => objeto;

    // Start is called before the first frame update
    void Start()
    {
        int producto = Random.Range(0, Areas._objetos_contiene);
        int area = Random.Range(0, Areas._areas);
        if (Areas.Objetos == null)
            Debug.Log("Objetos de areas esta en nulo");
        objeto = Areas.Objetos[area][producto];
    }

}
