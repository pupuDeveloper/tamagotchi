using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BunnyHole
{
    public class Minigame : MonoBehaviour
    {
        [SerializeField] private GameObject _berryPrefab; // Strawberry prefab.
        [SerializeField] private GameObject _eyePrefab; // Eyeball prefab.
        [SerializeField] private int _maxAmount; // The maximum amount of berries the player can collect.
        [SerializeField] private float _minSpawnDelay; // Minimum spawntime delay.
        [SerializeField] private float _maxSpawnDelay; // Maximum time the prefabs take to spawn.
        private List<GameObject> _instantiatedEyes = new List<GameObject>(); 
        private List<GameObject> _instantiatedBerries = new List<GameObject>();
        private GameObject popoutwindow; // Popout window that shows up first -> introductions to the minigame
        private int _countSpawn = 0; // Strawberry count
        private int _eyeCountSpawn = 0; // Eyeball count

        private void Awake()
        {
            // Finding the Popout window first
            popoutwindow = GameObject.Find("infoPopout");
            Debug.Log(GameManager.Instance.gameIsPaused);
        }
        private void Start()
        {
            // Checking that the counts are at 0 at the beginning.
            _countSpawn = 0;
            _eyeCountSpawn = 0;
        }
        private void FixedUpdate()
        {
            // If info Window is not open, start spawning strawberries and eyeballs.
            if (popoutwindow.activeSelf == false)
            {
                StartCoroutine(SpawnBerriesWithDelay());
            }
        }

        // IEnumerator coroutine randomises time between minSpawnDelay and maxSpawnDelay.
        // Randomises the position and then creates copies of the prefabs and spawns them
        // above the screen.
        // Adds the prefab copies to the list.
        private IEnumerator SpawnBerriesWithDelay()
        {
            // Sets the random x-axis position with random spawn delay
            // when and where the berries start to spawn.
            float delay = Random.Range(_minSpawnDelay, _maxSpawnDelay);
            yield return new WaitForSeconds(delay);
            Vector2 pos = new Vector2(Random.Range(-3.85f, 3.80f), 6);

            // If there is less or equals 15 spawn the berries.
            if (_countSpawn <= _maxAmount)
            {
                GameObject berries = Instantiate(_berryPrefab, pos, Quaternion.identity);
                _instantiatedBerries.Add(berries);
                _countSpawn++;

                // If there is less or equals 3 spawn the eyeballs.
                if (_eyeCountSpawn <= 2)
                {
                    GameObject eye = Instantiate(_eyePrefab, pos, Quaternion.identity);
                    _instantiatedEyes.Add(eye);
                    _eyeCountSpawn++;
                }
            }

        }
    }
}

