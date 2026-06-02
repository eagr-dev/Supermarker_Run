using UnityEngine;
using GoogleMobileAds.Api;
using System;
using System.Collections;

public class Anuncios : MonoBehaviour
{

    [Tooltip("Activa para usar IDs de prueba. Desactiva para usar IDs reales.")]
    [SerializeField] private bool DevelopmentBuild = true;

#if UNITY_EDITOR
    private const string AD_UNIT_ID = "ca-app-pub-3940256099942544/5224354917";
    private const string BANNER_UNIT_ID = "ca-app-pub-3940256099942544/6300978111";
    private const string INTERSTITIAL_UNIT_ID = "ca-app-pub-3940256099942544/1033173712"; // 
#elif UNITY_ANDROID
    private string AD_UNIT_ID 
    {
        get { return DevelopmentBuild ? "ca-app-pub-3940256099942544/5224354917" : "ca-app-pub-TU_ID_RECOMPENSA_AQUI"; }
    }

    private string BANNER_UNIT_ID 
    {
        get { return DevelopmentBuild ? "ca-app-pub-3940256099942544/6300978111" : "ca-app-pub-TU_ID_BANNER_AQUI"; }
    }

    // El nuevo ID para los anuncios de pantalla completa (Penalizaciones)
    private string INTERSTITIAL_UNIT_ID 
    {
        get 
        {
            if (DevelopmentBuild) 
                return "ca-app-pub-3940256099942544/1033173712"; // ID Prueba Android
            else 
                return "ca-app-pub-TU_ID_REAL_INTERSTITIAL_AQUI"; 
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
        // La inicialización SIEMPRE debe ir en el Start para evitar conflictos de hilos nativos
        MobileAds.Initialize((InitializationStatus init) =>
        {
            Debug.Log("[AdMob] Inicializado correctamente.");
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
                Debug.LogError($"[AdMob] Falló la carga del anuncio: {error}");
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
            CargarAnuncioRecompensa(); // Precargamos el que sigue
        };

        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError($"[AdMob] Falló la reproducción del anuncio: {error}");
            CargarAnuncioRecompensa(); // Intentamos cargar otro si este falló
        };
    }

    // =========================================================================
    // LÓGICA DEL PANEL DE BANNER
    // =========================================================================

    public void SolicitudCargarBanner()
    {
        // Si ya existe un banner previo, lo destruimos para no duplicar memoria
        if (bannerView != null)
        {
            bannerView.Destroy();
            bannerView = null;
        }

        // Creamos un tamaño adaptativo estándar para teléfonos, posicionado abajo al centro (Bottom)
        bannerView = new BannerView(BANNER_UNIT_ID, AdSize.Banner, AdPosition.Top);

        var adRequest = new AdRequest();
        Debug.Log("[AdMob] Solicitando carga de Banner...");
        bannerView.LoadAd(adRequest);
    }

    // Función pública para mostrar el Banner en menús o tiendas
    public void MostrarBanner()
    {
        if (bannerView == null)
        {
            SolicitudCargarBanner();
        }
        else
        {
            Debug.Log("[AdMob] Mostrando Banner en pantalla.");
            bannerView.Show();
        }
    }

    // Función pública para ocultar el Banner (útil al iniciar el gameplay principal)</dt>
    public void OcultarBanner()
    {
        if (bannerView != null)
        {
            Debug.Log("[AdMob] Ocultando Banner de la pantalla.");
            bannerView.Hide();
        }
    }

    // Limpieza de memoria si se destruye el objeto
    private void OnDestroy()
    {
        if (bannerView != null)
        {
            bannerView.Destroy();
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

            // Suscribir eventos para cuando el jugador cierre el anuncio
            ad.OnAdFullScreenContentClosed += () =>
            {
                Debug.Log("[AdMob] Intersticial cerrado. Precargando el siguiente...");
                CargarAnuncioIntersticial(); // Clave: Precargar el siguiente de inmediato
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

            // Si el anuncio se muestra, ejecutamos la acción del juego en cuanto el usuario lo cierre
            interstitialAd.OnAdFullScreenContentClosed += () =>
            {
                onAdClosedCallback?.Invoke();
            };

            interstitialAd.Show();
        }
        else
        {
            Debug.LogWarning("[AdMob] El intersticial no estaba listo. Continuando juego sin interrupción.");
            // Si no hay internet o no cargó, dejamos que el juego continúe al instante para no romper la experiencia
            onAdClosedCallback?.Invoke();
        }
    }

    public void AumentarConteoPartidas(Action onAdClosedCallback)
    {
        conteoPartidas++;
        if (conteoPartidas >= 3)
        {
            Debug.Log($"[AdMob] Se alcanzó el límite de 3 partidas. Mostrando 1 anuncio...");

            conteoPartidas = 0; // Reiniciamos contador
            MostrarAnuncioIntersticial(onAdClosedCallback);
        }
        else
        {
            Debug.Log("[AdMob] Aún no toca anuncio. Continuando flujo...");
            onAdClosedCallback?.Invoke();
        }
    }
}
