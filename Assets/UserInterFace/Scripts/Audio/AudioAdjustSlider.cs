using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioAdjustSlider : MonoBehaviour
{
    private AudioManager AM;

    private Slider slider;

    public GameObject menu;

    public bool Music;

    private void Awake()
    {
        AM = FindObjectOfType<AudioManager>();

        slider = GetComponent<Slider>();

        if (Music)
        {
            slider.value = AM.music;
            slider.onValueChanged.AddListener(AM.AdjustMusicVolume);
        }
        else
        {
            slider.value = AM.sound;
            slider.onValueChanged.AddListener(AM.AdjustSoundVolume);
        }

        if (menu != null)
        {
            menu.SetActive(false);
        }
    }
}
