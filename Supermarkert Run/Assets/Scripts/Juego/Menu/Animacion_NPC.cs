using System.Collections;
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
        StartCoroutine(Media_Vuelta());
        yield return new WaitForSeconds(0.5f);
        animacion.Play("PARADO");
        yield return new WaitForSeconds(2);
        es_estatico = true;
    }

    private IEnumerator Media_Vuelta()
    {
        float tiempo = 1f, timer = 0;
        while(timer < tiempo)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 180, 0)), timer / tiempo);
            timer += Time.deltaTime;
            yield return null;
        }
    }
}
