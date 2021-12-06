using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource _music;
    [SerializeField] Slider _sliderVolumeValue;
    private float _volumeStart;

    private void Start()
    {
        _volumeStart = AudioListener.volume;
        _sliderVolumeValue.value = _volumeStart;
    }
    public void SetMusicEnabled(bool value)
    {
        _music.enabled = value;
    }

    public void SetVolume(float value)
    {
        AudioListener.volume = value;
    }
}
