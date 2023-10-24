using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    void Awake()
    {
        happinessbar = happinessBarScriptHolder.GetComponent<happinessBar>();
        isBrushingOn = false;
        petProgress = 0;
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
            petAmount = Random.Range(10,20);
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
}
