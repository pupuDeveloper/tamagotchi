using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace BunnyHole.UI
{
    public class VolumeControl : MonoBehaviour
    {
        // Slider value 0 reprecents the -80dB volume. Slider value 1 reprecents
        // volume 0dB.
        [SerializeField] TMP_Text _volumeText;
        private AudioMixer _mixer;
        private Slider _slider;
        private string _parameterName;

        private void Awake()
        {
            // Tries to find the reference to the Slider, by going through all of
            // audio controls (master,music and sfx) children.
            _slider = GetComponentInChildren<Slider>();
        }

        private void OnDestroy()
        {
            if(_slider != null)
            {
                // Stop listening to the event, so the game doesn't leak memory!!
                _slider.onValueChanged.RemoveListener(OnSliderChanged);
            }
        }

        public void Setup(AudioMixer _mixer, string parameterName)
        {
            //this. refers to the field one.
            this._mixer = _mixer;
            this._parameterName = parameterName;


            // Initialize the slider with the initial volume read from the mixer.
            if (this._mixer.GetFloat(this._parameterName, out float decibel))
            {
                // Read the volume from mixer and set it to the slider.
                float linear = AudioManager.ToLinear(decibel);
                SetVolume(linear);
            }
          
            _slider.onValueChanged.AddListener(OnSliderChanged);
        }

        // Reads the value from the slider and sends it to mixer.
        public void Save()
        {
            _mixer.SetFloat(this._parameterName, AudioManager.ToDecibel(_slider.value));
        }
        private void OnSliderChanged(float sliderValue)
        {
            _volumeText.text = Mathf.RoundToInt(sliderValue * 100).ToString();

        }


        private void SetVolume(float linear)
        {
            _slider.value = linear;
            _volumeText.text = Mathf.RoundToInt(linear * 100).ToString();
        }
    }
}
