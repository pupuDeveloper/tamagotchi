using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class buttonAnims : MonoBehaviour
{
    private Button b;
    private Animator banimator;
    private bool selected;
    private bool reset;
    void Awake()
    {
        b = gameObject.GetComponent<Button>();
        banimator = gameObject.GetComponent<Animator>();
        b.interactable = false;
        reset = false;
    }

    void Update()
    {
        if (b.interactable == false)
        {
            reset = false;
            banimator.SetInteger("selected", 3);
        }
        else if (b.interactable && reset == false)
        {
            reset = true;
            banimator.SetTrigger("activation");
        }
    }
    public void selectedAnim()
    {
        if (banimator.GetInteger("selected") != 2)
        {
            banimator.SetInteger("selected", 2);
        }
        else if (banimator.GetInteger("selected") == 2)
        {
            banimator.SetInteger("selected", 1);
        }
    }
}
