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

    private Coroutine corutinaCaminar;
    public Transform DestinoActual { get; private set; }

    public void Caminar(float tiempo_animacion, Transform objetivo)
    {
        DestinoActual = objetivo;
        if (corutinaCaminar != null)
            StopCoroutine(corutinaCaminar);
        GPS.destination = objetivo.position;
        es_estatico = false;
        corutinaCaminar = StartCoroutine(Animacion_Caminar(tiempo_animacion));
    }

    private IEnumerator Animacion_Caminar(float tiempo_animacion)
    {
        animacion.Play("WALKING");
        float t = 0;
        while ((GPS.pathPending || GPS.remainingDistance > GPS.stoppingDistance + 0.05f) && t < tiempo_animacion + 3f)
        {
            t += Time.deltaTime;
            yield return null;
        }
        GPS.updateRotation = false;
        yield return Media_Vuelta();
        GPS.updateRotation = true;
        yield return new WaitForSeconds(0.5f);
        animacion.Play("PARADO");
        yield return new WaitForSeconds(2);
        es_estatico = true;
    }

    private IEnumerator Media_Vuelta()
    {
        Quaternion inicio = transform.rotation;
        Quaternion destino = Quaternion.Euler(0, 180, 0);
        float tiempo = 1f, timer = 0;
        while (timer < tiempo)
        {
            transform.rotation = Quaternion.Lerp(inicio, destino, timer / tiempo);
            timer += Time.deltaTime;
            yield return null;
        }
        transform.rotation = destino;
    }
}
