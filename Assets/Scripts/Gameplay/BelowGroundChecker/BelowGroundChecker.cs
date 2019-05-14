using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles any objects, including the player, potentially falling below the ground and not hitting the object destroyer.
public class BelowGroundChecker : MonoBehaviour {

    private PlayerControlla playerScript;

	// Use this for initialization
	void Start () {
        playerScript = GameObject.Find("Player").GetComponent<PlayerControlla>();
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerScript.standUp();     //ends the launch if player goes below ground
        }
        else
        {
            Destroy(other.gameObject);      //destroys any other game objects
        }
    }
}
