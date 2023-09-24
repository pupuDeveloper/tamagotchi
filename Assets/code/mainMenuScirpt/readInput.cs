using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class readInput : MonoBehaviour
{
    public string SuggestedInput;
    [SerializeField] private TMP_InputField inputfield;
    [SerializeField] private GameObject gameStartPopout;
    [SerializeField] private GameObject namepetselection;

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
            Debug.Log("name is too short!");
        }
        else
        {
            gameStartPopout.SetActive(true);
            namepetselection.SetActive(false);
        }
    }
}
