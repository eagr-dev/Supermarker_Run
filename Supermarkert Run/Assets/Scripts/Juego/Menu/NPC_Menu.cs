using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Menu : MonoBehaviour
{
    [SerializeField] GameObject Seguir, carrito;
    [SerializeField] NavMeshAgent GPS;
    [SerializeField] Animator animacion;
    [SerializeField] Transform Spawn;
    Transform seguir;
    // Start is called before the first frame update
    void Start()
    {
        seguir = Seguir.transform;
        StartCoroutine(Espera());
    }

    // Update is called once per frame
    void Update()
    {
        animacion.SetFloat("VelX", 1);
        float distancia = (transform.position - seguir.position).magnitude;
        if (distancia <= 3)
        {
            seguir = seguir.position != Spawn.position ? Spawn : Seguir.transform;
            StartCoroutine(Espera());
        }
    }

    private void Reinicio()
    {
        transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material.color = Random.ColorHSV();
        GPS.destination = seguir.position;
        int posmat = Random.Range(0, carrito.GetComponent<Get_Content_Car>().Get_Counts_Car() - 1);
        carrito.GetComponent<Get_Content_Car>().Set_Car(posmat);
    }

    IEnumerator Espera()
    {
        yield return new  WaitForSeconds(Random.Range(0, 10));
        Reinicio();
    }

}
