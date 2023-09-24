using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class readInput : MonoBehaviour
{
    private string SuggestedInput;
    [SerializeField] private TMP_InputField inputfield;

    void Start()
    {
        inputfield.characterLimit = 5;
    }

    public void ReadStringInput(string name)
    {
        SuggestedInput = name;
        Debug.Log(SuggestedInput);
    }

    public void SubmitName()
    {
        if (SuggestedInput.Length < 3)
        {
            Debug.LogError("name is too short!");
        }
        else
        {
            GameManager.Instance.CurrentlyPlayedPetName = SuggestedInput;
        }
    }
}
