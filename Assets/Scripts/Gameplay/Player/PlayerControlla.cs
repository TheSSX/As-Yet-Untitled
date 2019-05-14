using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Controls the base functionality of the player
public class PlayerControlla : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private Animator playerAnimator;
    private LevelManager levelmanager;
    private TargetControlla targetcontrolla;

    private bool hasFired, initialFire;
    private float currentVelocity;   

    // Use this for initialization
    void Start()
    {
        levelmanager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        playerAnimator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        targetcontrolla = GameObject.Find("LevelManager").GetComponent<TargetControlla>();

        hasFired = false;
        initialFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -6)      //if player ever goes below ground
        {
            standUp();      //end the launch
        }

        if (hasFired)       //if player has been fired
        {
            if (!levelmanager.isPaused() && initialFire)        //if game not paused and the character has just been launched (not yet touched the ground)
            {
                transform.Rotate(0, 0, -currentVelocity / 50);      //gentle rotation
            }
            
            if (currentVelocity >= 0.5f && !levelmanager.isPaused() && !initialFire)
            {
                transform.Rotate(0, 0, -currentVelocity);       //rotation relating to speed
                if ((transform.eulerAngles.z < 360 && transform.eulerAngles.z >= 340) || (transform.eulerAngles.z >= 0 && transform.eulerAngles.z < 20))
                {
                    transform.Rotate(0, 0, -3f);        //stop the player from bouncing on their head or feet without landing on their side
                }
            }

            //Pass the player's current velocity to the animator
            playerAnimator.SetFloat("currentVelocity", currentVelocity);
            playerAnimator.SetFloat("rigidbodyVelocityY", playerRigidbody.velocity.y);
        }     
    }

    //Lets the script know the player has been fired
    public void fire()
    {
        hasFired = true;
    }  

    //Called once the player touches the ground
    public void notInitialFire()
    {
        initialFire = false;
    }

    //Fetches the player's current velocity
    public float getCurrentVelocity()
    {
        return currentVelocity;
    }

    //Sets the player's current velocity on launch
    public void setCurrentVelocity(float x)
    {
        currentVelocity = x;
    }

    //Plays the stand up animation at the end of the launch and shows the results of the launch
    public void standUp()
    {
        freeze();
        transform.eulerAngles = new Vector3(0, 0, 0);
        transform.position = new Vector3(transform.position.x, -1.3f, transform.position.z);
        levelmanager.showResults();
    }

    //Called when the player comes to a stop so that no more forces act on them
    public void freeze()
    {
        currentVelocity = 0;
        playerRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        targetcontrolla.target(false);
    }

    //Lets the caller know if the player has launched
    public bool hasBeenFired()
    {
        return hasFired;
    }
}
