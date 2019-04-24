using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackMan : MonoBehaviour {

    private Animator jetanimator;
    private bool launched;
    private int counter;

	// Use this for initialization
	void Start () {
        jetanimator = GetComponent<Animator>();
        launched = false;
        counter = 0;

        jetanimator.SetBool("fire", false);
        jetanimator.SetBool("launch", false);
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x <= 20 && !launched)
        {
            jetanimator.SetBool("fire", true);
            launched = true;
        }
       
        if (launched && counter < 20)
        {
            counter++;
        }
        else if (counter == 20)
        {
            jetanimator.SetBool("launch", true);
            transform.position = new Vector2(transform.position.x, transform.position.y + 1);
        }

        if (transform.position.y > 120)
        {
            Destroy(this.gameObject);
        }
	}
}
