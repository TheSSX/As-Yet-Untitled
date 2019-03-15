﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAway : MonoBehaviour {

    public bool hasFired;
    public float speed;
    public PlayerControlla playerScript;

	// Use this for initialization
	void Start () {
        hasFired = false;
        playerScript = GameObject.Find("Player").GetComponent<PlayerControlla>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        speed = playerScript.getCurrentVelocity();
        transform.Translate(Time.deltaTime * -speed, 0, 0);
    }
}