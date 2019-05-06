using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {
    
    private SoundSystem soundsystem;
    public Button back;
    private MainMenuControlla menu;

	// Use this for initialization
	void Start () {

        soundsystem = GameObject.Find("SoundSystem").GetComponent<SoundSystem>();
        back.onClick.AddListener(BackOnClick);
        menu = GameObject.Find("Canvas").GetComponent<MainMenuControlla>();
    }

    public void switchMusic()
    {
        soundsystem.toggleMusic();
    }

    public void switchSoundEffects()
    {
        soundsystem.toggleSoundEffects();
    }

    private void BackOnClick()
    {
        menu.back();
    }
}
