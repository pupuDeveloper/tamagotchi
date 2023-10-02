using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class petButton : MonoBehaviour
{
    private bool isButtonAvailable;
    private happinessBar happinessbar;
    public GameObject happinessBarScriptHolder;
    public Button petbutton;
    void Awake()
    {
        happinessbar = happinessBarScriptHolder.GetComponent<happinessBar>();
    }

    public void petbuttonFunc()
    {
        GameManager.Instance.happiness += 0.075f;
        happinessbar.UpdateHappinessBar();
        petbutton.interactable = false;
        GameManager.Instance.brushPet = true;
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.activityToBeLaunched == 2 && GameManager.Instance.brushPet == false)
        {
            petbutton.interactable = true;
        }
    }
}
