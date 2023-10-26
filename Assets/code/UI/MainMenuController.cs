using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BunnyHole.UI
{
    public class MainMenuController : MonoBehaviour
    {
        public void OnNewGame()
        {
            GameManager.Instance.Go(States.StateType.MainScene);
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
