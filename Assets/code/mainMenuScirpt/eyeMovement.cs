using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class eyeMovement : MonoBehaviour
{
    private Vector3 originalPosition;
    private Vector3 point;
    [SerializeField] private Image pupil;
    [SerializeField] private Sprite pupilDilated;
    [SerializeField] private Sprite pupilShrunken;
    [SerializeField] private Animator m_Animator;

    void Start()
    {
        //Sets the original position of the eye
        originalPosition = transform.localPosition;
        //Set pupil sprite
        pupil.sprite = pupilDilated;
    }

    void Update()
    {
        FollowMousePosition();
    }

    private void FollowMousePosition() 
    {
        //Get mouse position
        point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
        //If the mouse is within bounds, move the eye toward the mousePosition
        if (point.x > -2.0 && point.x < 2.0 && point.y > -1.5 && point.y < 1.5)
        {
            transform.localPosition = originalPosition + new Vector3(point.x * 15, point.y * 10, 0);
        }
    }
    
    public void PupilChange() 
    {
        //Change pupil sprite on button enter or exit
        if (pupil.sprite == pupilDilated)
        {
            pupil.sprite = pupilShrunken;
        }
        else
        {
            pupil.sprite = pupilDilated;
        }
    }

    public void AnimationState(bool onButton) 
    {
        m_Animator.SetBool("OnButton", onButton);
    }

}
