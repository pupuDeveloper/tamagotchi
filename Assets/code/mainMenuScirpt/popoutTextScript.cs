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
    public newPetRandomiser petRandomiser;
    public pet petOption;

    void Start()
    {
        popoutText.text = "do you want to name your pet " + readinputScript.SuggestedInput + " and start the game?";
        GameManager.Instance.CurrentlyPlayedPetName = readinputScript.SuggestedInput;
        petOption = petRandomiser.petRandomiseAndCreate();
    }

    public void startGame()
    {
        GameManager.Instance.activePet = true;
        GameManager.Instance.gameIsPaused = false;
        GameManager.Instance.currentPet = petOption;
        SceneManager.LoadScene("mainScene");
    }
}
