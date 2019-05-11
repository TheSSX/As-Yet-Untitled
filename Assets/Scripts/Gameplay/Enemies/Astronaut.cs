using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astronaut : MonoBehaviour {

    private SoundSystem ss;
    private bool soundplayed;

    void Start()
    {
        ss = GameObject.Find("SoundSystem").GetComponent<SoundSystem>();
        soundplayed = false;        
    }

    // Update is called once per frame
    void Update () {
        transform.Rotate(0, 0, 10);
    }

    private void OnBecameVisible()
    {
        if (!soundplayed)
        {
            ss.playSound("astronaut");
            soundplayed = true;
        }
    }
}
