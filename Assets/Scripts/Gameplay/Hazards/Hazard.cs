using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Unique behavioural code for hazards
public class Hazard : MonoBehaviour {

    private Animator hazardAnimation;

    // Use this for initialization
    void Start () {
        hazardAnimation = GetComponent<Animator>();
	}

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            hazardAnimation.SetBool("hit", true);       //play animation of when player hits the hazard
        }
    }
}
