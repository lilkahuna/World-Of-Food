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
    [SerializeField] Text healthText;
    [SerializeField] Text gameOver;

    [Header("Booleans")]
    public bool collectibleAcquired = false;
    public bool playerCanMove = true;
    public bool restartPlayer = false;


    [SerializeField] GameObject fire;
    public PlayerScript playerScript;
    public int fireNumber = 1;
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

        healthText.text = ("Health: " + playerScript.health);

        if (playerScript.health == 0)
        {
            StartCoroutine(LevelFailed()); 
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
        gameOver.enabled = false;
        yield return new WaitForSeconds(4.8f);
        cam.cullingMask &= ~(1 << LayerMask.NameToLayer("Player"));
        cam.cullingMask&= ~(1 << LayerMask.NameToLayer("MiniMap"));
        yield return new WaitForSeconds(1f);
        introText.enabled = false;

        

        missionText.enabled = true;
        playerCanMove = true;   
    }

    private IEnumerator LevelFailed()
    {
        playerCanMove = false;
        gameOver.enabled = true;
        gameOver.text = "Mission Failed \n Try Again";
        GameObject[] fires = GameObject.FindGameObjectsWithTag("Fire");
        for(int i = 0; i < fires.Length; i++)
        {
            Destroy(fires[i].gameObject);
        }
        GameObject.Instantiate(fire, new Vector3(52, -198, 225), Quaternion.identity);
        GameObject.Instantiate(fire, new Vector3(157, -198, 121), Quaternion.identity);
        GameObject.Instantiate(fire, new Vector3(165, -198, 10), Quaternion.identity);
        GameObject.Instantiate(fire, new Vector3(50, -198, 10), Quaternion.identity);
        yield return new WaitForSeconds(5);
        restartPlayer = true;
        yield return new WaitForSeconds(1);
        gameOver.enabled = false;
        restartPlayer = false;
        playerCanMove = true;
        playerScript.health = 100;
    }
}