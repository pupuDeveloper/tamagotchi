using UnityEngine;
using UnityEngine.UI;

namespace BunnyHole.UI
{
    public class MainSceneController : MonoBehaviour
    {
        public void OnMinigameButton()
        {
            GameManager.Instance.Go(States.StateType.Minigame);
        }
    }
}
