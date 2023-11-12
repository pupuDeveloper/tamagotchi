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
        GameManager.Instance.poops.Remove(gameObject.transform.position);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        GameManager.Instance.happiness += 0.03f;
        StartCoroutine(happinessbar.particle(3));
        StartCoroutine("destroyDelay");
        }
    }
    IEnumerator destroyDelay()
    {
        yield return new WaitForSeconds(0.46f);
        Destroy(gameObject);
    }
}
