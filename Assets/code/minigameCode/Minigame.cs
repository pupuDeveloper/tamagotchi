using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Minigame : MonoBehaviour
{

    private float _xPos;
    private Vector3 _newPos;
    private float _fallSpeed = 6.0f;
    private float _spinSpeed = 250.0f;
    private GameObject popoutwindow;
    private void Awake()
    {
        popoutwindow = GameObject.Find("infoPopout");
        _xPos = Random.Range(-4.73f, 3.88f);
        _newPos = new Vector3(_xPos, 6, 0);
    }

    private void Update()
    {
        if (popoutwindow.activeSelf == false)
        {
            //move the object down the screen
        transform.Translate(Vector3.down * _fallSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.forward, _spinSpeed * Time.deltaTime);

        //if the object has reached the bottom of the screen
        if(transform.position.y < -6)
        {
            //move the object above the screen
            _xPos = Random.Range(-4.5f, 4.5f);
            _newPos = new Vector3(_xPos, 6, 0);
            transform.position = _newPos;
        }
        }
    }
}
