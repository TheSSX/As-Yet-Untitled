using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashControlla : MonoBehaviour {

    private LevelManager levelmanager;
    public int cashValue = 10;

    void Start()
    {
        levelmanager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            levelmanager.addCash(cashValue);
            Destroy(this.gameObject);
        }
    }
}
