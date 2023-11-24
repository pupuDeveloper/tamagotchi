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
        private bool isCoroutineRunning = false;
        [SerializeField] private Button brush;
        [SerializeField] private Button minigame;

        void FixedUpdate()
        {
            if (isCoroutineRunning == false && GameManager.Instance.gameIsPaused == false && brush.interactable ||
            isCoroutineRunning == false && GameManager.Instance.gameIsPaused == false && minigame.interactable ||
            isCoroutineRunning == false && GameManager.Instance.gameIsPaused && GameObject.FindWithTag("toy") != null)
            {
                StartCoroutine("passiveHappinessDecrease");
            }
        }

        IEnumerator passiveHappinessDecrease()
        {
            isCoroutineRunning = true;
            yield return new WaitForSeconds(timer);
            GameManager.Instance.happiness -= 0.01f * GameManager.Instance.happinessMultiplier;
            happinesbarScript.UpdateHappinessBar();
            isCoroutineRunning = false;
        }
    }
}
