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
    public int day { get; set; }
    public float dayProgression { get; set; }
    public float dayLenght { get; set; }
    private bool isDayChangeRunning { get; set; }
    public float happinessMultiplier { get; set; }
    public bool activePet { get; set; }
    public string CurrentlyPlayedPetName { get; set; }
    public bool gameIsPaused { get; set; }
    public float petDeathTimer { get; set; }
    public bool miniGamePlayed { get; set; }
    private bool minigameCoroutineRunning { get; set; }
    private void Awake()
    {
        //TODO: read values below from memory. if null, create said values below
        dayLenght = 15f;
        happiness = 0.5f;
        day = 1;
        dayProgression = 0f;
        happinessMultiplier = 1f;
        petDeathTimer = 20f;
        miniGamePlayed = false;
        gameIsPaused = true;
        minigameCoroutineRunning = false;
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
            dayProgression += Time.deltaTime;
            if (dayProgression >= dayLenght && isDayChangeRunning == false)
            {
                StartCoroutine("dayChange");
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
    }
    IEnumerator dayChange()
    {
        gameIsPaused = true;
        if (day == 6)
        {
            lastDayPetEnd();
        }
        else
        {
            isDayChangeRunning = true;
        // TODO: Fade black or similar that shows new day n shit
        yield return new WaitForSeconds(5);
        day++;
        happinessMultiplier += 0.1f;
        dayProgression = 0f;
        Debug.Log("New Day Has Started");
        isDayChangeRunning = false;
        gameIsPaused = false;
        }
    }
    void lastDayPetEnd()
    {
        Debug.Log("you survived with your... pet? for a week. It has spared you from its terror, but it will not spare others. It has left to raise hell elsewhere, but it didnt leave you empty handed");
        gameIsPaused = true;
        activePet = false;
        CurrentlyPlayedPetName = "";
        day = 1;
        dayProgression = 0f;
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
        day = 1;
        dayProgression = 0f;
        happinessMultiplier = 1f;
        petDeathTimer = 20f;
        happiness = 0.5f;
        miniGamePlayed = false;
        SceneManager.LoadScene("mainmenu");
    }
    IEnumerator miniGamecooldown()
    {
        minigameCoroutineRunning = true;
        yield return new WaitForSeconds (dayLenght - dayProgression);
        miniGamePlayed = false;
        minigameCoroutineRunning = false;
    }
}
