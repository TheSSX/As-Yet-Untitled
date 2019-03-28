using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour {

    protected AudioSource audiosource;
    protected Animator hazardAnimation;

    // Use this for initialization
    void Start () {
        audiosource = GetComponent<AudioSource>();
        audiosource.loop = false;
        hazardAnimation = GetComponent<Animator>();
	}

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            audiosource.Play();
            hazardAnimation.SetBool("hit", true);
        }
    }
}
