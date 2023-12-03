using System.Collections;
using System.Collections.Generic;
using BunnyHole;
using UnityEngine;
using UnityEngine.Audio;

public class loadVolumes : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;
    void Start()
    {
        _mixer.SetFloat("MasterVolume", AudioManager.ToDecibel(GameManager.Instance.volumeTextCopy1));
        _mixer.SetFloat("MusicVolume", AudioManager.ToDecibel(GameManager.Instance.volumeTextCopy2));
        _mixer.SetFloat("SFXVolume", AudioManager.ToDecibel(GameManager.Instance.volumeTextCopy3));
    }
}
