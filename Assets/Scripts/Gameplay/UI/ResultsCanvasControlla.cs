using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultsCanvasControlla : MonoBehaviour {

    public Button relaunch, shop, exit, deletesave;
    public Text enemieshit, cashthisround, totalcashamount, distancetravelled, newrecordtext;
    public LevelManager levelmanager;
    public GameObject deletepanel;
    public SoundSystem ss;

    // Use this for initialization
    void Start () {
        relaunch.onClick.AddListener(RelaunchOnClick);
        shop.onClick.AddListener(ShopOnClick);
        exit.onClick.AddListener(ExitOnClick);
        deletesave.onClick.AddListener(DeleteSaveOnClick);
        levelmanager = GameObject.Find("LevelManager").GetComponent<LevelManager>();

        deletepanel.SetActive(false);

        ss = GameObject.Find("SoundSystem").GetComponent<SoundSystem>().getInstance();
    }
	
	private void RelaunchOnClick()
    {
        ss.playSound("menubutton");
        levelmanager.relaunch();
    }

    private void ShopOnClick()
    {
        ss.playSound("menubutton");
        ss.playMusic("Shop");
        SceneManager.LoadSceneAsync("Shop");
    }

    private void ExitOnClick()
    {
        ss.playSound("menubutton");
        ss.playMusic("MainMenu");
        SceneManager.LoadSceneAsync("MainMenu");
    }

    private void DeleteSaveOnClick()
    {
        ss.playSound("menubutton");
        deletepanel.SetActive(true);
    }

    public void noDelete()
    {
        ss.playSound("menubutton");
        deletepanel.SetActive(false);
    }

    public void displayStats(int enemies, int thisround, int total, float distance, bool newrecord)
    {
        if (newrecord)
        {
            newrecordtext.text = "New record!";
        }

        distancetravelled.text = "Distance travelled: " + distance.ToString() + "m";
        enemieshit.text = "Enemies hit: " + enemies.ToString();
        cashthisround.text = "Cash this round: £" + thisround.ToString();
        totalcashamount.text = "£" + total.ToString();
    }
}
