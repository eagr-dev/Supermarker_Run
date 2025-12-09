using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class IA : MonoBehaviour
{
    public NavMeshAgent navegador;
    public GameObject objecto_seguir;
    private List<GameObject> posicion_cajas;
    private Vector3 resultado;
    private Mapa mapa_content;
    [SerializeField] private Animator animacion;


    private void Awake()
    {
        animacion.SetFloat("VelX", 1);
        animacion.SetFloat("VelY", 1);
        New_Color();
    }

    public void Set(Mapa mapa, GameObject objeto, List<GameObject> cajas)
    {
        mapa_content = mapa;
        objecto_seguir = objeto;
        posicion_cajas = cajas;

        if (objecto_seguir != null)
            New_position(Random_position());
        else
            Destroy(gameObject);
    }



    // Update is called once per frame
    void Update()
    {
        resultado = transform.position - objecto_seguir.transform.position;

        if(resultado.magnitude <= 3)
        {
            StartCoroutine(Tiempo_Muerto());
        }
         
    }

    private IEnumerator Tiempo_Muerto()
    {
        animacion.SetFloat("VelX", 0);
        animacion.SetFloat("VelY", 0);
        float tiempo = Random.Range(0, 10);
        yield return new WaitForSeconds(tiempo);
        float random_numnber = Random.Range(0f, 1f);
        Vector3 vector3 = random_numnber > 0.5f ? Ir_Caja() : Random_position();
        New_position(vector3);
        animacion.SetFloat("VelX", 1);
        animacion.SetFloat("VelY", 1);
    }

    private void New_position(Vector3 position)
    {
        objecto_seguir.transform.position = position;
        navegador.destination = objecto_seguir.transform.position;
    }

    private Vector3 Ir_Caja()
    {
        int index = Random.Range(0, posicion_cajas.Count);
        if (posicion_cajas[index].GetComponent<CajaEnemigo>().GetOcupado())
            return Random_position();
        Debug.Log($"el enemigo va a ir a la caja {index}");
        Vector3 vector3 = posicion_cajas[index].transform.position;
        vector3.y = 0;
        return vector3;
    }

    private Vector3 Random_position()
    {
        float resultadoX = Random.Range(mapa_content.X_minimo, mapa_content.X_maximo);
        float resultadoY = Random.Range(mapa_content.Y_minimo, mapa_content.Y_maximo);
        Vector3 vector3 = new(resultadoX, 0, resultadoY);
        return vector3;
    }


    private void New_Color()
    {
        transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material.color = Random.ColorHSV();
    }
}
