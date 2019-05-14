using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Unique behavioural code for the pufferfish
public class Pufferfish : MonoBehaviour {

    //Used to simulate a bobbing motion of the pufferfish
    private float upperlimit, lowerlimit;
    private bool rising;

	// Use this for initialization
	void Start () {
        upperlimit = transform.position.y + 3;
        lowerlimit = transform.position.y - 3;
        rising = true;
	}
	
	// Update is called once per frame. Simulates the bobbing of the pufferfish
	void Update () {

        if ((rising && transform.position.y >= upperlimit) || (!rising && transform.position.y <= lowerlimit))
        {
            rising = !rising;
        }

		if (transform.position.y < upperlimit && rising)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.2f);
        }
        else //if (transform.position.y > lowerlimit && !rising)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.2f);
        }
    }
}
