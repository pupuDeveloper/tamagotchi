using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    [SerializeField] private GameObject _globalLight;
    [SerializeField] private GameObject _spookyLight;
    private bool _lightOn = true;

    private void Awake()
    {
        _globalLight.SetActive(true);
        _spookyLight.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (_lightOn)
        {
            _globalLight.SetActive(false);
            _spookyLight.SetActive(true);
            _lightOn = false;
        }
        if(!_lightOn)
        {
            _spookyLight.SetActive(false);
            _globalLight.SetActive(true);
            _lightOn = true;
        }
    }
}
