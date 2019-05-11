using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayCanvasControlla : MonoBehaviour {

    public GameObject player;
    public PlayerControlla playercontroller;
    public LevelManager levelmanager;
    public TargetControlla target;
    public GunControlla gun;

    public Button pause;

    public Image aboveScreen, selectedGun;
    public Text heightAboveScreenText, heightText, distanceText, powerText, ammoText;

    [SerializeField]
    private Sprite[] gunsprites;

    public float height;
    public float distance;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        playercontroller = player.GetComponent<PlayerControlla>();
        levelmanager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        target = GameObject.Find("LevelManager").GetComponent<TargetControlla>();
        gun = GameObject.Find("Gun").GetComponent<GunControlla>();        

        aboveScreen.enabled = false;
        heightAboveScreenText.enabled = false;
        powerText.enabled = false;

        pause.onClick.AddListener(PauseOnClick);
    }
	
	// Update is called once per frame
	void Update () {

        if (!levelmanager.isPaused())
        { 
            updateHeight();
            renderAboveScreen();
            updateDistance();
        }     		
    }

    public void setAmmo(int x)
    {
        ammoText.text = "Ammo: " + x.ToString();
    }

    public void setGun(string x, int y)
    {
        ammoText.text = "Ammo: " + y.ToString();

        if (x == "Pistol")
        {
            selectedGun.sprite = gunsprites[0];
        } 
        else if (x == "Shotgun")
        {
            selectedGun.sprite = gunsprites[1];
        }
        else if (x == "Rifle")
        {
            selectedGun.sprite = gunsprites[2];
        }
        else if (x == "Sniper Rifle")
        {
            selectedGun.sprite = gunsprites[3];
        }
        else if (x == "Rocket Launcher")
        {
            selectedGun.sprite = gunsprites[4];
        }
        else if (x == "Golden Deagle")
        {
            selectedGun.sprite = gunsprites[5];
        }
    }

    public void displayPower(float power)
    {
        if (power == -1f)
        {
            powerText.enabled = false;
        }
        else
        {
            powerText.enabled = true;
            powerText.text = "Power: " + power.ToString("#") + "%";
        }
    }

    private void updateHeight()
    {
        height = (player.transform.position.y * 2) + 2.9f;

        if (height < 1f)
        {
            height = 0f;
            heightText.text = "Height: 0m";
        }
        else
        {
            heightText.text = "Height: " + height.ToString("#") + "m";
        }
    }

    private void updateDistance()
    {
        if (!levelmanager.isPaused())
        {
            distance += playercontroller.getCurrentVelocity() / 30;
        }
        
        if (distance == 0f)
        {
            distanceText.text = "Distance: 0m";
        }
        else
        {
            distanceText.text = "Distance: " + distance.ToString("0.##") + "m";
        }
    }

    private void renderAboveScreen()
    {
        if (player.transform.position.y > 110)
        {
            aboveScreen.enabled = true;
            heightAboveScreenText.enabled = true;
            heightAboveScreenText.text = (height - (110f * 2)).ToString("#") + "m";
        }
        else
        {
            aboveScreen.enabled = false;
            heightAboveScreenText.enabled = false;
        }
    }

    private void PauseOnClick()
    {
        levelmanager.setPaused(true);
        target.target(false);
    }

    public float getDistance()
    {
        return distance;
    }
}
