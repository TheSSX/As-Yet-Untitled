using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasControlla : MonoBehaviour {

    public GameObject player;
    public Image aboveScreen;
    public Text heightAboveScreen;
    public Image playerSprite;
    public float height;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        aboveScreen.enabled = false;
        heightAboveScreen.enabled = false;
        height = 0f;
    }
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.y > 110)
        {
            aboveScreen.enabled = true;
            heightAboveScreen.enabled = true;
            height = player.transform.position.y - 110f;
            heightAboveScreen.text = height.ToString("#") + "m";
        }
        else
        {
            aboveScreen.enabled = false;
            heightAboveScreen.enabled = false;
            height = 0f;
        }
	}
}
