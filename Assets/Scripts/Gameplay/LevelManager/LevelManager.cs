using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//The overseeing class in gameplay, managing and controlling data and events for many other objects
public class LevelManager : MonoBehaviour {

    private bool paused, showingResults;
    private GameObject gameplaycanvas, pausecanvas, resultscanvas;
    private PlayerAnimator playerskin;
    private BarrelSkinSelector launcherskin;
	private LauncherFire launcherfire;
    private GunControlla guncontrolla;
    private SaveLoad saveload;
    private GameData data;
    private int currentcash, enemieshit;

    //Holds the crucial data needed to set the sprites and animations of game objects, cash reserves and distance records. Used all over the gameplay and shop scenes
    public struct GameData
    {
        public int cash, skinUnlocked, barrelUnlocked, gunsUnlocked;
        public string currentSkin, barrelskin, gunname;
        public float furthestDistance;

        //Any new instance must contain all the data required of the program, to ensure nothing goes missing when saving and loading
        public GameData(int newcash, string newskin, int newSkinUnlocked, string newbarrelskin, int newbarrelUnlocked, string newgunname, int newgunsunlocked, float newFurthestDistance)
        {
            cash = newcash;
            currentSkin = newskin;
            skinUnlocked = newSkinUnlocked;
            barrelskin = newbarrelskin;
            barrelUnlocked = newbarrelUnlocked;
            gunname = newgunname;
            gunsUnlocked = newgunsunlocked;
            furthestDistance = newFurthestDistance;
        }
    }

    // Use this for initialization
    void Start () {

        gameplaycanvas = GameObject.Find("GameplayCanvas");
        pausecanvas= GameObject.Find("PauseCanvas");
        resultscanvas = GameObject.Find("ResultsCanvas");
        saveload = GameObject.Find("SaveLoadSystem").GetComponent<SaveLoad>();
        playerskin = GameObject.Find("Player").GetComponent<PlayerAnimator>();
        launcherskin = GameObject.Find("Barrel").GetComponent<BarrelSkinSelector>();
		launcherfire = GameObject.Find ("Player").GetComponent<LauncherFire>();
        guncontrolla = GameObject.Find("Gun").GetComponent<GunControlla>();
        currentcash = 0;
        enemieshit = 0;

        //Read in already saved user data
        data = saveload.load();

        //Debug.Log("Read in " + data.cash + " and " + data.currentSkin + " and " + data.skinUnlocked + " and " + data.barrelskin + " and " + data.barrelUnlocked + " and " + data.gunname);       

        playerskin.setSkin(data.currentSkin);       //Pass the current character skin to the player
        launcherskin.setSkin(data.barrelskin);      //Pass the current launcher skin to the launcher
		launcherfire.modPower(data.barrelskin);           //Pass the current launcher skin to the player
        guncontrolla.setGun(data.gunname);          //Pass the current gun skin to the gun
       
        paused = false;
        showingResults = false;    

        gameplaycanvas.SetActive(true);
        pausecanvas.SetActive(false);
        resultscanvas.SetActive(false);

        Time.timeScale = 1;
    }

    //Tells objects whether or not the game is paused
    public bool isPaused()
    {
        return paused;
    }

    //Adds a passed-in amount of cash to the cash amount collected this launch
    public void addCash(int x)
    {
        currentcash += x;
    }

    //Adds 1 to the count of how many enemies have been hit this round
    public void addEnemy()
    {
        enemieshit += 1;
    }

    //Tells an object whether or not results are being shown (launch is concluded)
    public bool isShowingResults()
    {
        return showingResults;
    }

    //Toggles the pause state of the game
    public void setPaused(bool x)
    {
        paused = x;

        //Show and hide the pause menu depending on the pause state
        if (x)
        {
            Time.timeScale = 0;
            gameplaycanvas.SetActive(false);
            pausecanvas.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            gameplaycanvas.SetActive(true);
            pausecanvas.SetActive(false);
        }
    }

    //Allows an object to save game data
    public void saveGame()
    {
        saveload.save(data);
    }

    //Starts a new launch
    public void relaunch()
    {
        SceneManager.LoadSceneAsync("Gameplay");
    }

    //Called when launch is concluded and results are to be shown to the player
    public void showResults()
    {
        float distancethisround = (float)System.Math.Round(gameplaycanvas.GetComponent<GameplayCanvasControlla>().getDistance(), 2);   //calculates the distance travelled by the player in the last launch
        currentcash += Mathf.RoundToInt(distancethisround * 10);    //calculates the cash earned from this launch using distance alone

        showingResults = true;
        gameplaycanvas.SetActive(false);
        pausecanvas.SetActive(false);
        resultscanvas.SetActive(true);      //shows the results panel

        if (distancethisround > data.furthestDistance)
        {
            data.furthestDistance = distancethisround;      //new distance record, notify the player of this
            resultscanvas.GetComponent<ResultsCanvasControlla>().displayStats(enemieshit, currentcash, currentcash += data.cash, distancethisround, true);  //true for new record obtained
        }
        else
        {
            resultscanvas.GetComponent<ResultsCanvasControlla>().displayStats(enemieshit, currentcash, currentcash += data.cash, distancethisround, false);
        }

        //Create new save data, taking into account the last round
        data = new GameData(currentcash, data.currentSkin, data.skinUnlocked, data.barrelskin, data.barrelUnlocked, data.gunname, data.gunsUnlocked, data.furthestDistance);
        saveGame();       
    }

    //Called from the results menu if the player wishes to delete their save data
    public void deleteSave()
    {
        saveload.deleteSave();
        relaunch();
    }
}
