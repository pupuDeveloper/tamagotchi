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
            pet1 = new pet(GameManager.Instance.CurrentlyPlayedPetName, GameManager.Instance.evolutionProgression, 1, 0);
            pet2 = new pet(GameManager.Instance.CurrentlyPlayedPetName, GameManager.Instance.evolutionProgression, 2, 0);
            pet3 = new pet(GameManager.Instance.CurrentlyPlayedPetName, GameManager.Instance.evolutionProgression, 3, 0);
            pets = new pet[3];
            pets[0] = pet1;
            pets[1] = pet2;
            pets[2] = pet3;
        }
        public pet petRandomiseAndCreate()
        {
            int index = Random.Range(0, pets.Length);
            pet Pet = pets[index];
            return Pet;
        }
    }
}

