using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class sleepScript : MonoBehaviour
{
    public RawImage rawImage;      
    public float fadeDuration = 2f; 
    public float holdDuration = 2f;
    public bool react;
    public bool fed;
    public GameObject bears;
    void Start()
    {
        fed = false;
        StartCoroutine(FadeInOut());
    }
    private void Update()
    {
        if (react)
        {
            bears.active = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                PlayerPrefs.SetInt("foodCount", PlayerPrefs.GetInt("foodCount") - 3);
                react = false;
                fed = true;
            }
        }
        else { bears.active = false; }
    }
    IEnumerator FadeInOut()
    {
        Color c = rawImage.color;
        c.a = 0f;
        rawImage.color = c;

        yield return StartCoroutine(Fade(0f, 1f, fadeDuration));

        if (Random.Range(0, 2) == 1)
        {
            transform.GetChild(1).gameObject.active = true;
            react = true;
            yield return new WaitForSeconds(holdDuration * 5);
            if (!fed&& Random.Range(0,2)==1) { SceneManager.LoadScene(3); }
            react = false;
            transform.GetChild(1).gameObject.active = false;
           
        }
        else
        {
            yield return new WaitForSeconds(holdDuration);

        }

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
        var temp = PlayerPrefs.GetInt("day");
        PlayerPrefs.SetInt("day", temp+1);
    }
}
