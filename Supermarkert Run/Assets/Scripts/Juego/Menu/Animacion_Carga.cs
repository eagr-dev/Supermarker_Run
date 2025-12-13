using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;


public class Animacion_Carga : MonoBehaviour
{
    [SerializeField] Camera camara;
    [SerializeField] Transform objeto_Seguir;
    [SerializeField] NavMeshAgent GPS;
    [SerializeField] private Vector3 distancia = new Vector3(0, 7, -3);
    public float progreso;
    [SerializeField] float POV = 30;
    [SerializeField] Animator animacion;
    bool Contacto = false;

    private void Start()
    {
        StartCoroutine(InicializarNavMesh());
    }

    private void Update()
    {
        Actualizar();
    }
    public void Cambiar_Escena(string escena)
    {
        camara.transform.position = transform.position - distancia;
        animacion.SetFloat("VelX", 1f);
        StartCoroutine(Cambio(escena));
    }

    private IEnumerator Cambio(string escena)
    {
        while ((transform.position - objeto_Seguir.position).magnitude >= 3)
        {
            yield return null;
        }

        SceneManager.LoadScene(escena);
        /*AsyncOperation proceso = SceneManager.LoadSceneAsync(escena);
        proceso.allowSceneActivation = false;
        while(!proceso.isDone)
        {
            yield return null;

            if ((transform.position - objeto_Seguir.position).magnitude <= 3)
            {
                proceso.allowSceneActivation = true;
            }
        }

        if(!proceso.allowSceneActivation)
        {
            float tiempo = (transform.position - objeto_Seguir.position).magnitude;
            yield return new WaitForSeconds(tiempo + 1f);
        }
        proceso.allowSceneActivation = true;*/

    }

    private IEnumerator InicializarNavMesh()
    {
        // Si ya está en NavMesh, no esperar
        if (GPS.isOnNavMesh)
        {
            Iniciar();
            yield break;
        }
        Debug.Log("no hay navmesh");
        // No está listo, reintentar con espera
        GPS.enabled = false;
        yield return new WaitForSeconds(1f);
        GPS.enabled = true;

        if (GPS.isOnNavMesh)
        {
            Iniciar();
        }
        else
        {
            Debug.LogError($"[{name}] NavMesh no disponible");
            gameObject.SetActive(false);
        }
    }
    private void Iniciar()
    {
        camara.fieldOfView = POV;
        camara.farClipPlane = 100;
        GPS.destination = objeto_Seguir.position;
        Rotar_Camara();
    }

    private void Actualizar()
    {
        if (!Contacto)
            camara.transform.position = transform.position + distancia;
    }

    private void Rotar_Camara()
    {
        var rotacion = camara.transform.rotation;
        rotacion.eulerAngles = new Vector3(45, 0, 0);
        camara.transform.rotation = rotacion;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Puerta")
        {
            Contacto = true;
        }

    }
}