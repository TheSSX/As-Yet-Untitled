using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    private bool paused;
    public GameObject gameplaycanvas, pausecanvas, resultscanvas;
    public Animator playerAnimator;
    public AnimatorOverrideController bearskin, athlete;

	// Use this for initialization
	void Start () {
        paused = false;
        gameplaycanvas = GameObject.Find("GameplayCanvas");
        pausecanvas = GameObject.Find("PauseCanvas");
        resultscanvas = GameObject.Find("ResultsCanvas");
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();

        gameplaycanvas.SetActive(true);
        pausecanvas.SetActive(false);
        resultscanvas.SetActive(false);
        Time.timeScale = 1;
        selectPlayerAnimation();
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

    //Have a number passed in here to be selected instead. This number comes from the player choice on the menu to choose skin
    public void selectPlayerAnimation()
    {
        int x = Random.Range(0, 2);
        if (x == 0)
        {
            playerAnimator.runtimeAnimatorController = bearskin;
        }
        else
        {
            playerAnimator.runtimeAnimatorController = athlete;
        }
    }
}
