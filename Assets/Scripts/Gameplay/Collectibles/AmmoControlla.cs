using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Specifies the behaviour of an ammo refill
public class AmmoControlla : MonoBehaviour {

    private GunControlla gun;
    private static SoundSystem ss;

    // Use this for initialization
    void Start () {

        gun = GameObject.Find("Gun").GetComponent<GunControlla>();
        ss = SoundSystem.getInstance();
    }

    //Called if the player comes into contact with the ammo
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ss.playSound("guncock");
            gun.refillAmmo();
            Destroy(this.gameObject);       //removes the ammo refill upon pickup
        }
    }
}
