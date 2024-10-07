using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA : MonoBehaviour
{
    public NavMeshAgent navegador;
    public GameObject objecto_seguir;
    private Vector3 resultado;
    public float X_minimo, X_maximo, Y_minimo, Y_maximo;

    // Start is called before the first frame update
    void Start()
    {
        New_position();
    }

    // Update is called once per frame
    void Update()
    {
        resultado = transform.position - objecto_seguir.transform.position;

        if(resultado.magnitude <= 3)
        {
            New_position();
        }
         
    }

    private void New_position()
    {
        float resultadoX = Random.Range(X_minimo, X_maximo);
        float resultadoY = Random.Range(Y_minimo, Y_maximo);
        objecto_seguir.transform.position = new Vector3(resultadoX, 0, resultadoY);
        navegador.destination = objecto_seguir.transform.position;
    }
}
