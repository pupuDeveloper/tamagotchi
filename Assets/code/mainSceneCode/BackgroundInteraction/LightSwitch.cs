using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightSwitch : MonoBehaviour
{
    // Lamp light
    [SerializeField] private Light2D _lampLight;
    // Window light
    [SerializeField] private Light2D _spookyLight;
    [SerializeField] private Light2D _globalLight;
    // Global light
    private bool _lightOn = true;

    private void Start()
    {
        _lampLight.enabled = false;
        _spookyLight.enabled = false;
    }

    private void OnMouseDown()
    {
        if (_lightOn)
        {
            _globalLight.intensity = 0.1f;
            _lampLight.enabled = true;
            _spookyLight.enabled = true;
            _lightOn = false;
        }
        else if(!_lightOn)
        {
            _globalLight.intensity = 1.0f;
            _spookyLight.enabled = false;
            _lampLight.enabled = false;
            _lightOn = true;
        }
    }
}
