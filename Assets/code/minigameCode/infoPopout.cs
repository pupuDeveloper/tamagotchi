using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class infoPopout : MonoBehaviour
{
    [SerializeField] private GameObject popout;
    [SerializeField] private Toggle toggle;
    [SerializeField] private GameObject crossImage;

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
    public void OnToggleValueChanged()
    {
        if (toggle.isOn)
        {
            crossImage.SetActive(true);
        }
        else
        {
            crossImage.SetActive(false);
        }
    }
}
