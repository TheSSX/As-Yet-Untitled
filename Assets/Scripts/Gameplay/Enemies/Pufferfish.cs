using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pufferfish : MonoBehaviour {

    private float upperlimit, lowerlimit;
    private bool rising;

	// Use this for initialization
	void Start () {
        upperlimit = transform.position.x + 3;
        lowerlimit = transform.position.x - 3;
        rising = true;
	}
	
	// Update is called once per frame
	void Update () {

        if ((rising && transform.position.x == upperlimit) || (!rising && transform.position.x == lowerlimit))
        {
            rising = !rising;
        }

		if (transform.position.x < upperlimit && rising)
        {
            transform.position = new Vector2(transform.position.x + 0.05f, transform.position.y);
        }
        else if (transform.position.x > lowerlimit && !rising)
        {
            transform.position = new Vector2(transform.position.x - 0.05f, transform.position.y);
        }
    }
}
