using UnityEngine;

namespace BunnyHole
{
    public class GameOverController : MonoBehaviour
    {
        public void OnMainMenu()
        {
            GameManager.Instance.Go(States.StateType.MainMenu);
        }

        public void OnQuitGame()
        {
            Application.Quit();
        }
    }
}
