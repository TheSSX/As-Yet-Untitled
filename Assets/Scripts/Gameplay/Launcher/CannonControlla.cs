using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Responsible for the movement and firing of the launcher
public class CannonControlla : MonoBehaviour {

    private float angle;
    private Animator cannonAnimation;
    private LevelManager levelmanager;
    private SoundSystem ss;
    private BarrelSkinSelector skins;
    private bool soundPlayed;

    // Use this for initialization
    void Start () {
        cannonAnimation = GetComponent<Animator>();
        cannonAnimation.SetBool("fired", false);
        levelmanager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        ss = SoundSystem.getInstance();
        skins = GetComponent<BarrelSkinSelector>();
        soundPlayed = false;
    }

    // Update is called once per frame
    //Launcher rotation functionality provided by user tknz on Unity forums. Link: https://answers.unity.com/questions/10615/rotate-objectweapon-towards-mouse-cursor-2d.html
    void Update()
    {
        if (!(Input.GetMouseButton(0)) && !levelmanager.isPaused())     //while the user has not clicked to fire and the game is not paused
        {
            //Points the launcher towards the user's mouse
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 5.23f;

            Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
            mousePos.x = mousePos.x - objectPos.x;
            mousePos.y = mousePos.y - objectPos.y;

            angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

            //Limits how high and low the launcher can aim
            if (angle > 70)
            {
                angle = 70f;
            }

            if (angle < 0)
            {
                angle = 0f;
            }
          
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        else   //if the user has clicked to fire or the game has paused, freeze the current angle in place
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }

        if (Input.GetMouseButtonUp(0))  //once the user has released the mouse to fire
        {
            cannonAnimation.SetBool("fired", true);     //play the appropriate firing animation
            playSound();
        }
    }

    //Retrieves the current angle of the launcher
    public float getAngle()
    {
        return angle;
    }

    //Retrieves the appropriate sound for the appropriate cannon and plays it
    private void playSound()
    {
        if (!soundPlayed)
        {
            string sound = skins.getSound();
            ss.playSound(sound);

            soundPlayed = true;
        }
    }
}
