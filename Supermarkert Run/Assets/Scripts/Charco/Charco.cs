using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charco : MonoBehaviour
{
    [SerializeField] ParticleSystem gotas;
    [SerializeField] AudioSource sonido;

    void Start()
    {
        var emision = gotas.emission;
        emision.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            var emision = gotas.emission;
            emision.enabled = true;
            gotas.Play();
            sonido.Play();
        }
    }

}
