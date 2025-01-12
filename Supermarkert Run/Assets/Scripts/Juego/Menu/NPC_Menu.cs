using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Menu : MonoBehaviour
{
    [SerializeField] GameObject Seguir;
    [SerializeField] NavMeshAgent GPS;
    [SerializeField] Animator animacion;
    [SerializeField] List<Transform> Spawn;
    // Start is called before the first frame update
    void Start()
    {
        Reinicio();
    }

    // Update is called once per frame
    void Update()
    {
        if (Seguir.transform.position.magnitude <= 3)
            Reinicio();
    }

    private void Reinicio()
    {
        transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material.color = Random.ColorHSV();
        transform.position = Spawn[Random.Range(0, Spawn.Count - 1)].position;
        GPS.destination = Seguir.transform.position;
    }
}
