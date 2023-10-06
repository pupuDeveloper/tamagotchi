using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class poopScript : MonoBehaviour
{

    private bool isCoroutineRunning;
    private bool isPassiveCoroutineRunning;
    public bool isCleaningOn;
    public int spawnInterval1;
    public int spawnInterval2;
    public float passiveTimer;
    public GameObject poopPrefab;
    private happinessBar happinessbar;
    public GameObject happinessBarScriptHolder;
    public Button cleanpoopButton;
    public List<GameObject> poops = new List<GameObject>();
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    void Awake()
    {
        happinessbar = happinessBarScriptHolder.GetComponent<happinessBar>();
        for (int i = 0; i < GameManager.Instance.poopAmount; i++)
        {
            Vector2 pos = new Vector2(Random.Range(-8.5f, 8.5f), Random.Range(-2.5f,0.5f));
            GameObject instancedPoop = Instantiate(poopPrefab, pos, Quaternion.identity);
            poops.Add(instancedPoop);
        }
    }

    //fixedupdate checks how many poops are in the screen from gamemanager, and also checks if a timer is running
    //before running the spawner script
    void FixedUpdate()
    {
        if (GameManager.Instance.poopAmount < 5 && isCoroutineRunning == false && GameManager.Instance.gameIsPaused == false)
        {
            StartCoroutine("spawnPoops");
        }
        if (GameManager.Instance.poopAmount < 1 && isCleaningOn == false)
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
        Vector2 pos = new Vector2(Random.Range(-6.5f, 6.5f), Random.Range(-1.5f,0.5f));
        GameObject instancedPoop = Instantiate(poopPrefab, pos, Quaternion.identity);
        GameManager.Instance.poopAmount++;
        poops.Add(instancedPoop);
        GameManager.Instance.happiness -= (0.02f * GameManager.Instance.happinessMultiplier);
        happinessbar.UpdateHappinessBar();
        isCoroutineRunning = false;
        Debug.Log("poopamount in gamemanager :" + GameManager.Instance.poopAmount);
        Debug.Log("poopamount in poopscript :" + poops);
    }

    IEnumerator passiveHappinessChange()
    {
        isPassiveCoroutineRunning = true;
        switch (GameManager.Instance.poopAmount)
        {
            case 0:
            break;
            
            case 1:
            GameManager.Instance.happiness -= (0.0017f * GameManager.Instance.happinessMultiplier);
            happinessbar.UpdateHappinessBar();
            break;

            case 2:
            GameManager.Instance.happiness -= (0.0034f * GameManager.Instance.happinessMultiplier);
            happinessbar.UpdateHappinessBar();
            break;

            case 3:
            GameManager.Instance.happiness -= (0.0068f * GameManager.Instance.happinessMultiplier);
            happinessbar.UpdateHappinessBar();
            break;

            case 4:
            GameManager.Instance.happiness -= (0.0132f * GameManager.Instance.happinessMultiplier);
            happinessbar.UpdateHappinessBar();
            break;

            case 5:
            GameManager.Instance.happiness -= (0.0264f * GameManager.Instance.happinessMultiplier);
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
        if (isCleaningOn)
        {
            isCleaningOn = false;
            Cursor.SetCursor(null, hotSpot, cursorMode);
        }
        else
        {
            isCleaningOn = true;
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        }
    }
}
