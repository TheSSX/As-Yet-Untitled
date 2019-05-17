using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Controls the pause menu
public class PauseCanvasControlla : MonoBehaviour {

    public Button resume, relaunch, exit;
    private SoundSystem ss;
    public LevelManager levelmanager;
    public TargetControlla targetcontrolla;
    public Toggle music, soundeffects;

    // Use this for initialization
    void Start()
    {
        resume.onClick.AddListener(ResumeOnClick);
        relaunch.onClick.AddListener(RelaunchOnClick);
        exit.onClick.AddListener(ExitOnClick);
        levelmanager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        targetcontrolla = GameObject.Find("LevelManager").GetComponent<TargetControlla>();
        ss = SoundSystem.getInstance();

        music = GameObject.Find("Music").GetComponent<Toggle>();
        soundeffects = GameObject.Find("SoundEffects").GetComponent<Toggle>();

        music.isOn = !ss.isMusicMuted();
        soundeffects.isOn = !ss.isSoundEffectsMuted();
    }

    //Resumes the game
    private void ResumeOnClick()
    {
        levelmanager.setPaused(false);
        targetcontrolla.target(true);
    }

    //Restarts the launch
    private void RelaunchOnClick()
    {
        levelmanager.relaunch();
    }

    //Exits to menu
    private void ExitOnClick()
    {
        Time.timeScale = 1;
        ss.playMusic("MainMenu");
        SceneManager.LoadSceneAsync("MainMenu");
    }

    //Toggles the music on and off if pressed. 
    public void switchMusic()
    {
        if (music.isOn)
        {
            ss.toggleMusic(false);
        }
        else
        {
            ss.toggleMusic(true);
            ss.playMusic("Gameplay");
        }
              
    }

    //Toggles the sound effects on and off if pressed. 

    public void switchSoundEffects()
    {
        if (soundeffects.isOn)
        {
            ss.toggleSoundEffects(false);
        }
        else
        {
            ss.toggleSoundEffects(true);
        }      
    }
}
