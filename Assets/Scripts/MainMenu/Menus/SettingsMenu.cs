using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Controls the settings for the game
public class SettingsMenu : MonoBehaviour {
    
    private SoundSystem ss;
    [SerializeField]
    private Button back;
    private MainMenuControlla menu;
    [SerializeField]
    private Toggle music, soundeffects;
    private bool initialToggle;

    // Use this for initialization
    void Start () {

        initialToggle = true;
        ss = SoundSystem.getInstance();
        back.onClick.AddListener(BackOnClick);
        menu = GameObject.Find("Canvas").GetComponent<MainMenuControlla>();
        music = GameObject.Find("Music").GetComponent<Toggle>();
        soundeffects = GameObject.Find("Sound Effects").GetComponent<Toggle>();

        music.isOn = !ss.musicclip.mute;
        soundeffects.isOn = !ss.isSoundEffectsMuted();
        initialToggle = false;
        GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
    }

    //Toggles the music being muted and not muted
    public void switchMusic()
    {
        if (!initialToggle)     //Relates to the synchronisation of settings menu in main menu and settings menu in game
        {
            if (music.isOn)
            {
                ss.toggleMusic(false);
            }
            else
            {
                ss.toggleMusic(true);
            }
        }     
    }

    //Toggles the sound effects being muted and not muted
    public void switchSoundEffects()
    {
        if (!initialToggle)
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

    //Returns to the main menu
    private void BackOnClick()
    {
        menu.back();
    }
}
