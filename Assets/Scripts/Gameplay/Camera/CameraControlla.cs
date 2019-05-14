using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls the movement of the camera. Moves relative to player position, keeps the player in-place on screen.
public class CameraControlla : MonoBehaviour {

    private GameObject player;
    private Vector3 playerposition;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {

        playerposition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

        transform.position = playerposition;       //sets the camera position to that of the player, with constant z position to prevent any issues

        if (transform.position.y < 4.5f)    //prevents the camera from going below ground
        {
            transform.position = new Vector3(transform.position.x, 4.5f, transform.position.z);
        }
        else if (transform.position.y > 101.9f)     //prevents the camera from going above the map
        {
            transform.position = new Vector3(transform.position.x, 101.9f, transform.position.z);
        }
    }
}
