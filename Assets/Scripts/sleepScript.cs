using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class sleepScript : MonoBehaviour
{
    public RawImage rawImage;      // Assign in Inspector
    public float fadeDuration = 2f; // Time to fade in/out
    public float holdDuration = 2f; // Time to wait at full opacity

    void Start()
    {
        
        StartCoroutine(FadeInOut());
    }

    IEnumerator FadeInOut()
    {
        // Start transparent
        Color c = rawImage.color;
        c.a = 0f;
        rawImage.color = c;

        // Fade in
        yield return StartCoroutine(Fade(0f, 1f, fadeDuration));

        // Wait at full opacity
        yield return new WaitForSeconds(holdDuration);

        // Fade out
        yield return StartCoroutine(Fade(1f, 0f, fadeDuration));
    }

    IEnumerator Fade(float startAlpha, float endAlpha, float duration)
    {
        float timer = 0f;
        Color c = rawImage.color;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;
            c.a = Mathf.Lerp(startAlpha, endAlpha, t);
            rawImage.color = c;
            yield return null;
        }

        c.a = endAlpha;
        rawImage.color = c;
    }
}
