using UnityEngine;
using UnityEngine.UI;

public class SliderColorGradient : MonoBehaviour
{
    [Header("Referencias UI")]
    [SerializeField] private Slider mySlider;
    [SerializeField] private Image fillImage;

    [Header("Configuración de Color")]
    [SerializeField] private Gradient colorGradient;

    void Start()
    {
        // Si no los arrastraste en el inspector, intentamos buscarlos
        if (mySlider == null) mySlider = GetComponent<Slider>();
        if (fillImage == null && mySlider != null) fillImage = mySlider.fillRect.GetComponent<Image>();

        // Suscribirse al evento para detectar cuando cambia el valor
        if (mySlider != null)
        {
            mySlider.onValueChanged.AddListener(UpdateSliderColor);

            // Inicializar el color con el valor actual
            UpdateSliderColor(mySlider.value);
        }
    }

    void UpdateSliderColor(float value)
    {
        if (fillImage == null || mySlider == null) return;

        // Evaluamos el valor normalizado (0 a 1)
        float normalizedValue = Mathf.InverseLerp(mySlider.minValue, mySlider.maxValue, value);

        // Asignamos el color correspondiente del degradado
        fillImage.color = colorGradient.Evaluate(normalizedValue);
    }

    void OnDestroy()
    {
        // Buena práctica: desuscribirse del evento al destruir el objeto
        if (mySlider != null)
        {
            mySlider.onValueChanged.RemoveListener(UpdateSliderColor);
        }
    }
}