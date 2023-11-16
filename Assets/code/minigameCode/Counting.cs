using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace BunnyHole
{

    public class Counting : MonoBehaviour
    {
        [SerializeField] private int _totalCount;
        public static int _count = 0;
        public TextMeshProUGUI countText;
        public static int eyeBallCount = 0;
        private bool completed = false;

        private void Start()
        {
            completed = false;
            _count = 0;
            eyeBallCount = 0;
            countText.text = _count + "/" + _totalCount;
        }
        private void Update()
        {
            countText.text = _count + "/" + _totalCount;
            if (eyeBallCount == 3 && completed == false)
            {
                FailedMinigame();
                completed = true;
            }
            if (_count == _totalCount && completed == false && eyeBallCount < 3)
            {
                TrackingCount();
                completed = true;
                //_count = 0;
            }
        }

        // Adds points for successfully compliting the minigame in to the happiness meter.
        // game is still paused in the main scene, and minigame has been played.
        // Checks the evolution progression in the game manager.
        // Coroutine waits before exiting the minigame to go back to the main scene.
        private void TrackingCount()
        {
            GameManager.Instance.minigameWasSuccess = true;
            GameManager.Instance.gameIsPaused = false;
            GameManager.Instance.miniGamePlayed = true;
            if (GameManager.Instance.evolutionProgression >= GameManager.Instance.evolutionLenght)
            {
                GameManager.Instance.evolutionChange();
            }
            StartCoroutine(WaitBeforeExit());
        }

        // No points to happines meter, game is still paused and minigame has been played
        // Checks the evolution progression for the pet and after that goes to the Coroutine
        // method that waits before exiting the minigame.
        private void FailedMinigame()
        {
            GameManager.Instance.minigameWasSuccess = false;
            GameManager.Instance.gameIsPaused = false;
            GameManager.Instance.miniGamePlayed = true;
            if (GameManager.Instance.evolutionProgression >= GameManager.Instance.evolutionLenght)
            {
                GameManager.Instance.evolutionChange();
            }
            StartCoroutine(WaitBeforeExit());
            Debug.Log(GameManager.Instance.happiness);
        }

        // Waits 1 second, before going to Exit method
        private IEnumerator WaitBeforeExit()
        {
            float _waiting = 1.0f;
            yield return new WaitForSeconds(_waiting);
            Exit();
        }

        // Changes the scene back to Main Scene after waiting 1.2second.
        private void Exit()
        {
            GameManager.Instance.returningFromMinigame = true;
            GameManager.Instance.Go(States.StateType.MainScene);
        }
    }
}
