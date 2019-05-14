using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script attached to all physical objects that move left in gameplay to simulate the player flying towards them. Movement speed is based on player's current velocity
public class MoveAway : MonoBehaviour {

    private float speed;
    private PlayerControlla playerScript;

	// Use this for initialization
	void Start () {
        playerScript = GameObject.Find("Player").GetComponent<PlayerControlla>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        speed = playerScript.getCurrentVelocity();
        transform.Translate(Time.deltaTime * -speed, 0, 0);     //Move left towards the player
    }
}
