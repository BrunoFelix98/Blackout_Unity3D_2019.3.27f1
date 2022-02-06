using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadMenu : MonoBehaviour
{
    public void ReloadScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
