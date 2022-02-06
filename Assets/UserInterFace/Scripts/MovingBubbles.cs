using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingBubbles : MonoBehaviour
{
    public Canvas parentCanvas;

    public Button Pbutton;
    public Button Obutton;
    public Button Cbutton;
    public Button Qbutton;

    public Button[] buttons;

    public void Start()
    {
        GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 0);

        buttons = FindObjectsOfType<Button>();
    }

    public void Update()
    {
        Move();
    }

    public void Move()
    {
        Vector2 movePos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvas.transform as RectTransform, Input.mousePosition, parentCanvas.worldCamera, out movePos);

        transform.position = new Vector3(transform.position.x, parentCanvas.transform.TransformPoint(movePos).y, transform.position.z);

        if (Pbutton.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Highlighted") || Obutton.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Highlighted") || Cbutton.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Highlighted") || Qbutton.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Highlighted"))
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 1);
        }
        else
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 0);
        }
    }
}
