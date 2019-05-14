using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Controls the main menu
public class MainMenuControlla : MonoBehaviour {

    [SerializeField]
    private GameObject mainpanel, settingspanel, instructionspanel;
    [SerializeField]
    private Button play, instructions, settings, exit;
    private int counter;

    private SoundSystem ss;

	// Use this for initialization
	void Start () {
        counter = 0;
        mainpanel.SetActive(false);
        settingspanel.SetActive(false);
        instructionspanel.SetActive(false);

        play.onClick.AddListener(PlayOnClick);
        instructions.onClick.AddListener(InstructionsOnClick);
        settings.onClick.AddListener(SettingsOnClick);
        exit.onClick.AddListener(ExitOnClick);

        ss = SoundSystem.getInstance();
    }

    // Update is called once per frame
    void Update () {

        if (counter <= 60)
        {
            counter++;

            if (counter == 60)
            {
                mainpanel.SetActive(true);      //Displays the menu buttons after 1 second of the game loading up
            }
        }
	}

    //Starts the game
    private void PlayOnClick()
    {
        ss.playSound("menubutton");
        ss.playMusic("Gameplay");
        SceneManager.LoadSceneAsync("Gameplay");
    }

    //Shows instructions
    private void InstructionsOnClick()
    {
        ss.playSound("menubutton");
        mainpanel.SetActive(false);
        instructionspanel.SetActive(true);
    }

    //Shows settings
    private void SettingsOnClick()
    {
        ss.playSound("menubutton");
        mainpanel.SetActive(false);
        settingspanel.SetActive(true);
    }

    //Exits the game
    private void ExitOnClick()
    {
        ss.playSound("menubutton");
        Application.Quit();
    }

    //Shows the main menu
    public void back()
    {
        ss.playSound("menubutton");
        mainpanel.SetActive(true);
        settingspanel.SetActive(false);
        instructionspanel.SetActive(false);
    }
}
