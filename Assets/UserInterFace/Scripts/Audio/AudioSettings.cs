using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSettings : MonoBehaviour
{

    [SerializeField]
    private AudioMixer soundMixer;
    [SerializeField]
    private AudioMixer musicMixer;

    public static AudioSettings instance;

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }  
    }
    void Start()
    {
        //Get the saved music volume, standard = 10f
        float music = PlayerPrefs.GetFloat("Music", 1f);
        float sound = PlayerPrefs.GetFloat("Audio", 1f);
    }

    public void AdjustMusicVolume(float music)
    {
        //Update AudioMixer
        musicMixer.SetFloat("Music", Mathf.Log10(music) * 20);

        //Update PlayerPrefs
        PlayerPrefs.SetFloat("Music", Mathf.Log10(music) * 20);

        //Save changes
        PlayerPrefs.Save();
    }

    public void AdjustSoundVolume(float sound)
    {
        //Update AudioMixer
        soundMixer.SetFloat("Sound", Mathf.Log10(sound) * 20);

        //Update PlayerPrefs
        PlayerPrefs.SetFloat("Sound", Mathf.Log10(sound) * 20);

        //Save changes
        PlayerPrefs.Save();
    }

    public AudioMixer GetMusicVolume()
    {
        return musicMixer;
    }

    public AudioMixer GetSoundVolume()
    {
        return soundMixer;
    }
}
