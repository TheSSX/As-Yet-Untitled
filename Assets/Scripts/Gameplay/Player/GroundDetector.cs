using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Deals with changing the player's velocity when they hit the ground. Also responds to the player getting stuck in the ground
public class GroundDetector : MonoBehaviour {

    private LevelManager levelmanager;
    private PlayerControlla player;
    private Rigidbody2D playerRigidbody;
    private PlayerAnimator playerAnimator;
    private bool isTouchingGround;
    private int counter;

	// Use this for initialization
	void Start () {
        levelmanager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        player = GetComponent<PlayerControlla>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<PlayerAnimator>();
        isTouchingGround = false;
        counter = 0;
	}
	
	// Update is called once per frame
	void Update () {

        
        if (isTouchingGround)
        {
            groundCount();      //called whenever the player is touching the ground
        }
    }

    //Stops player from getting stuck in the ground. If they get stuck in the ground for half a second, round is over and results are shown
    private void groundCount()
    {
        counter++;

        if (counter == 30)
        {
            if (!levelmanager.isPaused() && !player.getFinished())
            {
                player.standUp();
            }
            else
            {
                counter = 0;
            }
        }
    }

    //Amends velocity and animation whenever the player touches the ground
    private void OnTriggerEnter2D(Collider2D other)
    {
        float currentVelocity = player.getCurrentVelocity();

        if (other.tag == "Ground" && currentVelocity >= 0.5f && !isTouchingGround)
        {
            player.notInitialFire();        //lets player know they've touched the ground so different movements apply
            playerAnimator.setAnimation();

            if ((playerRigidbody.velocity.y < currentVelocity * 0.75f) && currentVelocity >= 0.75f)
            {
                currentVelocity *= 0.75f;       //reduces velocity by 25% on a regular impact. Prevents it from freefalling to zero too quickly
            }
            else
            {
                currentVelocity = playerRigidbody.velocity.y;
            }

            isTouchingGround = true;
        }
        else if (other.tag == "Ground" && !levelmanager.isPaused())
        {
            currentVelocity *= 0.75f;
            isTouchingGround = true;
        }

        player.setCurrentVelocity(currentVelocity);
    }

    //Resets the ground check upon leaving the ground
    private void OnTriggerExit2D(Collider2D collision)
    {
        isTouchingGround = false;
        counter = 0;
    }
}
