using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collision : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Are strawberries colliding with the basket? If yes, destroy
        // the strawberry
        if(collision.gameObject.layer == LayerMask.NameToLayer("Basket"))
        {
            Destroy(gameObject);
            Debug.Log("correct");
            // Adds count to the Counting script when colliding with the basket
            Counting._count++;
            Debug.Log(Counting._count);
        }
    }
}
