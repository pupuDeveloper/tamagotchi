using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playWithButton : MonoBehaviour
{

    //rn just using a bool that can be checked from editor since we haven't decided or
    //programmed the rate of which the playwithbunny button is available
    public bool isButtonAvailable;
    private happinessBar happinessbar;
    public GameObject happinessBarScriptHolder;
    public Button playWithBunnyButton;
    void Awake()
    {
        happinessbar = happinessBarScriptHolder.GetComponent<happinessBar>();
    }
    public void playWithBunny()
    {
        if (!isButtonAvailable)
        {
            playWithBunnyButton.interactable = false;
        }
        GameManager.Instance.happiness += 0.30f;
        happinessbar.UpdateHappinessBar();
    }
}
