using BunnyHole; // BunnyHole namespace
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
    private AudioSource _openAudio; // Button open audio effect.
    void Awake()
    {
        // Get Audio Source component from the button.
        _openAudio = GetComponent<AudioSource>();
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
            // If the button is selected play the button on audio clip.
            if(_openAudio != null)
            {
                AudioManager.PlayClip(_openAudio, BunnyHole.Config.SoundEffect.SelectButton);
            }
            animRenderer.enabled = true;
            banimator.SetTrigger("startAnim");
        }
        else
        {
            selected = false;
            // If button is not selected play the button off audio clip.
            if(_openAudio != null)
            {
                AudioManager.PlayClip(_openAudio, BunnyHole.Config.SoundEffect.UnselectButton);
            }
            animRenderer.enabled = false;
        }
    }
}
