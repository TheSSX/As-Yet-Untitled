using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlla : MonoBehaviour {

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
    public float currentVelocity;
    private bool initialFire;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        //playerAnimation = GetComponent<Animator>();
        hasFired = false;
        scroll = GameObject.FindObjectOfType<scroll>();
        groundcheckradius = 2f;
        isTouchingGround = false;
        initialFire = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (!hasFired)
        {
            if (getReadyToFire())
            {
                hasFired = true;
            }
        }
        else
        {
            if (initialFire)
            {
                transform.Rotate(0, 0, -currentVelocity/50);
            }
            else if (transform.position.y > -2 && currentVelocity >= 0.5f)
            {
                transform.Rotate(0, 0, -currentVelocity);
                if ((transform.eulerAngles.z < 360 && transform.eulerAngles.z >= 340) || (transform.eulerAngles.z >= 0 && transform.eulerAngles.z < 20))
                {
                    transform.Rotate(0, 0, -3f);
                }
            }

            isTouchingGround = Physics2D.OverlapCircle(transform.position, groundcheckradius, groundlayer);
            if (isTouchingGround)
            {
                if ((rigidbody.velocity.y < currentVelocity*0.75f) && currentVelocity >= 1.5f)
                {
                    currentVelocity = currentVelocity*0.75f;
                }
                else
                {
                    currentVelocity = rigidbody.velocity.y;
                }
                

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
            Destroy(barrel);
            GameObject launcher = GameObject.Find("Launcher");
            Destroy(launcher);
            rigidbody.AddForce(new Vector2(3, 1) * 10f * (power * power), ForceMode2D.Impulse);
            currentVelocity = rigidbody.velocity.y;
            scroll.hasFired(power * power * power * power * power * power);
            power = 1;
            return true;
        }

        return false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        /*if (other.tag == "Ground")
        {
            isTouchingGround = true;
            Debug.Log("touching ground");
        }*/
    }

    public float getCurrentVelocity()
    {
        return currentVelocity;
    }
}
