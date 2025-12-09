using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto_caido : MonoBehaviour, IGuardarObjeto
{
    private void Start()
    {
        Debug.Log($"Objeto que spawneo {name}");
        Destroy(gameObject, 10f);
    }

    string IGuardarObjeto.Get_Object()
    {
        return name;
    }
}
