using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eyeMovement : MonoBehaviour
{
    private Vector3 originalPosition;
    private Vector3 point;
    [SerializeField] private Image pupil;
    [SerializeField] private Sprite pupilDilated;
    [SerializeField] private Sprite pupilShrunken;
    void Start()
    {
        //Sets the original position of the eye
        originalPosition = transform.localPosition;
        pupil.sprite = pupilDilated;
    }
    void Update()
    {
        EyeMovement();
        OnMouseOverButton();
    }

    private void EyeMovement() {
        //Get mouse position
        point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
        //If the mouse is within bounds, move the eye toward the mousePosition
        if (point.x > -2.0 && point.x < 2.0 && point.y > -1.5 && point.y < 1.5)
        {
            transform.localPosition = originalPosition + new Vector3(point.x * 15, point.y * 10, 0);
        }
        // Debug.Log(transform.localPosition);
        // Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
    
    private void OnMouseOverButton() {
        //If the mouse is over a button, change pupil image
        if (Input.GetKey("space"))
        {
            Debug.Log("Space");
            pupil.sprite = pupilShrunken;
        }
        else
        {
            pupil.sprite = pupilDilated;
        }
    }
}
