using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class StartCreds : MonoBehaviour
{
    void Update()
    {
        if (GetComponent<VideoController>().isDone)
        {
            SceneManager.LoadScene("Credits");
        }
    }
}
