using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            playerScript.standUp();
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
