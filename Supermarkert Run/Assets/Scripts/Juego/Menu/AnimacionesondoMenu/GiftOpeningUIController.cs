using UnityEngine;
using UnityEngine.UI;
using TMPro; // <--- Importante para usar TextMeshPro
using System.Collections;

public class GiftOpeningUIController : MonoBehaviour
{
    [Header("Padre y Contenedores")]
    [SerializeField] private GameObject panelPadre;

    [Header("Imágenes del Regalo")]
    [SerializeField] private GameObject imgRegaloCerrado;
    [SerializeField] private GameObject imgTapa;
    [SerializeField] private GameObject imgBaseRegalo;
    [SerializeField] private Image imgBrilloFondo;

    [Header("Recompensa")]
    [SerializeField] private GameObject imgRecompensa;
    [SerializeField] private Sprite imgDinero;
    [SerializeField] private TextMeshProUGUI txtRecompensa; // <--- Referencia al componente TMP

    [Header("Botones")]
    [SerializeField] private GameObject btnReintentarAnuncio;
    [SerializeField] private GameObject btnObtener;

    [Header("Dinero")]
    [SerializeField] private TextMeshProUGUI txtDinero;

    public static readonly string GiftClaimed = "GiftClaime";
    public static event System.Action OnRecompensaReclamada;

    enum TipoRegalo
    { DINERO, SKIN, SOMBRERO }
    TipoRegalo tipo;
    const int tipoDinero = 85, tipoSkin = 95, tipoSombrero = 100;

    //REGALOS
    int cantidadRegalo;
    


    // Método para activar toda la UI y lanzar la secuencia
    public void IniciarAperturaRegalo()
    {
        int regaloDar = UnityEngine.Random.Range(0, 100);

        tipo = regaloDar switch
        {
            >= 0 and <= tipoDinero => TipoRegalo.DINERO,
            > tipoDinero and <= tipoSkin => TipoRegalo.SKIN,
            > tipoSkin and <= tipoSombrero => TipoRegalo.SOMBRERO,
            _ => TipoRegalo.DINERO
        };

        // Cambiar sprite y texto según el tipo de regalo
        Image imageRe = imgRecompensa.GetComponent<Image>();

        cantidadRegalo = tipo switch
        {
            TipoRegalo.DINERO => UnityEngine.Random.Range(1, 100),
            TipoRegalo.SKIN => UnityEngine.Random.Range(0, BuildStructs.PCMG.GetCountSkins()),
            TipoRegalo.SOMBRERO => UnityEngine.Random.Range(0, BuildStructs.PCMG.GetCountSombreros()),
            _ => 0 // Caso por defecto obligatorio en expresiones switch
        };

        var PCMG = BuildStructs.PCMG;
        switch (tipo)
        {
            case TipoRegalo.DINERO:
                imageRe.sprite = imgDinero;
                string monedas = Idioma.GetLengua() switch
                {
                    Idioma.Lengua.ESPANIOL => "Monedas",
                    Idioma.Lengua.INGLES => "Coins",
                    Idioma.Lengua.PORTUGUES => "Moedas",
                    _ => "Monedas" // Caso por defecto obligatorio en expresiones switch
                };
                txtRecompensa.text = $"+{cantidadRegalo} {monedas}";
                break;
            case TipoRegalo.SKIN:
                string skin = Idioma.GetLengua() switch
                {
                    Idioma.Lengua.ESPANIOL => $"¡Nueva Skin! {PCMG.GetSkin(cantidadRegalo).nombre_espaniol}",
                    Idioma.Lengua.INGLES => $"New Skin! {PCMG.GetSkin(cantidadRegalo).nombre_ingles}",
                    Idioma.Lengua.PORTUGUES => $"Nova Skin! {PCMG.GetSkin(cantidadRegalo).nombre_portugues}",
                    _ => $"¡Nueva Skin! {PCMG.GetSkin(cantidadRegalo).nombre_espaniol}" // Caso por defecto obligatorio en expresiones switch
                };
                txtRecompensa.text = skin;
                imageRe.color = PCMG.GetSkin(cantidadRegalo).color;
                if (PCMG.GetSkin(cantidadRegalo).icono != null)
                    imageRe.sprite = PCMG.GetSkin(cantidadRegalo).icono;
                break;
            case TipoRegalo.SOMBRERO:
                string sombrero = Idioma.GetLengua() switch
                {
                    Idioma.Lengua.ESPANIOL => $"¡Nuevo Sombrero! {PCMG.GetSombrero(cantidadRegalo).nombre_espaniol}",
                    Idioma.Lengua.INGLES => $"New Hat! {PCMG.GetSombrero(cantidadRegalo).nombre_ingles}",
                    Idioma.Lengua.PORTUGUES => $"Novo Chapéu! {PCMG.GetSombrero(cantidadRegalo).nombre_portugues}",
                    _ => $"¡Nuevo Sombrero! {PCMG.GetSombrero(cantidadRegalo).nombre_espaniol}" // Caso por defecto obligatorio en expresiones switch
                };
                txtRecompensa.text = sombrero;
                imageRe.sprite = PCMG.GetSombrero(cantidadRegalo).icon;
                break;
        }

        panelPadre.SetActive(true);
        StartCoroutine(SecuenciaAperturaCofre());
    }

    private IEnumerator SecuenciaAperturaCofre()
    {
        // Estado inicial: solo se ve el regalo cerrado, ocultamos lo demás
        imgRegaloCerrado.SetActive(true);
        imgTapa.SetActive(false);
        imgBaseRegalo.SetActive(false);
        imgRecompensa.SetActive(false);
        if (txtRecompensa != null) txtRecompensa.gameObject.SetActive(false); // Ocultar texto al inicio
        imgBrilloFondo.gameObject.SetActive(false);
        btnReintentarAnuncio.SetActive(false);
        btnObtener.SetActive(false);

        // ==========================================
        // PASO 1: LA "LUCHA" (Sacudida del regalo)
        // ==========================================
        float tiempoLucha = 0.8f;
        float elapsed = 0f;
        Vector3 posOriginal = imgRegaloCerrado.transform.localPosition;

        while (elapsed < tiempoLucha)
        {
            elapsed += Time.deltaTime;
            // Efecto de temblor usando Seno
            float offsetX = Mathf.Sin(elapsed * 40f) * 10f;
            imgRegaloCerrado.transform.localPosition = posOriginal + new Vector3(offsetX, 0f, 0f);
            yield return null;
        }
        imgRegaloCerrado.transform.localPosition = posOriginal;

        // ==========================================
        // PASO 2: APERTURA (Cambio a Tapa y Base + Brillo)
        // ==========================================
        imgRegaloCerrado.SetActive(false);
        imgBaseRegalo.SetActive(true);
        imgTapa.SetActive(true);

        // Mostrar y animar el brillo de fondo
        imgBrilloFondo.gameObject.SetActive(true);
        StartCoroutine(AnimarBrillo(0.8f));

        // Mover la tapa hacia arriba y rotarla un poco simulando que se abre
        float tiempoTapa = 0.3f;
        elapsed = 0f;
        Vector3 tapaPosIni = imgTapa.transform.localPosition;
        Vector3 tapaPosFin = tapaPosIni + new Vector3(50f, 100f, 0f);

        while (elapsed < tiempoTapa)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / tiempoTapa;
            imgTapa.transform.localPosition = Vector3.Lerp(tapaPosIni, tapaPosFin, t);
            yield return null;
        }

        // ==========================================
        // PASO 3: EL OBJETO Y EL TEXTO SALEN VOLANDO CON REBOTE
        // ==========================================
        imgRecompensa.SetActive(true);
        if (txtRecompensa != null) txtRecompensa.gameObject.SetActive(true);

        RectTransform rectRecompensa = imgRecompensa.GetComponent<RectTransform>();
        RectTransform rectTexto = txtRecompensa != null ? txtRecompensa.GetComponent<RectTransform>() : null;

        Vector3 recompensaPosInicio = imgBaseRegalo.transform.localPosition;
        Vector3 recompensaPosPico = recompensaPosInicio + new Vector3(0f, 150f, 0f); // Sube más de la cuenta
        Vector3 recompensaPosFinal = recompensaPosInicio + new Vector3(0f, 0f, 0f);  // Baja y se queda en su sitio (rebote)

        float tiempoVuelo = 0.4f;
        elapsed = 0f;

        // Fase subida al pico
        while (elapsed < tiempoVuelo)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / tiempoVuelo;

            Vector3 currentPos = Vector3.Lerp(recompensaPosInicio, recompensaPosPico, Mathf.SmoothStep(0f, 1f, t));
            Vector3 currentScale = Vector3.Lerp(Vector3.zero, Vector3.one * 1.2f, t);

            rectRecompensa.localPosition = currentPos;
            rectRecompensa.localScale = currentScale;

            if (rectTexto != null)
            {
                rectTexto.localPosition = currentPos + new Vector3(0f, -60f, 0f); // Un poco abajo de la imagen
                rectTexto.localScale = currentScale;
            }

            yield return null;
        }

        // Fase rebote hacia abajo hasta la posición final
        elapsed = 0f;
        while (elapsed < 0.2f)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / 0.2f;

            Vector3 currentPos = Vector3.Lerp(recompensaPosPico, recompensaPosFinal, Mathf.SmoothStep(0f, 1f, t));
            Vector3 currentScale = Vector3.Lerp(Vector3.one * 1.2f, Vector3.one, t);

            rectRecompensa.localPosition = currentPos;
            rectRecompensa.localScale = currentScale;

            if (rectTexto != null)
            {
                rectTexto.localPosition = currentPos + new Vector3(0f, -60f, 0f);
                rectTexto.localScale = currentScale;
            }

            yield return null;
        }

        // ==========================================
        // PASO 4: APARECEN LOS BOTONES
        // ==========================================
        btnReintentarAnuncio.SetActive(true);
        btnObtener.SetActive(true);
    }

    private IEnumerator AnimarBrillo(float duracion)
    {
        float elapsed = 0f;
        RectTransform rectBrillo = imgBrilloFondo.GetComponent<RectTransform>();
        rectBrillo.localScale = Vector3.zero;

        Color colorOriginal = imgBrilloFondo.color;

        while (elapsed < duracion)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duracion;
            rectBrillo.localScale = Vector3.Lerp(Vector3.zero, Vector3.one * 1.5f, Mathf.SmoothStep(0f, 1f, t));

            // Hacer un fade-in rápido del alfa
            colorOriginal.a = Mathf.Lerp(0f, 0.8f, t);
            imgBrilloFondo.color = colorOriginal;
            yield return null;
        }
    }

    // =========================================================================
    // MÉTODOS PARA LOS BOTONES DE LA UI
    // =========================================================================

    public void OnClickReintentarConAnuncio()
    {
        btnReintentarAnuncio.SetActive(false);
        btnObtener.SetActive(false);

        if (Anuncios.Instancia != null)
        {
            Anuncios.Instancia.MostrarAnuncioRecompensa((bool recompensaObtenida) =>
            {
                if (recompensaObtenida)
                {
                    Debug.Log("[GiftOpeningUIController] Anuncio visto con éxito. Otorgando nuevo intento / recompensa extra...");
                    IniciarAperturaRegalo();
                }
                else
                {
                    Debug.Log("[GiftOpeningUIController] El usuario cerró el anuncio antes de tiempo. No hay recompensa.");
                    btnReintentarAnuncio.SetActive(true);
                    btnObtener.SetActive(true);
                }
            });
        }
        else
        {
            Debug.LogWarning("[GiftOpeningUIController] No se encontró la instancia de la clase Anuncios en la escena.");
            btnReintentarAnuncio.SetActive(true);
            btnObtener.SetActive(true);
        }
    }

    public void OnClickObtenerRecompensa()
    {
        Debug.Log("[GiftOpeningUIController] Recompensa aceptada. Cerrando interfaz.");

        switch (tipo)
        {
            case TipoRegalo.DINERO:
                BuildStructs.Dinero.Set_Agregar((uint)cantidadRegalo);
                txtDinero.text = BuildStructs.Dinero.Get_Dinero().ToString();
                break;
            case TipoRegalo.SKIN:
                 var skin = BuildStructs.PCMG.GetSkin(cantidadRegalo);
                skin.precio = 0;
                BuildStructs.PCMG.SetSkin(cantidadRegalo, skin);
                break;
            case TipoRegalo.SOMBRERO:
                BuildStructs.PCMG.SetSombreroComprado(cantidadRegalo);
                break;
        }

        OnRecompensaReclamada?.Invoke();

        FindAnyObjectByType<Sistema_Guardado>().GuardarLocal();

        PlayerPrefs.SetInt(GiftClaimed, 1);

        if (panelPadre != null)
        {
            panelPadre.SetActive(false);
        }
    }
}