using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace BunnyHole
{

    public class minigameButton : MonoBehaviour
    {
        private bool isButtonAvailable;
        public Button minigamebutton;
        private Scene scene;
        [SerializeField] private GameObject creature;
        public CursorMode cursorMode = CursorMode.Auto;
        public Vector2 hotSpot = Vector2.zero;
        public void Switch()
        {
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name == "mainScene")
            {
                Cursor.SetCursor(null, hotSpot, cursorMode);
                GameManager.Instance.creaturePosition = creature.transform.position;
                GameManager.Instance.gameIsPaused = true;
            }
        }
        void FixedUpdate()
        {
            scene = SceneManager.GetActiveScene();
            if (GameManager.Instance.miniGamePlayed == false && scene.name == "mainScene" && GameManager.Instance.activityToBeLaunched == 3)
            {
                minigamebutton.interactable = true;
            }
            else if (GameManager.Instance.miniGamePlayed && scene.name == "mainScene")
            {
                minigamebutton.interactable = false;
            }
        }
    }
}
