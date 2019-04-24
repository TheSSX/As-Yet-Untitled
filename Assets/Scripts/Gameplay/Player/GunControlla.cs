using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControlla : MonoBehaviour {

    private GameplayCanvasControlla gameplaycanvas;
    private Rigidbody2D playerrigidbody;
    private GameObject player;

    private string gunname;
    private int ammo, strength;

    private int counter;

    void Start () {
        gameplaycanvas = FindObjectOfType<GameplayCanvasControlla>();
        player = GameObject.Find("Player");
        playerrigidbody = player.GetComponent<Rigidbody2D>();

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
        }
        else if (gunname == "Shotgun")
        {
            ammo = 7;
            strength = 14;
        }
        else if (gunname == "Rifle")
        {
            ammo = 8;
            strength = 18;
        }
        else if (gunname == "Sniper Rifle")
        {
            ammo = 7;
            strength = 24;
        }
        else if (gunname == "Rocket Launcher")
        {
            ammo = 5;
            strength = 30;
        }
        else
        {
            ammo = 8;
            strength = 40;
        }

        gameplaycanvas.setGun(gunname, ammo);
    }

    private void OnMouseEnter()
    {
        if (Input.GetMouseButton(0) && ammo > 0 && counter == 120)
        {
            gameplaycanvas.setAmmo(--ammo);
            playerrigidbody.AddForce(new Vector2(3, 1) * strength*2, ForceMode2D.Impulse);

            counter = 0;
        }
    }
}
