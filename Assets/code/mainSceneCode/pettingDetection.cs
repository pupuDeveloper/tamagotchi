using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pettingDetection : MonoBehaviour
{

    private petButton petbutton;
    private happinessBar happinessbar;
    [SerializeField] private GameObject heartParticle;
    private Animator playAniClip;

    void Awake()
    {
        petbutton = GameObject.Find("Main Camera").GetComponent<petButton>();
        happinessbar = GameObject.Find("happinesbarBackground").GetComponent<happinessBar>();
        playAniClip = heartParticle.GetComponent<Animator>();
    }

    void OnMouseEnter()
    {
        if (petbutton.isBrushingOn)
        {
            Vector2 pos = new Vector2(Random.Range(-1f, 1f), Random.Range(1f, 1.5f));
            heartParticle.transform.position = pos;
            playAniClip.Play("petheartanimation");
            petbutton.petProgress++;
        }
    }
}
