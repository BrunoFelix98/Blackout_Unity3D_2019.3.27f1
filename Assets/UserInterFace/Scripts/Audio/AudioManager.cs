using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    public float music;
    public float sound;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        Play("MenuBG");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        s.source.Stop();
    }

    public void AdjustMusicVolume(float volume)
    {
        music = volume;

        foreach (Sound s in sounds)
        {
            if (s.musicCategory)
            {
                s.volume = volume;
                s.source.volume = volume;
            }
        }
    }

    public void AdjustSoundVolume(float volume)
    {
        sound = volume;

        foreach (Sound s in sounds)
        {
            if (s.soundCategory)
            {
                s.volume = volume;
                s.source.volume = volume;
            }
        }
    }

}
