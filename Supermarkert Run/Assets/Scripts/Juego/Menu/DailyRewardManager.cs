using UnityEngine;
using UnityEngine.EventSystems;

public class DailyRewardManager : MonoBehaviour
{
    public static DailyRewardManager Instance;

    [Header("Configuración de Interacción")]
    [SerializeField] private bool isUIElement = false; // Cambiará a true si en otra temporada usas UI
    [SerializeField] private Transform target3DObject; // El regalo 3D actual
    [Header("Controlador de UI de Apertura")]
    [SerializeField] private GiftOpeningUIController giftUIController;

    private bool canInteract = false;


    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void EnableInteraction(bool enable)
    {
        canInteract = enable;
    }

    void Update()
    {
        if (!canInteract) return;

        // Si tu temporada actual usa 3D (como Navidad o Halloween)
        if (!isUIElement)
        {
            DetectTouchOrClick3D();
        }
        // Si en el futuro cambias a UI, el manager puede ignorar el raycast 
        // porque los botones de UI ya manejan sus propios eventos táctiles nativos.
    }

    private void DetectTouchOrClick3D()
    {
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Vector3 inputPosition = Input.touchCount > 0 ? (Vector3)Input.GetTouch(0).position : Input.mousePosition;

            // Evitar que toque si hace clic sobre una UI superpuesta
            if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
                return;

            Ray ray = Camera.main.ScreenPointToRay(inputPosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (target3DObject != null && hit.transform == target3DObject)
                {
                    OpenRewardFlow();
                }
            }
        }
    }

    private void OpenRewardFlow()
    {
        canInteract = false;
        Debug.Log("¡Recompensa reclamada! Abriendo panel común de anuncios / intentos...");

        // AQUÍ LLAMAS A TU LÓGICA GENERAL:
        // - Mostrar panel de monedas / puntos.
        // - Mostrar opción: "¿Ver anuncio para otro intento?"
        if (giftUIController != null)
        {
            giftUIController.IniciarAperturaRegalo();
        }
        else
        {
            Debug.LogError("[DailyRewardManager] Falta asignar el GiftOpeningUIController en el Inspector.", this);
        }
    }
}