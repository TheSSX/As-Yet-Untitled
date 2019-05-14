using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls the launching of the player from the cannon
public class LauncherFire : MonoBehaviour {

    private GameObject barrel;
    private GameplayCanvasControlla canvas;
    private CannonControlla cannon;
    private Rigidbody2D playerRigidbody;
    private PlayerControlla player;
    private Renderer playerRenderer;
    private PlayerAnimator playerAnimator;
    private float power;
    private bool increasing;

    //Constant stats for the power levels of each cannon
    private const int basicCannonmod = 6;
    private const int goldCannonmod = 10;
    private const int tankmod = 14;
    private const int samturretmod = 22;
    private const int missilelaunchermod = 26;
    private const int diamondmod = 30;

    private int powermod;

    // Use this for initialization
    void Start () {
        barrel = GameObject.Find("Barrel");
        canvas = GameObject.Find("GameplayCanvas").GetComponent<GameplayCanvasControlla>();
        cannon = barrel.GetComponent<CannonControlla>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        player = GetComponent<PlayerControlla>();
        playerRenderer = GetComponent<Renderer>();
        playerAnimator = GetComponent<PlayerAnimator>();

        power = 0;
        increasing = true;
        playerRenderer.enabled = false;     //hides the player before launch
    }

    void Update()
    {
        Vector2 pos = barrel.transform.position;
        transform.position = new Vector2(pos.x + 2, pos.y + 2);     //sets the launcher near to the barrel

        if ((Input.GetMouseButton(0)))      //if player holding down the left mouse button
        {
            //Code to swing the power level back and forth between 0 and 100 while left mouse button held
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
                power -= Time.deltaTime * 50;
            }

            canvas.displayPower(power);     //displays the current power level
        }
        else if (power != 0)        //if power level is set, we are ready to fire
        {
            if (power < 15)
            {
                power = 15;     //ensures a minimum power level
            }

            float angle = cannon.getAngle();        //retrieves the angle of launch

            canvas.displayPower(-1f);       //hides the current power level upon launch
            FixedJoint2D join = GetComponent<FixedJoint2D>();
            Destroy(join);      //removes the join between launcher and player that exists before launch

            power /= 75;

            playerRigidbody.AddForce(new Vector2(angle, angle / 60) * powermod * (power * power), ForceMode2D.Impulse);   //Code to fire the player with an appropriate level of power. I wouldn't touch this if I were you

            if (angle > 35)
            {
                angle = 35 - (angle - 35);      //used to ensure the velocity of the player is at its highest when angle = 45 degrees. For example, a player launched at an angle of 20 degrees will have an equivalent velocity as one launched at 70 degrees
            }

            float currentVelocity = (25 + angle / 20) * power * (powermod / 6);
            playerRenderer.enabled = true;
            playerAnimator.fired();                         //shows the player and plays a random animation when they launch
            playerAnimator.setAnimation();
            player.setCurrentVelocity(currentVelocity);
            player.fire();
            this.enabled = false;       //once launched, the launcher script is no longer required and just uses unnecessary resources
        }
    }

    //Receives the name of the launcher and sets the power of the launcher based on that
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
        else if (x == "tank")
        {
            powermod = tankmod;
        }
        else if (x == "SAM turret")
        {
            powermod = samturretmod;
        }
        else if (x == "missile launcher")
        {
            powermod = missilelaunchermod;
        }
        else if (x == "diamond")
        {
            powermod = diamondmod;
        }
    }
}
