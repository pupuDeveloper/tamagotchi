using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Minigame : MonoBehaviour
{
    [SerializeField] private GameObject _berryPrefab;
    //private float _xPos;
    //private Vector3 _newPos;
   // private float _fallSpeed = 2.0f;
   // private float _spinSpeed = 250.0f;
    private GameObject popoutwindow;
    private void Awake()
    {
        popoutwindow = GameObject.Find("infoPopout");
    }

    private void FixedUpdate()
    {
        if (popoutwindow.activeSelf == false)
        {
            SpawnBerries();
            //move the object down the screen
            //transform.Translate(Vector3.down * _fallSpeed * Time.deltaTime, Space.World);
           // transform.Rotate(Vector3.forward, _spinSpeed * Time.deltaTime);
        }
    }

    private void SpawnBerries()
    {
        Vector2 pos = new Vector2(Random.Range(-2.51f, 1.66f), 6);
        Instantiate(_berryPrefab, pos, Quaternion.identity);
    }
}
