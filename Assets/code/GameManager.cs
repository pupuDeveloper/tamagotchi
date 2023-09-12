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

    private void Awake()
    {
        happiness = 0.5f;
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
    }
}
