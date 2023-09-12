using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class happinessBar : MonoBehaviour
{

    [SerializeField] private Image happinessbarFill;

    void Awake()
    {
        UpdateHappinessBar();
    }
//this function adds or subtracts happiness points from the bar. 0 is 0 and 1 is full (0.5 is half bar)
    public void UpdateHappinessBar()
    {
        happinessbarFill.fillAmount = GameManager.Instance.happiness;
    }
}
