using UnityEngine;

public class AnimacionFondoMenu : MonoBehaviour
{
    [Header("Estrategia Activa (Halloween, Navidad, etc.)")]
    [SerializeField] private MonoBehaviour animationStrategyComponent;
    private IBackgroundAnimation _animationStrategy;

    void Awake()
    {
        // Validar y castear el componente asignado en el Inspector a la interfaz
        _animationStrategy = animationStrategyComponent as IBackgroundAnimation;

        if (_animationStrategy == null)
        {
            Debug.LogError($"[AnimacionFondoMenu] El objeto '{animationStrategyComponent.name}' no implementa IBackgroundAnimation.", this);
        }
    }

    void Start()
    {
        if (_animationStrategy == null) return;

        // 1. Inicializar estados (por ejemplo, verificar si ya se hizo hoy)
        _animationStrategy.Initialize();

        // 2. Ejecutar la animación solo si cumple la condición
        if (_animationStrategy.ShouldRun())
        {
            StartCoroutine(_animationStrategy.PlayAnimation());
        }
    }
}