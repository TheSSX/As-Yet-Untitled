using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseCanvasControlla : MonoBehaviour {

    public Button resume, relaunch, exit;
    private SoundSystem soundsystem;
    public LevelManager levelmanager;
    public TargetControlla targetcontrolla;

    // Use this for initialization
    void Start () {
        resume.onClick.AddListener(ResumeOnClick);
        relaunch.onClick.AddListener(RelaunchOnClick);
        exit.onClick.AddListener(ExitOnClick);
        levelmanager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        targetcontrolla = GameObject.Find("LevelManager").GetComponent<TargetControlla>();
        soundsystem = GameObject.Find("SoundSystem").GetComponent<SoundSystem>();
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
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void switchMusic()
    {
        soundsystem.toggleMusic();
    }

    public void switchSoundEffects()
    {
        soundsystem.toggleSoundEffects();
    }
}
