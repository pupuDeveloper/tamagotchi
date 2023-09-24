using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject namePet;
    [SerializeField] private GameObject mainmenu;
    public void playGame()
    {
        if (GameManager.Instance.activePet)
        {
            SceneManager.LoadScene("mainScene");
        }
        else
        {
            namePet.SetActive(true);
            mainmenu.SetActive(false);
        }
    }
    
    public void quitGame()
    {
        Debug.Log("Quitted! (This only happens in a build, not in the editor)");
        Application.Quit();
    }
}
