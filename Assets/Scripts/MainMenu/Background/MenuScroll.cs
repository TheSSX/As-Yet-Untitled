using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScroll : MonoBehaviour
{
    public float speed = 3;
    float offset;
    Renderer backgroundRenderer;

    // Use this for initialization
    void Start()
    {
        backgroundRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        offset += (Time.deltaTime * speed) / 50;
        backgroundRenderer.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
