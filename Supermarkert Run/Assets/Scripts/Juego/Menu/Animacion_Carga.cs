using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine.UI;


public class Animacion_Carga : MonoBehaviour
{


    [SerializeField] private GameObject Menu_Carga;
    [SerializeField] private Animator animcion_jugar;
    [SerializeField] private AnimationClip tiempo_animacion_jugar;
    [SerializeField] private Slider carga;
    [SerializeField] private float timeCarga = 2;

    public void Cambiar_Escena(string escena)
    {
        StartCoroutine(Animacion(escena));
    }

    IEnumerator Animacion(string escena)
    {
        animcion_jugar.Play("PANEL");
        yield return new WaitForSeconds((tiempo_animacion_jugar.length / 2) - 0.10f);
        Menu_Carga.SetActive(true);
        float progreso = 0, deltaSumado = 0;

        while(progreso < 1)
        {
            deltaSumado += Time.deltaTime;
            progreso = deltaSumado / timeCarga;
            carga.value = progreso;
            yield return null;
        }

        yield return null;
        SceneManager.LoadScene(escena);
    }

}