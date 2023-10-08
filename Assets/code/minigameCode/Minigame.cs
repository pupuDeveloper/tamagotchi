using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Minigame : MonoBehaviour
{
    [SerializeField] private GameObject _berryPrefab;
    [SerializeField] private int _maxAmount;
    [SerializeField] private float _minSpawnDelay;
    [SerializeField] private float _maxSpawnDelay;
    private GameObject popoutwindow;
    private int _countSpawn = 0;

    private void Awake()
    {
        popoutwindow = GameObject.Find("infoPopout");
    }

    private void FixedUpdate()
    {
        // If infoWindow is not open, start spawning strawberries
        if (popoutwindow.activeSelf == false)
        {
            StartCoroutine(SpawnBerriesWithDelay());
        }
    }

    // Spawning strawberries
    private IEnumerator SpawnBerriesWithDelay()
    {
        // Sets the random x-axis position with random spawn delay
        // when and where the berries start to spawn
        Vector2 pos = new Vector2(Random.Range(-3.85f, 3.80f), 6);
        float delay = Random.Range(_minSpawnDelay, _maxSpawnDelay);
        yield return new WaitForSeconds(delay);

        // If there is less or equals 14 spawn the berries
        if (_countSpawn <= 14)
        {
            Instantiate(_berryPrefab, pos, Quaternion.identity);
            _countSpawn++;
        }
    }
}

