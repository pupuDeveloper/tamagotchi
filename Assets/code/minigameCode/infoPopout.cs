using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class infoPopout : MonoBehaviour
{
    [SerializeField] private GameObject popout;
    [SerializeField] private Toggle toggle;

    void Start()
    {
        if (GameManager.Instance.minigameInfotoggle == false)
        {
            popout.SetActive(true);
        }
        else
        {
        popout.SetActive(false);
        }
        Debug.Log("bool in gamemanager is: " +GameManager.Instance.minigameInfotoggle);
    }

    public void OkButton()
    {
        if (toggle.isOn)
        {
            GameManager.Instance.minigameInfotoggle = true;
        }
        else
        {
            GameManager.Instance.minigameInfotoggle = false;
        }
    }
}
