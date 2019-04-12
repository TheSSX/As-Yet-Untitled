using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControlla : MonoBehaviour {

    private int ammo;
    private float strength;

    private GameplayCanvasControlla gameplaycanvas;
    private Rigidbody2D playerrigidbody;
    private GameObject player;

    // Use this for initialization
    void Start () {
        gameplaycanvas = FindObjectOfType<GameplayCanvasControlla>();
        player = GameObject.Find("Player");
        playerrigidbody = player.GetComponent<Rigidbody2D>();

        ammo = 5;
        strength = 10;

        gameplaycanvas.newAmmoText(ammo);
    }

    void Update()
    {
        transform.position = player.transform.position;
    }

    public void setDetails(int newammo, float newstrength)
    {
        ammo = newammo;
        strength = newstrength;
    }

    public int getAmmo()
    {
        return ammo;
    }

    private void OnMouseEnter()
    {
        if (Input.GetMouseButton(0) && ammo > 0)
        {
            gameplaycanvas.newAmmoText(--ammo);
            playerrigidbody.AddForce(new Vector2(3, 1) * strength*2, ForceMode2D.Impulse);
        }
    }


}
