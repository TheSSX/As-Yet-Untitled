using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSkinSelector : MonoBehaviour {

    public Transform barrelsize;
    public Animator barrelAnimator;
    public AnimatorOverrideController gold, tank, samturret, missilelauncher, diamond;
    public RuntimeAnimatorController basic;
    public string sound;

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
            sound = "cannonweak";
        }
        else if (x == "gold")
        {
            barrelAnimator.runtimeAnimatorController = gold;
            barrelsize.localScale = new Vector3(1.3f, 1.3f, 1.3f);
            sound = "cannonweak";
        }
        else if (x == "tank")
        {
            barrelAnimator.runtimeAnimatorController = tank;
            barrelsize.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            sound = "cannonweak";
        }
        else if (x == "SAM turret")
        {
            barrelAnimator.runtimeAnimatorController = samturret;
            barrelsize.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            sound = "cannonpowerful";
        }
        else if (x == "missile launcher")
        {
            barrelAnimator.runtimeAnimatorController = missilelauncher;
            barrelsize.localScale = new Vector3(1, 1, 1);
            sound = "cannonpowerful";
        }
        else if (x == "diamond")
        {
            barrelAnimator.runtimeAnimatorController = diamond;
            barrelsize.localScale = new Vector3(1.3f, 1.3f, 1.3f);
            sound = "cannonpowerful";
        }

        standchanger.changeSprite(x);
    }
}
