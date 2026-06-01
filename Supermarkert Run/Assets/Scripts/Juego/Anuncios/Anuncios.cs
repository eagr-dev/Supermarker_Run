using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class Anuncios : MonoBehaviour
{

    [Tooltip("Activa para usar IDs de prueba. Desactiva para usar IDs reales.")]
    [SerializeField] private bool DevelopmentBuild = true; // CORREGIDO: Sin static

#if UNITY_EDITOR
    // En el editor de PC siempre usamos el ID de prueba
    private const string AD_UNIT_ID = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_ANDROID
    // CORREGIDO: Propiedad de instancia (sin static) para leer correctamente DevelopmentBuild
    private string AD_UNIT_ID 
    {
        get 
        {
            // Si la casilla está marcada en el Inspector
            if (DevelopmentBuild) 
            {
                return "ca-app-pub-3940256099942544/5224354917"; // ID de prueba
            }
            else 
            {
                // TODO: Recuerda cambiar esto por tu ID REAL de la consola de AdMob cuando pases a producción
                return "ca-app-pub-3940256099942544~3347511713"; 
            }
        }
    }
#else
    private const string AD_UNIT_ID = "ca-app-pub-3940256099942544/5224354917";
#endif


    public static Anuncios Instancia { get; private set; }
    private RewardedAd rewardedAd;

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MobileAds.Initialize( (InitializationStatus init) => 
        {
            Debug.Log("Inicializando anuncios");
            CargarAnuncioRecompensa();
        });
    }

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

}
