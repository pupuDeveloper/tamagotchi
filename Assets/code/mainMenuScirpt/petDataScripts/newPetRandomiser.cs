using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newPetRandomiser : MonoBehaviour
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
        pet Pet = new pet();
        Pet.petName = GameManager.Instance.CurrentlyPlayedPetName;
        Pet.upperBody = upperBodySprites[index1];
        Pet.lowerBody = lowerBodySprites[index2];
        Pet.ageInSeconds = 0f;
        return Pet;
        }
        else
        {
            return null;
        }
    }
}
