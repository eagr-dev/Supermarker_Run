using UnityEngine;
using System;
using System.Collections;

public class ChrismastAnimation : MonoBehaviour, IBackgroundAnimation
{
    [Header("Referencias")]
    [SerializeField] private Transform trineo;
    [SerializeField] private Transform regalo;

    [Header("Trayectoria Elíptica del Trineo")]
    [SerializeField] private Vector3 trineoStartPos;
    [SerializeField] private Vector3 trineoEndPos;
    [SerializeField] private float ellipseHeight = 3f; // Altura del arco de la elipse

    [Header("Configuración del Regalo")]
    [SerializeField] private Vector3 regaloEndPos; // Posición final exacta donde aterrizará y se quedará el regalo
    [SerializeField] private float duration = 2.0f;

    private const string LastDateKey = "LastSleighDropDate";

    public bool ShouldRun()
    {
        string todayStr = DateTime.Now.ToString("yyyy-MM-dd");
        string lastDropDate = PlayerPrefs.GetString(LastDateKey, string.Empty);
        return lastDropDate != todayStr; // Solo se ejecuta si aún no se ha hecho hoy
    }

    public void Initialize()
    {
        string todayStr = DateTime.Now.ToString("yyyy-MM-dd");
        string lastDropDate = PlayerPrefs.GetString(LastDateKey, string.Empty);

        if (lastDropDate == todayStr)
        {
            // Ya pasó hoy: posicionar directamente en el destino final
            trineo.position = trineoEndPos;
            regalo.position = regaloEndPos;
            regalo.gameObject.SetActive(true);
        }
        else
        {
            // Nuevo día: colocar en el inicio y ocultar el regalo hasta que caiga en la animación
            trineo.position = trineoStartPos;
            regalo.gameObject.SetActive(false);
        }
    }

    public IEnumerator PlayAnimation()
    {
        string todayStr = DateTime.Now.ToString("yyyy-MM-dd");
        float elapsed = 0f;

        bool giftSpawned = false;
        Vector3 giftStartPos = Vector3.zero;

        // Cálculos matemáticos para la elipse basada en Seno y Coseno
        Vector3 center = (trineoStartPos + trineoEndPos) / 2f;
        float radiusX = Vector3.Distance(trineoStartPos, trineoEndPos) / 2f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;

            // 1. Movimiento elíptico: va de 0 a PI para ir de Start a End correctamente
            float angle = Mathf.Lerp(0f, Mathf.PI, t);
            float x = center.x + Mathf.Cos(angle) * radiusX;
            float y = center.y + Mathf.Sin(angle) * ellipseHeight;
            float z = Mathf.Lerp(trineoStartPos.z, trineoEndPos.z, t);

            trineo.position = new Vector3(x, y, z);

            // 2. El regalo no se ve hasta la mitad del recorrido (t >= 0.5)
            if (t >= 0.5f)
            {
                if (!giftSpawned)
                {
                    // Al llegar a la mitad, aparece en la posición exacta del trineo
                    giftStartPos = trineo.position;
                    regalo.position = giftStartPos;
                    regalo.gameObject.SetActive(true);
                    giftSpawned = true;
                }

                float dropT = (t - 0.5f) * 2f; // Normalizar de 0 a 1 para la caída
                regalo.position = Vector3.Lerp(giftStartPos, regaloEndPos, Mathf.SmoothStep(0f, 1f, dropT));
            }

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Asegurar posiciones finales exactas
        trineo.position = trineoEndPos;
        regalo.position = regaloEndPos;
        regalo.gameObject.SetActive(true);

        //Guardar que ya se completó el evento de hoy
        PlayerPrefs.SetString(LastDateKey, todayStr);
        PlayerPrefs.Save();
    }
}