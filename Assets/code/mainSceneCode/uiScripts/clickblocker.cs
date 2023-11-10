using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clickblocker : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    void FixedUpdate()
    {
        if (pauseMenu.activeSelf)
        {
            gameObject.GetComponent<Image>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<Image>().enabled = false;
        }
    }
}
