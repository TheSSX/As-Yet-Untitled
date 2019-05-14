using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls the sounds and forces applied to the player when touching different objects
public class HazardCollisionDetector : MonoBehaviour {

    private Rigidbody2D rgd;
    private PlayerControlla playercontrolla;
    private LevelManager levelmanager;
    private int counter;
    private SoundSystem ss;
    private Animator playerAnimation;
    private Renderer playerRenderer;

    // Use this for initialization
    void Start () {
        rgd = GetComponent<Rigidbody2D>();
        playercontrolla = GetComponent<PlayerControlla>();
        levelmanager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        counter = 0;
        ss = SoundSystem.getInstance();
        playerAnimation = GetComponent<Animator>();
        playerRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (counter < 60)
        {
            counter++;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")      //when touching the ground
        {
            ss.playSound("playerland");
        }
        else if (other.tag == "FloatingSpikes") //when touching floating spikes
        {
            ss.playSound("spikes");
            playercontrolla.freeze();
            transform.eulerAngles = new Vector3(0, 0, 180);
            transform.position = new Vector3(other.transform.position.x - 0.8f, other.transform.position.y - 1.5f, other.transform.position.z);
            playerAnimation.SetBool("hitBySpikes", true);
            levelmanager.showResults();
        }
        else if (other.tag == "GroundSpikes")      //when touching ground spikes
        {
            ss.playSound("spikes");
            playercontrolla.freeze();
            transform.eulerAngles = new Vector3(0, 0, 270);
            transform.position = new Vector3(other.transform.position.x, other.transform.position.y + 0.5f, other.transform.position.z);
            playerAnimation.SetBool("hitBySpikes", true);
            levelmanager.showResults();
        }
        else if (other.tag == "Chomper")        //when touching a chomper
        {
            ss.playSound("swallow");
            playerRenderer.enabled = false;
            playercontrolla.freeze();
            levelmanager.showResults();
        }

        if (counter == 60)      //player can only interact with one object a second. This prevents an exponential application of force that could send the player too high or far
        {
            if (other.tag == "Jet")     //when touching a jet
            {
                rgd.AddForce(new Vector2(4, 0.5f) * 50, ForceMode2D.Impulse);
                playercontrolla.setCurrentVelocity(playercontrolla.getCurrentVelocity() * 2);               
            }
            else if (other.tag == "Pufferfish")     //when touching a pufferfish
            {
                ss.playSound("balloonpop");
                rgd.AddForce(new Vector2(4, 0.5f) * 45, ForceMode2D.Impulse);
                playercontrolla.setCurrentVelocity(playercontrolla.getCurrentVelocity() * 1.8f);
            }
            else if (other.tag == "Jetpack Man")        //when touching a jetpack man
            {
                rgd.AddForce(new Vector2(4, 0.5f) * 40, ForceMode2D.Impulse);
                playercontrolla.setCurrentVelocity(playercontrolla.getCurrentVelocity() * 1.3f);
            }
            else if (other.tag == "Astronaut")      //when touching an astronaut
            {
                rgd.AddForce(new Vector2(4, -0.5f) * 30, ForceMode2D.Impulse);      //hits the player down to prevent them from going too high
                playercontrolla.setCurrentVelocity(playercontrolla.getCurrentVelocity() * 1.5f);
            }
            else if (other.tag == "Bomb")       //when touching a bomb
            {
                ss.playSound("explosion");
                rgd.AddForce(new Vector2(4, 0.5f) * 55, ForceMode2D.Impulse);
                playercontrolla.setCurrentVelocity(playercontrolla.getCurrentVelocity() * 2.5f);
            }

            levelmanager.addEnemy();        //add one to the enemies hit count
            counter = 0;
        }
    }
}
