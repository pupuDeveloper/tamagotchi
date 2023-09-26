using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class minigameButton : MonoBehaviour
{
    private bool isButtonAvailable;
    public Button minigamebutton;
    public void Switch()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Minigame")
        {
            GameManager.Instance.gameIsPaused = false;
            GameManager.Instance.miniGamePlayed = true;
            SceneManager.LoadScene (sceneName:"mainScene");
        }
        else if (scene.name == "mainScene")
        {
            GameManager.Instance.gameIsPaused = true;
            SceneManager.LoadScene (sceneName:"Minigame");
        }
    }
    void FixedUpdate()
    {
        if (GameManager.Instance.miniGamePlayed == false)
        {
            minigamebutton.interactable = true;
        }
        else
        {
            minigamebutton.interactable = false;
        }
    }
}
