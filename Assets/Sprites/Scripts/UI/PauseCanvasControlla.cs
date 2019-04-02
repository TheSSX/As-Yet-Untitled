using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseCanvasControlla : MonoBehaviour {

    public Button resume, relaunch;
    public LevelManager levelmanager;

    // Use this for initialization
    void Start () {
        resume.onClick.AddListener(ResumeOnClick);
        relaunch.onClick.AddListener(RelaunchOnClick);
        levelmanager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    private void ResumeOnClick()
    {
        levelmanager.setPaused(false);
    }

    private void RelaunchOnClick()
    {
        levelmanager.relaunch();
    }
}
