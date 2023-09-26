using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collision : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private Minigame minigameScript;

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.transform == _target)
        {
            Destroy(this.gameObject);
            Debug.Log("correct");
            Counting._count++;
            Debug.Log(Counting._count);
        }
    }
}
