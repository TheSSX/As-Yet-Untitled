using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControlla : MonoBehaviour {

    private GameplayCanvasControlla gameplaycanvas;
    private Rigidbody2D playerrigidbody;
    private GameObject player;
    private SoundSystem ss;
    private TargetControlla target;

    private string gunname, sound;
    private int ammo, strength;

    private int counter;

    void Start () {
        gameplaycanvas = FindObjectOfType<GameplayCanvasControlla>();
        player = GameObject.Find("Player");
        playerrigidbody = player.GetComponent<Rigidbody2D>();
        ss = GameObject.Find("SoundSystem").GetComponent<SoundSystem>();
        target = GameObject.Find("LevelManager").GetComponent<TargetControlla>();

        counter = 0;
    }

    void Update()
    {
        transform.position = player.transform.position;
        
        if (counter < 120)
        {
            counter++;
        }
    }

    public string getGun()
    {
        return gunname;
    }

    public void setGun(string x)
    {
        gunname = x;

        if (gunname == "Pistol")
        {
            ammo = 5;
            strength = 10;
            sound = "gunweak";
        }
        else if (gunname == "Shotgun")
        {
            ammo = 7;
            strength = 14;
            sound = "gunweak";
        }
        else if (gunname == "Rifle")
        {
            ammo = 8;
            strength = 18;
            sound = "gunpowerful";
        }
        else if (gunname == "Sniper Rifle")
        {
            ammo = 7;
            strength = 24;
            sound = "gunpowerful";
        }
        else if (gunname == "Rocket Launcher")
        {
            ammo = 5;
            strength = 30;
            sound = "rocketlauncher";
        }
        else if (gunname == "Golden Deagle")
        {
            ammo = 8;
            strength = 40;
            sound = "goldendeagle";
        }

        gameplaycanvas.setGun(gunname, ammo);
    }

    private void OnMouseEnter()
    {
        if (Input.GetMouseButton(0) && ammo > 0 && counter == 120)
        {
            target.hit();
            gameplaycanvas.setAmmo(--ammo);
            playerrigidbody.AddForce(new Vector2(3, 1) * strength*2, ForceMode2D.Impulse);
            ss.playSound(sound);

            counter = 0;
        }
    }
}
