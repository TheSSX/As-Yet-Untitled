using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
