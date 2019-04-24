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
    private CannonControlla cannon;
    private TargetControlla targetcontrolla;

    private bool isTouchingGround, hasFired, increasing, initialFire;
    private float currentVelocity, lastVelocity, power;   
    private int currentColliderIndex, counter;

	private const int basicCannonmod = 6;
	private const int goldCannonmod = 20;

	private int powermod;   

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
        cannon = GameObject.Find("Barrel").GetComponent<CannonControlla>();
        targetcontrolla = GameObject.Find("LevelManager").GetComponent<TargetControlla>();

        targetcontrolla.target(true);

        powermod = basicCannonmod;
        hasFired = false;
        isTouchingGround = false;
        initialFire = true;
        increasing = true;
        playerRenderer.enabled = false;

        playerAnimation.SetBool("hasFired", false);
        playerAnimation.SetBool("hitBySpikes", false);
    }

    // Update is called once per frame
    void Update()
    {
        //Stops player from getting stuck in the ground
        if (isTouchingGround)
        {
            groundCount();           
        }

        if (!hasFired && getReadyToFire())
        {
            hasFired = true;           
        }
        else
        {
            //currentVelocity *= 0.999f;

            if (!levelmanager.isPaused())
            {
                transform.Rotate(0, 0, -currentVelocity / 50);
            }
            
            if (initialFire)
            {               
                colliders[currentColliderIndex].enabled = true;
            }
            else if (currentVelocity >= 0.5f && !levelmanager.isPaused() && !initialFire)
            {
                transform.Rotate(0, 0, -currentVelocity);
                if ((transform.eulerAngles.z < 360 && transform.eulerAngles.z >= 340) || (transform.eulerAngles.z >= 0 && transform.eulerAngles.z < 20))
                {
                    transform.Rotate(0, 0, -3f);
                }
            }

            playerAnimation.SetFloat("currentVelocity", currentVelocity);
            playerAnimation.SetFloat("rigidbodyVelocityY", playerRigidbody.velocity.y);
        }     
    }

    private void groundCount()
    {
        counter++;

        if (counter == 30)
        {
            if (!levelmanager.isPaused())
            {
                standUp();
            }
            else
            {
                counter = 0;
            }
        }
    }

	public void modPower(string x)
	{
		if (x == "basic")  
		{
			powermod = basicCannonmod;
		} 
		else if (x == "gold") 
		{
			powermod = goldCannonmod;
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
                power = 100;
                increasing = false;
            }
            else if (power <= 0)
            {
                power = 0;
                increasing = true;
            }

            if (power < 20 && increasing)
            {
                power += Time.deltaTime * 50;
            }
            else if (power >= 20 && power < 60 && increasing)
            {
                power += Time.deltaTime * 70;
            }
            else if (power >= 60 && power < 80 && increasing)
            {
                power += Time.deltaTime * 80;
            }
            else if (power >= 80 && power < 100 && increasing)
            {
                power += Time.deltaTime * 120;
            }
            else if (power >= 80 && power < 100 && !increasing)
            {
                power -= Time.deltaTime * 120;
            }
            else if (power >= 60 && power < 80 && !increasing)
            {
                power -= Time.deltaTime * 80;
            }
            else if (power >= 20 && power < 60 && !increasing)
            {
                power -= Time.deltaTime * 70;
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

            float angle = cannon.getAngle();

            canvas.displayPower(-1f);
            FixedJoint2D join = GetComponent<FixedJoint2D>();
            Destroy(join);
            
            power /= 40;

            playerRigidbody.AddForce(new Vector2(angle, angle / 60) * powermod * (power * power), ForceMode2D.Impulse);   //I wouldn't touch this if I were you
            if (angle > 35)
            {
                angle = 35 - (angle - 35);
            }
          
            //When cannon upgrades, the first number will be the only change
			currentVelocity = (25 + angle / 20) * power * (powermod/6);

            playerRenderer.enabled = true;
            playerAnimation.SetBool("hasFired", true);
            power = 0;

            return true;
        }

        return false;
    }

    public void setCurrentVelocity(float x)
    {
        currentVelocity = x;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //lastVelocity = currentVelocity;

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
        else if (other.tag == "Ground" && !levelmanager.isPaused())
        {          
            currentVelocity *= 0.75f;
        }
        else if (other.tag == "FloatingSpikes")
        {
            freeze();            
            transform.eulerAngles = new Vector3(0, 0, 180);
            transform.position = new Vector3(other.transform.position.x - 0.8f, other.transform.position.y - 1.5f, other.transform.position.z);
            playerAnimation.SetBool("hitBySpikes", true);
            levelmanager.showResults();
        }
        else if (other.tag == "GroundSpikes")
        {
            freeze();
            transform.eulerAngles = new Vector3(0, 0, 270);
            transform.position = new Vector3(other.transform.position.x, other.transform.position.y + 0.5f, other.transform.position.z);
            playerAnimation.SetBool("hitBySpikes", true);
            levelmanager.showResults();
        }
        else if (other.tag == "Chomper")
        {
            playerRenderer.enabled = false;
            freeze();
            levelmanager.showResults();
        }
    }

    private void freeze()
    {
        //lastVelocity = 0;
        currentVelocity = 0;
        playerRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        targetcontrolla.target(false);
    }

    private void setAnimation()
    {
        int random = Random.Range(0, 5);
        playerAnimation.SetInteger("randomInt", random);
        colliders[currentColliderIndex].enabled = false;
        currentColliderIndex = random;
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
        freeze();
        transform.eulerAngles = new Vector3(0, 0, 0);
        transform.position = new Vector3(transform.position.x, -1.63f, transform.position.z);
        levelmanager.showResults();
    }

    public bool hasBeenFired()
    {
        return hasFired;
    }
}
