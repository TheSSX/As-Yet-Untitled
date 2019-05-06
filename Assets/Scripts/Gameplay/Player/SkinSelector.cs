using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSelector : MonoBehaviour {

    public Transform playersize;
    public Animator playerAnimator;
    public AnimatorOverrideController athlete, racecardriver, ninja, boxer, mrpresident;
    public RuntimeAnimatorController bearskin;

    // Use this for initialization
    void Start () {
        playerAnimator = GetComponent<Animator>();
        playersize = GetComponent<Transform>();
        playersize.localScale = new Vector3(1.5f, 1.5f, 1.5f);
	}
	
    public void setSkin(string x)
    {
        if (x == "bearskin")
        {
            playerAnimator.runtimeAnimatorController = bearskin;
        }
        else if (x == "athlete")
        {
            playerAnimator.runtimeAnimatorController = athlete;
            playersize.localScale = new Vector3(1, 1, 1);
        }
        else if (x == "racecar driver")
        {
            playerAnimator.runtimeAnimatorController = racecardriver;
            playersize.localScale = new Vector3(1, 1, 1);
        }
        else if (x == "ninja")
        {
            playerAnimator.runtimeAnimatorController = ninja;
            playersize.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        }
        else if (x == "boxer")
        {
            playerAnimator.runtimeAnimatorController = boxer;
            playersize.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        }
        else if (x == "mr president")
        {
            playerAnimator.runtimeAnimatorController = mrpresident;
            playersize.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        }
    }
}
