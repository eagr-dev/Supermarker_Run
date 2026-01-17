using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Menu : MonoBehaviour
{
    [SerializeField] private GameObject Seguir, carrito;
    [SerializeField] private NavMeshAgent GPS;
    [SerializeField] private Animator animacion;
    [SerializeField] private Transform Spawn;

    private Transform seguir;
    private bool inicializado = false;

    void Start()
    {
        StartCoroutine(InicializarNavMesh());
    }

    private IEnumerator InicializarNavMesh()
    {
        // Si ya está en NavMesh, no esperar
        if (GPS.isOnNavMesh)
        {
            InicializarNPC();
            yield break;
        }
        Debug.Log("no hay navmesh");
        // No está listo, reintentar con espera
        GPS.enabled = false;
        yield return new WaitForSeconds(1f);
        GPS.enabled = true;

        if (GPS.isOnNavMesh)
        {
            InicializarNPC();
        }
        else
        {
            Debug.LogError($"[{name}] NavMesh no disponible");
            gameObject.SetActive(false);
        }
    }

    private void InicializarNPC()
    {
        seguir = Seguir.transform;
        inicializado = true;
        StartCoroutine(Espera());
    }

    void Update()
    {
        if (!inicializado) return;

        animacion.SetFloat("VelX", 1);
        float distancia = Vector3.Distance(transform.position, seguir.position);

        if (distancia <= 3f)
        {
            seguir = seguir.position != Spawn.position ? Spawn : Seguir.transform;
            StartCoroutine(Espera());
        }
    }

    private void Reinicio()
    {
        if (!GPS.isOnNavMesh) return;

        Material material = transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material;
        Color nuevo_color = Random.ColorHSV();
        material.SetColor("_Color", nuevo_color);
        material.SetColor("_RimColor", nuevo_color);
        material.SetColor("_SpecularColor", nuevo_color);
        GPS.SetDestination(seguir.position);

        int posmat = Random.Range(0, carrito.GetComponent<Get_Content_Car>().Get_Counts_Car());
        carrito.GetComponent<Get_Content_Car>().Set_Car(posmat);
    }

    private IEnumerator Espera()
    {
        yield return new WaitForSeconds(Random.Range(0f, 10f));
        Reinicio();
    }
}