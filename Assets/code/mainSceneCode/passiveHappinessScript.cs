using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace BunnyHole
{
    public class passiveHappinessScript : MonoBehaviour
    {
        [SerializeField] private happinessBar happinesbarScript;
        [SerializeField] private float timer;
        private bool isCoroutine1Running = false;
        private bool isCoroutine2Running = false;
        private bool isCoroutine3Running = false;
        [SerializeField] private Button brush;
        [SerializeField] private Button minigame;
        private int duplicatePreventer = 0;
        private int duplicateChecker;

        void FixedUpdate()
        {
            Debug.Log(GameObject.Find("toy(Clone)"));
            if (GameManager.Instance.gameIsPaused == false)
            {
                if (brush.interactable && isCoroutine1Running == false)
                {
                    duplicateChecker = 1;
                    StartCoroutine("passiveHappinessDecrease");
                }
                else if (minigame.interactable && isCoroutine2Running == false)
                {
                    duplicateChecker = 2;
                    StartCoroutine("passiveHappinessDecrease");
                }
                else if (GameObject.Find("toy(Clone)") != null && isCoroutine3Running == false)
                {
                    duplicateChecker = 3;
                    StartCoroutine("passiveHappinessDecrease");
                }
            }
        }

        IEnumerator passiveHappinessDecrease()
        {
            duplicatePreventer = duplicateChecker;
            switch (duplicatePreventer)
            {
                case 1:
                isCoroutine1Running = true;
                break;
                case 2:
                isCoroutine2Running = true;
                break;
                case 3:
                isCoroutine3Running = true;
                break;
            }
            yield return new WaitForSeconds(timer);
            GameManager.Instance.happiness -= 0.01f * GameManager.Instance.happinessMultiplier;
            happinesbarScript.UpdateHappinessBar();
            switch (duplicatePreventer)
            {
                case 1:
                isCoroutine1Running = false;
                break;
                case 2:
                isCoroutine2Running = false;
                break;
                case 3:
                isCoroutine3Running = false;
                break;
            }
        }
    }
}
