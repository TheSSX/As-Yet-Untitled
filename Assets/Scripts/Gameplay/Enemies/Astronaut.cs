using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Unique behavioural code for the astronaut enemy
public class Astronaut : MonoBehaviour {

    private SoundSystem ss;

    void Start()
    {
        ss = SoundSystem.getInstance();       
    }

    private void OnBecameVisible()
    {
        ss.playSound("astronaut");      //plays the astronaut sound effect when the astronaut appears on screen
    }
}
