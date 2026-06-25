using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto_caido : MonoBehaviour, IGuardarObjeto
{
    public static event Action<Objeto_caido> OnObjetoDestruido;
    private Vector3 escalaFinal = new(0.5f, 0.5f , 0.5f);
    private Vector3 escalaPrincipio = new();
    private float timeAnimation = 9f;

    private void Start()
    {
        escalaPrincipio = transform.localScale;
        StartCoroutine(Animacion());
        Destroy(gameObject, 10f);
    }

    private void OnDestroy()
    {
        OnObjetoDestruido?.Invoke(this);
    }

    public string Get_Object()
    {
        return name;
    }

    private IEnumerator Animacion()
    {
        float tiempoTranscurrido = 0f;

        while (tiempoTranscurrido < timeAnimation)
        {
            tiempoTranscurrido += Time.deltaTime;
            float progreso = tiempoTranscurrido / timeAnimation;
            Vector3 posicionActual = Vector3.Lerp(escalaPrincipio, escalaFinal, progreso);
            transform.localScale = posicionActual;
            yield return null;
        }
        transform.localScale = escalaFinal;
    }
}
