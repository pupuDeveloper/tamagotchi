using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace BunnyHole
{
    public class creatureStatus : MonoBehaviour
    {
        public pet playedPet;
        private bool showText;
        [SerializeField] private GameObject ageText;
        private AudioSource _openAudio;
        void Awake()
        {
            playedPet = GameManager.Instance.currentPet;
            if (GameManager.Instance.evolution == 1)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = playedPet.childSprite;
            }
            if (GameManager.Instance.evolution == 2)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = playedPet.adultSprite;
            }
            _openAudio = GetComponent<AudioSource>();
            if (GameManager.Instance.idleAnimInt < 0)
            {
                triggerIdleAnim();
            }
            else
            {
                gameObject.GetComponent<Animator>().SetInteger("whichIdleAnim", GameManager.Instance.idleAnimInt);
            }
            if (GameManager.Instance.returningFromMinigame && GameManager.Instance.minigameWasSuccess)
            {
                gameObject.GetComponent<creatureHappyanim>().triggerHappyAnim();
                StartCoroutine("cd");
            }
            ageText.SetActive(false);
            GameManager.Instance.currentPet.petName = GameManager.Instance.CurrentlyPlayedPetName;
            gameObject.transform.position = GameManager.Instance.creaturePosition;
        }

        void FixedUpdate()
        {
            Vector2 pos = new Vector2(gameObject.transform.position.x + 1.25f, gameObject.transform.position.y + 1.75f);
            ageText.transform.position = pos;
            GameManager.Instance.currentPet.ageInSeconds = GameManager.Instance.evolutionProgression;
            float hours = TimeSpan.FromSeconds(GameManager.Instance.currentPet.ageInSeconds).Hours;
            float minutes = TimeSpan.FromSeconds(GameManager.Instance.currentPet.ageInSeconds).Minutes;
            float seconds = TimeSpan.FromSeconds(GameManager.Instance.currentPet.ageInSeconds).Seconds;
            string textFieldHours = hours.ToString();
            string textFieldMinutes = minutes.ToString();
            string textFieldSeconds = minutes.ToString();
            if (showText)
            {
                ageText.SetActive(true);
                ageText.GetComponent<TMP_Text>().text = "age:\n" + hours + " day\n" + minutes + " h\n" + seconds + " min";
            }
            else
            {
                ageText.SetActive(false);
            }
        }

        public void triggerIdleAnim()
        {
            if (GameManager.Instance.evolution == 1)
            {
                switch (GameManager.Instance.currentPet.childSprite.name)
                {
                    case ("baby1_0"):
                        GameManager.Instance.idleAnimInt = 0;
                        gameObject.GetComponent<Animator>().SetBool("happyanim", false);
                        gameObject.GetComponent<Animator>().SetInteger("whichIdleAnim", 0);
                        break;

                    case ("baby2_0"):
                        GameManager.Instance.idleAnimInt = 2;
                        gameObject.GetComponent<Animator>().SetBool("happyanim", false);
                        gameObject.GetComponent<Animator>().SetInteger("whichIdleAnim", 2);
                        break;

                    case ("baby3_0"):
                        GameManager.Instance.idleAnimInt = 4;
                        gameObject.GetComponent<Animator>().SetBool("happyanim", false);
                        gameObject.GetComponent<Animator>().SetInteger("whichIdleAnim", 4);
                        break;
                }
            }

            if (GameManager.Instance.evolution == 2)

            {
                switch (GameManager.Instance.currentPet.adultSprite.name)
                {
                    case ("adult1_0"):
                        GameManager.Instance.idleAnimInt = 1;
                        gameObject.GetComponent<Animator>().SetBool("happyanim", false);
                        gameObject.GetComponent<Animator>().SetInteger("whichIdleAnim", 1);
                        break;

                    case ("adult2_0"):
                        GameManager.Instance.idleAnimInt = 3;
                        gameObject.GetComponent<Animator>().SetBool("happyanim", false);
                        gameObject.GetComponent<Animator>().SetInteger("whichIdleAnim", 3);
                        break;

                    case ("adult3_0"):
                        GameManager.Instance.idleAnimInt = 5;
                        gameObject.GetComponent<Animator>().SetBool("happyanim", false);
                        gameObject.GetComponent<Animator>().SetInteger("whichIdleAnim", 5);
                        break;
                }
            }
        }
        void OnMouseDown()
        {
            if (!showText)
            {
                showText = true;
            }
            else
            {
                showText = false;
            }
        }
        IEnumerator cd()
        {
            yield return new WaitForSeconds(1);
            if (_openAudio != null)
                {
                    AudioManager.PlayClip(_openAudio, Config.SoundEffect.PetHappy);
                }
            yield return new WaitForSeconds(1);
            gameObject.GetComponent<Animator>().SetBool("happyanim", false);
            gameObject.GetComponent<Animator>().SetInteger("whichIdleAnim", GameManager.Instance.idleAnimInt);
        }
    }
}
