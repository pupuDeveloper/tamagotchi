using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collision : MonoBehaviour
{
    private Vector3 _newPos;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Are strawberries colliding with the basket? If yes, destroy
        // the strawberry
      /*  if (collision.gameObject.layer == LayerMask.NameToLayer("Basket"))
        {
            Destroy(gameObject);
            Debug.Log("correct");
            // Adds count to the Counting script when colliding with the basket
            Counting._count++;
            Debug.Log(Counting._count);
        }*/

        if (collision.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            float _xPos = Random.Range(-3.85f, 3.80f);
            _newPos = new Vector3(_xPos, 6, 0);
            transform.position = _newPos;

        }
    }
}
