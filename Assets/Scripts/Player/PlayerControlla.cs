using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlla : MonoBehaviour
{

    private Rigidbody2D rigidbody;
    private bool isTouchingGround;
    private bool hasFired = false;
    private float power = 1;
    public scroll scroll;
    public float currentVelocity;
    private bool initialFire;
    private Animator animation;
    public float lastVelocity;

    [SerializeField]
    private PolygonCollider2D[] colliders;
    private int currentColliderIndex = 0;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        hasFired = false;
        scroll = GameObject.FindObjectOfType<scroll>();
        isTouchingGround = false;
        initialFire = true;
        animation = GetComponent<Animator>();
        animation.SetBool("hasFired", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasFired)
        {
            if (getReadyToFire())
            {
                hasFired = true;
                animation.SetBool("hasFired", true);
            }
        }
        else
        {
            transform.Rotate(0, 0, -currentVelocity / 50);

            if (initialFire)
            {               
                colliders[currentColliderIndex].enabled = true;
            }
            else if (transform.position.y > -2 && currentVelocity >= 0.5f)
            {
                transform.Rotate(0, 0, -currentVelocity);
                if ((transform.eulerAngles.z < 360 && transform.eulerAngles.z >= 340) || (transform.eulerAngles.z >= 0 && transform.eulerAngles.z < 20))
                {
                    transform.Rotate(0, 0, -3f);
                }
            }
        }

        animation.SetFloat("currentVelocity", currentVelocity);
        animation.SetFloat("rigidbodyVelocityY", rigidbody.velocity.y);

        if (currentVelocity < 0.5f && hasFired)
        {
            standUp();
        }
    }

    private bool getReadyToFire()
    {
        GameObject barrel = GameObject.Find("Barrel");
        Vector2 pos = barrel.transform.position;
        transform.position = new Vector2(pos.x + 2, pos.y + 2);

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
            currentVelocity = rigidbody.velocity.y;
            scroll.hasFired(power * power * power * power * power * power);
            power = 1;
            return true;
        }

        return false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground" && currentVelocity >= 0.5f && !isTouchingGround)
        {
            initialFire = false;
            setAnimation();

            if ((rigidbody.velocity.y < currentVelocity * 0.75f) && currentVelocity >= 0.75f)
            {
                lastVelocity = currentVelocity;
                currentVelocity *= 0.75f;
            }
            else
            {
                lastVelocity = currentVelocity;
                currentVelocity = rigidbody.velocity.y;               
            }

            isTouchingGround = true;

            if (currentVelocity == lastVelocity)
            {
                lastVelocity = 0f;
                currentVelocity = 0f;
            }
        }
        else if (other.tag == "Ground")
        {
            currentVelocity *= 0.75f;

            if (currentVelocity < 0.5f || rigidbody.velocity.y < 0.001)
            {
                lastVelocity = 0f;
                currentVelocity = 0f;
            }
        }
    }

    private void setAnimation()
    {
        int random = Random.Range(0, 3);
        animation.SetInteger("randomInt", random);
        colliders[currentColliderIndex].enabled = false;
        currentColliderIndex = random + 1;
        colliders[currentColliderIndex].enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTouchingGround = false;
    }

    public float getCurrentVelocity()
    {
        return currentVelocity;
    }

    private void standUp()
    {
        lastVelocity = 0f;
        currentVelocity = 0f;
        rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        transform.eulerAngles = new Vector3(0, 0, 0);
        transform.position = new Vector3(transform.position.x, -1.63f, transform.position.z);
    }
}
