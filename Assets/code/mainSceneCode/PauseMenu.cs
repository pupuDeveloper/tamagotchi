using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenuUI;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameManager.Instance.gameIsPaused )
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameManager.Instance.gameIsPaused = false;
    }
    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameManager.Instance.gameIsPaused = true;
    }
    public void loadMenu()
    {
        SceneManager.LoadScene("mainmenu");
        Time.timeScale = 1f;
    }
    public void quitGame()
    {
        Debug.Log("Quitted! (This only happens in a build, not in the editor)");
        Time.timeScale = 1f;
        Application.Quit();
    }
}