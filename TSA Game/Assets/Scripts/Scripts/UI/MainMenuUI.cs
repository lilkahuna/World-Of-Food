using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour {

    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Image blackScreenImage;
    [SerializeField] private float fadeDuration = 3f;

    private void Awake() {
        playButton.onClick.AddListener(() => {
            StartCoroutine(FadeToBlackAndLoadScene("Cutscene"));
        });
        quitButton.onClick.AddListener(() => {
            Application.Quit();
        });

        Time.timeScale = 1f;
    }

    private IEnumerator FadeToBlackAndLoadScene(string sceneName) {
    if (blackScreenImage == null) {
        Debug.LogError("The blackScreenImage variable is not assigned in the Inspector!");
        yield break;
    }

    float elapsedTime = 0f;
    while (elapsedTime < fadeDuration) {
        float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
        blackScreenImage.color = new Color(0f, 0f, 0f, alpha);
        yield return null;
        elapsedTime += Time.deltaTime;
    }
    blackScreenImage.color = Color.black;
    SceneManager.LoadScene(sceneName);
}
}