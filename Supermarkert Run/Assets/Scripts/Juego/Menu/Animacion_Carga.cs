using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Animacion_Carga : MonoBehaviour
{
    [SerializeField] Camera camara;
    [SerializeField] Transform objeto_Seguir;
    [SerializeField]private Vector3 distancia = new Vector3(0,7,-3);
    public float progreso;
    [SerializeField] float velocidad, POV = 30;
    float velocidad_real = 0;
    [SerializeField] Animator animacion;

    private void Update()
    {
        velocidad_real = velocidad * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, objeto_Seguir.position, velocidad_real);
        camara.transform.position = transform.position + distancia;
        camara.fieldOfView = POV;
        camara.farClipPlane = 100;
        var rotacion = camara.transform.rotation;
        rotacion.eulerAngles = new Vector3(45, 0, 0);
        camara.transform.rotation = rotacion;
    }
    public void Cambiar_Escena(string escena)
    {
        camara.transform.position = transform.position - distancia;
        animacion.SetFloat("VelX", 1f);
        StartCoroutine(Cambio(escena));
    }

    private IEnumerator Cambio(string escena)
    {
        AsyncOperation proceso = SceneManager.LoadSceneAsync(escena);
        proceso.allowSceneActivation = false;
        while(!proceso.isDone)
        {
            yield return null;

            if (transform.position == objeto_Seguir.position)
            {
                proceso.allowSceneActivation = true;
            }
        }

        if(!proceso.allowSceneActivation)
        {
            float tiempo = (transform.position - objeto_Seguir.position).magnitude;
            yield return new WaitForSeconds(tiempo + 1f);
        }
        proceso.allowSceneActivation = true;

    }
}
