using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creatureStatus : MonoBehaviour
{
    public pet playedPet;
    private int animInt;
    
    void Start()
    {
        playedPet = GameManager.Instance.currentPet;
        GameManager.Instance.currentPet.petName = GameManager.Instance.CurrentlyPlayedPetName;
        Debug.Log("Make sure you take good care of " + GameManager.Instance.CurrentlyPlayedPetName + "!");
        if (GameManager.Instance.evolution == 1 || GameManager.Instance.evolution == 2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = playedPet.childSprite;
        }
        if (GameManager.Instance.evolution == 3)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = playedPet.adultSprite;
        }

        switch (gameObject.GetComponent<SpriteRenderer>().sprite.name)
        {
            case ("baby1_0"):
            gameObject.GetComponent<Animator>().SetInteger("whichIdleAnim", 0);
            break;

            case ("adult1_0"):
            gameObject.GetComponent<Animator>().SetInteger("whichIdleAnim", 1);
            break;

            case ("baby2_0"):
            gameObject.GetComponent<Animator>().SetInteger("whichIdleAnim", 2);
            break;

            case ("adult2_0"):
            gameObject.GetComponent<Animator>().SetInteger("whichIdleAnim", 3);
            break;

            case ("baby3_0"):
            gameObject.GetComponent<Animator>().SetInteger("whichIdleAnim", 4);
            break;

            case ("adult3_0"):
            gameObject.GetComponent<Animator>().SetInteger("whichIdleAnim", 5);
            break;
        }
    }
}
