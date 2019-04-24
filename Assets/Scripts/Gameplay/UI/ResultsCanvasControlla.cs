using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultsCanvasControlla : MonoBehaviour {

    public Button relaunch, shop, exit, deletesave;
    public Text enemieshit, cashthisround, totalcashamount;
    public LevelManager levelmanager;
    public GameObject deletepanel;

    // Use this for initialization
    void Start () {
        relaunch.onClick.AddListener(RelaunchOnClick);
        shop.onClick.AddListener(ShopOnClick);
        exit.onClick.AddListener(ExitOnClick);
        deletesave.onClick.AddListener(DeleteSaveOnClick);
        levelmanager = GameObject.Find("LevelManager").GetComponent<LevelManager>();

        deletepanel.SetActive(false);
    }
	
	private void RelaunchOnClick()
    {
        levelmanager.relaunch();
    }

    private void ShopOnClick()
    {
        SceneManager.LoadSceneAsync("Shop");
    }

    private void ExitOnClick()
    {
        Application.Quit();
    }

    private void DeleteSaveOnClick()
    {
        deletepanel.SetActive(true);
    }

    public void noDelete()
    {
        deletepanel.SetActive(false);
    }

    public void displayStats(int enemies, int thisround, int total)
    {
        enemieshit.text = "Enemies hit: " + enemies.ToString();
        cashthisround.text = "Cash this round: £" + thisround.ToString();
        totalcashamount.text = "£" + total.ToString();
    }
}
