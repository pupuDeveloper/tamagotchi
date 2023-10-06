using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class minigameButton : MonoBehaviour
{
    private bool isButtonAvailable;
    public Button minigamebutton;
    private Scene scene;
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
        scene = SceneManager.GetActiveScene();
        if (GameManager.Instance.miniGamePlayed == false && scene.name == "mainScene" && GameManager.Instance.activityToBeLaunched == 3)
        {
            minigamebutton.interactable = true;
        }
        else if (GameManager.Instance.miniGamePlayed)
        {
            minigamebutton.interactable = false;
        }
    }
}
