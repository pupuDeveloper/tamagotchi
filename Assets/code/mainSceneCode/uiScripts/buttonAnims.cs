using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonAnims : MonoBehaviour
{
    private Button b;
    [SerializeField] private GameObject animations;
    private SpriteRenderer animRenderer;
    private Animator banimator;
    private bool selected;
    private bool reset;
    void Awake()
    {
        b = gameObject.GetComponent<Button>();
        animRenderer = animations.GetComponent<SpriteRenderer>();
        banimator = animations.GetComponent<Animator>();
        animRenderer.enabled = false;
        selected = false;
        reset = false;
    }
    
    void FixedUpdate()
    {
        if (b.interactable == false)
        {
            reset = true;
            animRenderer.enabled = false;
            selected = false;
        }
        else if(b.interactable && reset)
        {
            reset = false;
            animRenderer.enabled = true;
            banimator.SetTrigger("startAnim2");
            banimator.ResetTrigger("startAnim");
        }
    }
    public void selectButton()
    {
        if (selected == false)
        {
            selected = true;
            animRenderer.enabled = true;
            banimator.SetTrigger("startAnim");
        }
        else
        {
            selected = false;
            animRenderer.enabled = false;
        }
    }
}
