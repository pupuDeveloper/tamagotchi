using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace BunnyHole
{
    public class petButton : MonoBehaviour
    {
        // private bool isButtonAvailable; This variable is never used, so commented it out.
        public bool isBrushingOn;
        private happinessBar happinessbar;
        public GameObject happinessBarScriptHolder;
        public Button petbutton;
        public int petAmount;
        public int petProgress;
        [SerializeField] private Texture2D cursorTexture;
        public CursorMode cursorMode = CursorMode.Auto;
        public Vector2 hotSpot = Vector2.zero;
        private AudioSource _openAudio;
        private creatureStatus creatureStatusScript;
        private creatureAnims creatureAnimScript;
        void Awake()
        {
            happinessbar = happinessBarScriptHolder.GetComponent<happinessBar>();
            isBrushingOn = false;
            petProgress = 0;
            _openAudio = GetComponent<AudioSource>();
            creatureStatusScript = GameObject.Find("Creature").GetComponent<creatureStatus>();
            creatureAnimScript = GameObject.Find("Creature").GetComponent<creatureAnims>();
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
                if (GameManager.Instance.evolution == 1)
                {
                    if (_openAudio != null)
                    {
                        AudioManager.PlayClip(_openAudio, Config.SoundEffect.PetHappyYoung);
                    }
                }
                else if (GameManager.Instance.evolution == 2)
                {
                    if (_openAudio != null)
                    {
                        AudioManager.PlayClip(_openAudio, Config.SoundEffect.PetHappyAdult);
                    }
                }
                creatureAnimScript.triggerHappyAnim();
                StartCoroutine("animCooldown");
                isBrushingOn = false;
                StartCoroutine(happinessbar.particle(15));
                petbutton.interactable = false;
                GameManager.Instance.brushPet = true;
                petAmount = 0;
                petProgress = 0;
                Cursor.SetCursor(null, hotSpot, cursorMode);
                GameManager.Instance.happiness += 0.15f;
            }
        }
        IEnumerator animCooldown()
        {
            yield return new WaitForSeconds(1.5f);
            creatureStatusScript.triggerIdleAnim();
        }
    }
}
