using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlla : MonoBehaviour {

    private Rigidbody2D rigidbody;
    public float groundcheckradius;
    public LayerMask groundlayer;
    private bool isTouchingGround;
    private bool hasFired = false;
    private float power = 1;
    private GameObject background;
    public scroll scroll;
    public float currentVelocity;
    private bool initialFire;
    private SpriteRenderer renderer;
    //public Texture2D[] myTextures;
    public Sprite[] myTextures;
	private Animator animation;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        //playerAnimation = GetComponent<Animator>();
        hasFired = false;
        scroll = GameObject.FindObjectOfType<scroll>();
        groundcheckradius = 5f;
        isTouchingGround = false;
        initialFire = true;
        renderer = GetComponent<SpriteRenderer>();
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
                renderer.sprite = myTextures[1];
                animation.SetBool("hasFired", true);
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

            /*isTouchingGround = Physics2D.OverlapCircle(transform.position, groundcheckradius, groundlayer);
			if (transform.position.y <= -2 && currentVelocity >= 0.5f) {
				renderer.sprite = myTextures [Random.Range (0, 4)];
                animation.SetInteger("randomInt", Random.Range(0, 3));

                if ((rigidbody.velocity.y < currentVelocity * 0.75f) && currentVelocity >= 1.5f) {
					currentVelocity = currentVelocity * 0.75f;
				} else {
					currentVelocity = rigidbody.velocity.y;
				}
			}*/
        }
		
		animation.SetFloat ("currentVelocity", currentVelocity);
		animation.SetFloat ("rigidbodyVelocityY", rigidbody.velocity.y);	

		if (currentVelocity < 0.5f && hasFired) 
		{
			standUp ();
		}
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
        if (other.tag == "Ground" && currentVelocity >= 0.5f && !isTouchingGround)
        {
            renderer.sprite = myTextures[Random.Range(0, 4)];
            animation.SetInteger("randomInt", Random.Range(0, 3));

            if ((rigidbody.velocity.y < currentVelocity * 0.75f) && currentVelocity >= 0.75f)
            {
                currentVelocity = currentVelocity * 0.75f;
            }
            else
            {
                currentVelocity = rigidbody.velocity.y;
            }

            isTouchingGround = true;       
        }
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
		currentVelocity = 0f;
		rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
		transform.eulerAngles = new Vector3 (0, 0, 0);
		transform.position = new Vector3 (transform.position.x, -1.63f, transform.position.z);
	}
}
