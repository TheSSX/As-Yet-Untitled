using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardCollisionDetector : MonoBehaviour {

    private Rigidbody2D rgd;
    private PlayerControlla playercontrolla;
    private LevelManager levelmanager;
    private int counter;
    private SoundSystem ss;

	// Use this for initialization
	void Start () {
        rgd = GetComponent<Rigidbody2D>();
        playercontrolla = GetComponent<PlayerControlla>();
        levelmanager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        counter = 0;
        ss = GameObject.Find("SoundSystem").GetComponent<SoundSystem>();
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
        if (other.tag == "Ground")
        {
            ss.playSound("playerland");
        }
        else if (other.tag == "FloatingSpikes" || other.tag == "GroundSpikes")
        {
            ss.playSound("spikes");
        }
        else if (other.tag == "Chomper")
        {
            ss.playSound("swallow");
        }

        if (counter == 60)
        {
            if (other.tag == "Jet")
            {
                rgd.AddForce(new Vector2(4, 0.5f) * 150, ForceMode2D.Impulse);
                playercontrolla.setCurrentVelocity(playercontrolla.getCurrentVelocity() * 2);
                levelmanager.addEnemy();
            }
            else if (other.tag == "Pufferfish")
            {
                ss.playSound("balloonpop");
                rgd.AddForce(new Vector2(4, 0.5f) * 130, ForceMode2D.Impulse);
                playercontrolla.setCurrentVelocity(playercontrolla.getCurrentVelocity() * 1.8f);
                levelmanager.addEnemy();
            }
            else if (other.tag == "Jetpack Man")
            {
                rgd.AddForce(new Vector2(4, 0.5f) * 120, ForceMode2D.Impulse);
                playercontrolla.setCurrentVelocity(playercontrolla.getCurrentVelocity() * 1.5f);
                levelmanager.addEnemy();
            }
            else if (other.tag == "Astronaut")
            {
                rgd.AddForce(new Vector2(4, -0.5f) * 90, ForceMode2D.Impulse);
                playercontrolla.setCurrentVelocity(playercontrolla.getCurrentVelocity() * 1.1f);
                levelmanager.addEnemy();
            }
            else if (other.tag == "Bomb")
            {
                ss.playSound("explosion");
                rgd.AddForce(new Vector2(4, 0.5f) * 160, ForceMode2D.Impulse);
                playercontrolla.setCurrentVelocity(playercontrolla.getCurrentVelocity() * 2.5f);
                levelmanager.addEnemy();
            }

            counter = 0;
        }
    }
}
