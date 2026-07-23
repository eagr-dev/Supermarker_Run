using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Ump.Api;
using System;
using System.Collections;

public class Anuncios : MonoBehaviour
{

    [Tooltip("Activa para usar IDs de prueba. Desactiva para usar IDs reales.")]
    [SerializeField] private bool DevelopmentBuild = true;

    [Tooltip("Los ID de prueba y real para app ID de admon.")]
    [SerializeField] private string DevelopmentIDBuild = "ca-app-pub-3940256099942544~3347511713";
    [SerializeField] private string DeploymentIDBuild = "ca-app-pub-3641463045788683~3556593478";

    /// <summary>
    /// Activa la geografía de prueba de UMP para simular un usuario en la UE.
    /// Útil para probar el flujo de consentimiento sin estar físicamente en Europa.
    /// IMPORTANTE: Desactivar en producción.
    /// </summary>
    [Tooltip("Simula geografía de la UE para probar el flujo de consentimiento UMP. Desactivar en producción.")]
    [SerializeField] private bool testUmpGeography = false;

#if UNITY_EDITOR
    private const string AD_UNIT_ID = "ca-app-pub-3940256099942544/5224354917";
    private const string BANNER_UNIT_ID = "ca-app-pub-3940256099942544/6300978111";
    private const string INTERSTITIAL_UNIT_ID = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_ANDROID
    private string AD_UNIT_ID 
    {
        get { return DevelopmentBuild ? "ca-app-pub-3940256099942544/5224354917" : "ca-app-pub-3641463045788683/7451450924"; }
    }

    private string BANNER_UNIT_ID 
    {
        get { return DevelopmentBuild ? "ca-app-pub-3940256099942544/6300978111" : "ca-app-pub-3641463045788683/2835068977"; }
    }

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

    /// <summary>
    /// True cuando el flujo UMP ya terminó (sin importar si el usuario aceptó o rechazó).
    /// Los anuncios solo se cargan después de que esto sea true.
    /// </summary>
    public bool ConsentimentoGestionado { get; private set; } = false;

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
        // Paso 1: Gestionar consentimiento UMP antes de inicializar AdMob
        GestionarConsentimientoUMP();
    }


    // =========================================================================
    // LÓGICA UMP — CONSENTIMIENTO GDPR
    // =========================================================================

    /// <summary>
    /// Punto de entrada del flujo UMP.
    /// Solicita información de consentimiento y, si aplica, muestra el formulario al usuario.
    /// Solo inicializa AdMob al finalizar, sin importar la decisión del usuario.
    /// </summary>
    private void GestionarConsentimientoUMP()
    {
        var parametros = new ConsentRequestParameters();

        // Modo debug: fuerza geografía de la UE y restablece el estado de consentimiento previo
        // para poder ver el formulario en cada sesión durante pruebas.
        if (DevelopmentBuild || testUmpGeography)
        {
            parametros.ConsentDebugSettings = new ConsentDebugSettings
            {
                DebugGeography = DebugGeography.EEA,
                TestDeviceHashedIds = new System.Collections.Generic.List<string>
                {
                    // Agrega aquí el ID de tu dispositivo de prueba (se imprime en logcat
                    // como "Use new ConsentDebugSettings.TestDeviceHashedIds = ["XXXX"]")
                    // Ejemplo: "33BE2250B43518CCDA7DE426D04EE231"
                }
            };
        }

        ConsentInformation.Update(parametros, OnConsentInfoActualizado);
    }

    private void OnConsentInfoActualizado(FormError error)
    {
        if (error != null)
        {
            // Si falla la solicitud de info, inicializamos AdMob de todas formas
            // para no bloquear la experiencia del usuario en regiones sin GDPR.
            Debug.LogWarning($"[UMP] Error al actualizar info de consentimiento: {error.Message}. Inicializando AdMob de todas formas.");
            InicializarAdMob();
            return;
        }

        Debug.Log($"[UMP] Estado de consentimiento: {ConsentInformation.ConsentStatus}");
        Debug.Log($"[UMP] ¿Se puede mostrar formulario?: {ConsentInformation.IsConsentFormAvailable()}");

        // Si es necesario recopilar consentimiento y hay formulario disponible, mostrarlo.
        if (ConsentInformation.IsConsentFormAvailable() &&
            ConsentInformation.ConsentStatus == ConsentStatus.Required)
        {
            ConsentForm.LoadAndShowConsentFormIfRequired(OnFormCerrado);
        }
        else
        {
            // No se requiere consentimiento (fuera de la UE) o ya fue dado anteriormente.
            InicializarAdMob();
        }
    }

    private void OnFormCerrado(FormError error)
    {
        if (error != null)
        {
            Debug.LogWarning($"[UMP] Error en el formulario de consentimiento: {error.Message}");
        }
        else
        {
            Debug.Log($"[UMP] Formulario cerrado. Estado final: {ConsentInformation.ConsentStatus}");
        }

        // Siempre inicializamos AdMob al cerrar el formulario.
        // Si el usuario rechazó, AdMob simplemente no mostrará anuncios personalizados.
        InicializarAdMob();
    }

    /// <summary>
    /// Permite al usuario revisar o cambiar su consentimiento en cualquier momento
    /// (por ejemplo, desde un botón en el menú de ajustes del juego).
    /// </summary>
    public void MostrarOpcionesPrivacidad()
    {
        if (!ConsentInformation.IsConsentFormAvailable())
        {
            Debug.LogWarning("[UMP] No hay formulario de privacidad disponible.");
            return;
        }

        ConsentForm.ShowPrivacyOptionsForm((FormError error) =>
        {
            if (error != null)
                Debug.LogWarning($"[UMP] Error al mostrar opciones de privacidad: {error.Message}");
            else
                Debug.Log("[UMP] Usuario revisó sus opciones de privacidad.");
        });
    }

    /// <summary>
    /// Restablece el estado de consentimiento (solo para pruebas / QA).
    /// Nunca llamar en producción.
    /// </summary>
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public void RestablecerConsentimientoDebug()
    {
        ConsentInformation.Reset();
        Debug.LogWarning("[UMP] Estado de consentimiento restablecido (solo debug).");
    }


    // =========================================================================
    // INICIALIZACIÓN DE ADMOB
    // =========================================================================

    private void InicializarAdMob()
    {
        ConsentimentoGestionado = true;

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
    // LÓGICA DE RECOMPENSA (REWARDS)
    // =========================================================================

    private void CargarAnuncioRecompensa()
    {
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
                Debug.LogError($"[AdMob] Falló la carga del anuncio: {error}");
                return;
            }

            rewardedAd = ad;
            Debug.Log("[AdMob] Anuncio de recompensa cargado y listo.");

            SuscribirEventos(ad);
        });
    }

    public void MostrarAnuncioRecompensa(Action<bool> callbackRecompensa)
    {
        if (rewardedAd is not null && rewardedAd.CanShowAd())
        {
            bool accionRecompensa = false;

            rewardedAd.Show((Reward reward) =>
            {
                accionRecompensa = true;
                Debug.Log($"[AdMob] Recompensa otorgada: {reward.Amount} {reward.Type}");
            });

            rewardedAd.OnAdFullScreenContentClosed += () =>
            {
                Debug.Log("[AdMob] Anuncio cerrado. Enviando resultado a la clase...");
                callbackRecompensa?.Invoke(accionRecompensa);
                CargarAnuncioRecompensa();
            };
        }
        else
        {
            Debug.LogWarning("[AdMob] El anuncio no está listo todavía o falló la conexión.");
            Notificacion.MostrarAlertaNativa(new NotificacionInformacionStruct(
                "Anuncio no disponible", "El anuncio no está listo todavía o falló la conexión. Intenta de nuevo más tarde.",
                "Ad Unavailable", "The ad is not ready yet or the connection failed. Please try again later.",
                "Anúncio indisponível", "O anúncio ainda não está pronto ou a conexão falhou. Tente novamente mais tarde."
            ));
        }
    }

    private void SuscribirEventos(RewardedAd ad)
    {
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("[AdMob] Anuncio cerrado por el usuario. Cargando el siguiente...");
            CargarAnuncioRecompensa();
        };

        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError($"[AdMob] Falló la reproducción del anuncio: {error}");
            CargarAnuncioRecompensa();
        };
    }


    // =========================================================================
    // LÓGICA DEL PANEL DE BANNER
    // =========================================================================

    public void SolicitudCargarBanner()
    {
        if (!Inicializado)
        {
            Debug.LogWarning("[AdMob] Se intentó cargar un banner antes de terminar la inicialización.");
            return;
        }

        DestruirBannerInterno();

        bannerView = new BannerView(BANNER_UNIT_ID, AdSize.Banner, AdPosition.Top);

        bannerView.OnBannerAdLoaded += OnBannerLoaded;
        bannerView.OnBannerAdLoadFailed += OnBannerFailed;

        var adRequest = new AdRequest();
        Debug.Log("[AdMob] Solicitando carga de Banner...");
        bannerView.LoadAd(adRequest);

        StartCoroutine(TimeoutDestruccionBanner());
    }

    private void OnBannerLoaded()
    {
        Debug.Log("[AdMob] Banner cargado.");

        if (_pendingHide)
        {
            Debug.Log("[AdMob] Se detectó _pendingHide=true al cargar. Destruyendo banner.");
            DestruirBannerInterno();
        }
    }

    private void OnBannerFailed(LoadAdError error)
    {
        Debug.LogError($"[AdMob] Banner falló al cargar: {error}");

        if (_pendingHide)
        {
            Debug.Log("[AdMob] Banner falló pero _pendingHide=true. Limpiando referencia.");
            DestruirBannerInterno();
        }
    }

    private IEnumerator TimeoutDestruccionBanner()
    {
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
            Debug.LogWarning($"[AdMob] Excepción al destruir banner (ignorada): {e.Message}");
        }
        finally
        {
            bannerView = null;
            _pendingHide = false;
        }
    }

    [Obsolete("Hasta no encontrar solución de que realmente se muestra después de ocultar no usar")]
    public void MostrarBanner()
    {
        _pendingHide = false;

        if (bannerView != null)
        {
            Debug.Log("[AdMob] Banner ya existe, mostrando el existente.");
            bannerView.Show();
            return;
        }

        Debug.Log("[AdMob] Banner no existe, solicitando uno nuevo.");
        SolicitudCargarBanner();
    }

    [Obsolete("Hasta no encontrar solución de que realmente se oculte no usar")]
    public void OcultarBanner()
    {
        _pendingHide = true;

        if (bannerView != null)
        {
            DestruirBannerInterno();
        }
        else
        {
            Debug.Log("[AdMob] OcultarBanner llamado pero banner aún no existe. Flag activado, capas 2 y 3 lo manejarán.");
        }
    }

    private void OnDestroy()
    {
        if (bannerView != null)
        {
            DestruirBannerInterno();
        }
    }


    // =========================================================================
    // LÓGICA DEL INTERSTICIAL
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
                Debug.LogError($"[AdMob] Falló la carga del Intersticial: {error}");
                return;
            }

            interstitialAd = ad;
            Debug.Log("[AdMob] Anuncio Intersticial cargado y listo.");

            ad.OnAdFullScreenContentClosed += () =>
            {
                Debug.Log("[AdMob] Intersticial cerrado. Precargando el siguiente...");
                CargarAnuncioIntersticial();
            };

            ad.OnAdFullScreenContentFailed += (AdError adError) =>
            {
                Debug.LogError($"[AdMob] Falló la reproducción del Intersticial: {adError}");
                CargarAnuncioIntersticial();
            };
        });
    }

    public void MostrarAnuncioIntersticial(Action onAdClosedCallback)
    {
        if (interstitialAd is not null && interstitialAd.CanShowAd())
        {
            Debug.Log("[AdMob] Mostrando Intersticial de penalización.");

            interstitialAd.OnAdFullScreenContentClosed += () =>
            {
                onAdClosedCallback?.Invoke();
            };

            interstitialAd.Show();
        }
        else
        {
            Debug.LogWarning("[AdMob] El intersticial no estaba listo. Continuando juego sin interrupción.");
            onAdClosedCallback?.Invoke();
        }
    }

    public void AumentarConteoPartidas(Action onAdClosedCallback)
    {
        conteoPartidas++;
        if (conteoPartidas >= 3)
        {
            Debug.Log($"[AdMob] Se alcanzó el límite de 3 partidas. Mostrando 1 anuncio...");
            conteoPartidas = 0;
            MostrarAnuncioIntersticial(onAdClosedCallback);
        }
        else
        {
            Debug.Log("[AdMob] Aún no toca anuncio. Continuando flujo...");
            onAdClosedCallback?.Invoke();
        }
    }
}