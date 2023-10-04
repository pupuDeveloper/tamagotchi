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
    private int activityInterval1 { get; set; }
    private int activityInterval2 { get; set; }
    public int activityToBeLaunched { get; set; }
    public bool isActivityCooldownRunning { get; set; }
    private int individualActivityCooldown { get; set; }
    public List<pet> petCollection { get; set; }
    public pet currentPet { get; set; }
    private void Awake()
    {
        //TODO: read values below from memory. if null, create said values below
        evolutionLenght = 180f;
        happiness = 0.5f;
        evolution = 1;
        evolutionProgression = 0f;
        happinessMultiplier = 1f;
        petDeathTimer = 20f;
        activityInterval1 = 3;
        activityInterval2 = 12;
        individualActivityCooldown = 20;
        miniGamePlayed = false;
        brushPet = false;
        bunnyPlay = false;
        gameIsPaused = true;
        minigameCoroutineRunning = false;
        isBunnyPlayCooldownRunning = false;
        isbrushBunnyCooldownRunning = false;
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
                StartCoroutine("evolutionChange");
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
        if (isActivityCooldownRunning == false)
        {
            StartCoroutine("activityCooldown");
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
        if (evolution == 2)
        {
            evolutionLenght = 360f;
        }
        else if (evolution == 3)
        {
            evolutionLenght = 9999999999999999999f;
        }
        Debug.Log("Your pet is growing!!!");
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
        petCollection.Add(currentPet);
        currentPet = null;
        SceneManager.LoadScene("mainmenu");
    }
    IEnumerator miniGamecooldown()
    {
        minigameCoroutineRunning = true;
        yield return new WaitForSeconds (individualActivityCooldown);
        miniGamePlayed = false;
        minigameCoroutineRunning = false;
    }
    IEnumerator brushBunnyCooldown()
    {
        isbrushBunnyCooldownRunning = true;
        yield return new WaitForSeconds (individualActivityCooldown);
        brushPet = false;
        isbrushBunnyCooldownRunning = false;
    }
    IEnumerator playWithBunnyCooldown()
    {
        isBunnyPlayCooldownRunning = true;
        yield return new WaitForSeconds (individualActivityCooldown);
        bunnyPlay = false;
        isBunnyPlayCooldownRunning = false;
    }
    IEnumerator activityCooldown()
    {
        isActivityCooldownRunning = true;
        int activityInterval = Random.Range(activityInterval1, activityInterval2);
        yield return new WaitForSeconds (activityInterval);
        activityToBeLaunched = activityRandomizer();
        while (activityToBeLaunched == 0)
        {
            activityToBeLaunched = activityRandomizer();
            yield return new WaitForSeconds(1);
        }
        Debug.Log("minigame number :" + activityToBeLaunched);
        isActivityCooldownRunning = false;
    }
    public int activityRandomizer()
    {
        int activityNumber = 0;
        List<int> availableGames= new List<int>();
        if (minigameCoroutineRunning == false)
        {
            availableGames.Add(1);
        }
        if(isbrushBunnyCooldownRunning == false)
        {
            availableGames.Add(2);
        }
        if(isBunnyPlayCooldownRunning == false)
        {
            availableGames.Add(3);
        }
        if (availableGames.Count == 0)
        {
            activityNumber = 0;
            return activityNumber;
        }
        int pickActivity = Random.Range (0, availableGames.Count);
        activityNumber = availableGames[pickActivity];
        return activityNumber;
    }
}
