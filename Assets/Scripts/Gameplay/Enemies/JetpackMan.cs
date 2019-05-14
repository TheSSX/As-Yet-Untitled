using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Unique behavioural code for the jetpack man enemy
public class JetpackMan : MonoBehaviour {

    private Animator jetanimator;
    private bool launched;      //used to only play sound effect once jetpack man launches
    private int counter;        //times the animations of jetpack man so it takes a third of a second to take off
    private SoundSystem ss;

	// Use this for initialization
	void Start () {
        jetanimator = GetComponent<Animator>();
        launched = false;
        counter = 0;
        ss = SoundSystem.getInstance();

        jetanimator.SetBool("fire", false);
        jetanimator.SetBool("launch", false);   //starting animation state, not taken off yet
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x <= 20 && !launched)    //if close enough to the player and hasn't launched yet
        {
            jetanimator.SetBool("fire", true);      //launch
            launched = true;
        }
       
        if (launched && counter < 20)
        {
            counter++;      //count up until lift off
        }
        else if (counter == 19)
        {
            jetanimator.SetBool("launch", true);        //lift off animation        
        }
        else if (counter == 20)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 1);       //physically move jetpack man while he launches
        }

        if (transform.position.y > 120)
        {
            Destroy(this.gameObject);       //automatically destroys jetpack man once he gets above the map
        }
	}

    private void OnBecameVisible()
    {
        if (launched)
        {
            ss.playSound("jetpackman");     //plays jetpack man sound effect upon appearing on screen
        }
    }
}
