using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

    private PlayerControlla playerScript;

    [SerializeField]
    private GameObject floatingspike, groundspike;
    int counter = 0;


	// Use this for initialization
	void Start () {
        playerScript = GameObject.Find("Player").GetComponent<PlayerControlla>();
	}
	
	// Update is called once per frame
	void Update () {

        if (playerScript.hasFired)
        {
            counter++;

            if (counter == 60)
            {
                Instantiate(floatingspike, new Vector3(25, Random.Range(-2, 106), 1), Quaternion.identity);
                counter = 0;
            }
        }
	}
}
