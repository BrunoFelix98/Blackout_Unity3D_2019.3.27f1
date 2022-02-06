using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController3D : MonoBehaviour
{
    public float RotSpeed = 1 ;
    public Transform Target, Player;
    public Menus Pause;
    float mouseX, mouseY;
    public Interactable Menu;

    void Start()
    {
        //Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Menu = GameObject.FindGameObjectWithTag("Player").GetComponent<Interactable>();
        Pause = GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<Menus>();
    }
    private void LateUpdate()
    {
        if(!Menu.MenuActive || !Pause.active)
            camControler();
    }
    void camControler()
    {
        mouseX += Input.GetAxis("Mouse X") * RotSpeed;
        mouseY += Input.GetAxis("Mouse Y") * RotSpeed;
        //mouseY = Mathf.Clamp(mouseY, -35, 60);
        transform.LookAt(Target);
        Target.rotation = Quaternion.Euler(-mouseY, mouseX, 0);
        Player.rotation = Quaternion.Euler(0, mouseX, 0);
    }
}