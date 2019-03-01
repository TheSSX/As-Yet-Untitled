using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class bounce : MonoBehaviour
{
    GameObject player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y <= -1)
        {
            scroll scroll = GetComponent<scroll>();
            changeSpeed(scroll.speed);
        }
    }

    void changeSpeed(float speed)
    {
        Renderer renderer = GetComponent(typeof(Renderer)) as Renderer;
        Vector2 offset = new Vector2(Time.time * speed, 0);
        renderer.material.mainTextureOffset = offset;
    }
}
