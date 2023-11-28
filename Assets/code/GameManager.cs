using BunnyHole.States;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System;

namespace BunnyHole
{
    public class GameManager : MonoBehaviour, ISaveable
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
        public float happiness { get; set; }
        public int evolution { get; set; }
        public float evolutionProgression { get; set; }
        public float evolutionLenght { get; set; }
        public float happinessMultiplier { get; set; }
        public bool activePet { get; set; } // remember to save this on file
        public string CurrentlyPlayedPetName { get; set; }
        public bool gameIsPaused { get; set; }
        public float petDeathTimer { get; set; }
        public bool miniGamePlayed { get; set; }
        private bool minigameCoroutineRunning { get; set; }
        public bool minigameInfotoggle { get; set; }
        public bool lostToy { get; set; }
        private bool isLostToyCooldownRunning { get; set; }
        public bool dragging { get; set; }
        public bool brushPet { get; set; }
        private bool isbrushBunnyCooldownRunning { get; set; }
        private int activityInterval1 { get; set; }
        private int activityInterval2 { get; set; }
        public int activityToBeLaunched { get; set; }
        public bool isActivityCooldownRunning { get; set; }
        private int individualActivityCooldown { get; set; }
        public List<pet> petCollection { get; set; }
        public List<Vector3> poops { get; set; }
        public pet currentPet { get; set; }
        public Vector3 creaturePosition { get; set; }
        public bool returningFromMinigame { get; set; }
        public bool minigameWasSuccess { get; set; }
        public int idleAnimInt { get; set; }
        public newPetRandomiserBD petRandomiser { get; set; }
        public SaveSystem SaveSystem { get; private set; }

        // Contains all states
        private List<GameStateBase> _states = new List<GameStateBase>();
        // The currently active state.
        public GameStateBase CurrentState { get; private set; }
        private GameStateBase PreviousState { get; set; }

        private void Awake()
        {
            //TODO: read values below from memory. if null, create said values below
            evolutionLenght = 100f; // Don't save to file
            happiness = 0.5f;
            evolution = 1;
            evolutionProgression = 0f;
            happinessMultiplier = 1f; // Don't save to file
            petDeathTimer = 5f; // Don't save to file
            activityInterval1 = 3; // Don't save to file
            activityInterval2 = 12; // Don't save to file
            individualActivityCooldown = 20; // Don't save to file
            miniGamePlayed = false; // Don't save to file
            brushPet = false; // Don't save to file
            lostToy = false; // Don't save to file
            gameIsPaused = true; // Don't save to file
            minigameCoroutineRunning = false; // Don't save to file
            isLostToyCooldownRunning = false; // Don't save to file
            isbrushBunnyCooldownRunning = false; // Don't save to file
            minigameInfotoggle = false; // Don't save to file
            dragging = false; // Don't save to file
            creaturePosition = new Vector3(0, -2, -9); // Don't save to file
            poops = new List<Vector3>(); // Don't save to file
            petCollection = new List<pet>();
            returningFromMinigame = false; // Don't save to file
            idleAnimInt = -1; // Don't save to file
            currentPet = new pet("empty", 0 , null, null, 0); //placeholder
            InitializeSaveSystem();
            if (_instance)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }
            InitializeState();
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            string mainSaveSlot = SaveSystem.mainSaveSlot;
            SaveSystem.Load(mainSaveSlot);
            if (currentPet.childSprite == null || currentPet.adultSprite == null)
            {
                switch (currentPet.type)
            {
                case 1:
                currentPet.childSprite = petRandomiser.pet1.childSprite;
                currentPet.adultSprite = petRandomiser.pet1.adultSprite;
                break;
                case 2:
                currentPet.childSprite = petRandomiser.pet2.childSprite;
                currentPet.adultSprite = petRandomiser.pet2.adultSprite;
                break;
                case 3:
                currentPet.childSprite = petRandomiser.pet3.childSprite;
                currentPet.adultSprite = petRandomiser.pet3.adultSprite;
                break;
                case 0:
                break;
            }
            }
        }

        private void InitializeSaveSystem()
        {
            SaveSystem = new SaveSystem();
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
                if (happiness > 0)
                {
                    petDeathTimer = 5f;
                }
                if (miniGamePlayed && minigameCoroutineRunning == false)
                {
                    StartCoroutine("miniGamecooldown");
                }
                if (isActivityCooldownRunning == false)
                {
                    StartCoroutine("activityCooldown");
                }
            }
            if (petDeathTimer <= 0 && gameIsPaused == false)
            {
                gameOver();
            }
            if (brushPet && isbrushBunnyCooldownRunning == false)
            {
                StartCoroutine("brushBunnyCooldown");
            }
            if (lostToy && isLostToyCooldownRunning == false)
            {
                StartCoroutine("lostToyBunnyCooldown");
            }
        }
        public void evolutionChange()
        {
            // TODO: evolution after minigame played and age is above x
            evolution++;
            happinessMultiplier += 0.1f;
            if (evolution == 2)
            {
                evolutionLenght = 9999999999999999999f;
            }
            Debug.Log("Your pet is growing!!!");
        }
        void gameOver()
        {
            gameIsPaused = true;
            petCollection.Add(currentPet);
            Debug.Log("you didn't attend to your pets needs, and its pathetic existence withered away.");
            activePet = false;
            CurrentlyPlayedPetName = "";
            evolution = 1;
            evolutionProgression = 0f;
            happinessMultiplier = 1f;
            petDeathTimer = 20f;
            happiness = 0.5f;
            miniGamePlayed = false;
            currentPet = null;
            Go(StateType.GameOver);
        }
        IEnumerator miniGamecooldown()
        {
            minigameCoroutineRunning = true;
            yield return new WaitForSeconds(individualActivityCooldown);
            miniGamePlayed = false;
            minigameCoroutineRunning = false;
        }
        IEnumerator brushBunnyCooldown()
        {
            isbrushBunnyCooldownRunning = true;
            yield return new WaitForSeconds(individualActivityCooldown);
            brushPet = false;
            isbrushBunnyCooldownRunning = false;
        }
        IEnumerator lostToyBunnyCooldown()
        {
            isLostToyCooldownRunning = true;
            yield return new WaitForSeconds(individualActivityCooldown);
            lostToy = false;
            isLostToyCooldownRunning = false;
        }
        IEnumerator activityCooldown()
        {
            isActivityCooldownRunning = true;
            int activityInterval = UnityEngine.Random.Range(activityInterval1, activityInterval2);
            yield return new WaitForSeconds(activityInterval);
            activityToBeLaunched = activityRandomizer();
            while (activityToBeLaunched == 0)
            {
                activityToBeLaunched = activityRandomizer();
                yield return new WaitForSeconds(1);
            }
            isActivityCooldownRunning = false;
        }
        public int activityRandomizer()
        {
            int activityNumber = 0;
            List<int> availableGames = new List<int>();
            if (minigameCoroutineRunning == false)
            {
                availableGames.Add(1);
            }
            if (isbrushBunnyCooldownRunning == false)
            {
                availableGames.Add(2);
            }
            if (isLostToyCooldownRunning == false)
            {
                availableGames.Add(3);
            }
            if (availableGames.Count == 0)
            {
                activityNumber = 0;
                return activityNumber;
            }
            int pickActivity = UnityEngine.Random.Range(0, availableGames.Count);
            activityNumber = availableGames[pickActivity];
            return activityNumber;
        }

        private void InitializeState()
        {
            // Probably have to change how initialState is Introstate and
            // not main menu state.
            GameStateBase initialState = (new IntroState());
            //Create all states.
            _states.Add(initialState);
            _states.Add(new MainMenuState());
            _states.Add(new MainSceneState());
            _states.Add(new OptionsState());
            _states.Add(new CreditsState());
            _states.Add(new MinigameState());
            _states.Add(new GameOverState());

            string activeSceneName = SceneManager.GetActiveScene().name.ToLower();
            foreach (GameStateBase state in _states)
            {
                if (state.SceneName.ToLower() == activeSceneName)
                {
                    initialState = state;
                    break;
                }
            }

            CurrentState = initialState;
            CurrentState.Activate();
        }

        private GameStateBase GetState(StateType type)
        {
            // Loop through all states.
            foreach (GameStateBase state in _states)
            {
                // If the state type matches the request type, return the state.
                if (state.Type == type)
                {
                    return state;
                }
            }
            // If no state was found, return null. Null is used as an error value here.
            return null;
        }

        public bool Go(StateType targetStateType)
        {
            // Is the transition from the current state to target state allowed?
            if (!CurrentState.IsValidTarget(targetStateType))
            {
                // The transition from current state to the target is not legal.
                // Prevent the transition
                Debug.Log($"Transition from {CurrentState.Type} to {targetStateType} is not allowed.");
                return false;
            }

            // Get the target state.
            GameStateBase targetState = GetState(targetStateType);

            if (targetState == null)
            {
                Debug.Log($"Target state {targetStateType} is not found.");
                return false;
            }

            // Deactivate the current state.
            CurrentState.Deactivate();
            // Stores a reference to the previous state. Used in Go Back
            //functionality
            PreviousState = CurrentState;
            // Change the state.
            CurrentState = targetState;
            // Activate the new state.
            CurrentState.Activate();

            return true;
        }

        public bool GoBack()
        {
            return Go(PreviousState.Type);
        }

        public void Save(BinarySaver writer)
        {
            //evolution
            writer.WriteInt(evolution);
            //pet type
            writer.WriteInt(currentPet.type);
            //pets age
            writer.WriteFloat(currentPet.ageInSeconds);
            //happiness
            writer.WriteFloat(happiness);
            //evo progression
            writer.WriteFloat(evolutionProgression);
            //is there a current pet
            writer.WriteBool(activePet);
            //pets name
            writer.WriteString(currentPet.petName);
        }

        public void Load(BinarySaver reader)
        {
            evolution = reader.ReadInt();
            currentPet.type = reader.ReadInt();
            currentPet.ageInSeconds = reader.ReadFloat();
            happiness = reader.ReadFloat();
            evolutionProgression = reader.ReadFloat();
            activePet = reader.ReadBool();
            currentPet.petName = reader.ReadString();
        }
    }
}

