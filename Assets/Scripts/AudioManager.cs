using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

    }

    public void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            FindObjectOfType<AudioManager>().Play("MainMenuMusic");
        }
        else if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            FindObjectOfType<AudioManager>().Play("MainGameMusic");
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, Sound => Sound.name == name);
        s.source.Play();
    }

    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, Sound => Sound.name == name);
        s.source.Pause();
    }

}
