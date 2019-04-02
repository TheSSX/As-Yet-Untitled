﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultsCanvasControlla : MonoBehaviour {

    public Button relaunch, shop, exit;
    public LevelManager levelmanager;

    // Use this for initialization
    void Start () {
        relaunch.onClick.AddListener(RelaunchOnClick);
        shop.onClick.AddListener(ShopOnClick);
        exit.onClick.AddListener(ExitOnClick);
        levelmanager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }
	
	private void RelaunchOnClick()
    {
        levelmanager.relaunch();
    }

    private void ShopOnClick()
    {

    }

    private void ExitOnClick()
    {
        Application.Quit();
    }
}
