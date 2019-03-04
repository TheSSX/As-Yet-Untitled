using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlla : MonoBehaviour {

    private float speed = 5;
    private Rigidbody2D rigidbody;
    public Transform groundcheckpoint;
    public float groundcheckradius;
    public LayerMask groundlayer;
    private bool isTouchingGround;
    private bool hasFired = false;
    private Animator playerAnimation;
    private float power = 1;
    private GameObject background;
    public scroll scroll;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        //playerAnimation = GetComponent<Animator>();
        hasFired = false;
        scroll = GameObject.FindObjectOfType<scroll>();
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundcheckpoint.position, groundcheckradius, groundlayer);

        if (!hasFired)
        {
            if (getReadyToFire())
            {
                hasFired = true;
            }
        }

        //if (Input.GetButtonDown("Jump") && isTouchingGround)
        // {
        //    rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpspeed);
        //}

        //Animation code, changes the parameters in the Animator object
        //playerAnimation.SetFloat("Speed", Mathf.Abs(rigidbody.velocity.x));
        //playerAnimation.SetBool("OnGround", isTouchingGround);
    }

    private bool getReadyToFire()
    {
        GameObject barrel = GameObject.Find("Barrel");
        Vector2 pos = barrel.transform.position;
        transform.position = new Vector2(barrel.transform.position.x + 2, barrel.transform.position.y + 2);

        if ((Input.GetMouseButton(0)))
        {         
            power += Time.deltaTime;
            if (power > 2.5f)
            {
                power = 2.5f;
            }
        }
        else if (power != 1)
        {
            FixedJoint2D join = GetComponent<FixedJoint2D>();
            Destroy(join);
            rigidbody.AddForce(new Vector2(3, 1) * 10f * (power * power), ForceMode2D.Impulse);
            scroll.hasFired(power * power * power * power * power * power);
            Debug.Log("power is " + power);
            power = 1;
            return true;
        }

        return false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        /*if (other.tag == "FallDetector")
        {
            gamelevelmanager.respawn();  
        }

        if (other.tag == "Checkpoint")
        {
            respawnpoint = other.transform.position;
        }*/
    }
}
