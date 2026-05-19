using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationIcon : MonoBehaviour
{
    [SerializeField] private List<RectTransform> rectTransforms;
    [SerializeField] private float MaxSize = 1.5f, TimeAnimation = 0.5f, TimeSleep = 5f;

    void Start()
    {
        if (rectTransforms != null)
        {
            foreach (RectTransform rectTransform in rectTransforms)
            {
                StartCoroutine(Animacion(rectTransform));
            }
        }
    }

    private IEnumerator Animacion(RectTransform icon)
    {
        Vector3 startScale = icon.localScale;
        Vector3 endScale = startScale * MaxSize;
        float elapsed = 0f;
        Animator anim = icon.GetComponent<Animator>();

        yield return new WaitForSeconds(TimeSleep);

        while (true)
        {
            if (anim != null) anim.enabled = false;
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

            if (anim != null) anim.enabled = true;

            yield return new WaitForSeconds(TimeSleep);
        }
    }
}