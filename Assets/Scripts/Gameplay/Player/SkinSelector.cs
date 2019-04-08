using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSelector : MonoBehaviour {

    public Transform playersize;
    public Animator playerAnimator;
    public AnimatorOverrideController bearskin, athlete;

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
            //playerAnimator.runtimeAnimatorController = bearskin;
        }
        else if (x == "athlete")
        {
            playerAnimator.runtimeAnimatorController = athlete;
            playersize.localScale = new Vector3(1, 1, 1);
        }
    }
}
