using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace BunnyHole
{
    public class petButton : MonoBehaviour
    {
        private bool isButtonAvailable;
        public bool isBrushingOn;
        private happinessBar happinessbar;
        public GameObject happinessBarScriptHolder;
        public Button petbutton;
        public int petAmount;
        public int petProgress;
        public Texture2D cursorTexture;
        public CursorMode cursorMode = CursorMode.Auto;
        public Vector2 hotSpot = Vector2.zero;
        private AudioSource _openAudio;
        private creatureStatus creatureStatusScript;
        private creatureHappyanim creatureHappyanimScript;
        void Awake()
        {
            happinessbar = happinessBarScriptHolder.GetComponent<happinessBar>();
            isBrushingOn = false;
            petProgress = 0;
            _openAudio = GetComponent<AudioSource>();
            creatureStatusScript = GameObject.Find("Creature").GetComponent<creatureStatus>();
            creatureHappyanimScript = GameObject.Find("Creature").GetComponent<creatureHappyanim>();
        }

        public void petbuttonFunc()
        {
            if (isBrushingOn)
            {
                isBrushingOn = false;
                Cursor.SetCursor(null, hotSpot, cursorMode);
            }
            else
            {
                isBrushingOn = true;
                Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
                petAmount = Random.Range(10, 20);
            }
        }

        void FixedUpdate()
        {
            if (GameManager.Instance.activityToBeLaunched == 2 && GameManager.Instance.brushPet == false)
            {
                petbutton.interactable = true;
            }
            if (petProgress >= petAmount && isBrushingOn && GameManager.Instance.brushPet == false)
            {
                if (_openAudio != null)
                {
                    AudioManager.PlayClip(_openAudio, Config.SoundEffect.PetHappy);
                }
                creatureHappyanimScript.triggerHappyAnim();
                StartCoroutine("animCooldown");
                GameManager.Instance.happiness += 0.15f;
                isBrushingOn = false;
                happinessbar.UpdateHappinessBar();
                petbutton.interactable = false;
                GameManager.Instance.brushPet = true;
                petAmount = 0;
                petProgress = 0;
                Cursor.SetCursor(null, hotSpot, cursorMode);
            }
        }
        IEnumerator animCooldown()
        {
            yield return new WaitForSeconds(1.5f);
            creatureStatusScript.triggerIdleAnim();
        }
    }
}
