using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class moveBackground : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject background;
    public bool isPressed;

    void Update()
    {
        if (isPressed)
        {
            if (EventSystem.current.currentSelectedGameObject.name == "right" && background.transform.position.x < 10)
            {
                background.transform.position += new Vector3 (7 * Time.deltaTime, 0, 0);
            }
            else if (EventSystem.current.currentSelectedGameObject.name == "left" && background.transform.position.x > -10)
            {
                background.transform.position -= new Vector3 (7 * Time.deltaTime, 0, 0);
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }

}
