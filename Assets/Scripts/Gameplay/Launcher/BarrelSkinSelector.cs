using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSkinSelector : MonoBehaviour {

    public Transform barrelsize;
    public Animator barrelAnimator;
    public AnimatorOverrideController gold, tank, samturret;
    public RuntimeAnimatorController basic;

    public StandChanger standchanger;

    // Use this for initialization
    void Start()
    {
        barrelAnimator = GetComponent<Animator>();
        barrelsize = GetComponent<Transform>();
        barrelsize.localScale = new Vector3(1.5f, 1.5f, 1.5f);

        standchanger = GameObject.Find("Launcher").GetComponent<StandChanger>();
    }

    public void setSkin(string x)
    {
        if (x == "basic")
        {
            barrelAnimator.runtimeAnimatorController = basic;          
        }
        else if (x == "gold")
        {
            barrelAnimator.runtimeAnimatorController = gold;
            barrelsize.localScale = new Vector3(1.3f, 1.3f, 1.3f);
        }
        else if (x == "tank")
        {
            barrelAnimator.runtimeAnimatorController = tank;
            barrelsize.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        }
        else if (x == "SAM turret")
        {
            barrelAnimator.runtimeAnimatorController = samturret;
            barrelsize.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        }

        standchanger.changeSprite(x);
    }
}
