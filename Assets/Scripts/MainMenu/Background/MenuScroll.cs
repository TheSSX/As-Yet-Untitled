using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Scrolls the background image of the main menu
public class MenuScroll : MonoBehaviour
{
    private float speed = 3;
    private float offset;
    private Renderer backgroundRenderer;

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
