using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passiveHappinessScript : MonoBehaviour
{
    [SerializeField] private happinessBar happinesbarScript;
    [SerializeField] private int timer;
    private bool isCoroutineRunning = false;

    void FixedUpdate()
    {
        if (isCoroutineRunning == false && GameManager.Instance.gameIsPaused == false)
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
