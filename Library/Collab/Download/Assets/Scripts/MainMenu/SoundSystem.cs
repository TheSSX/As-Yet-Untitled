using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System;

public sealed class SoundSystem : MonoBehaviour {

    private static SoundSystem ss = null;
    private static readonly object padlock = new object();

    public static bool soundeffectsmute, musicmute;
    public static string scene = "empty";
    public AudioSource musicclip;

    public AudioClip gameplay, mainmenu;

    public AudioClip[] shopmusic;

    public Sound[] sounds = new Sound[17];

    SoundSystem() { }

	// Use this for initialization
	void Start () {

        if (ss != null)
        {
            DestroyObject(gameObject);
        }
        else
        {
            ss = this;
        }

        DontDestroyOnLoad(this);

        scene = SceneManager.GetActiveScene().name;
        soundeffectsmute = false;
        musicmute = false;
        musicclip = GetComponent<AudioSource>();

        playMusic(scene);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
        }
    }

    public static SoundSystem getInstance()
    {
        lock (padlock);

        if (ss == null)
        {
            ss = new SoundSystem();
        }

        return ss;
    }

    public void toggleSoundEffects(bool x)
    {
        soundeffectsmute = x;
    }

    public void toggleMusic(bool x)
    {
        musicmute = x;

        musicclip.mute = musicmute;
    }

    public void playSound(string name)
    {
        if (!soundeffectsmute)
        {
            foreach (Sound s in sounds)
            {
                if (s.name == name)
                {
                    s.source.Play();
                    return;
                }
            }

            /*Sound s = Array.Find(sounds, sound => sound.name == name);
            if (s == null)
            {
                Debug.Log("Couldn't find " + name);
            }
            else if (name == "astronaut")
            {
                int random = UnityEngine.Random.Range(0, 4);
                {
                    if (random == 1)
                    {
                        s.source.Play();
                    }
                }
            }
            else
            {
                s.source.Play();
            }*/
        }
    }

    public void playMusic(string name)
    {
        if (!musicmute)
        {
            scene = name;

            if (scene == "MainMenu")
            {
                musicclip.clip = mainmenu;
            }
            else if (scene == "Gameplay")
            {
                musicclip.clip = gameplay;
            }
            else if (scene == "Shop")
            {
                musicclip.clip = gameplay;
            }

            musicclip.Play();
        }
    }

    public bool isMusicMuted()
    {
        return musicmute;
    }

    public bool isSoundEffectsMuted()
    {
        return soundeffectsmute;
    }

    public void playShopMusic()
    {
        if (!musicmute)
        {
            int random = UnityEngine.Random.Range(0, 5);
            musicclip.clip = shopmusic[random];
            musicclip.Play();
        }
    }
}
