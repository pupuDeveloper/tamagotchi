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

		public static float ToLinear(float dB)
		{
			// Clamp01 makes sure that we don't return lower than 0 and greater than 1 value
			return Mathf.Clamp01(Mathf.Pow(10.0f, dB / 20.0f));
		}

		public static float ToDecibel(float linear)
		{
			return linear <= 0 ? -80f : Mathf.Log10(linear) * 20.0f;
		}
	}
}
