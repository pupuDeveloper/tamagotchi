using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playWithButton : MonoBehaviour
{

    //rn just using a bool that can be checked from editor since we haven't decided or
    //programmed the rate of which the playwithbunny button is available
    private bool isButtonAvailable;
    private happinessBar happinessbar;
    public GameObject happinessBarScriptHolder;
    public Button playWithBunnyButton;
    void Awake()
    {
        happinessbar = happinessBarScriptHolder.GetComponent<happinessBar>();
    }

    public void playWithBunny()
    {
        GameManager.Instance.happiness += 0.10f;
        happinessbar.UpdateHappinessBar();
        playWithBunnyButton.interactable = false;
        GameManager.Instance.bunnyPlay = true;
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.activityToBeLaunched == 1 && GameManager.Instance.bunnyPlay == false)
        {
            playWithBunnyButton.interactable = true;
        }
    }
}
