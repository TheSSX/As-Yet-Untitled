using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls the gun object and stores details about the currently selected gun, its ammo and its strength. Also controls the firing of the gun
public class GunControlla : MonoBehaviour {

    private GameplayCanvasControlla gameplaycanvas; 
    private Rigidbody2D playerrigidbody;
    private GameObject player;
    private SoundSystem ss;
    private TargetControlla target;

    private string gunname, sound;
    private int ammo, strength, maxammo;

    private int counter;

    void Start () {
        gameplaycanvas = FindObjectOfType<GameplayCanvasControlla>();
        player = GameObject.Find("Player");
        playerrigidbody = player.GetComponent<Rigidbody2D>();
        ss = SoundSystem.getInstance();
        target = GameObject.Find("LevelManager").GetComponent<TargetControlla>();

        counter = 0;
    }

    void Update()
    {
        transform.position = player.transform.position;     //detects if the gun is colliding with the player object
        
        //Used so that the player can only fire once per second
        if (counter < 60)
        {
            counter++;
        }
    }

    //Passes the name of the gun to the class so it can evaluate its stats and set its sound effect
    public void setGun(string x)
    {
        gunname = x;

        if (gunname == "Pistol")
        {
            ammo = 5;
            maxammo = 5;
            strength = 10;
            sound = "gunweak";
        }
        else if (gunname == "Shotgun")
        {
            ammo = 7;
            maxammo = 7;
            strength = 14;
            sound = "gunweak";
        }
        else if (gunname == "Rifle")
        {
            ammo = 8;
            maxammo = 8;
            strength = 17;
            sound = "gunpowerful";
        }
        else if (gunname == "Sniper Rifle")
        {
            ammo = 7;
            maxammo = 7;
            strength = 20;
            sound = "gunpowerful";
        }
        else if (gunname == "Rocket Launcher")
        {
            ammo = 5;
            maxammo = 5;
            strength = 25;
            sound = "rocketlauncher";
        }
        else if (gunname == "Golden Deagle")
        {
            ammo = 8;
            maxammo = 8;
            strength = 30;
            sound = "goldendeagle";
        }

        gameplaycanvas.setGun(gunname, ammo);
    }

    //Detects if the player and target overlap. If this happens and the player clicks, this function fires the gun and subtracts 1 from the ammo
    private void OnMouseEnter()
    {
        if (Input.GetMouseButton(0) && ammo > 0 && counter == 60)
        {
            target.hit();
            gameplaycanvas.setAmmo(--ammo);
            playerrigidbody.AddForce(new Vector2(3, 1) * strength*2, ForceMode2D.Impulse);      //adds an appropriate amount of force to the player, relative to the gun strength
            ss.playSound(sound);

            counter = 0;
        }
    }

    //Called when the player picks up an ammo refill
    public void refillAmmo()
    {
        ammo = maxammo;
        gameplaycanvas.setAmmo(ammo);
    }
}
