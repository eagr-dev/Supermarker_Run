using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine.UI;


public class Animacion_Carga : MonoBehaviour
{
    [System.Serializable]
    struct Consejo
    {
        public string espaniol, ingles, portugues;
    }

    [SerializeField] private GameObject Menu_Carga;
    [SerializeField] private Animator animcion_jugar;
    [SerializeField] private AnimationClip tiempo_animacion_jugar;
    [SerializeField] private Slider carga;
    [SerializeField] private TMPro.TMP_Text texto_consejo;
    [SerializeField] private float timeCarga = 2;
    [SerializeField] private List<Consejo> consejos;

    public void Cambiar_Escena(string escena)
    {
        SeleccionarConsejoAleatorio();
        StartCoroutine(Animacion(escena));
    }

    private void SeleccionarConsejoAleatorio()
    {
        int posicion = Random.Range(0, consejos.Count);
        switch(Idioma.GetLengua())
        {
            case Idioma.Lengua.ESPANIOL:
                texto_consejo.text = consejos[posicion].espaniol;
                break;
            case Idioma.Lengua.INGLES:
                texto_consejo.text = consejos[posicion].ingles;
                break;
            case Idioma.Lengua.PORTUGUES:
                texto_consejo.text = consejos[posicion].portugues;
                break;
        }
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