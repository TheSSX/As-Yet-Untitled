using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

    private PlayerControlla playerScript;

    public GameObject floatingspike, groundspike, chomper, jet, pufferfish, jetpackman, astronaut, money, moneybag;
    public LevelManager levelmanager;
    private int counter = 0;

	// Use this for initialization
	void Start () {
        playerScript = GameObject.Find("Player").GetComponent<PlayerControlla>();
        levelmanager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {

        if (playerScript.hasBeenFired() && !levelmanager.isPaused() && !levelmanager.isShowingResults())
        {
            counter++;

            if (counter % 60 == 0)
            {
                int random = Random.Range(0, 4);
                if (random < 4)
                {
                    Instantiate(money, new Vector3(25, Random.Range(8, 106), 1), Quaternion.identity);
                }
                else
                {
                    Instantiate(moneybag, new Vector3(25, Random.Range(8, 106), 1), Quaternion.identity);
                }
            }

            if (counter == 60)
            {
                Instantiate(floatingspike, new Vector3(25, Random.Range(8, 106), 1), Quaternion.identity);
            }
            else if (counter == 120)
            {
                Instantiate(groundspike, new Vector3(25, -2.3f), Quaternion.identity);
            }
            else if (counter == 180)
            {
                Instantiate(chomper, new Vector3(25, -1.18f), Quaternion.identity);
            }
            else if (counter == 240)
            {
                Instantiate(jet, new Vector3(25, Random.Range(20, 106), 1), Quaternion.identity);
            }
            else if (counter == 300)
            {
                Instantiate(pufferfish, new Vector3(25, Random.Range(10, 106), 1), Quaternion.identity);
            }
            else if (counter == 360)
            {
                Instantiate(jetpackman, new Vector3(25, -0.96f), Quaternion.identity);
            }
            else if (counter == 420)
            {
                Instantiate(astronaut, new Vector3(25, Random.Range(78.2f, 106), 1), Quaternion.identity);
                counter = 0;
            }
        }
	}
}
