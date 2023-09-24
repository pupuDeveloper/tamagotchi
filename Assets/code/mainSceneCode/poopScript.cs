using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class poopScript : MonoBehaviour
{

    private bool isCoroutineRunning;
    private bool isPassiveCoroutineRunning;
    public int spawnInterval1;
    public int spawnInterval2;
    public int passiveTimer;
    public GameObject poopPrefab;
    private happinessBar happinessbar;
    public GameObject happinessBarScriptHolder;
    public Button cleanpoopButton;
    List<GameObject> poops = new List<GameObject>();

    void Awake()
    {
        happinessbar = happinessBarScriptHolder.GetComponent<happinessBar>();
    }

    //fixedupdate checks how many poops are in the screen from gamemanager, and also checks if a timer is running
    //before running the spawner script
    void FixedUpdate()
    {
        if (GameManager.Instance.poopAmount < 5 && isCoroutineRunning == false && GameManager.Instance.gameIsPaused == false)
        {
            StartCoroutine("spawnPoops");
        }

        if (GameManager.Instance.poopAmount < 1)
        {
            cleanpoopButton.interactable = false;
        }
        else
        {
            cleanpoopButton.interactable = true;
        }

        if (isPassiveCoroutineRunning == false)
        {
            StartCoroutine("passiveHappinessChange");
        }
    }

    //IEnumerator coroutine randomises time between spawnInterval1 and Spawninterval2
    //Then it randomises position
    //Then it creates a copy of the poop prefab and spawns it to the screen
    //It also adds the added prefab copy to the poops list
    IEnumerator spawnPoops()
    {
        isCoroutineRunning = true;
        int spawnTime = Random.Range(spawnInterval1, spawnInterval2);
        yield return new WaitForSeconds (spawnTime);
        Vector2 pos = new Vector2(Random.Range(-13.5f, 13.5f), Random.Range(-2.5f,1f));
        GameObject instancedPoop = Instantiate(poopPrefab, pos, Quaternion.identity);
        GameManager.Instance.poopAmount++;
        Debug.Log(GameManager.Instance.poopAmount);
        poops.Add(instancedPoop);
        GameManager.Instance.happiness -= (0.05f * GameManager.Instance.happinessMultiplier);
        happinessbar.UpdateHappinessBar();
        isCoroutineRunning = false;
    }

    IEnumerator passiveHappinessChange()
    {
        isPassiveCoroutineRunning = true;
        switch (GameManager.Instance.poopAmount)
        {
            case 0:
            GameManager.Instance.happiness += 0.02f;
            happinessbar.UpdateHappinessBar();
            break;
            
            case 1:
            GameManager.Instance.happiness += 0.01f;
            happinessbar.UpdateHappinessBar();
            break;

            case 2:
            break;

            case 3:
            GameManager.Instance.happiness -= (0.01f * GameManager.Instance.happinessMultiplier);
            happinessbar.UpdateHappinessBar();
            break;

            case 4:
            GameManager.Instance.happiness -= (0.02f * GameManager.Instance.happinessMultiplier);
            happinessbar.UpdateHappinessBar();
            break;

            case 5:
            GameManager.Instance.happiness -= (0.04f * GameManager.Instance.happinessMultiplier);
            happinessbar.UpdateHappinessBar();
            break;
        }
        yield return new WaitForSeconds (passiveTimer);
        isPassiveCoroutineRunning = false;
    }

    // This method is for the cleaning/bathroom button that cleans poops
    // after destroying all poops in the List, it also clears the list
    // and makes sure gamemanager also has correct (0) amount of poops
    public void cleanPoopButton()
    {
        foreach (GameObject poop in poops)
        {
            Destroy(poop);
        }
        poops.Clear();
        GameManager.Instance.poopAmount = 0;
        GameManager.Instance.happiness += 0.10f;
        happinessbar.UpdateHappinessBar();
    }
}
