using System.Collections;
using UnityEngine;

public class AnimationIcon : MonoBehaviour
{
    [SerializeField] private RectTransform MisionesIcon, TOIcon;
    [SerializeField] private float MaxSize = 1.5f, TimeAnimation = 0.5f, TimeSleep = 5f;

    void Start()
    {
        StartCoroutine(Animacion(MisionesIcon));
        StartCoroutine(Animacion(TOIcon));
    }

    private IEnumerator Animacion(RectTransform icon)
    {
        Vector3 startScale = icon.localScale;
        Vector3 endScale = startScale * MaxSize;
        float elapsed = 0f;

        yield return new WaitForSeconds(TimeSleep);

        while (true)
        {
            // Crece
            elapsed = 0f;
            while (elapsed < TimeAnimation)
            {
                float t = elapsed / TimeAnimation;
                float tEased = t * (2 - t);
                icon.localScale = Vector3.Lerp(startScale, endScale, tEased);
                elapsed += Time.deltaTime;
                yield return null;
            }
            icon.localScale = endScale;

            // Encoge
            elapsed = 0f;
            while (elapsed < TimeAnimation)
            {
                float t = elapsed / TimeAnimation;
                float tEased = t * (2 - t);
                icon.localScale = Vector3.Lerp(endScale, startScale, tEased);
                elapsed += Time.deltaTime;
                yield return null;
            }
            icon.localScale = startScale;

            yield return new WaitForSeconds(TimeSleep);
        }
    }
}