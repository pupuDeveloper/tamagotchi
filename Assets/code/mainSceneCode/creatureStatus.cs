using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creatureStatus : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Make sure you take good care of " + GameManager.Instance.CurrentlyPlayedPetName + "!");
    }
}
