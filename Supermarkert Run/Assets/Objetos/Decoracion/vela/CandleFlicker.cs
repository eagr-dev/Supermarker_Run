using UnityEngine;

public class CandleFlicker : MonoBehaviour
{
    private Light candleLight;
    public float minIntensity = 12f;
    public float maxIntensity = 18f;
    public float flickerSpeed = 0.08f;

    void Start()
    {
        candleLight = GetComponent<Light>();
        StartCoroutine(FlickerRoutine());
    }

    System.Collections.IEnumerator FlickerRoutine()
    {
        while (true)
        {
            candleLight.intensity = Random.Range(minIntensity, maxIntensity);
            yield return new WaitForSeconds(flickerSpeed);
        }
    }
}