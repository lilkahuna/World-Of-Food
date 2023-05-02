using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    //public string Egypt;
    public string url;
    public string Egypt;

    private VideoPlayer videoPlayer;

    private void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.url = url;
        
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            Play();
        }
    }

    public void Play()
    {
        videoPlayer.Play();
        videoPlayer.isLooping = false;
        StartCoroutine(TimerMethod());
        //SceneManager.LoadScene("Egypt");
    }

    public IEnumerator TimerMethod()
    {
        yield return new WaitForSeconds(31);
        SceneManager.LoadScene("Egypt");
    }
}
