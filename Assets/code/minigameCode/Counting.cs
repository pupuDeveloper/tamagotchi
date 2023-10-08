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

    private void Start()
    {
        _count = 0;
        button.interactable = false;
        countText.text = "Completion: " + _count + "/" + _totalCount;
    }
    private void TrackingCount()
    {
        Debug.Log("good job you collected all the strawberries");
        GameManager.Instance.happiness += 0.15f;
        button.interactable = true;
    }
    private void Update()
    {

        countText.text = "Completion: " + _count + "/" + _totalCount;
        if (_count == _totalCount)
        {
           // _count = 0;
            TrackingCount();
        }
    }
}
