using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public bool isDone;

    public void PlayVideo()
    {
        GetComponent<VideoPlayer>().Play();
    }

    void OnEnable()
    {
        GetComponent<VideoPlayer>().loopPointReached += loopPointReached;
    }

    void OnDisable()
    {
        GetComponent<VideoPlayer>().loopPointReached -= loopPointReached;
    }

    void loopPointReached(VideoPlayer v)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().invincible = false;
        isDone = true;
        gameObject.SetActive(false);
    }
}
