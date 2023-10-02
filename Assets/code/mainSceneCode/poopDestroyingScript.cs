using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poopDestroyingScript : MonoBehaviour
{

    private poopScript poopscript
    void OnMouseDown()
    {
        if (isCleaningOn)
        {
        poops.Remove(gameObject);
        Destroy(gameObject);
        }
    }
}
