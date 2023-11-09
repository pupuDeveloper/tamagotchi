using BunnyHole.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace BunnyHole.UI
{
    public class OptionsController : MonoBehaviour
    {
        [SerializeField] private VolumeControl _masterVolume;
        [SerializeField] private VolumeControl _musicVolume;
        [SerializeField] private VolumeControl _sfxVolume;
        [SerializeField] private AudioMixer _mixer;
        [SerializeField] private string _masterVolumeName;
        [SerializeField] private string _musicVolumeName;
        [SerializeField] private string _sfxVolumeName;

        private void Start()
        {
            _masterVolume.Setup(_mixer, _masterVolumeName);
            _musicVolume.Setup(_mixer, _musicVolumeName);
            _sfxVolume.Setup(_mixer, _sfxVolumeName);
        }
        public void OnSave()
        {
            //TODO: Saving mechanics
            _masterVolume.Save();
            _musicVolume.Save();
            _sfxVolume.Save();
        }

        public void OnClose()
        {
            GameManager.Instance.GoBack();
        }
    }
}
