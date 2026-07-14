using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Objeto_random_carro : MonoBehaviour, IGuardarObjeto
{
    [SerializeField] private string objeto;
    [SerializeField] private Areas.Area_product area_Product;
    [SerializeField] private GameObject UIRoullete, UIAnuncios;
    [SerializeField] private Image[] images = new Image[maxImage];
    [SerializeField] private Sprite[] sprites = new Sprite[maxSprite];
    [SerializeField] private TMP_Text nombre_objeto, objetos_buscados;
    [SerializeField] private AudioSource sonido_ruleta, sonido_acierto, sonido_fallo;
    [SerializeField] private Image iconoFalloAcierto;
    [SerializeField] private Sprite sprite_Acierto, sprite_Fallo;
    [SerializeField] private Button Aceptar, Cancelar;
    private List<string> objetos = new();
    private readonly int maxObjectContains = 10;
    private int position = 0;
    List<Areas.Area_product> areas_Product = new();
    const int maxImage = 5, maxSprite = 8;

    public string Get_Object() => objeto;

    // Start is called before the first frame update
    void Start()
    {
        CrearListaObjetos();
        Aceptar.onClick.AddListener(BTN_Aceptar);
        Cancelar.onClick.AddListener(BTN_Cancelar);
    }


    public IEnumerator AnimacionUI(bool acierto)
    {
        UIRoullete.SetActive(true);

        if (position >= maxObjectContains)
        {
            yield return StartCoroutine(AnimacionUIAnuncios());
            yield break;
        }

        objetos_buscados.text = $"{position + 1}/{maxObjectContains}";
        yield return null;
        sonido_ruleta.Play();

        int indexPointer = 2;
        int maxS = sprites.Length;
        int indexTarget = (int)area_Product;

        int finalOffset = ((indexTarget - indexPointer) % maxS + maxS) % maxS;

        float totalTime = sonido_ruleta.clip.length - 1f;
        float T_fast = 0.04f;
        float T_slow = 0.35f;
        float slowFraction = 0.35f;

        float timeForSlowing = totalTime * slowFraction;
        float timeForFast = totalTime - timeForSlowing;

        int stepsFast = Mathf.Max(1, (int)(timeForFast / T_fast));

        // Calcular cuántos pasos de frenado caben con curva sinusoidal
        int stepsToSlow = 0;
        float simulatedTime = 0f;
        while (simulatedTime < timeForSlowing)
        {
            float t = simulatedTime / timeForSlowing;
            float stepDuration = Mathf.Lerp(T_fast, T_slow, 1f - Mathf.Cos(t * Mathf.PI * 0.5f));
            simulatedTime += stepDuration;
            stepsToSlow++;
            if (stepsToSlow > 200) break;
        }

        int totalSteps = stepsFast + stepsToSlow;
        int currentOffset = ((finalOffset - totalSteps) % maxS + maxS) % maxS;

        // --- Fase 1: Velocidad constante ---
        for (int step = 0; step < stepsFast; step++)
        {
            currentOffset = (currentOffset + 1) % maxS;
            for (int i = 0; i < maxImage; i++)
                images[i].sprite = sprites[(currentOffset + i) % maxS];

            nombre_objeto.text = objetos[Random.Range(0, maxObjectContains - 1)];
            yield return new WaitForSeconds(T_fast);
        }

        // --- Fase 2: Frenado suave sinusoidal ---
        float elapsedSlow = 0f;
        for (int step = 0; step < stepsToSlow; step++)
        {
            currentOffset = (currentOffset + 1) % maxS;
            for (int i = 0; i < maxImage; i++)
                images[i].sprite = sprites[(currentOffset + i) % maxS];

            float t = Mathf.Clamp01(elapsedSlow / timeForSlowing);
            float stepDuration = Mathf.Lerp(T_fast, T_slow, 1f - Mathf.Cos(t * Mathf.PI * 0.5f));

            nombre_objeto.text = objetos[Random.Range(0, maxObjectContains - 1)];
            elapsedSlow += stepDuration;
            yield return new WaitForSeconds(stepDuration);
        }

        yield return null;

        nombre_objeto.text = objeto;

        iconoFalloAcierto.gameObject.SetActive(true);
        iconoFalloAcierto.sprite = acierto ? sprite_Acierto : sprite_Fallo;

        AudioSource sonido = acierto ? sonido_acierto : sonido_fallo;
        sonido.Play();

        yield return StartCoroutine(AnimacionIcono());

        yield return new WaitForSeconds(1f);

        iconoFalloAcierto.gameObject.SetActive(false);
        UIRoullete.SetActive(false);

        position++;
        if (position >= maxObjectContains) yield break;
        objeto = objetos[position];
        area_Product = areas_Product[position];
    }

    private IEnumerator AnimacionIcono()
    {
        // 1. Guardamos la posición original en el plano UI (RectTransform)
        Vector2 posicionOriginal = iconoFalloAcierto.rectTransform.anchoredPosition;

        float duracion = 1.0f; // Duración estricta de 1 segundo
        float tiempoTranscurrido = 0f;

        // --- Ajustes del Jitter (Ajusta a tu gusto) ---
        float intensidad = 25f; // Qué tan lejos se mueve a los lados (en píxeles)
        float velocidad = 35f;  // Qué tan rápido va de lado a lado (frecuencia)

        while (tiempoTranscurrido < duracion)
        {
            tiempoTranscurrido += Time.deltaTime;

            // Progreso de la animación de 0 a 1
            float progreso = tiempoTranscurrido / duracion;

            // Calculamos el movimiento -> <- usando Seno
            // Multiplicamos por (1f - progreso) para que la vibración se reduzca gradualmente hasta 0
            float offsetX = Mathf.Sin(tiempoTranscurrido * velocidad) * intensidad * (1f - progreso);

            // Aplicamos el desplazamiento solo en el eje X
            iconoFalloAcierto.rectTransform.anchoredPosition = new Vector2(posicionOriginal.x + offsetX, posicionOriginal.y);

            yield return null; // Espera al siguiente frame de renderizado
        }

        // 2. Aseguramos que al terminar quede EXACTAMENTE en la posición original
        iconoFalloAcierto.rectTransform.anchoredPosition = posicionOriginal;
    }

    private IEnumerator AnimacionUIAnuncios()
    {
        // 1. Activamos el objeto antes de empezar a escalarlo
        UIAnuncios.SetActive(true);

        // 2. Lo inicializamos en su escala inicial de 0.5
        UIAnuncios.transform.localScale = new Vector3(0.5f, 0.5f, 1f);

        float tiempo = 0f;
        float duracion = 0.25f; // Ajusta este tiempo (en segundos) según qué tan rápida quieras la animación

        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;
            float progreso = tiempo / duracion;

            // Interpolamos suavemente de 0.5f a 1f usando SmoothStep
            float escala = Mathf.SmoothStep(0.5f, 1f, progreso);

            // Aplicamos la escala en X e Y (Z se mantiene en 1 para UI)
            UIAnuncios.transform.localScale = new Vector3(escala, escala, 1f);

            yield return null; // Espera al siguiente frame
        }

        // 3. Nos aseguramos de que termine exactamente en 1
        UIAnuncios.transform.localScale = Vector3.one;
    }

    private void CrearListaObjetos()
    {
        HashSet<string> objetosSet = new();
        while (objetosSet.Count < maxObjectContains)
        {
            int producto = Random.Range(0, Areas._objetos_contiene - 1);
            int area = Random.Range(0, Areas._areas - 1);
            if (Areas.Objetos == null)
            {
                Debug.LogError("Objetos de areas esta en nulo");
                return;
            }
            if (objetosSet.Add(Areas.Objetos[area][producto]))
                areas_Product.Add((Areas.Area_product)area);
        }

        objetos = objetosSet.Distinct().ToList();
        objeto = objetos[position];
        area_Product = areas_Product[position];
    }

    void LimpiarListaObjetos()
    {
        objetos.Clear();
        areas_Product.Clear();
    }

    private void BTN_Aceptar()
    {
        Anuncios.Instancia.MostrarAnuncioRecompensa((bool exito) =>
        {
            if (!exito)
            {
                Debug.Log("El jugador no completo su anuncio");
                Notificacion.MostrarAlertaNativa(new NotificacionInformacionStruct(
                "Aviso", "No se pudo otorgar la recompensa. Asegúrate de ver el video completo.",
                "Notice", "Could not grant reward. Make sure to watch the full video.",
                "Aviso", "Não foi possível conceder a recompensa. Certifique-se de assistir ao vídeo completo."
                ));
                return;
            }

            position = 0;
            LimpiarListaObjetos();
            CrearListaObjetos();
            UIAnuncios.SetActive(false);
            UIRoullete.SetActive(false);
        });
    }

    private void BTN_Cancelar()
    {
        UIAnuncios.SetActive(false);
        UIRoullete.SetActive(false);
    }

    public void CancelarAnimacionUI()
    {
        StopAllCoroutines(); // por si AnimacionUI tenía sub-corutinas propias (AnimacionIcono, etc.)
        UIRoullete.SetActive(false);
        sonido_ruleta.Stop();
        iconoFalloAcierto.gameObject.SetActive(false);
    }
}
