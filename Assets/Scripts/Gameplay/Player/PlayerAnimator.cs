using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles the animation of the player
public class PlayerAnimator : MonoBehaviour {

    public Transform playersize;
    public Animator theanimation;
    public AnimatorOverrideController athlete, racecardriver, ninja, boxer, mrpresident;        //all the possible skins of the player, stored as different animator controllers
    public RuntimeAnimatorController bearskin;      //the default

    [SerializeField]
    private PolygonCollider2D[] colliders;      //all the different colliders the player could have. Each one matches a specific animation, helping to make bounces along the ground more realistic
    private int currentColliderIndex;       //the array index of the current collider

    // Use this for initialization
    void Start () {
        theanimation = GetComponent<Animator>();
        playersize = GetComponent<Transform>();
        playersize.localScale = new Vector3(1.5f, 1.5f, 1.5f);

        theanimation.SetBool("hasFired", false);
        theanimation.SetBool("hitBySpikes", false);
        colliders[currentColliderIndex].enabled = true;
    }

    //Changes the skin and size of the player based on the passed-in string
    public void setSkin(string x)
    {
        if (x == "bearskin")
        {
            theanimation.runtimeAnimatorController = bearskin;
        }
        else if (x == "athlete")
        {
            theanimation.runtimeAnimatorController = athlete;
            playersize.localScale = new Vector3(1, 1, 1);
        }
        else if (x == "racecar driver")
        {
            theanimation.runtimeAnimatorController = racecardriver;
            playersize.localScale = new Vector3(1, 1, 1);
        }
        else if (x == "ninja")
        {
            theanimation.runtimeAnimatorController = ninja;
            playersize.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        }
        else if (x == "boxer")
        {
            theanimation.runtimeAnimatorController = boxer;
            playersize.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        }
        else if (x == "mr president")
        {
            theanimation.runtimeAnimatorController = mrpresident;
            playersize.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        }
    }

    //Sets a random animation between 4 in the animtor which represent the player hitting the ground. Also changes the collider to the right one
    public void setAnimation()
    {
        int random = Random.Range(0, 5);
        theanimation.SetInteger("randomInt", random);
        colliders[currentColliderIndex].enabled = false;
        currentColliderIndex = random;
        colliders[currentColliderIndex].enabled = true;
    }

    //Lets the animator know the player has been fired
    public void fired()
    {
        theanimation.SetBool("hasFired", true);
    }
}
