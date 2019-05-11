using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackMan : MonoBehaviour {

    private Animator jetanimator;
    private bool launched, soundplayed;
    private int counter;
    private SoundSystem ss;

	// Use this for initialization
	void Start () {
        jetanimator = GetComponent<Animator>();
        launched = false;
        soundplayed = false;
        counter = 0;
        ss = GameObject.Find("SoundSystem").GetComponent<SoundSystem>();

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
        else if (counter == 19)
        {
            jetanimator.SetBool("launch", true);                   
        }
        else if (counter == 20)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 1);
        }

        if (transform.position.y > 120)
        {
            Destroy(this.gameObject);
        }
	}

    private void OnBecameVisible()
    {
        if (launched && !soundplayed)
        {
            ss.playSound("jetpackman");
            soundplayed = true;
        }
    }
}
