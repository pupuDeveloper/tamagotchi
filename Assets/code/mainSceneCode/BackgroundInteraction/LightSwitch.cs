using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightSwitch : MonoBehaviour
{
    // Lamp light
    [SerializeField] private Light2D _lampLight;
    // Window light
    [SerializeField] private Light2D _spookyLight;
    [SerializeField] private Light2D _globalLight;
    // Electric box light
    [SerializeField] private Light2D _electricLight;
    // Global light
    private bool _lightOn = true;
    // Particles
    [SerializeField] private GameObject _particles;

    private void Start()
    {
        _lampLight.enabled = false;
        _spookyLight.enabled = false;
        _electricLight.enabled = false;
        _particles.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (_lightOn)
        {
            _globalLight.intensity = 0.1f;
            _lampLight.enabled = true;
            _spookyLight.enabled = true;
            _electricLight.enabled = true;
            _lightOn = false;
            _particles.SetActive(true);
        }
        else if(!_lightOn)
        {
            _globalLight.intensity = 1.0f;
            _spookyLight.enabled = false;
            _lampLight.enabled = false;
            _electricLight.enabled = false;
            _lightOn = true;
            _particles.SetActive(false);
        }
    }
    
}
