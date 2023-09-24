using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class popoutTextScript : MonoBehaviour
{
    [SerializeField] private TMP_Text popoutText;
    public readInput readinputScript;

    void Start()
    {
        popoutText.text = "do you want to name your pet " + readinputScript.SuggestedInput + " and start the game?";
    }

    public void startGame()
    {
        GameManager.Instance.CurrentlyPlayedPetName = readinputScript.SuggestedInput;
        GameManager.Instance.activePet = true;
        GameManager.Instance.gameIsPaused = false;
        SceneManager.LoadScene("mainScene");
    }
}
