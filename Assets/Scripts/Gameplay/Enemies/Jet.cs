using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Unique behavioural code for the jet enemy
public class Jet : MonoBehaviour {

    private SoundSystem ss;

	// Use this for initialization
	void Start () {
        ss = SoundSystem.getInstance();
	}

    private void OnBecameVisible()
    {
        ss.playSound("plane");    //plays the jet sound effect when the jet appears on screen
    }
}
