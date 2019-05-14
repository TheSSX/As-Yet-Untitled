using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles the spawning of enemies and hazards on the right side of the screen. This is mostly random
public class ObjectSpawner : MonoBehaviour {

    private PlayerControlla playerScript;
    [SerializeField]
    private GameObject floatingspike, groundspike, chomper, jet, pufferfish, jetpackman, astronaut, money, moneybag, bomb, ammo;    //all objects that can be spawned
    private LevelManager levelmanager;
    private int collectiblecounter, enemycounter;
    private float collectibletime, enemytime;
    private bool collectibleset, enemyset;

	// Use this for initialization
	void Start () {
        playerScript = GameObject.Find("Player").GetComponent<PlayerControlla>();
        levelmanager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        collectiblecounter = 0;
        enemycounter = 0;
        collectibleset = false;
        enemyset = false;
        setCollectibleTime();
        setEnemyTime();
	}
	
	// Update is called once per frame
	void Update () {

        //While gameplay is happening and the launch is not over, spawn enemies
        if (playerScript.hasBeenFired() && !levelmanager.isPaused() && !levelmanager.isShowingResults())
        {
            if (!collectibleset)
            {
                setCollectibleTime();
                collectibleset = true;
            }
            else
            {
                if (collectiblecounter < collectibletime)
                {
                    collectiblecounter++;     //count towards the time when more collectibles can be spawned in

                    if (collectiblecounter >= collectibletime)
                    {
                        int random = Random.Range(0, 6);    //determines whether money, a money bag or an ammo refill spawns spawns

                        if (random < 3)
                        {
                            Instantiate(money, new Vector3(25, Random.Range(8, 106), 1), Quaternion.identity);      //spawn the item at a random height
                        }
                        else if (random == 4)
                        {
                            Instantiate(moneybag, new Vector3(25, Random.Range(8, 106), 1), Quaternion.identity);
                        }
                        else
                        {
                            Instantiate(ammo, new Vector3(15, Random.Range(8, 106), Random.Range(-45, 45)), Quaternion.identity);
                        }

                        collectiblecounter = 0;
                        collectibleset = false;
                        setCollectibleTime();     //regenerate random time until collectible spawns again
                    }
                }
            }

            if (!enemyset)
            {
                setEnemyTime();
                enemyset = true;
            }
            else
            {
                if (enemycounter < enemytime)
                {
                    enemycounter++;     //count towards the time when more enemies can be spawned in

                    if (enemycounter >= enemytime)
                    {
                        int random = Random.Range(0, 8);    //determines which enemy or hazard will be spawned in     

                        if (random == 0)
                        {
                            Instantiate(floatingspike, new Vector3(25, Random.Range(8, 106), 1), Quaternion.identity);      //spawn at a random height
                        }
                        else if (random == 1)
                        {
                            Instantiate(groundspike, new Vector3(25, -2.3f), Quaternion.identity);
                        }
                        else if (random == 2)                                                           //ground spikes and chomper always spawn on the ground so have a constant height
                        {
                            Instantiate(chomper, new Vector3(25, -1.18f), Quaternion.identity);
                        }
                        else if (random == 3)
                        {
                            Instantiate(jet, new Vector3(25, Random.Range(20, 106), 1), Quaternion.identity);
                        }
                        else if (random == 4)
                        {
                            Instantiate(pufferfish, new Vector3(25, Random.Range(10, 106), 1), Quaternion.identity);
                        }
                        else if (random == 5)
                        {
                            Instantiate(jetpackman, new Vector3(25, -0.96f), Quaternion.identity);
                        }
                        else if (random == 6)
                        {
                            Instantiate(astronaut, new Vector3(25, Random.Range(78.2f, 106), 1), Quaternion.identity);
                        }
                        else if (random == 7)
                        {
                            Instantiate(bomb, new Vector3(25, Random.Range(10, 106), 1), Quaternion.identity);
                        }

                        enemycounter = 0;
                        setEnemyTime();
                    }
                }
            }          
        }
	}

    //Sets a random time until a collectible can be spawned again. This is based on player speed
    private void setCollectibleTime()
    {
        float speed = playerScript.getCurrentVelocity();
        collectibletime = Random.Range(4000, 80000) / speed;
    }

    //Sets a random time until an enemy or hazard can be spawned again. This is based on player speed
    private void setEnemyTime()
    {
        float speed = playerScript.getCurrentVelocity();
        enemytime = Random.Range(500, 3000) / speed;
    }
}
