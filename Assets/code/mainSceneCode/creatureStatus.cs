using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creatureStatus : MonoBehaviour
{
    public pet playedPet;
    void Start()
    {
        playedPet = GameManager.Instance.currentPet;
        GameManager.Instance.currentPet.petName = GameManager.Instance.CurrentlyPlayedPetName;
        Debug.Log("Make sure you take good care of " + GameManager.Instance.CurrentlyPlayedPetName + "!");
        if (GameManager.Instance.evolution == 1 || GameManager.Instance.evolution == 2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = GameManager.Instance.currentPet.childSprite;
        }
        if (GameManager.Instance.evolution == 3)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = GameManager.Instance.currentPet.adultSprite;
        }
    }
}
