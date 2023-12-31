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
        [SerializeField] private GameObject thoughtBubbleText;
        [SerializeField] private Sprite childSprite1;
        [SerializeField] private Sprite childSprite2;
        [SerializeField] private Sprite childSprite3;
        [SerializeField] private Sprite adultSprite1;
        [SerializeField] private Sprite adultSprite2;
        [SerializeField] private Sprite adultSprite3;
        private AudioSource _openAudio;
        private bool cd3bool;
        void Awake()
        {
            playedPet = GameManager.Instance.currentPet;
            setupPlayedSprite();
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
                gameObject.GetComponent<creatureAnims>().triggerHappyAnim();
                StartCoroutine("cd");
            }
            if (GameManager.Instance.returningFromMinigame && GameManager.Instance.minigameWasSuccess == false)
            {
                gameObject.GetComponent<creatureAnims>().triggerSadAnim();
                StartCoroutine("cd2");
            }
            ageText.SetActive(false);
            GameManager.Instance.currentPet.petName = GameManager.Instance.CurrentlyPlayedPetName;
            gameObject.transform.position = GameManager.Instance.creaturePosition;
            cd3bool = false;
        }

        void FixedUpdate()
        {
            Vector2 pos = new Vector2(gameObject.transform.position.x + 1.25f, gameObject.transform.position.y + 1.75f);
            Vector2 pos2 = new Vector2(gameObject.transform.position.x + 0.3f, gameObject.transform.position.y + 2.65f);
            ageText.transform.position = pos;
            thoughtBubbleText.transform.position = pos2;
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
                ageText.GetComponent<TMP_Text>().text = "age\n" + hours + " day\n" + minutes + " h\n" + seconds + " min";
            }
            else
            {
                ageText.SetActive(false);
            }
            if (GameManager.Instance.happiness < 0.41f && cd3bool == false)
            {
                StartCoroutine("cd3");
            }
        }
        public void setupPlayedSprite()
        {
            if (GameManager.Instance.evolution == 1)
            {
                switch (GameManager.Instance.currentPet.type)
                {
                    case 1:
                        gameObject.GetComponent<SpriteRenderer>().sprite = childSprite1;
                        break;

                    case 2:
                        gameObject.GetComponent<SpriteRenderer>().sprite = childSprite2;
                        break;

                    case 3:
                        gameObject.GetComponent<SpriteRenderer>().sprite = childSprite3;
                        break;
                }
            }

            if (GameManager.Instance.evolution == 2)

            {
                switch (GameManager.Instance.currentPet.type)
                {
                    case 1:
                        gameObject.GetComponent<SpriteRenderer>().sprite = adultSprite1;
                        break;

                    case 2:
                        gameObject.GetComponent<SpriteRenderer>().sprite = adultSprite2;
                        break;

                    case 3:
                        gameObject.GetComponent<SpriteRenderer>().sprite = adultSprite3;
                        break;
                }
            }
        }

        public void triggerIdleAnim()
        {
            if (GameManager.Instance.evolution == 1)
            {
                switch (GameManager.Instance.currentPet.type)
                {
                    case 1:
                        GameManager.Instance.idleAnimInt = 0;
                        gameObject.GetComponent<Animator>().SetBool("happyanim", false);
                        gameObject.GetComponent<Animator>().SetInteger("whichIdleAnim", 0);
                        break;

                    case 2:
                        GameManager.Instance.idleAnimInt = 2;
                        gameObject.GetComponent<Animator>().SetBool("happyanim", false);
                        gameObject.GetComponent<Animator>().SetInteger("whichIdleAnim", 2);
                        break;

                    case 3:
                        GameManager.Instance.idleAnimInt = 4;
                        gameObject.GetComponent<Animator>().SetBool("happyanim", false);
                        gameObject.GetComponent<Animator>().SetInteger("whichIdleAnim", 4);
                        break;
                }
            }

            if (GameManager.Instance.evolution == 2)

            {
                switch (GameManager.Instance.currentPet.type)
                {
                    case 1:
                        GameManager.Instance.idleAnimInt = 1;
                        gameObject.GetComponent<Animator>().SetBool("happyanim", false);
                        gameObject.GetComponent<Animator>().SetInteger("whichIdleAnim", 1);
                        break;

                    case 2:
                        GameManager.Instance.idleAnimInt = 3;
                        gameObject.GetComponent<Animator>().SetBool("happyanim", false);
                        gameObject.GetComponent<Animator>().SetInteger("whichIdleAnim", 3);
                        break;

                    case 3:
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

        //coroutine for succesful minigame animations and SFX
        IEnumerator cd()
        {
            yield return new WaitForSeconds(1);
            if (_openAudio != null && GameManager.Instance.evolution == 1)
            {
                AudioManager.PlayClip(_openAudio, Config.SoundEffect.PetHappyYoung);
            }
            if (_openAudio != null && GameManager.Instance.evolution == 2)
            {
                AudioManager.PlayClip(_openAudio, Config.SoundEffect.PetHappyAdult);
            }
            yield return new WaitForSeconds(1);
            gameObject.GetComponent<Animator>().SetBool("happyanim", false);
            gameObject.GetComponent<Animator>().SetInteger("whichIdleAnim", GameManager.Instance.idleAnimInt);
        }

        //coroutine for Unsuccesful minigame animations and SFX
        IEnumerator cd2()
        {
            yield return new WaitForSeconds(1);
            if (_openAudio != null && GameManager.Instance.evolution == 1)
            {
                AudioManager.PlayClip(_openAudio, Config.SoundEffect.PetAngryYoung);
            }
            if (_openAudio != null && GameManager.Instance.evolution == 2)
            {
                AudioManager.PlayClip(_openAudio, Config.SoundEffect.PetAngryAdult);
            }
            yield return new WaitForSeconds(1);
            gameObject.GetComponent<Animator>().SetBool("sadanim", false);
            gameObject.GetComponent<Animator>().SetInteger("whichIdleAnim", GameManager.Instance.idleAnimInt);
        }

        //coroutine for when happiness is under 40%, SFX and animation
        IEnumerator cd3()
        {
            cd3bool = true;
            gameObject.GetComponent<Animator>().SetBool("sadanim", true);
            if (_openAudio != null && GameManager.Instance.evolution == 1)
            {
                AudioManager.PlayClip(_openAudio, Config.SoundEffect.PetAngryYoung);
            }
            if (_openAudio != null && GameManager.Instance.evolution == 2)
            {
                AudioManager.PlayClip(_openAudio, Config.SoundEffect.PetAngryAdult);
            }
            yield return new WaitForSeconds(1);
            gameObject.GetComponent<Animator>().SetBool("sadanim", false);
            gameObject.GetComponent<Animator>().SetInteger("whichIdleAnim", GameManager.Instance.idleAnimInt);
            yield return new WaitForSeconds(4);
            cd3bool = false;
        }
    }
}
