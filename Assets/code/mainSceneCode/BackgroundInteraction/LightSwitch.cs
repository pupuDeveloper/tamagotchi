using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightSwitch : MonoBehaviour
{
    // Lamp lights
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

    private void Awake()
    {
        // Lamp lights are on right from the start.
        _lampLight.enabled = true;
        _lampLightUp.enabled = true;
        // Window light and electric light are off.
        _spookyLight.enabled = false;
        _electricLight.enabled = true;
        // Particles are not active.
        _particles.SetActive(false);
    }

    // Electric box's collider clicked
    private void OnMouseDown()
    {
        // Are the lights on = global light bright and lamp lights on
        if (_lightOn)
        {
            // By cliking the electrict box the global light's intenssity goes
            // lower and lamp lights go off.
            _globalLight.intensity = 0.1f;
            _lampLight.enabled = false;
            _lampLightUp.enabled = false;
            // Window light and electric box's lights go on.
            _spookyLight.enabled = true;
            _electricLight.enabled = true;
            // light is not on.
            _lightOn = false;
            // Activates particle effect.
            _particles.SetActive(true);
        }
        // If lights are not on
        else if (!_lightOn)
        {
            // Global light intensity back to normal.
            _globalLight.intensity = 0.4f;
            // Window and electric box's lights go off.
            _spookyLight.enabled = false;
            _electricLight.enabled = true;
            // Lamp lights back.
            _lampLight.enabled = true;
            _lampLightUp.enabled = true;
            _lightOn = true;
            // Particle effect is not activated.
            _particles.SetActive(false);
        }
    }

}
