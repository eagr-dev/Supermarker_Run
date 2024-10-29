using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class IA : MonoBehaviour
{
    public NavMeshAgent navegador;
    public GameObject objecto_seguir;
    private Vector3 resultado;
    private Mapa mapa_content;
    [SerializeField] private Animator animacion;

    private void Awake()
    {
        mapa_content = FindObjectOfType<Dinero_Obtenido>().Get_Mapa(SceneManager.GetActiveScene().name);
        animacion.SetFloat("VelX", 1);
        animacion.SetFloat("VelY", 1);
    }

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
            StartCoroutine(Tiempo_Muerto());
        }
         
    }

    private IEnumerator Tiempo_Muerto()
    {
        animacion.SetFloat("VelX", 0);
        animacion.SetFloat("VelY", 0);
        float tiempo = Random.Range(0, 10);
        yield return new WaitForSeconds(tiempo);
        New_position();
        animacion.SetFloat("VelX", 1);
        animacion.SetFloat("VelY", 1);
    }

    private void New_position()
    {
        float resultadoX = Random.Range(mapa_content.X_minimo, mapa_content.X_maximo);
        float resultadoY = Random.Range(mapa_content.Y_minimo, mapa_content.Y_maximo);
        objecto_seguir.transform.position = new Vector3(resultadoX, 0, resultadoY);
        navegador.destination = objecto_seguir.transform.position;
    }
}
