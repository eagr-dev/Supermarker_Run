using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Seleccion_PU : MonoBehaviour
{
    [SerializeField] float limite, valor_ant;
    int valor_actual;
    [SerializeField] Transform objetos, ultimoPowerUp;
    readonly List<Vector3> posiciones_iniciales = new();
    Repartir_power RP;
    [SerializeField]TMP_Text Nombre,Descripcion;
    [SerializeField] private AudioSource Click_Botones;
    Vector3 posicion_presentacion = new(7, -0.72f, 14.48f);
    Vector3 suma_nueva_posicion = new(7, 0, 0), resta_nueva_posicion = new(-7, 0, 0);
    [SerializeField]float distancia_minina = 3;
    [SerializeField]float duracionAnimacion = 0.5f;

    private void Start()
    {
        RP = FindFirstObjectByType<Repartir_power>();
        Interfaz_PowerUp primerPU = null;
        foreach (Transform obj in objetos)
        {
            posiciones_iniciales.Add(obj.localPosition);
            Interfaz_PowerUp powerUp = obj.GetComponent<Interfaz_PowerUp>();

            if (primerPU is null)
                primerPU = powerUp;
            if(powerUp is not null)
                powerUp.Set_Descripcion_Nombre();
        }

        SetText(primerPU);
    }

    public void BTN_SIG()
    {
        Click_Botones.Play();
        if (ultimoPowerUp.localPosition == posicion_presentacion)
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
        var hijosConPowerUp = objetos.GetComponentsInChildren<Interfaz_PowerUp>();
        int it = 0;
        foreach(var obj in hijosConPowerUp)
        {
            obj.Animacion();
            posiciones_iniciales[it] += posicion_sumar;
            nueva_posicion = posiciones_iniciales[it];
            StartCoroutine(AnimacionPU(obj.gameObject, nueva_posicion));
            float magnitud = (posiciones_iniciales[it] - posicion_presentacion).magnitude;
            if (magnitud < distancia_minina)
            {
                SetText(obj);
            }
            it++;
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

        //Validar que se vio el anuncio
        Anuncios.Instancia.MostrarAnuncioRecompensa((bool exito) =>
        {
            if(!exito)
            {
                Debug.Log("El jugador no completo su anuncio");
                Notificacion.MostrarAlertaNativa(new NotificacionInformacionStruct(
                "Aviso", "No se pudo otorgar la recompensa. Asegúrate de ver el video completo.",
                "Notice", "Could not grant reward. Make sure to watch the full video.",
                "Aviso", "Não foi possível conceder a recompensa. Certifique-se de assistir ao vídeo completo."
                ));
                return;
            }
            
            RP.Set_Enum(Mathf.Abs(valor_actual));
            Debug.Log($"Se vio con exito el anuncio y obtuvo {RP.Get_Power_Up()}");

            Notificacion.MostrarAlertaNativa(new NotificacionInformacionStruct(
            "¡Recompensa!", "Has recibido tu recompensa con éxito.",
            "Reward!", "You have successfully received your reward.",
            "Recompensa!", "Você recebeu sua recompensa com sucesso."
            ));
        }
        );
    }
}
