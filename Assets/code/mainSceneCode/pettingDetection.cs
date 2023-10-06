using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pettingDetection : MonoBehaviour
{

    private petButton petbutton;
    private happinessBar happinessbar;

    void Awake()
    {
        petbutton = GameObject.Find("Main Camera").GetComponent<petButton>();
        happinessbar = GameObject.Find("happinesbarBackground").GetComponent<happinessBar>();
    }

    void OnMouseEnter()
    {
        if (petbutton.isBrushingOn)
        {
            petbutton.petProgress++;
        }
    }
}
