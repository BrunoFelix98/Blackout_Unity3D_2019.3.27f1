using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [System.Serializable]
    public class Action
    {
        public Color color;
        public Sprite sprite;
        public string name;
        public bool unlocked;
    }

    public Action[] options;

    public bool MenuActive;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Cursor.lockState = CursorLockMode.None;
            RadialMenuSpawner.instance.SpawnMenu(this);
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (Time.timeScale == 1.0f)
            {
                Time.timeScale = 0.1f;
                MenuActive = true;
            }
            else
            {
                Time.timeScale = 1.0f;
            }
        }
    }
}
