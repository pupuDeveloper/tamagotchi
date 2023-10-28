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
    public newPetRandomiserBD petRandomiser;
    public pet petOption;

    void Start()
    {
        popoutText.text = "Create " + readinputScript.SuggestedInput + " and start game?";
        GameManager.Instance.CurrentlyPlayedPetName = readinputScript.SuggestedInput;
        petOption = petRandomiser.petRandomiseAndCreate();
        Debug.Log(petOption);
    }

    public void startGame()
    {
        GameManager.Instance.activePet = true;
        GameManager.Instance.gameIsPaused = false;
        GameManager.Instance.currentPet = petOption;
        Debug.Log(GameManager.Instance.currentPet);
        SceneManager.LoadScene("mainScene");
    }
}
