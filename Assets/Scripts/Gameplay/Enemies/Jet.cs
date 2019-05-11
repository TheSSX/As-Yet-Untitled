using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jet : MonoBehaviour {

    private SoundSystem ss;
    private bool soundplayed;

	// Use this for initialization
	void Start () {
        ss = GameObject.Find("SoundSystem").GetComponent<SoundSystem>();
        soundplayed = false;
	}

    private void OnBecameVisible()
    {
        if (!soundplayed)
        {
            ss.playSound("plane");
            soundplayed = true;
        }        
    }
}
