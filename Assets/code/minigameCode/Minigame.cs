using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Minigame : MonoBehaviour
{
    [SerializeField] private GameObject _berryPrefab;
    [SerializeField] private float _spawnTime;

    private GameObject popoutwindow;
    private float _countDown = 5;
    private void Awake()
    {
        popoutwindow = GameObject.Find("infoPopout");
    }

    private void FixedUpdate()
    {
        if (popoutwindow.activeSelf == false)
        {
            SpawnBerries();
            _countDown -= Time.fixedDeltaTime;
            if(_countDown <= 0)
            {
                _countDown = _spawnTime;
            }
        }
    }

    private void SpawnBerries()
    {
        Vector2 pos = new Vector2(Random.Range(-2.51f, 1.66f), 6);
        Instantiate(_berryPrefab, pos, Quaternion.identity);
    }
}
