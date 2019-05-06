using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlla : MonoBehaviour {

    public GameObject player;
    private Vector3 playerposition;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {

        playerposition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

        transform.position = playerposition;

        if (transform.position.y < 4.5f)
        {
            transform.position = new Vector3(transform.position.x, 4.5f, transform.position.z);
        }
        else if (transform.position.y > 101.9f)
        {
            transform.position = new Vector3(transform.position.x, 101.9f, transform.position.z);
        }
    }
}
