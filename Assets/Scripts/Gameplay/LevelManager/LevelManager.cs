using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    private bool paused, showingResults;
    public GameObject gameplaycanvas, pausecanvas, resultscanvas;
    public SkinSelector playerskin;
    public SaveLoad saveload;
    public GameData data;
    public bool hasSaveFile;

    public struct GameData
    {
        public int cash;
        public string currentSkin;
        public int skinUnlocked;

        public GameData(int newcash, string newskin, int newSkinUnlocked)
        {
            cash = newcash;
            currentSkin = newskin;
            skinUnlocked = newSkinUnlocked;
        }
    }

    // Use this for initialization
    void Start () {

        saveload = GameObject.Find("SaveLoadSystem").GetComponent<SaveLoad>();
        playerskin = GameObject.Find("Player").GetComponent<SkinSelector>();
        data = saveload.load();
        Debug.Log("Read in " + data.cash + " and " + data.currentSkin + " and " + data.skinUnlocked);
        //saveload.deleteSave();

        // if (!saveChecker())
        //{
        // hasSaveFile = false;          
        // playerskin.setSkin("bearskin");
        //}
        //else
        //{
        //hasSaveFile = true;
        playerskin.setSkin(data.currentSkin);
        //}

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
        Debug.Log("Read in " + data.cash + " and " + data.currentSkin + " and " + data.skinUnlocked);
        if (data.cash == -1)
        {
            data = new GameData(0, "bearskin", 1);
            return false;
        }

        return true;
    }

    public bool isPaused()
    {
        return paused;
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
        updateCash();
        saveGame();
        showingResults = true;
        gameplaycanvas.SetActive(false);
        pausecanvas.SetActive(false);
        resultscanvas.SetActive(true);
        resultscanvas.GetComponent<ResultsCanvasControlla>().displayCash(data.cash);
    }

    public void updateCash()
    {
        int newcash = data.cash;
        newcash += Mathf.RoundToInt(gameplaycanvas.GetComponent<GameplayCanvasControlla>().getDistance() * 10);
        data = new GameData(newcash, data.currentSkin, data.skinUnlocked);
    }
}
