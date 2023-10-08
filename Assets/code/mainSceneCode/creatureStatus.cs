using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creatureStatus : MonoBehaviour
{
    public pet playedPet;
    void Start()
    {
        playedPet = GameManager.Instance.currentPet;
        Debug.Log("Make sure you take good care of " + GameManager.Instance.CurrentlyPlayedPetName + "!");
    }
}
