using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public float delayTime = 1f; // added delay time
    public float fadeTime = 1f;

    private Image fadeImage;

    void Start()
    {
        fadeImage = GetComponentInChildren<Image>();
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        fadeImage.color = new Color(0f, 0f, 0f, 255f);
        yield return new WaitForSeconds(delayTime); // added delay

        float t = 0f;

        while (t < fadeTime)
        {
            t += Time.deltaTime;
            float normalizedTime = t / fadeTime;

            fadeImage.color = new Color(0f, 0f, 0f, 1f - normalizedTime);

            yield return null;
        }

        Destroy(gameObject);
    }
}
