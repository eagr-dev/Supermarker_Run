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
    [SerializeField] private float duration = 2.0f; // Duración total del movimiento del trineo
    [SerializeField] private float giftDropDuration = 0.8f; // Tiempo específico que tarda el regalo en caer

    [Header("Configuración del Bucle Ambiental")]
    [SerializeField] private float tiempoMinEspera = 4.0f; // Tiempo mínimo de espera aleatoria entre vuelos
    [SerializeField] private float tiempoMaxEspera = 10.0f; // Tiempo máximo de espera aleatoria entre vuelos

    private const string LastDateKey = "LastSleighDropDate";

    // Variable auxiliar para saber la dirección del próximo viaje en el bucle
    // true = va de Start a End | false = va de End a Start
    private bool movingToEnd = true;

    private void OnEnable()
    {
        // Nos suscribimos al evento global de la UI
        GiftOpeningUIController.OnRecompensaReclamada += DesactivarRegaloEnRuntime;
    }

    private void OnDisable()
    {
        // Limpiamos la suscripción para evitar fugas de memoria
        GiftOpeningUIController.OnRecompensaReclamada -= DesactivarRegaloEnRuntime;
    }

    public void DesactivarRegaloEnRuntime()
    {
        if (regalo != null && regalo.gameObject.activeSelf)
        {
            regalo.gameObject.SetActive(false);
            Debug.Log("[ChrismastAnimation] Regalo reclamado. Desactivando el objeto 3D en runtime.");
        }
    }

    public bool ShouldRun() => true;

    public void Initialize()
    {
        string todayStr = DateTime.Now.ToString("yyyy-MM-dd");
        string lastDropDate = PlayerPrefs.GetString(LastDateKey, string.Empty);
        int giftClaimed = PlayerPrefs.GetInt(GiftOpeningUIController.GiftClaimed, 0);

        Debug.Log($"Reclamacion del regalo: {giftClaimed}");

        if(giftClaimed != 0 && lastDropDate == todayStr)
        {
            trineo.position = trineoStartPos;
            regalo.gameObject.SetActive(false);
            DailyRewardManager.Instance.EnableInteraction(false);
        }
        else if (lastDropDate == todayStr)
        {
            // Ya pasó hoy: posicionar el regalo directamente en su destino final y habilitar interacción
            trineo.position = trineoEndPos;
            regalo.position = regaloEndPos;
            regalo.gameObject.SetActive(true);
            DailyRewardManager.Instance.EnableInteraction(true);
            PlayerPrefs.SetInt(GiftOpeningUIController.GiftClaimed, 0);
        }
        else
        {
            // Nuevo día: colocar el trineo en el inicio y ocultar el regalo hasta que caiga
            trineo.position = trineoStartPos;
            regalo.gameObject.SetActive(false);
            PlayerPrefs.SetInt(GiftOpeningUIController.GiftClaimed, 0);
        }
    }

    public IEnumerator PlayAnimation()
    {
        string todayStr = DateTime.Now.ToString("yyyy-MM-dd");
        string lastDropDate = PlayerPrefs.GetString(LastDateKey, string.Empty);
        bool yaReclamadoHoy = (lastDropDate == todayStr);

        if (!yaReclamadoHoy)
        {
            // 1. Si no se ha reclamado hoy, ejecutamos la corrutina de la caída del regalo
            yield return StartCoroutine(SecuenciaRegaloDiario(todayStr));
        }

        DailyRewardManager.Instance.EnableInteraction(true);
        // 2. Una vez terminada la animación del día (o si ya pasó), arrancamos la corrutina del bucle ambiental infinito
        yield return StartCoroutine(BucleVuelosAmbientales());
    }

    // =========================================================================
    // CORRUTINA 1: ANIMACIÓN DEL REGALO DIARIO (Caída a mitad de camino)
    // =========================================================================
    private IEnumerator SecuenciaRegaloDiario(string todayStr)
    {
        float elapsed = 0f;
        bool giftSpawned = false;
        Vector3 giftStartPos = Vector3.zero;
        float giftElapsed = 0f;

        Vector3 center = (trineoStartPos + trineoEndPos) / 2f;
        float radiusX = Vector3.Distance(trineoStartPos, trineoEndPos) / 2f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            float angle = Mathf.Lerp(0f, Mathf.PI, t);
            float x = center.x + Mathf.Cos(angle) * radiusX;
            float y = center.y + Mathf.Sin(angle) * ellipseHeight;
            float z = Mathf.Lerp(trineoStartPos.z, trineoEndPos.z, t);

            trineo.position = new Vector3(x, y, z);

            // El regalo cae cuando el trineo llega a la mitad del recorrido (t >= 0.5)
            if (t >= 0.5f)
            {
                if (!giftSpawned)
                {
                    giftStartPos = trineo.position;
                    regalo.position = giftStartPos;
                    regalo.gameObject.SetActive(true);
                    giftSpawned = true;
                    giftElapsed = 0f;
                }

                if (giftSpawned)
                {
                    giftElapsed += Time.deltaTime;
                    float dropT = Mathf.Clamp01(giftElapsed / giftDropDuration);
                    regalo.position = Vector3.Lerp(giftStartPos, regaloEndPos, Mathf.SmoothStep(0f, 1f, dropT));
                }
            }

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Asegurar posiciones finales exactas de la animación del regalo
        trineo.position = trineoEndPos;
        regalo.position = regaloEndPos;
        regalo.gameObject.SetActive(true);

        // Guardar que ya se completó el evento de hoy
        PlayerPrefs.SetString(LastDateKey, todayStr);
        PlayerPrefs.Save();
        // Como terminó en el punto End, la siguiente vuelta del bucle ambiental debe ir hacia Start
        movingToEnd = false;
    }

    // =========================================================================
    // CORRUTINA 2: BUCLE AMBIENTAL CONSTANTE Y ALEATORIO
    // =========================================================================
    private IEnumerator BucleVuelosAmbientales()
    {
        while (true)
        {
            // Espera con un tiempo aleatorio entre el mínimo y máximo configurado
            float esperaAleatoria = UnityEngine.Random.Range(tiempoMinEspera, tiempoMaxEspera);
            yield return new WaitForSeconds(esperaAleatoria);

            Debug.Log($"el valor de movingToEnd: {movingToEnd}");
            // Definir origen y destino basándonos en nuestra variable auxiliar 'movingToEnd'
            Vector3 origen = movingToEnd ? trineoStartPos : trineoEndPos;
            Vector3 destino = movingToEnd ? trineoEndPos : trineoStartPos;
            Debug.Log($"El origen: {origen}, el destino {destino}");
            // Ejecutar el movimiento del trineo
            yield return StartCoroutine(MoverTrineo(origen, destino));

            // Invertir la dirección para el siguiente viaje
            movingToEnd = !movingToEnd;
        }
    }

    // Método auxiliar reutilizable para mover el trineo de un punto a otro usando la elipse
    // Método auxiliar reutilizable para mover el trineo de un punto a otro respetando la dirección
    private IEnumerator MoverTrineo(Vector3 desde, Vector3 hacia)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;

            // 1. Interpolación lineal limpia para X y Z desde el origen hasta el destino real
            float x = Mathf.Lerp(desde.x, hacia.x, t);
            float z = Mathf.Lerp(desde.z, hacia.z, t);

            // 2. Interpolamos la altura base entre los dos puntos y le sumamos el arco parabólico/elíptico con Seno
            float baseY = Mathf.Lerp(desde.y, hacia.y, t);
            float y = baseY + Mathf.Sin(t * Mathf.PI) * ellipseHeight;

            trineo.position = new Vector3(x, y, z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Asegurar la posición final exacta
        trineo.position = hacia;
    }
}