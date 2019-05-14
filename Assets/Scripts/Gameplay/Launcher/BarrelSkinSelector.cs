using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Responsible for changing the skin of the launcher's barrel
public class BarrelSkinSelector : MonoBehaviour {

    private Transform barrelsize;
    private Animator barrelAnimator;
    [SerializeField]
    private AnimatorOverrideController gold, tank, samturret, missilelauncher, diamond;     //each upgrade of launcher has a different skin. These controllers contain those skins
    [SerializeField]
    private RuntimeAnimatorController basic;
    private string sound;

    private StandChanger standchanger;

    // Use this for initialization
    void Start()
    {
        barrelAnimator = GetComponent<Animator>();
        barrelsize = GetComponent<Transform>();
        barrelsize.localScale = new Vector3(1.5f, 1.5f, 1.5f);

        standchanger = GameObject.Find("Launcher").GetComponent<StandChanger>();
    }

    public string getSound()
    {
        return sound;
    }

    //Receives the name of the launcher and changes the skin, size and sound effect appropriately
    public void setSkin(string x)
    {
        if (x == "basic")
        {
            barrelAnimator.runtimeAnimatorController = basic;       //basic cannon
            sound = "cannonweak";
        }
        else if (x == "gold")
        {
            barrelAnimator.runtimeAnimatorController = gold;        //gold cannon
            barrelsize.localScale = new Vector3(1.3f, 1.3f, 1.3f);
            sound = "cannonweak";
        }
        else if (x == "tank")
        {
            barrelAnimator.runtimeAnimatorController = tank;        //tank
            barrelsize.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            sound = "cannonweak";
        }
        else if (x == "SAM turret")
        {
            barrelAnimator.runtimeAnimatorController = samturret;       //SAM turret
            barrelsize.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            sound = "cannonpowerful";
        }
        else if (x == "missile launcher")
        {
            barrelAnimator.runtimeAnimatorController = missilelauncher;     //missile launcher
            barrelsize.localScale = new Vector3(1, 1, 1);
            sound = "cannonpowerful";
        }
        else if (x == "diamond")
        {
            barrelAnimator.runtimeAnimatorController = diamond;             //diamond cannon
            barrelsize.localScale = new Vector3(1.3f, 1.3f, 1.3f);
            sound = "cannonpowerful";
        }

        standchanger.changeSprite(x);       //passes the cannon name onto the launcher stand, which will also change its skin
    }
}
