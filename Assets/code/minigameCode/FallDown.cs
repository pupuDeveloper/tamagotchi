using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBerries : MonoBehaviour
{
    private float _fallSpeed = 5.0f;
    private float _spinSpeed = 250.0f;

    private void FixedUpdate()
    {
            transform.Translate(Vector3.down * _fallSpeed * Time.deltaTime, Space.World);
            transform.Rotate(Vector3.forward, _spinSpeed * Time.deltaTime);
    }
}
