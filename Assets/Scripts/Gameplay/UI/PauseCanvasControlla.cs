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
    public Toggle music, soundeffects;
    private bool initialToggle;

    // Use this for initialization
    void Start()
    {
        initialToggle = true;
        resume.onClick.AddListener(ResumeOnClick);
        relaunch.onClick.AddListener(RelaunchOnClick);
        exit.onClick.AddListener(ExitOnClick);
        levelmanager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        targetcontrolla = GameObject.Find("LevelManager").GetComponent<TargetControlla>();
        soundsystem = GameObject.Find("SoundSystem").GetComponent<SoundSystem>().getInstance();

        music = GameObject.Find("Music").GetComponent<Toggle>();
        soundeffects = GameObject.Find("SoundEffects").GetComponent<Toggle>();

        music.isOn = !soundsystem.isMusicMuted();
        soundeffects.isOn = !soundsystem.isSoundEffectsMuted();
        initialToggle = false;
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
        soundsystem.playMusic("MainMenu");
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void switchMusic()
    {
        if (!initialToggle)
        {
            if (music.isOn)
            {
                soundsystem.toggleMusic(false);
            }
            else
            {
                soundsystem.toggleMusic(true);
            }
        }       
    }

    public void switchSoundEffects()
    {
        if (!initialToggle)
        {
            if (soundeffects.isOn)
            {
                soundsystem.toggleSoundEffects(false);
            }
            else
            {
                soundsystem.toggleSoundEffects(true);
            }
        }        
    }
}
