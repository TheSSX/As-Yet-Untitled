using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour
{

    public float speed;
    float offset;
    Renderer renderer;

    // Use this for initialization
    void Start()
    {
        speed = 0f;
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        speed -= 0.002f;

        if (speed >= 0)
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
        speed = x;
    }
}
