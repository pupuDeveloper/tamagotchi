using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class pet
{
    public string petName;
    public float ageInSeconds;
    public Sprite childSprite;
    public Sprite adultSprite;

    public pet(string petName, float ageInSeconds, Sprite childSprite, Sprite adultSprite)
    {
        this.petName = petName;
        this.ageInSeconds = ageInSeconds;
        this.childSprite = childSprite;
        this.adultSprite = adultSprite;
    }
}

