using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace BunnyHole
{
    public class LightSwitch : MonoBehaviour
    {
        [SerializeField] private Light2D _lampLight; // Lamp light.
        [SerializeField] private Light2D _lampLightUp; // Lamp light up.
        [SerializeField] private Light2D _spookyLight; // Window light.
        [SerializeField] private Light2D _globalLight; // Global light in the scene, which is a must.
        [SerializeField] private Light2D _electricLight; // Electric box light.
        [SerializeField] private GameObject _particles; // Particles.
        [SerializeField] private Sprite _boxHover; // Box hover sprite.
        private bool _lightOn = true; // Global light is bright check, true at first.

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

        // When mouse enters the collider do this.
        private void OnMouseEnter()
        {
            // Get the Sprite Renderer component and add box hover to the sprite.
            GetComponent<SpriteRenderer>().sprite = _boxHover;
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
                _electricLight.enabled = false;
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

        // When the mouse exits the collider.
        private void OnMouseExit()
        {
            // No sprites to the sprite renderer.
            GetComponent<SpriteRenderer>().sprite = null;
        }
    }
}
