﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour {

    private LevelManager.GameData data;

    public void Start()
    {
        ZPlayerPrefs.Initialize("IamZETOwow!987", "IvmD123A12");
    }

    public void save(LevelManager.GameData data)
    {
        ZPlayerPrefs.SetInt("Cash", data.cash);
        ZPlayerPrefs.SetString("CurrentSkin", data.currentSkin);
        ZPlayerPrefs.SetInt("SkinUnlocked", data.skinUnlocked);
        ZPlayerPrefs.SetString("BarrelSkin", data.barrelskin);
        ZPlayerPrefs.SetInt("BarrelUnlocked", data.barrelUnlocked);
        ZPlayerPrefs.SetString("GunName", data.gunname);
        ZPlayerPrefs.SetInt("GunsUnlocked", data.gunsUnlocked);

        ZPlayerPrefs.Save();
        Debug.Log("Saved data with cash at £" + data.cash + ", skin at " + data.currentSkin + ", skins unlocked at " + data.skinUnlocked + ", barrel skin as " + data.barrelskin + ", barrels unlocked at " + data.barrelUnlocked + ", gun as " + data.gunname + " and guns unlocked at " + data.gunsUnlocked);
    }

    public LevelManager.GameData load()
    {
        int cash = ZPlayerPrefs.GetInt("Cash", 0);
        string skin = ZPlayerPrefs.GetString("CurrentSkin", "bearskin");    
        int skinUnlocked = ZPlayerPrefs.GetInt("SkinUnlocked", 1);        
        string barrelskin = ZPlayerPrefs.GetString("BarrelSkin", "basic");
        int barrelUnlocked = ZPlayerPrefs.GetInt("BarrelUnlocked", 1);
        string gunname = ZPlayerPrefs.GetString("GunName", "Pistol");
        int gunsUnlocked = ZPlayerPrefs.GetInt("GunsUnlocked", 1);

        data = new LevelManager.GameData(cash, skin, skinUnlocked, barrelskin, barrelUnlocked, gunname, gunsUnlocked);
        return data;
    }

    public void deleteSave()
    {
        ZPlayerPrefs.DeleteAll();
    }
}
