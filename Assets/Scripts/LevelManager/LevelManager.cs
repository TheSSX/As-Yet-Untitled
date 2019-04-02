using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    private bool paused;
    public GameObject gameplaycanvas, pausecanvas, resultscanvas;

	// Use this for initialization
	void Start () {
        paused = false;
        gameplaycanvas = GameObject.Find("GameplayCanvas");
        pausecanvas = GameObject.Find("PauseCanvas");
        resultscanvas = GameObject.Find("ResultsCanvas");
        gameplaycanvas.SetActive(true);
        pausecanvas.SetActive(false);
        resultscanvas.SetActive(false);
        Time.timeScale = 1;
    }

    public bool isPaused()
    {
        return paused;
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

    public void relaunch()
    {
        SceneManager.LoadSceneAsync("Gameplay");
    }

    public void showResults()
    {
        gameplaycanvas.SetActive(false);
        pausecanvas.SetActive(false);
        resultscanvas.SetActive(true);
    }
}
