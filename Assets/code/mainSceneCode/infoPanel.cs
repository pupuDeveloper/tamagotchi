using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infoPanel : MonoBehaviour
{
    [SerializeField] private GameObject infoPanelObject;

    void Awake()
    {
        if (GameManager.Instance.isInfoGiven == false)
        {
            GameManager.Instance.gameIsPaused = true;
            infoPanelObject.SetActive(true);
        }
        else
        {
            infoPanelObject.SetActive(false);
        }
    }

    public void okButton()
    {
        infoPanelObject.SetActive(false);
        GameManager.Instance.isInfoGiven = true;
        GameManager.Instance.gameIsPaused = false;
    }
}
