using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Seleccion_PU : MonoBehaviour
{
    [SerializeField] float limite, valor_ant;
    int valor_actual;
    [SerializeField] Transform objetos;
    readonly List<Vector3> posiciones_iniciales = new();
    Repartir_power RP;
    [SerializeField]TMP_Text Nombre,Descripcion;
    [SerializeField] private AudioSource Click_Botones;
    Vector3 posicion_presentacion = new(7, -0.72f, 14.48f);
    Vector3 suma_nueva_posicion = new(7, 0, 0), resta_nueva_posicion = new(-7, 0, 0);
    [SerializeField]float distancia_minina = 3;
    [SerializeField]float duracionAnimacion = 0.5f;

    private void Awake()
    {
        RP = FindFirstObjectByType<Repartir_power>();
        foreach (Transform obj in objetos)
        {
            //posiciones_iniciales.Add(obj.position);
            posiciones_iniciales.Add(obj.localPosition);
            obj.GetComponent<Interfaz_PowerUp>().Set_Descripcion_Nombre();
        }
        var powerUp = objetos.GetChild(0).GetComponent<Interfaz_PowerUp>();

        SetText(powerUp);
    }

    public void BTN_SIG()
    {
        Click_Botones.Play();
        if (objetos.GetChild(objetos.childCount - 1).localPosition == posicion_presentacion)
            return;
        valor_actual++;
        ValidarCercano(resta_nueva_posicion);
    }

    public void BTN_ANT()
    {
        Click_Botones.Play();
        if (objetos.GetChild(0).localPosition == posicion_presentacion)
            return;
        valor_actual--;
        ValidarCercano(suma_nueva_posicion);
    }


    private void ValidarCercano(Vector3 posicion_sumar)
    {
        Vector3 nueva_posicion;
        for (int i = 0; i < objetos.childCount; i++)
        {
            GameObject hijo = objetos.GetChild(i).gameObject;
            Interfaz_PowerUp interfaz_PowerUp = hijo.GetComponent<Interfaz_PowerUp>();
            interfaz_PowerUp.Animacion();
            posiciones_iniciales[i] += posicion_sumar;
            nueva_posicion = posiciones_iniciales[i];
            StartCoroutine(AnimacionPU(hijo, nueva_posicion));
            float magnitud = (posiciones_iniciales[i] - posicion_presentacion).magnitude;
            if(magnitud < distancia_minina)
            {
                SetText(interfaz_PowerUp);
            }
        }
    }

    IEnumerator AnimacionPU(GameObject objeto, Vector3 nueva_posicion)
    {
        Transform transform = objeto.transform;
        Vector3 posicionInicial = transform.localPosition;
        Vector3 posicionFinal = nueva_posicion;

        float tiempoTranscurrido = 0f;

        while (tiempoTranscurrido < duracionAnimacion)
        {
            tiempoTranscurrido += Time.deltaTime;
            float t = tiempoTranscurrido / duracionAnimacion;

            // Ease-out para movimiento suave
            float tSuave = 1f - Mathf.Pow(1f - t, 2f);

            // Interpolar posición LOCAL
            transform.localPosition = Vector3.Lerp(posicionInicial, posicionFinal, tSuave);

            yield return null;
        }

        // Asegurar posición final exacta
        transform.localPosition = posicionFinal;
    }

    void SetText(Interfaz_PowerUp interfaz_PowerUp)
    {
        interfaz_PowerUp.Set_Descripcion_Nombre();
        Nombre.text = interfaz_PowerUp.name;
        Descripcion.text = interfaz_PowerUp.descripcion;
    }

    public void BTN_Power()
    {
        Click_Botones.Play();
        Debug.Log($"Se envio la posicion {valor_actual}");
        RP.Set_Enum(Mathf.Abs(valor_actual));
        Debug.Log($"se dio {RP.Get_Power_Up()}");
    }
}
