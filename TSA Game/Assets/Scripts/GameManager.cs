using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool collectibleAcquired = false;
    [SerializeField] Text indicatorText;
    private int currentScene;

    // Start is called before the first frame update
    void Start()
    {
       currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (collectibleAcquired)
        {
            StartCoroutine(CollectibleCollected());
            collectibleAcquired = false;
        }
    }  

    public IEnumerator CollectibleCollected()
        {
        
            indicatorText.text = "Level Collectible Acquired";
            yield return new WaitForSeconds(5f);
            if (SceneManager.GetActiveScene().name == "Level 2")
                indicatorText.text = "Heading To Restaurant";

            else
            {
                indicatorText.text = "Heading To Next Level";
            }
            yield return new WaitForSeconds(3);
            int newScene = currentScene + 1;
            SceneManager.LoadScene(newScene);
        }
}