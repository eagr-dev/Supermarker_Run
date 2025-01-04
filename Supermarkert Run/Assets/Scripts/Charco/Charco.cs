using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charco : MonoBehaviour
{
    [SerializeField] ParticleSystem gotas;

    void Start()
    {
        gotas.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") || other.CompareTag("Enemigo"))
        {
            gotas.Play();
        }
    }

}
