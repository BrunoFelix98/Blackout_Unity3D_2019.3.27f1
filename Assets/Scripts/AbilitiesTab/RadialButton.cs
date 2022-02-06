using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RadialButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image circle;
    public Sprite defaultCircle;
    public Sprite highlighted;
    public Image icon;
    public string title;
    public bool unlocked;
    public RadialMenu myMenu;

    Color defaultColor;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (unlocked)
        {
            myMenu.selected = this;
            defaultColor = circle.color;
            circle.sprite = highlighted;
        }
        else
        {
            defaultColor = circle.color;
            circle.sprite = circle.sprite;
            circle.color = Color.grey;
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (unlocked)
        {
            myMenu.selected = null;
            circle.sprite = defaultCircle;
        }
        else
        {
            myMenu.selected = null;
            circle.sprite = defaultCircle;
        }
        
    }
}
