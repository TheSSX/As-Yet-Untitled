using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script controlling the UI during regular, running gameplay
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
    private Sprite[] gunsprites;        //all the possible images of the current gun are stored here. They are displayed in the top right of the screen

    //Store the current height above ground of the player and the distance they have travelled. As these are constantly being updated on the canvas, it made sense to store them here
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

        //While the game is not paused, update the player's height and distance travelled and check if they are above screen
        if (!levelmanager.isPaused())
        { 
            updateHeight();
            renderAboveScreen();
            updateDistance();
        }     		
    }

    //Updates the remaining ammo text displayed in the top right
    public void setAmmo(int x)
    {
        ammoText.text = "Ammo: " + x.ToString();
    }

    //Receives the name of the selected gun and updates to the appropriate gun sprite, as well as its max ammo capacity
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

    //Displays the power level of the launcher before launch while the player is holding the left mouse button. Hides when not a valid value
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

    //Displays the height of the player in metres using their y position
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

    //Updates and displays the distance travelled by the player using their current velocity
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

    //Displays a notification at the top of the screen of how far above the screen the player is if they happen to go above the map
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

    //Pauses the game if the pause button clicked
    private void PauseOnClick()
    {
        levelmanager.setPaused(true);
        target.target(false);
    }

    //Fetches the distance travelled by the player
    public float getDistance()
    {
        return distance;
    }
}
