using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Plays a sound and increases the cash collected that round upon being collected by the player
public class CashControlla : MonoBehaviour {

    private LevelManager levelmanager;
    public int cashValue = 10;
    private SoundSystem ss;

    void Start()
    {
        levelmanager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        ss = SoundSystem.getInstance();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ss.playSound("cash");
            levelmanager.addCash(cashValue);
            Destroy(this.gameObject);
        }
    }
}
