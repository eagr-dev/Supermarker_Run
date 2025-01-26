using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Animacion_NPC : MonoBehaviour
{
    [SerializeField] Animator animacion;
    [SerializeField] float tiempo_animacion_quieto;
    [SerializeField] NavMeshAgent GPS;
    bool es_estatico = true;

    void Start()
    {
        StartCoroutine(Animacion_Quieto());
    }

    private IEnumerator Animacion_Quieto()
    {
        float tiempo = Random.Range(5, 20);
        while(true)
        {
            yield return new WaitForSeconds(tiempo);
            if(es_estatico)
            {
                animacion.Play("PARADO");
            }
            yield return new WaitForSeconds(tiempo_animacion_quieto);

            tiempo = Random.Range(5, 20);
        }
    }

    public void Caminar(float tiempo_animacion, Transform objetivo)
    {
        StopAllCoroutines();
        GPS.destination = objetivo.position;
        es_estatico = false;
        StartCoroutine(Animacion_Caminar(tiempo_animacion));
    }

    private IEnumerator Animacion_Caminar(float tiempo_animacion)
    {
        animacion.Play("WALKING");
        yield return new WaitForSeconds(tiempo_animacion);
        transform.Rotate(new Vector3(0, 180, 0));
        animacion.Play("PARADO");
        yield return new WaitForSeconds(2);
        es_estatico = true;
    }
}
