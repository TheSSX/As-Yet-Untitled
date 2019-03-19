using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonControlla : MonoBehaviour {

    public float angle;
    private Animator animation;
    public PlayerControlla playerScript;

    // Use this for initialization
    void Start () {
        animation = GetComponent<Animator>();
        animation.SetBool("fired", false);
    }

    // Update is called once per frame
    //Rotation functionality provided by user tknz on Unity forums. Link: https://answers.unity.com/questions/10615/rotate-objectweapon-towards-mouse-cursor-2d.html
    void Update()
    {
        if (!(Input.GetMouseButton(0)))
        {
            //rotation
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 5.23f;

            Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
            mousePos.x = mousePos.x - objectPos.x;
            mousePos.y = mousePos.y - objectPos.y;

            angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
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
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }

        if (Input.GetMouseButtonUp(0))
        {
            animation.SetBool("fired", true);           
        }
    }
}
