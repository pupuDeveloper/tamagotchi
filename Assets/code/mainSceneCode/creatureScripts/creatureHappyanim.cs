using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creatureHappyanim : MonoBehaviour
{
    private creatureStatus creatureStatusScript;

    void Awake()
    {
        creatureStatusScript = gameObject.GetComponent<creatureStatus>();
    }

    public void triggerHappyAnim()
    {
        gameObject.GetComponent<Animator>().SetBool("happyanim", true);
    }
}
