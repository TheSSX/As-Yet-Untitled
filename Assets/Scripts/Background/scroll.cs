using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour
{

    public float speed;
    float offset;
    Renderer renderer;
    public PlayerControlla playerScript;

    // Use this for initialization
    void Start()
    {
        speed = 0f;
        renderer = GetComponent<Renderer>();
        playerScript = GameObject.Find("Player").GetComponent<PlayerControlla>();
    }

    // Update is called once per frame
    void Update()
    {       
        speed = playerScript.getCurrentVelocity();

        if (speed >= 0.5f)
        {
            offset += (Time.deltaTime * speed) / 10;

            renderer.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }
        else
        {
            speed = 0;
            offset += (Time.deltaTime * speed) / 10;
            renderer.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }
    }

    public void hasFired(float x)
    {
        Rigidbody2D player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        speed = player.velocity.y;
    }
}
