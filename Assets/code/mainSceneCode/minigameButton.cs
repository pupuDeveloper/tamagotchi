using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class minigameButton : MonoBehaviour
{
    public void Switch()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Minigame")
        {
            GameManager.Instance.gameIsPaused = false;
            SceneManager.LoadScene (sceneName:"mainScene");
        }
        else if (scene.name == "mainScene")
        {
            GameManager.Instance.gameIsPaused = true;
            SceneManager.LoadScene (sceneName:"Minigame");
        }
    }
}
