using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControlla : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private Animator playerAnimation;
    private GameObject barrel;
    public GameplayCanvasControlla canvas;
    public LevelManager levelmanager;
    private Renderer playerRenderer;

    private bool isTouchingGround, hasFired, hitBySpikes, increasing, initialFire;
    private float currentVelocity, lastVelocity, power;   
    private int currentColliderIndex, counter;

    [SerializeField]
    private PolygonCollider2D[] colliders;
    

    // Use this for initialization
    void Start()
    {
        canvas = FindObjectOfType<GameplayCanvasControlla>();
        barrel = GameObject.Find("Barrel");
        levelmanager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        playerAnimation = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerRenderer = GetComponent<Renderer>();

        hasFired = false;
        hitBySpikes = false;
        isTouchingGround = false;
        initialFire = true;
        increasing = true;
        
        playerAnimation.SetBool("hasFired", false);
        playerAnimation.SetBool("hitBySpikes", false);
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
            playerRenderer.enabled = false;
            if (getReadyToFire())
            {
                hasFired = true;
                playerAnimation.SetBool("hasFired", true);
            }
        }
        else
        {
            playerRenderer.enabled = true;

            if (!levelmanager.isPaused())
            {
                transform.Rotate(0, 0, -currentVelocity / 50);
            }
            
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

        playerAnimation.SetFloat("currentVelocity", currentVelocity);
        playerAnimation.SetFloat("rigidbodyVelocityY", playerRigidbody.velocity.y);
    }

    private bool getReadyToFire()
    {
        CannonControlla cannon = GameObject.Find("Barrel").GetComponent<CannonControlla>();
        float angle = cannon.getAngle();

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
            if (power < 10)
            {
                power = 10;
            }

            canvas.displayPower(-1f);
            FixedJoint2D join = GetComponent<FixedJoint2D>();
            Destroy(join);
            
            power /= 40f;
            playerRigidbody.AddForce(new Vector2(3, 1) * 10f * (power * power), ForceMode2D.Impulse);
            currentVelocity = playerRigidbody.velocity.y;
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

            if ((playerRigidbody.velocity.y < currentVelocity * 0.75f) && currentVelocity >= 0.75f)
            {
                currentVelocity *= 0.75f;
            }
            else
            {
                currentVelocity = playerRigidbody.velocity.y;               
            }

            isTouchingGround = true;
        }
        else if (other.tag == "Ground")
        {          
            currentVelocity *= 0.75f;
        }
        else if (other.tag == "FloatingSpikes")
        {
            lastVelocity = 0f;
            currentVelocity = 0f;
            playerRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            transform.eulerAngles = new Vector3(0, 0, 180);
            transform.position = new Vector3(other.transform.position.x - 0.8f, other.transform.position.y - 1.5f, other.transform.position.z);
            hitBySpikes = true;
            playerAnimation.SetBool("hitBySpikes", true);
            levelmanager.showResults();
        }
        else if (other.tag == "GroundSpikes")
        {
            lastVelocity = 0f;
            currentVelocity = 0f;
            playerRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            transform.eulerAngles = new Vector3(0, 0, 270);
            transform.position = new Vector3(other.transform.position.x, other.transform.position.y + 0.5f, other.transform.position.z);
            hitBySpikes = true;
            playerAnimation.SetBool("hitBySpikes", true);
            levelmanager.showResults();
        }
        else if (other.tag == "Chomper")
        {
            GetComponent<Renderer>().enabled = false;
            lastVelocity = 0f;
            currentVelocity = 0f;
            playerRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            levelmanager.showResults();
        }

        if (currentVelocity == lastVelocity && isTouchingGround)
        {
            standUp();
        }
    }

    private void setAnimation()
    {
        int random = Random.Range(0, 3);
        playerAnimation.SetInteger("randomInt", random);
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

    public void standUp()
    {
        lastVelocity = 0f;
        currentVelocity = 0f;
        playerRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        transform.eulerAngles = new Vector3(0, 0, 0);
        transform.position = new Vector3(transform.position.x, -1.63f, transform.position.z);
        levelmanager.showResults();
    }

    public bool hasBeenFired()
    {
        return hasFired;
    }
}
