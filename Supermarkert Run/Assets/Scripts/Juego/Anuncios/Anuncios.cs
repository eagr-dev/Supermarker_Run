using UnityEngine;
using GoogleMobileAds.Api;
using System;
using System.Collections;

public class Anuncios : MonoBehaviour
{

    [Tooltip("Activa para usar IDs de prueba. Desactiva para usar IDs reales.")]
    [SerializeField] private bool DevelopmentBuild = true;

    [Tooltip("Los ID de prueba y real para app ID de admon.")]
    [SerializeField] private string DevelopmentIDBuild = "ca-app-pub-3940256099942544~3347511713";
    [SerializeField] private string DeploymentIDBuild = "ca-app-pub-3641463045788683~3556593478";

#if UNITY_EDITOR
    private const string AD_UNIT_ID = "ca-app-pub-3940256099942544/5224354917";
    private const string BANNER_UNIT_ID = "ca-app-pub-3940256099942544/6300978111";
    private const string INTERSTITIAL_UNIT_ID = "ca-app-pub-3940256099942544/1033173712"; // 
#elif UNITY_ANDROID
    private string AD_UNIT_ID 
    {
        get { return DevelopmentBuild ? "ca-app-pub-3940256099942544/5224354917" : "ca-app-pub-3641463045788683/7451450924"; }
    }

    private string BANNER_UNIT_ID 
    {
        get { return DevelopmentBuild ? "ca-app-pub-3940256099942544/6300978111" : "ca-app-pub-3641463045788683/2835068977"; }
    }

    // El nuevo ID para los anuncios de pantalla completa (Penalizaciones)
    private string INTERSTITIAL_UNIT_ID 
    {
        get 
        {
            if (DevelopmentBuild) 
                return "ca-app-pub-3940256099942544/1033173712"; // ID Prueba Android
            else 
                return "ca-app-pub-3641463045788683/7259879230"; 
        }
    }
#else
    private const string AD_UNIT_ID = "ca-app-pub-3940256099942544/5224354917";
    private const string BANNER_UNIT_ID = "ca-app-pub-3940256099942544/6300978111";
    private const string INTERSTITIAL_UNIT_ID = "ca-app-pub-3940256099942544/1033173712";
#endif

    public static Anuncios Instancia { get; private set; }

    private int conteoPartidas = 0;

    private RewardedAd rewardedAd;
    private BannerView bannerView;
    private InterstitialAd interstitialAd;
    public bool Inicializado { get; private set; } = false;
    private bool _pendingHide = false;

    private void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // La inicializaci�n SIEMPRE debe ir en el Start para evitar conflictos de hilos nativos
        MobileAds.Initialize((InitializationStatus init) =>
        {
            Debug.Log("[AdMob] Inicializado correctamente.");
            Inicializado = true;
            CargarAnuncioRecompensa();
            SolicitudCargarBanner();
            CargarAnuncioIntersticial();
        });
    }


    // =========================================================================
    // L�GICA DE RECOMPENSA (REWARDS)
    // =========================================================================
    private void CargarAnuncioRecompensa()
    {
        // Si ya hay uno cargado, lo limpiamos antes de pedir otro
        if (rewardedAd is not null)
        {
            rewardedAd.Destroy();
            rewardedAd = null;
        }

        var adRequest = new AdRequest();

        RewardedAd.Load(AD_UNIT_ID, adRequest, (RewardedAd ad, LoadAdError error) =>
        {
            if (error is not null)
            {
                Debug.LogError($"[AdMob] Fall� la carga del anuncio: {error}");
                return;
            }

            rewardedAd = ad;
            Debug.Log("[AdMob] Anuncio de recompensa cargado y listo.");

            // Suscribirnos al evento por si el anuncio se cierra, cargar el siguiente
            SuscribirEventos(ad);
        });
    }

    public void MostrarAnuncioRecompensa(Action<bool> callbackRecompensa)
    {
        if (rewardedAd is not null && rewardedAd.CanShowAd())
        {
            bool accionRecompensa = false; // Guardamos la recompensa a entregar

            rewardedAd.Show((Reward reward) =>
            {
                accionRecompensa = true;
                Debug.Log($"[AdMob] Recompensa otorgada: {reward.Amount} {reward.Type}");
            });

            rewardedAd.OnAdFullScreenContentClosed += () =>
            {
                Debug.Log("[AdMob] Anuncio cerrado. Enviando resultado a la clase...");

                callbackRecompensa?.Invoke(accionRecompensa);

                CargarAnuncioRecompensa(); // Precargamos el siguiente anuncio
            };
        }
        else
        {
            Debug.LogWarning("[AdMob] El anuncio no est� listo todav�a o fall� la conexi�n.");
            Notificacion.MostrarAlertaNativa(new NotificacionInformacionStruct(
            "Anuncio no disponible", "El anuncio no est� listo todav�a o fall� la conexi�n. Intenta de nuevo m�s tarde.",
            "Ad Unavailable", "The ad is not ready yet or the connection failed. Please try again later.",
            "An�ncio indispon�vel", "O an�ncio ainda n�o est� pronto ou a conex�o falhou. Tente novamente mais tarde."
            ));
        }
    }

    private void SuscribirEventos(RewardedAd ad)
    {
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("[AdMob] Anuncio cerrado por el usuario. Cargando el siguiente...");
            CargarAnuncioRecompensa(); // Precargamos el que sigue
        };

        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError($"[AdMob] Fall� la reproducci�n del anuncio: {error}");
            CargarAnuncioRecompensa(); // Intentamos cargar otro si este fall�
        };
    }

    // =========================================================================
    // L�GICA DEL PANEL DE BANNER
    // =========================================================================

    public void SolicitudCargarBanner()
    {
        if (!Inicializado)
        {
            Debug.LogWarning("[AdMob] Se intentó cargar un banner antes de terminar la inicialización.");
            return;
        }

        // Si ya existe uno, destruir antes de crear otro
        DestruirBannerInterno();

        bannerView = new BannerView(BANNER_UNIT_ID, AdSize.Banner, AdPosition.Top);

        // ═══ CAPA 2: Suscribir eventos ANTES de cargar ═══
        // Si se pidió ocultar mientras cargaba, el evento lo detecta al terminar
        bannerView.OnBannerAdLoaded += OnBannerLoaded;
        bannerView.OnBannerAdLoadFailed += OnBannerFailed;

        var adRequest = new AdRequest();
        Debug.Log("[AdMob] Solicitando carga de Banner...");
        bannerView.LoadAd(adRequest);

        // ═══ CAPA 3: Coroutine de timeout (fallback de 2s) ═══
        // Si AdMob nunca dispara el evento (crash interno), este coroutine termina igual
        StartCoroutine(TimeoutDestruccionBanner());
    }

    private void OnBannerLoaded()
    {
        Debug.Log("[AdMob] Banner cargado.");

        // ═══ CAPA 2 en acción ═══
        // Si mientras cargaba alguien llamó OcultarBanner(), lo destruimos ahora
        if (_pendingHide)
        {
            Debug.Log("[AdMob] Se detectó _pendingHide=true al cargar. Destruyendo banner.");
            DestruirBannerInterno();
        }
    }

    private void OnBannerFailed(LoadAdError error)
    {
        Debug.LogError($"[AdMob] Banner falló al cargar: {error}");

        // Misma lógica: si se pidió ocultar, limpiar referencia de todas formas
        if (_pendingHide)
        {
            Debug.Log("[AdMob] Banner falló pero _pendingHide=true. Limpiando referencia.");
            DestruirBannerInterno();
        }
    }

    private IEnumerator TimeoutDestruccionBanner()
    {
        // Esperar máximo 2 segundos. Si para entonces _pendingHide sigue true
        // y bannerView no fue destruido, forzamos la destrucción.
        yield return new WaitForSeconds(2f);

        if (_pendingHide && bannerView != null)
        {
            Debug.LogWarning("[AdMob] Timeout alcanzado con _pendingHide=true. Destruyendo banner a la fuerza.");
            DestruirBannerInterno();
        }
    }

    /// <summary>
    /// Método interno centralizado para destruir el banner.
    /// Todo pasa por aquí — nunca llamar Destroy() directamente desde fuera.
    /// </summary>
    private void DestruirBannerInterno()
    {
        if (bannerView == null) return;

        try
        {
            bannerView.OnBannerAdLoaded -= OnBannerLoaded;
            bannerView.OnBannerAdLoadFailed -= OnBannerFailed;
            bannerView.Destroy();
        }
        catch (Exception e)
        {
            // AdMob a veces lanza si el estado nativo es inválido. Ignoramos — ya limpiamos.
            Debug.LogWarning($"[AdMob] Excepción al destruir banner (ignorada): {e.Message}");
        }
        finally
        {
            // null SIEMPRE, sin importar si Destroy() lanzó o no
            bannerView = null;
            _pendingHide = false;
        }
    }

    [Obsolete("Hasta no encontrar solucion de que realmente se muestra despues de ocultar no usar")]
    public void MostrarBanner()
    {
        _pendingHide = false;

        // Si ya existe un banner vivo, solo mostrarlo — no crear otro
        if (bannerView != null)
        {
            Debug.Log("[AdMob] Banner ya existe, mostrando el existente.");
            bannerView.Show();
            return;
        }

        // Solo llega aquí si fue destruido (después de un gameplay)
        Debug.Log("[AdMob] Banner no existe, solicitando uno nuevo.");
        SolicitudCargarBanner();
    }

    [Obsolete("Hasta no encontrar solucion de que realmente se oculte no usar")]
    public void OcultarBanner()
    {
        // ═══ CAPA 1: Flag inmediato ═══
        // Se activa antes de cualquier async — cualquier callback lo verá
        _pendingHide = true;

        if (bannerView != null)
        {
            // Si ya existe y está listo, destruir directo
            DestruirBannerInterno();
        }
        else
        {
            Debug.Log("[AdMob] OcultarBanner llamado pero banner aún no existe. Flag activado, capas 2 y 3 lo manejarán.");
        }
    }

    // Quitar el viejo IEnumerator DestruirBannerSeguro() — ya no se necesita
    // La lógica está integrada en las 3 capas

    private void OnDestroy()
    {
        if (bannerView != null)
        {
            DestruirBannerInterno();
        }
    }

    // =========================================================================
    // L�GICA DEL INTERSTICIAL
    // =========================================================================
    private void CargarAnuncioIntersticial()
    {
        if (interstitialAd is not null)
        {
            interstitialAd.Destroy();
            interstitialAd = null;
        }

        var adRequest = new AdRequest();
        Debug.Log("[AdMob] Solicitando carga de Intersticial...");

        InterstitialAd.Load(INTERSTITIAL_UNIT_ID, adRequest, (InterstitialAd ad, LoadAdError error) =>
        {
            if (error is not null)
            {
                Debug.LogError($"[AdMob] Fall� la carga del Intersticial: {error}");
                return;
            }

            interstitialAd = ad;
            Debug.Log("[AdMob] Anuncio Intersticial cargado y listo.");

            // Suscribir eventos para cuando el jugador cierre el anuncio
            ad.OnAdFullScreenContentClosed += () =>
            {
                Debug.Log("[AdMob] Intersticial cerrado. Precargando el siguiente...");
                CargarAnuncioIntersticial(); // Clave: Precargar el siguiente de inmediato
            };

            ad.OnAdFullScreenContentFailed += (AdError adError) =>
            {
                Debug.LogError($"[AdMob] Fall� la reproducci�n del Intersticial: {adError}");
                CargarAnuncioIntersticial();
            };
        });
    }
    public void MostrarAnuncioIntersticial(Action onAdClosedCallback)
    {
        if (interstitialAd is not null && interstitialAd.CanShowAd())
        {
            Debug.Log("[AdMob] Mostrando Intersticial de penalizaci�n.");

            // Si el anuncio se muestra, ejecutamos la acci�n del juego en cuanto el usuario lo cierre
            interstitialAd.OnAdFullScreenContentClosed += () =>
            {
                onAdClosedCallback?.Invoke();
            };

            interstitialAd.Show();
        }
        else
        {
            Debug.LogWarning("[AdMob] El intersticial no estaba listo. Continuando juego sin interrupci�n.");
            // Si no hay internet o no carg�, dejamos que el juego contin�e al instante para no romper la experiencia
            onAdClosedCallback?.Invoke();
        }
    }

    public void AumentarConteoPartidas(Action onAdClosedCallback)
    {
        conteoPartidas++;
        if (conteoPartidas >= 3)
        {
            Debug.Log($"[AdMob] Se alcanz� el l�mite de 3 partidas. Mostrando 1 anuncio...");

            conteoPartidas = 0; // Reiniciamos contador
            MostrarAnuncioIntersticial(onAdClosedCallback);
        }
        else
        {
            Debug.Log("[AdMob] A�n no toca anuncio. Continuando flujo...");
            onAdClosedCallback?.Invoke();
        }
    }
}