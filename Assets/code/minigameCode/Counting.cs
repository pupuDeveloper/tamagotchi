using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Counting : MonoBehaviour
{
    [SerializeField] private int _totalCount;
    public Button button;
    public static int _count = 0;
    public TextMeshProUGUI countText;
    public static int eyeBallCount = 0;
    private bool completed = false;

    private void Start()
    {
        completed = false;
        _count = 0;
        eyeBallCount = 0;
        button.interactable = false;
        countText.text = "Completion: " + _count + "/" + _totalCount;
    }
    private void TrackingCount()
    {
        // Debug.Log("good job you collected all the strawberries");

        GameManager.Instance.happiness += 0.01f * _count;
        button.interactable = true;
    }
    private void Update()
    {
        countText.text = "Completion: " + _count + "/" + _totalCount;
        if (_count == _totalCount && completed == false)
        {
            TrackingCount();
            completed = true;
            //_count = 0;
        }
    }
}
