using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Gamemanager is NULL");
            }

            return _instance;
        }
    }
    public int poopAmount { get; set; }
    public float happiness { get; set; }
    public int evolution { get; set; }
    public float evolutionProgression { get; set; }
    public float evolutionLenght { get; set; }
    private bool isEvolutionRunning { get; set; }
    public float happinessMultiplier { get; set; }
    public bool activePet { get; set; }
    public string CurrentlyPlayedPetName { get; set; }
    public bool gameIsPaused { get; set; }
    public float petDeathTimer { get; set; }
    public bool miniGamePlayed { get; set; }
    private bool minigameCoroutineRunning { get; set; }
    public bool minigameInfotoggle { get; set; }
    public bool isInfoGiven { get; set; }
    public bool bunnyPlay { get; set; }
    private bool isBunnyPlayCooldownRunning { get; set; }
    public bool brushPet { get; set; }
    private bool isbrushBunnyCooldownRunning { get; set; }
    private void Awake()
    {
        //TODO: read values below from memory. if null, create said values below
        evolutionLenght = 180f;
        happiness = 0.5f;
        evolution = 1;
        evolutionProgression = 0f;
        happinessMultiplier = 1f;
        petDeathTimer = 20f;
        miniGamePlayed = false;
        gameIsPaused = true;
        minigameCoroutineRunning = false;
        minigameInfotoggle = false;
        isInfoGiven = false;
        if (_instance)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(this);
    }
    void Update()
    {
        if (gameIsPaused == false)
        {
            if (happiness > 1)
            {
                happiness = 1;
            }
            else if (happiness <= 0)
            {
                happiness = 0;
                petDeathTimer -= Time.deltaTime;
            }
            evolutionProgression += Time.deltaTime;
            if (evolutionProgression >= evolutionLenght && isEvolutionRunning == false)
            {
                StartCoroutine("dayChange");
            }
            if (happiness > 0)
            {
                petDeathTimer = 20f;
            }
        }
        if (petDeathTimer <= 0 && gameIsPaused == false)
        {
            gameOver();
        }
        if (miniGamePlayed && minigameCoroutineRunning == false)
        {
            StartCoroutine("miniGamecooldown");
        }
        if (brushPet && isbrushBunnyCooldownRunning == false)
        {
            StartCoroutine("brushBunnyCooldown");
        }
        if (bunnyPlay && isBunnyPlayCooldownRunning == false)
        {
            StartCoroutine("playWithBunnyCooldown");
        }
    }
    IEnumerator evolutionChange()
    {
        gameIsPaused = true;
        if (evolution == 6)
        {
            lastDayPetEnd();
        }
        else
        {
            isEvolutionRunning = true;
        // TODO: Fade black or similar that shows new evolution n shit
        yield return new WaitForSeconds(6);
        evolution++;
        happinessMultiplier += 0.1f;
        evolutionProgression = 0f;
        Debug.Log("New Day Has Started");
        isEvolutionRunning = false;
        gameIsPaused = false;
        }
    }
    void lastDayPetEnd()
    {
        Debug.Log("you survived with your... pet? for a week. It has spared you from its terror, but it will not spare others. It has left to raise hell elsewhere, but it didnt leave you empty handed");
        gameIsPaused = true;
        activePet = false;
        CurrentlyPlayedPetName = "";
        evolution = 1;
        evolutionProgression = 0f;
        happinessMultiplier = 1f;
        happiness = 0.5f;
        miniGamePlayed = false;
        SceneManager.LoadScene("mainmenu");
    }
    void gameOver()
    {
        gameIsPaused = true;
        Debug.Log("you didn't attend to your pets needs, and its pathetic existence withered away.");
        activePet = false;
        CurrentlyPlayedPetName = "";
        evolution = 1;
        evolutionProgression = 0f;
        happinessMultiplier = 1f;
        petDeathTimer = 20f;
        happiness = 0.5f;
        miniGamePlayed = false;
        SceneManager.LoadScene("mainmenu");
    }
    IEnumerator miniGamecooldown()
    {
        minigameCoroutineRunning = true;
        yield return new WaitForSeconds (evolutionLenght - evolutionProgression);
        miniGamePlayed = false;
        minigameCoroutineRunning = false;
    }
    IEnumerator brushBunnyCooldown()
    {
        isbrushBunnyCooldownRunning = true;
        yield return new WaitForSeconds ((evolutionLenght / 4) - 10);
        brushPet = false;
        isbrushBunnyCooldownRunning = false;
    }
    IEnumerator playWithBunnyCooldown()
    {
        isBunnyPlayCooldownRunning = true;
        yield return new WaitForSeconds (evolutionLenght - evolutionProgression);
        bunnyPlay = false;
        isBunnyPlayCooldownRunning = false;
    }
}
