using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

namespace BunnyHole.UI
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private GameObject _namePet;
        [SerializeField] private GameObject _mainMenu;

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
                _mainMenu.SetActive(false);
            }
        }

        public void OnOptions()
        {
            GameManager.Instance.Go(States.StateType.Options);
        }

        public void OnCredits()
        {
            GameManager.Instance.Go(States.StateType.Credits);
        }
        public void onGraveyard()
        {
            GameManager.Instance.Go(States.StateType.Graveyard);
        }

        public void OnQuit()
        {
            Application.Quit();
        }
    }

}
