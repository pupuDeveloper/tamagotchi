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

    private void Start()
    {
        _count = 0;
        button.interactable = false;
    }
    private void TrackingCount()
    {
        Debug.Log("good job you collected all the strawberries");
        GameManager.Instance.happiness += 0.30f;
        button.interactable = true;
        
    }
    private void Update()
    {
        if (_count == _totalCount)
        {
            _count = 0;
            TrackingCount();
        }
    }
}
