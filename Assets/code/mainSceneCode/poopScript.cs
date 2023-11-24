using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace BunnyHole
{
    public class poopScript : MonoBehaviour
    {

        private bool isCoroutineRunning;
        private bool isPassiveCoroutineRunning;
        public bool isCleaningOn;
        public int spawnInterval1;
        public int spawnInterval2;
        public float passiveTimer;
        public GameObject poopPrefab;
        public GameObject pukePrefab;
        public GameObject pissPrefab;
        private happinessBar happinessbar;
        public GameObject happinessBarScriptHolder;
        public Button cleanpoopButton;
        public Texture2D cursorTexture;
        public CursorMode cursorMode = CursorMode.Auto;
        public Vector2 hotSpot = Vector2.zero;
        public GameObject creature;
        public bool poopHasSpawned;
        private Vector3 addedVector;

        void Awake()
        {
            happinessbar = happinessBarScriptHolder.GetComponent<happinessBar>();
            for (int i = 0; i < GameManager.Instance.poops.Count; i++)
            {
                Vector3 pos = GameManager.Instance.poops[i];
                RandomizeMess(pos);
            }
        }

        //fixedupdate checks how many poops are in the screen from gamemanager, and also checks if a timer is running
        //before running the spawner script
        void FixedUpdate()
        {
            if (GameManager.Instance.poops.Count < 5 && isCoroutineRunning == false && GameManager.Instance.gameIsPaused == false)
            {
                StartCoroutine("spawnPoops");
            }
            if (GameManager.Instance.poops.Count < 1 && isCleaningOn == false)
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
            if (GameManager.Instance.poops.Count == 0)
            {
                isCleaningOn = false;
                Cursor.SetCursor(null, hotSpot, cursorMode);
                creature.GetComponentInChildren<BoxCollider2D>().enabled = true;
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
            yield return new WaitForSeconds(spawnTime);
            float rWidth = Random.Range(-0.5f, 0.5f);
            //float rHeight = Random.Range(-0.9f,-0.75f);
            float rHeight = -0.3f;
            Vector3 pos = new Vector3(creature.transform.position.x + rWidth, creature.transform.position.y + rHeight, -9);
            RandomizeMess(pos);
            poopHasSpawned = true;
            GameManager.Instance.poops.Add(addedVector);
            GameManager.Instance.happiness -= (0.02f * GameManager.Instance.happinessMultiplier);
            happinessbar.UpdateHappinessBar();
            isCoroutineRunning = false;
        }

        IEnumerator passiveHappinessChange()
        {
            isPassiveCoroutineRunning = true;
            switch (GameManager.Instance.poops.Count)
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
            yield return new WaitForSeconds(passiveTimer);
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
                creature.GetComponentInChildren<BoxCollider2D>().enabled = true;
            }
            else
            {
                isCleaningOn = true;
                Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
                creature.GetComponentInChildren<BoxCollider2D>().enabled = false;
            }
        }
        public void RandomizeMess(Vector3 pos)
        {
            int whichMess = Random.Range(1, 4);
            if (whichMess == 1)
            {
                GameObject instancedMess = Instantiate(poopPrefab, pos, Quaternion.identity);
                addedVector = instancedMess.transform.position;
            }
            else if (whichMess == 2)
            {
                GameObject instancedMess = Instantiate(pissPrefab, pos, Quaternion.identity);
                addedVector = instancedMess.transform.position;
            }
            else if (whichMess == 3)
            {
                GameObject instancedMess = Instantiate(pukePrefab, pos, Quaternion.identity);
                addedVector = instancedMess.transform.position;
            }
        }
    }
}
