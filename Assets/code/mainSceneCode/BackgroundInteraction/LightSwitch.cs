using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightSwitch : MonoBehaviour
{
    // Lamp light
    [SerializeField] private Light2D _lampLight;
    [SerializeField] private Light2D _lampLightUp;
    // Window light
    [SerializeField] private Light2D _spookyLight;
    [SerializeField] private Light2D _globalLight;
    // Electric box light
    [SerializeField] private Light2D _electricLight;
    // Global light is bright check
    private bool _lightOn = true;
    // Particles
    [SerializeField] private GameObject _particles;

    private void Start()
    {
        _lampLight.enabled = true;
        _lampLightUp.enabled = true;
        _spookyLight.enabled = false;
        _electricLight.enabled = false;
        _particles.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (_lightOn)
        {
            _globalLight.intensity = 0.1f;
            _lampLight.enabled = false;
            _lampLightUp.enabled = false;
            _spookyLight.enabled = true;
            _electricLight.enabled = true;
            _lightOn = false;
            _particles.SetActive(true);
        }
        else if(!_lightOn)
        {
            _globalLight.intensity = 0.4f;
            _spookyLight.enabled = false;
            _lampLight.enabled = true;
            _lampLightUp.enabled = true;
            _electricLight.enabled = false;
            _lightOn = true;
            _particles.SetActive(false);
        }
    }
    
}
