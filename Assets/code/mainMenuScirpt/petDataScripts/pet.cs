using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class pet
{
    public string petName;
    public float ageInSeconds;
    public Sprite upperBody;
    public Sprite lowerBody;

    public pet(string petName, float ageInSeconds, Sprite upperBody, Sprite lowerBody)
    {
        this.petName = petName;
        this.ageInSeconds = ageInSeconds;
        this.upperBody = upperBody;
        this.lowerBody = lowerBody;
    }
}

