using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BunnyHole.Config
{
    [CreateAssetMenu(fileName = "AudioData", menuName = "Data/AudioContainer")]
    public class AudioContainer : ScriptableObject
    {
        [Serializable]
        public class SoundItem
        {
            public SoundEffect Type;
            public AudioClip Clip;

            //TODO: Audio Clip array if needed depending how the pet feels
        }

        [SerializeField] private SoundItem[] _soundEffects;

        public AudioClip GetClipByType(SoundEffect effectType)
        {
            foreach(SoundItem soundEffect in _soundEffects)
            {
                if(soundEffect.Type == effectType)
                {
                    return soundEffect.Clip;
                }
            }

            return null;
        }
    }
}
