using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool collectibleAcquired = false;
    public bool playerCanMove = false;
    [SerializeField] TMP_Text introText;
    [SerializeField] TMP_Text missionText;
    [SerializeField] TMP_Text indicatorText;
    private int currentScene;
    [SerializeField] Camera camera;

    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(LevelStart());
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

    private IEnumerator LevelStart()
    {   
        introText.enabled = true;
        yield return new WaitForSeconds(10f);
        introText.enabled = false;
        missionText.enabled = true;
        playerCanMove = true;
    }
}