using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    public Sprite egypt;
    public Sprite france;
    public Sprite italy;
    public Sprite hawaii;
    public float fadeDuration = 0.5f;
    
    private Image image;
    private Sprite[] sprites;
    private int currentSpriteIndex = 0;

    void Start()
    {
        image = GetComponent<Image>();
        sprites = new Sprite[] { egypt, france, italy, hawaii };
        InvokeRepeating("FadeToNextImage", 0f, 10f);
    }

    void FadeToNextImage()
    {
        currentSpriteIndex = (currentSpriteIndex + 1) % sprites.Length;
        Sprite nextSprite = sprites[currentSpriteIndex];
        StartCoroutine(FadeToSprite(nextSprite));
    }

    IEnumerator FadeToSprite(Sprite nextSprite)
    {
        image.CrossFadeAlpha(0f, fadeDuration, false);
        yield return new WaitForSeconds(fadeDuration);
        image.sprite = nextSprite;
        image.CrossFadeAlpha(1f, fadeDuration, false);
    }
}
