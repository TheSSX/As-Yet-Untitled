using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {
    
    private SoundSystem soundsystem;
    public Button back;
    private MainMenuControlla menu;
    public Toggle music, soundeffects;
    private bool initialToggle;

    // Use this for initialization
    void Start () {

        initialToggle = true;
        soundsystem = GameObject.Find("SoundSystem").GetComponent<SoundSystem>().getInstance();
        back.onClick.AddListener(BackOnClick);
        menu = GameObject.Find("Canvas").GetComponent<MainMenuControlla>();
        music = GameObject.Find("Music").GetComponent<Toggle>();
        soundeffects = GameObject.Find("Sound Effects").GetComponent<Toggle>();

        music.isOn = !soundsystem.musicclip.mute;
        soundeffects.isOn = !soundsystem.isSoundEffectsMuted();
        initialToggle = false;
        GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
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

    private void BackOnClick()
    {
        menu.back();
    }
}
