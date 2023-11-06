using BunnyHole.Config;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BunnyHole
{
    public static class AudioManager
    {
        private const string AudioContainerName = "AudioData";
        private static AudioContainer _container;

        public static AudioContainer Container
        {
            get
            {
                if(_container == null)
                {
                    _container = Resources.Load<AudioContainer>(AudioContainerName);
                }

                return _container;
            }
        }
        public static bool PlayClip(AudioSource source, SoundEffect effectType)
        {
            AudioClip clip = Container.GetClipByType(effectType);
            if(clip != null && source != null)
            {
                source.PlayOneShot(clip);
                return true;
            }

            return false;
        }
    }
}
