using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    [Header("Text Objects References")]
    [SerializeField] TMP_Text introText;
    [SerializeField] Text missionText;
    [SerializeField] TMP_Text indicatorText;

    [Header("Booleans")]
    public bool collectibleAcquired = false;
    public bool playerCanMove = true;

    


    private int currentScene;
    [SerializeField] Camera cam;
    Color limegreen = new Vector4(0.12f, 1, 0, 1);

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
        playerCanMove = false;
        indicatorText.text = "Mission Accomplished: Level Collectible Acquired";
        missionText.color = limegreen;
        yield return new WaitForSeconds(5f);

        for (int i=0; i<4; i++)
        {
            indicatorText.text = "Heading To Next Level.";
            yield return new WaitForSeconds(.5f);
            indicatorText.text = "Heading To Next Level..";
            yield return new WaitForSeconds(.5f);
            indicatorText.text = "Heading To Next Level...";
            yield return new WaitForSeconds(.5f);
        }

        Debug.Log("Hooray");
        int newScene = currentScene + 1;
        SceneManager.LoadScene(newScene);
    }

    private IEnumerator LevelStart()
    {   
        introText.enabled = true;
        missionText.enabled = false;
        yield return new WaitForSeconds(4.8f);
        cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Don't Show"));
        yield return new WaitForSeconds(1f);
        introText.enabled = false;

        

        missionText.enabled = true;
        playerCanMove = true;   
    }
}