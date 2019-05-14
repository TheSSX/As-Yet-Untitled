using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles the movement of the background image while the player is moving. Moves relative to the player's speed
public class scroll : MonoBehaviour
{
    private float speed, offset;
    private Renderer backgroundRenderer;
    private PlayerControlla playerScript;

    // Use this for initialization
    void Start()
    {
        speed = 0;
        offset = 0;
        backgroundRenderer = GetComponent<Renderer>();
        playerScript = GameObject.Find("Player").GetComponent<PlayerControlla>();
    }

    // Update is called once per frame
    void Update()
    {       
        speed = playerScript.getCurrentVelocity(); //fetches the player's current speed

        //Background scrolling offset code courtesy of Charger Games of YouTube, link: https://www.youtube.com/watch?v=HrDxnMI7pCc
        if (speed >= 0.5f)
        {
            if (speed > 100)
            {
                speed = 100;    //limits how quickly the background scrolls
            }

            offset += (Time.deltaTime * speed) / 50;

            backgroundRenderer.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));   //calculates and displays the background image with some offset to give the effect of scrolling
        }
        else //if the player is not moving
        {
            speed = 0;
            offset += (Time.deltaTime * speed) / 50;
            backgroundRenderer.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));   //pauses the scrolling
        }
    }
}
