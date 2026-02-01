using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image image;
    public float fadeDuration = 1f;

    void Start()
    {
        StartCoroutine(FadeOut());
    }

    // Call this to load any scene with fade
    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeAndLoad(sceneName));
    }

    IEnumerator FadeAndLoad(string sceneName)
    {
        yield return StartCoroutine(FadeIn());
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator FadeIn()
    {
        float t = 0;
        Color c = image.color;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            c.a = t / fadeDuration;
            image.color = c;
            yield return null;
        }
    }

    IEnumerator FadeOut()
    {
        float t = 0;
        Color c = image.color;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            c.a = 1f - (t / fadeDuration);
            image.color = c;
            yield return null;
        }
    }
}