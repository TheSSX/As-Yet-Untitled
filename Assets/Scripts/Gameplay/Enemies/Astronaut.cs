using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astronaut : MonoBehaviour {

    private float ypos;

    void Start()
    {
        ypos = transform.position.y;
    }

    // Update is called once per frame
    void Update () {
        transform.Rotate(0, 0, 10);
    }
}
