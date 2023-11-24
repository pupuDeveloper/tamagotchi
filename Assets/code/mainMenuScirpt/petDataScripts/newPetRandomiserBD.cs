using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BunnyHole
{
    public class newPetRandomiserBD : MonoBehaviour
    {
        public pet pet1;
        public pet pet2;
        public pet pet3;
        public pet[] pets;

        //TODO: array of personality types


        void Start()
        {
            pet1 = new pet(GameManager.Instance.CurrentlyPlayedPetName, GameManager.Instance.evolutionProgression, pet1.childSprite, pet1.adultSprite, 1);
            pet2 = new pet(GameManager.Instance.CurrentlyPlayedPetName, GameManager.Instance.evolutionProgression, pet2.childSprite, pet2.adultSprite, 2);
            pet3 = new pet(GameManager.Instance.CurrentlyPlayedPetName, GameManager.Instance.evolutionProgression, pet3.childSprite, pet3.adultSprite, 3);
            pets = new pet[3];
            pets[0] = pet1;
            pets[1] = pet2;
            pets[2] = pet3;
        }
        public pet petRandomiseAndCreate()
        {
            if (GameManager.Instance.currentPet == null)
            {
                int index = Random.Range(0, pets.Length);
                pet Pet = pets[index];
                return Pet;
            }
            else
            {
                return null;
            }
        }
    }
}
