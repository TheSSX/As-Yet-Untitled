using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    //Rotation function provided by user tknz on Unity forums. Link: https://answers.unity.com/questions/10615/rotate-objectweapon-towards-mouse-cursor-2d.html
    void Update()
    {
        //rotation
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        if (angle > 70)
        {
            angle = 70f;
        }

        if (angle < 0)
        {
            angle = 0f;
        }

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
