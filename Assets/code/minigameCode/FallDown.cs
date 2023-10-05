using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBerries : MonoBehaviour
{
    private float _fallSpeed = 5.0f;
    private float _spinSpeed = 250.0f;
    private Vector3 _newPos;

    private void FixedUpdate()
    {
        // Move the objects down
        transform.Translate(Vector3.down * _fallSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.forward, _spinSpeed * Time.deltaTime);

        // Is the object's y-axis position in -6?
        // If yes, transform the position back above the screen
        if(transform.position.y < -6)
        {
            float _xPos = Random.Range(-3.85f, 3.80f);
            _newPos = new Vector3(_xPos, 6, 0);
            transform.position = _newPos;
        }
    }
}
