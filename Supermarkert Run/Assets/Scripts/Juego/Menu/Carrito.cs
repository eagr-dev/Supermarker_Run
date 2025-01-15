using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrito : MonoBehaviour
{
    [SerializeField] Transform Objetivo;
    [SerializeField] float min, max;
    Vector3 posicion_inicial;
    float velocidad = 0;

    void Start()
    {
        posicion_inicial = transform.position;
        velocidad = Random.Range(min, max);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Objetivo.position, velocidad * Time.deltaTime);
        if (Vector3.Distance(transform.position, Objetivo.position) <= 2)
        {
            transform.position = posicion_inicial;
            velocidad = Random.Range(min, max);
        }
    }
}
