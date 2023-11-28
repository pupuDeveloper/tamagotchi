using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class buttonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] public eyeMovement eye;
    // This function will be called when the pointer enters the button
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eye != null) {
            eye.AnimationState(true);
            eye.PupilChange();
            Debug.Log("Pointer entered the object!");
        }
    }
    // This function will be called when the pointer exits the button
    public void OnPointerExit(PointerEventData eventData)
    {
        if (eye != null) {
            eye.AnimationState(false);
            eye.PupilChange();
            Debug.Log("Pointer exited the object!");
        }
        
    }
}

