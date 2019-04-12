using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseCanvasControlla : MonoBehaviour {

    public Button resume, relaunch, exit;
    public LevelManager levelmanager;
    public TargetControlla targetcontrolla;

    // Use this for initialization
    void Start () {
        resume.onClick.AddListener(ResumeOnClick);
        relaunch.onClick.AddListener(RelaunchOnClick);
        exit.onClick.AddListener(ExitOnClick);
        levelmanager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        targetcontrolla = GameObject.Find("LevelManager").GetComponent<TargetControlla>();
    }

    private void ResumeOnClick()
    {
        levelmanager.setPaused(false);
        targetcontrolla.target(true);
    }

    private void RelaunchOnClick()
    {
        levelmanager.relaunch();
    }

    private void ExitOnClick()
    {
        levelmanager.saveGame();
        Application.Quit();
    }
}
