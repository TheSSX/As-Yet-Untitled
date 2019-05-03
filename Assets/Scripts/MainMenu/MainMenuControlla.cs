using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuControlla : MonoBehaviour {

    public GameObject mainpanel, settingspanel, instructionspanel;
    public Button play, instructions, settings, exit;
    private int counter;

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
        SceneManager.LoadSceneAsync("Gameplay");
    }

    private void InstructionsOnClick()
    {
        mainpanel.SetActive(false);
        instructionspanel.SetActive(true);
    }

    private void SettingsOnClick()
    {
        mainpanel.SetActive(false);
        settingspanel.SetActive(true);
    }

    private void ExitOnClick()
    {
        Application.Quit();
    }

    public void back()
    {
        mainpanel.SetActive(true);
        settingspanel.SetActive(false);
        instructionspanel.SetActive(false);
    }
}
