using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newPetRandomiserBD : MonoBehaviour
{
    public List<Sprite> upperBodySprites = new List<Sprite>();
    public List<Sprite> lowerBodySprites = new List<Sprite>();

    //TODO: array of personality types

    public pet petRandomiseAndCreate()
    {
        if (GameManager.Instance.currentPet == null)
        {
        int index1 = Random.Range(0, upperBodySprites.Count);
        int index2 = Random.Range(0, lowerBodySprites.Count);
        pet Pet = new pet(GameManager.Instance.CurrentlyPlayedPetName, 0f, upperBodySprites[index1], lowerBodySprites[index2]);
        Debug.Log(Pet);
        return Pet;
        }
        else
        {
            return null;
        }
    }
}
