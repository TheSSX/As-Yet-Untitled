using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Controls the results screen that shows post-launch
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

        ss = SoundSystem.getInstance();
    }
	
    //Launches the player again
	private void RelaunchOnClick()
    {
        ss.playSound("menubutton");
        levelmanager.relaunch();
    }

    //Takes the player to the shop
    private void ShopOnClick()
    {
        ss.playSound("menubutton");
        ss.playMusic("Shop");
        SceneManager.LoadSceneAsync("Shop");
    }

    //Exits to main menu
    private void ExitOnClick()
    {
        ss.playSound("menubutton");
        ss.playMusic("MainMenu");
        SceneManager.LoadSceneAsync("MainMenu");
    }

    //Shows the confirmation to delete save panel
    private void DeleteSaveOnClick()
    {
        ss.playSound("menubutton");
        deletepanel.SetActive(true);
    }

    //Hides the confirmation to delete save panel if the user pressed no
    public void noDelete()
    {
        ss.playSound("menubutton");
        deletepanel.SetActive(false);
    }

    //Receives the stats of the round and displays them
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
