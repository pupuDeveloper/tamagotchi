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
       // public Button button;
        public static int _count = 0;
        public TextMeshProUGUI countText;
        public static int eyeBallCount = 0;
        private bool completed = false;

        private void Start()
        {
            completed = false;
            _count = 0;
            eyeBallCount = 0;
            //button.interactable = false;
            countText.text = _count + "/" + _totalCount;
        }
        private void Update()
        {
            countText.text = _count + "/" + _totalCount;
            if (eyeBallCount == 3 && _count == _totalCount && completed == false)
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
        private void TrackingCount()
        {
            // Debug.Log("good job you collected all the strawberries");
            GameManager.Instance.happiness += 0.15f;
            GameManager.Instance.gameIsPaused = false;
            GameManager.Instance.miniGamePlayed = true;
            if (GameManager.Instance.evolutionProgression >= GameManager.Instance.evolutionLenght)
            {
                GameManager.Instance.evolutionChange();
            }
            GameManager.Instance.Go(States.StateType.MainScene);
            //button.interactable = true;
        }

        private void FailedMinigame()
        {
            GameManager.Instance.happiness += 0f;
            GameManager.Instance.gameIsPaused = false;
            GameManager.Instance.miniGamePlayed = true;
            if (GameManager.Instance.evolutionProgression >= GameManager.Instance.evolutionLenght)
            {
                GameManager.Instance.evolutionChange();
            }
            GameManager.Instance.Go(States.StateType.MainScene);
            //button.interactable = true;
            Debug.Log(GameManager.Instance.happiness);
        }
    }
}
