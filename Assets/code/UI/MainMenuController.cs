using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BunnyHole.UI
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private GameObject _namePet;
        public void OnNewGame()
        {
            if (GameManager.Instance.activePet)
            {
                GameManager.Instance.gameIsPaused = false;
                GameManager.Instance.Go(States.StateType.MainScene);
            }
            else
            {
                _namePet.SetActive(true);
            }
        }

        public void OnOptions()
        {
            GameManager.Instance.Go(States.StateType.Options);
        }

        public void OnQuit()
        {
            Application.Quit();
        }
    }

}
