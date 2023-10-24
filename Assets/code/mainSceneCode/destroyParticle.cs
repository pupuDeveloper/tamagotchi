using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyParticle : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 0.45f);
    }
}
