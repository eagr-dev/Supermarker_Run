using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charco : MonoBehaviour
{
    [SerializeField] ParticleSystem gotas;
    [SerializeField] AudioSource sonido;

    void Start()
    {
        gotas.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") || other.CompareTag("Enemigo"))
        {
            gotas.Play();
            sonido.Play();
        }
    }

}
