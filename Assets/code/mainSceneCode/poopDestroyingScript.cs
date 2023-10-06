using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poopDestroyingScript : MonoBehaviour
{

    private poopScript poopscript;
    private happinessBar happinessbar;

    void Awake()
    {
        poopscript = GameObject.Find("poopSpawner").GetComponent<poopScript>();
        happinessbar = GameObject.Find("happinesbarBackground").GetComponent<happinessBar>();
    }
    void OnMouseDown()
    {
        if (poopscript.isCleaningOn)
        {
        poopscript.poops.Remove(gameObject);
        GameManager.Instance.happiness += 0.03f;
        GameManager.Instance.poopAmount--;
        happinessbar.UpdateHappinessBar();
        Destroy(gameObject);
        }
    }
}
