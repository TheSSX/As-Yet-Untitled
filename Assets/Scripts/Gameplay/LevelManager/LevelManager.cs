using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    private bool paused, showingResults;
    public GameObject gameplaycanvas, pausecanvas, resultscanvas;
    public SkinSelector playerskin;
    public BarrelSkinSelector launcherskin;
	public PlayerControlla player;
    public GunControlla guncontrolla;
    public SaveLoad saveload;
    public GameData data;
    public SoundSystem ss;

    private int currentcash, enemieshit;

    public struct GameData
    {
        public int cash, skinUnlocked, barrelUnlocked, gunsUnlocked;
        public string currentSkin, barrelskin, gunname;
        public float furthestDistance;

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

        ss = GameObject.Find("SoundSystem").GetComponent<SoundSystem>().getInstance();
        saveload = GameObject.Find("SaveLoadSystem").GetComponent<SaveLoad>();
        playerskin = GameObject.Find("Player").GetComponent<SkinSelector>();
        launcherskin = GameObject.Find("Barrel").GetComponent<BarrelSkinSelector>();
		player = GameObject.Find ("Player").GetComponent<PlayerControlla>();
        guncontrolla = GameObject.Find("Gun").GetComponent<GunControlla>();
        currentcash = 0;
        enemieshit = 0;

        data = saveload.load();
        Debug.Log("Read in " + data.cash + " and " + data.currentSkin + " and " + data.skinUnlocked + " and " + data.barrelskin + " and " + data.barrelUnlocked + " and " + data.gunname);       

        playerskin.setSkin(data.currentSkin);
        launcherskin.setSkin(data.barrelskin);
		player.modPower(data.barrelskin);
        guncontrolla.setGun(data.gunname);
       
        paused = false;
        showingResults = false;
        gameplaycanvas = GameObject.Find("GameplayCanvas");
        pausecanvas = GameObject.Find("PauseCanvas");
        resultscanvas = GameObject.Find("ResultsCanvas");    

        gameplaycanvas.SetActive(true);
        pausecanvas.SetActive(false);
        resultscanvas.SetActive(false);

        Time.timeScale = 1;
    }

    public bool saveChecker()
    {
        data = saveload.load();
        
        if (data.cash == -1)
        {
            data = new GameData(0, "bearskin", 1, "basic", 1, "Pistol", 1, 0);
            return false;
        }

        return true;
    }

    public bool isPaused()
    {
        return paused;
    }

    public void addCash(int x)
    {
        currentcash += x;
    }

    public void addEnemy()
    {
        enemieshit += 1;
    }

    public bool isShowingResults()
    {
        return showingResults;
    }

    public void setPaused(bool x)
    {
        paused = x;

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

    public void saveGame()
    {
        saveload.save(data);
    }

    //Autosaves after every launch
    public void relaunch()
    {
        SceneManager.LoadSceneAsync("Gameplay");
    }

    public void showResults()
    {
        float distancethisround = (float)System.Math.Round(gameplaycanvas.GetComponent<GameplayCanvasControlla>().getDistance(), 2);
        currentcash += Mathf.RoundToInt(distancethisround * 10);

        showingResults = true;
        gameplaycanvas.SetActive(false);
        pausecanvas.SetActive(false);
        resultscanvas.SetActive(true);

        if (distancethisround > data.furthestDistance)
        {
            data.furthestDistance = distancethisround;
            resultscanvas.GetComponent<ResultsCanvasControlla>().displayStats(enemieshit, currentcash, currentcash += data.cash, distancethisround, true);
        }
        else
        {
            resultscanvas.GetComponent<ResultsCanvasControlla>().displayStats(enemieshit, currentcash, currentcash += data.cash, distancethisround, false);
        }

        data = new GameData(currentcash, data.currentSkin, data.skinUnlocked, data.barrelskin, data.barrelUnlocked, data.gunname, data.gunsUnlocked, data.furthestDistance);
        saveGame();       
    }

    public void deleteSave()
    {
        saveload.deleteSave();
        relaunch();
    }
}
