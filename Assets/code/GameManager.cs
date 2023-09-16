using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private void Awake()
    {
        //TODO: read values below from memory. if null, create said values below
        dayLenght = 210f;
        happiness = 0.5f;
        day = 1;
        dayProgression = 0f;
        happinessMultiplier = 1f;
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
        if (happiness > 1)
        {
            happiness = 1;
        }
        else if (happiness < 0)
        {
            happiness = 0;
        }
        dayProgression += Time.deltaTime;
        if (dayProgression >= dayLenght && isDayChangeRunning == false)
        {
            StartCoroutine("dayChange");
        }
    }
    IEnumerator dayChange()
    {
        isDayChangeRunning = true;
        // TODO: Fade black or similar that shows new day n shit
        yield return new WaitForSeconds (5);
        day++;
        happinessMultiplier += 0.1f;
        dayProgression = 0f;
        Debug.Log("New Day Has Started");
        isDayChangeRunning = false;
    }
}
