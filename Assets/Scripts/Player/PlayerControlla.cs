using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControlla : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private bool isTouchingGround;
    public bool hasFired = false;
    private float power = 0;
    public float currentVelocity;
    private bool initialFire;
    private Animator animation;
    GameObject barrel;
    public float lastVelocity;
    public CanvasControlla canvas;
    bool increasing = true;

    [SerializeField]
    private PolygonCollider2D[] colliders;
    private int currentColliderIndex = 0;
    private int counter;

    // Use this for initialization
    void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent < CanvasControlla>();
        barrel = GameObject.Find("Barrel");
        counter = 0;
        rigidbody = GetComponent<Rigidbody2D>();
        hasFired = false;
        isTouchingGround = false;
        initialFire = true;
        animation = GetComponent<Animator>();
        animation.SetBool("hasFired", false);
    }

    // Update is called once per frame
    void Update()
    {
        //Stops player from getting stuck in the ground
        if (isTouchingGround)
        {
            counter++;

            if (counter == 30)
            {
                standUp();
            }
        }

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
            else if (currentVelocity >= 0.5f)
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
        Vector2 pos = barrel.transform.position;
        transform.position = new Vector2(pos.x + 2, pos.y + 2);

        if ((Input.GetMouseButton(0)))
        {
            if (power >= 100)
            {
                power = 100f;
                increasing = false;
            }
            else if (power <= 0)
            {
                power = 0f;
                increasing = true;
            }

            if (power < 20 && increasing)
            {
                power += Time.deltaTime * 50;
            }
            else if (power >= 20 && power < 60 && increasing)
            {
                power += Time.deltaTime * 60;
            }
            else if (power >= 60 && power < 80 && increasing)
            {
                power += Time.deltaTime * 80;
            }
            else if (power >= 80 && power < 100 && increasing)
            {
                power += Time.deltaTime * 100;
            }
            else if (power >= 80 && power < 100 && !increasing)
            {
                power -= Time.deltaTime * 100;
            }
            else if (power >= 60 && power < 80 && !increasing)
            {
                power -= Time.deltaTime * 80;
            }
            else if (power >= 20 && power < 60 && !increasing)
            {
                power -= Time.deltaTime * 60;
            }
            else 
            {
                power -= Time.deltaTime *50;
            }

            canvas.displayPower(power);
        }
        else if (power != 0)
        {
            canvas.displayPower(-1f);
            FixedJoint2D join = GetComponent<FixedJoint2D>();
            Destroy(join);
            CannonControlla cannon = GameObject.Find("Barrel").GetComponent<CannonControlla>();
            float angle = cannon.angle;
            power /= 40f;
            rigidbody.AddForce(new Vector2(3, 1) * 10f * (power * power), ForceMode2D.Impulse);
            currentVelocity = rigidbody.velocity.y;
            power = 0;
            return true;
        }

        return false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        lastVelocity = currentVelocity;

        if (other.tag == "Ground" && currentVelocity >= 0.5f && !isTouchingGround)
        {
            initialFire = false;
            setAnimation();

            if ((rigidbody.velocity.y < currentVelocity * 0.75f) && currentVelocity >= 0.75f)
            {
                currentVelocity *= 0.75f;
            }
            else
            {
                currentVelocity = rigidbody.velocity.y;               
            }

            isTouchingGround = true;
        }
        else if (other.tag == "Ground")
        {          
            currentVelocity *= 0.75f;
        }

        if (currentVelocity == lastVelocity)
        {
            standUp();
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
        counter = 0;
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
