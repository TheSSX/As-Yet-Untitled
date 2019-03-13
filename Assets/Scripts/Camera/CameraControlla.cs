using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlla : MonoBehaviour {

    public GameObject player;
    public float offset;
    private Vector3 playerposition;
    //public float offsetsmoothing;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

        playerposition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

        if (player.transform.localScale.x > 0f)
        {
            playerposition = new Vector3(playerposition.x + offset, playerposition.y, playerposition.z);
        }
        else
        {
            playerposition = new Vector3(playerposition.x - offset, playerposition.y, playerposition.z);
        }

        transform.position = playerposition;
    }
}
