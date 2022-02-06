using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoScene : MonoBehaviour
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
        GetComponent<VideoPlayer>().SetDirectAudioVolume(0, PlayerPrefs.GetFloat("Music", 1f));
        if (SceneManager.GetActiveScene().name.Equals("Game"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("Credits");
        }
        else
        {
            SceneManager.LoadScene("Game");
        }
        isDone = true;
        gameObject.SetActive(false);
    }
}
