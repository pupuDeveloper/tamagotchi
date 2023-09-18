using GA.BunnyHole.Generated;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;

    private void Update()
    {
        Vector2 _pos = transform.position;
        if(Input.GetKey("d"))
        {
            _pos.x += _speed * Time.deltaTime;
        }
        if(Input.GetKey("a"))
        {
            _pos.x -= _speed * Time.deltaTime;
        }

        transform.position = _pos;
    }
}
