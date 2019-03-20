using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasControlla : MonoBehaviour {

    public GameObject player;
    public PlayerControlla playercontroller;

    public Image aboveScreen;
    public Text heightAboveScreenText;

    public Text heightText;   
    public Text distanceText;
    public Text powerText;

    public float height;
    public float distance; 

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        playercontroller = player.GetComponent<PlayerControlla>();
        aboveScreen.enabled = false;
        heightAboveScreenText.enabled = false;
        powerText.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {

        updateHeight();
        renderAboveScreen();
        updateDistance();		
    }

    public void displayPower(float power)
    {
        if (power == -1f)
        {
            powerText.enabled = false;
        }
        else
        {
            powerText.enabled = true;
            powerText.text = "Power: " + power.ToString("#") + "%";
        }
    }

    private void updateHeight()
    {
        height = (player.transform.position.y * 2) + 2.9f;

        if (height < 1f)
        {
            height = 0f;
            heightText.text = "Height: 0m";
        }
        else
        {
            heightText.text = "Height: " + height.ToString("#") + "m";
        }
    }

    private void updateDistance()
    {
        distance += playercontroller.getCurrentVelocity() / 30;

        if (distance == 0f)
        {
            distanceText.text = "Distance: 0m";
        }
        else
        {
            distanceText.text = "Distance: " + distance.ToString("0.##") + "m";
        }
    }

    private void renderAboveScreen()
    {
        if (player.transform.position.y > 110)
        {
            aboveScreen.enabled = true;
            heightAboveScreenText.enabled = true;
            heightAboveScreenText.text = (height - (110f * 2)).ToString("#") + "m";
        }
        else
        {
            aboveScreen.enabled = false;
            heightAboveScreenText.enabled = false;
        }
    }
}
