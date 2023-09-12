using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.transform == _target)
        {
            Destroy(this.gameObject);
            Debug.Log("correct");
        }
    }
}
