using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuControlla : MonoBehaviour {

    public GameObject mainpanel, settingspanel, instructionspanel;
    public Button play, instructions, settings, exit;
    private int counter;

    public SoundSystem ss;

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

        ss = GameObject.Find("SoundSystem").GetComponent<SoundSystem>();
    }

    // Update is called once per frame
    void Update () {

        if (counter <= 60)
        {
            counter++;

            if (counter == 60)
            {
                mainpanel.SetActive(true);
            }
        }
	}

    private void PlayOnClick()
    {
        ss.playSound("menubutton");
        ss.playMusic("Gameplay");
        SceneManager.LoadSceneAsync("Gameplay");
    }

    private void InstructionsOnClick()
    {
        ss.playSound("menubutton");
        mainpanel.SetActive(false);
        instructionspanel.SetActive(true);
    }

    private void SettingsOnClick()
    {
        ss.playSound("menubutton");
        mainpanel.SetActive(false);
        settingspanel.SetActive(true);
    }

    private void ExitOnClick()
    {
        ss.playSound("menubutton");
        Application.Quit();
    }

    public void back()
    {
        ss.playSound("menubutton");
        mainpanel.SetActive(true);
        settingspanel.SetActive(false);
        instructionspanel.SetActive(false);
    }
}
