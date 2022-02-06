using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menus : MonoBehaviour
{
    public bool active;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            transform.GetChild(0).gameObject.SetActive(true);

            if (transform.GetChild(0).gameObject.activeSelf)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                active = true;
                Time.timeScale = 0;
            }
        }
    }

    public void ResumeMM()
    {
        active = false;
        Time.timeScale = 1;
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        active = false;
        Time.timeScale = 1;
    }
}
