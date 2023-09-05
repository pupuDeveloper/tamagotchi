using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame : MonoBehaviour
{

    public float _xPos;
    public Vector3 _newPos;
    public float _fallSpeed = 8.0f;
    public float _spinSpeed = 250.0f;
    [SerializeField] private Transform _target;

    private void Awake()
    {
        _xPos = Random.Range(-4.8f, 4.8f);
        _newPos = new Vector3(_xPos, 6, 0);
    }

    private void Update()
    {
        //move the object down the screen
        transform.Translate(Vector3.down * _fallSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.forward, _spinSpeed * Time.deltaTime);

        //if the object has reached the bottom of the screen
        if(transform.position.y < -6)
        {
            //move the objecta above the screen
            _xPos = Random.Range(-4.5f, 4.5f);
            _newPos = new Vector3(_xPos, 6, 0);
            transform.position = _newPos;
        }
    }
}
