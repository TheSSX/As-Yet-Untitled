using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Holds data for each sound effect of the game
[System.Serializable]
public class Sound {

    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = 1;

    [HideInInspector]
    public AudioSource source;

}
