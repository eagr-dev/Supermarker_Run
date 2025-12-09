using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaEnemigo : MonoBehaviour
{
    bool cajaOcupada = false;

    private void OnTriggerEnter(Collider other)
    {
        cajaOcupada = other.CompareTag("Enemigo");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemigo"))
            cajaOcupada = false;
    }

    public bool GetOcupado() => cajaOcupada;
}
