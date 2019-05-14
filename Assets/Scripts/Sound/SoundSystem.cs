using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System;

//Singleton class that controls the playing of all sounds and music
public sealed class SoundSystem : MonoBehaviour {

    private static SoundSystem ss = null;
    private static readonly object padlock = new object();      //used to control access to new instantiations of the class

    private static bool soundeffectsmute, musicmute;
    private static string scene = "empty";

    public AudioSource musicclip;
    [SerializeField]
    private AudioClip gameplay, mainmenu;
    [SerializeField]
    private AudioClip[] shopmusic;       //stores the 5 possible tracks that can play in the shop

    [SerializeField]
    private Sound[] sounds = new Sound[17];      //stores the 17 sound effects of the game

	// Use this for initialization
	void Start () {

        if (ss != null && ss != this)
        {
            DestroyObject(gameObject);
            return;
        }

        ss = this;
        DontDestroyOnLoad(this);

        scene = SceneManager.GetActiveScene().name;
        soundeffectsmute = false;
        musicmute = false;
        musicclip = GetComponent<AudioSource>();

        playMusic(scene);

        //Gives each sound an audio source and an appropriate volume and track
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
        }
    }

    //Returns the current instantiation of the SoundSystem to any objects that ask for it
    public static SoundSystem getInstance()
    {
        lock (padlock);

        if (ss == null)
        {
            ss = GameObject.Find("SoundSystem").GetComponent<SoundSystem>();
        }

        return ss;
    }

    //Toggles whether sound effects are muted or not
    public void toggleSoundEffects(bool x)
    {
        soundeffectsmute = x;
    }

    //Toggles whether music is muted or not
    public void toggleMusic(bool x)
    {
        musicmute = x;

        musicclip.mute = musicmute;    
    }

    //Receives a string name of the sound effect to play and searches the array of sound effects for it by their own name. If it matches, play the sound
    public void playSound(string name)
    {
        if (!soundeffectsmute)
        {
            foreach (Sound s in sounds)
            {
                if (s.name == name)
                {
                    if (name == "astronaut")
                    {
                        if (UnityEngine.Random.Range(0,4) == 0)
                        {
                            s.source.Play();
                        }
                    }
                    else
                    {
                        s.source.Play();
                    }
                    
                    return;
                }
            }
        }
    }

    //Receives a string name and plays the music track appropriate to the scene name passed in
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

    //Lets the caller know if music is muted
    public bool isMusicMuted()
    {
        return musicmute;
    }

    //Lets the caller know if sound effects are muted
    public bool isSoundEffectsMuted()
    {
        return soundeffectsmute;
    }

    //Plays one of five possible music samples for the shop
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
