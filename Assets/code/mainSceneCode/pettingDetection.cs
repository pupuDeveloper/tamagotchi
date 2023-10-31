using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pettingDetection : MonoBehaviour
{
    private petButton petbutton;
    private happinessBar happinessbar;
    [SerializeField] private GameObject heartParticle;
    int animLayer = 0;
    private float currentXpos;
    private float currentYpos;

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
            Vector2 pos = new Vector2(Random.Range(currentXpos - 0.5f, currentXpos + 0.5f), Random.Range(currentYpos + 0.4f, currentYpos + 0.1f));
            GameObject instancedParticleEffect = Instantiate(heartParticle, pos, Quaternion.identity);
        }
    }

    void FixedUpdate()
    {
        currentXpos = transform.position.x;
        currentYpos = transform.position.y;
    }
}

