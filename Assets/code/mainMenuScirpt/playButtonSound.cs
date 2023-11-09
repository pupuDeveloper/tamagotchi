using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BunnyHole
{
    public class playButtonSound : MonoBehaviour
    {
        private AudioSource _openAudio;

        void Awake()
        {
            _openAudio = GetComponent<AudioSource>();
        }
        public void buttonSound()
        {
            if (_openAudio != null)
            {
                AudioManager.PlayClip(_openAudio, Config.SoundEffect.menuButton);
            }
        }
    }
}
