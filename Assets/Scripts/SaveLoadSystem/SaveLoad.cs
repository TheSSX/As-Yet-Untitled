using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Directly handles the saving and loading of data through PlayerPrefs
public class SaveLoad : MonoBehaviour {

    void Start()
    {
        //ZPlayerPrefs.Initialize("IamZETOwow!987", "IvmD123A12");
    }

    //Saves the game data
    public void save(LevelManager.GameData data)
    {
        PlayerPrefs.SetInt("Cash", data.cash);        
        PlayerPrefs.SetString("CurrentSkin", data.currentSkin);
        PlayerPrefs.SetInt("SkinUnlocked", data.skinUnlocked);
        PlayerPrefs.SetString("BarrelSkin", data.barrelskin);
        PlayerPrefs.SetInt("BarrelUnlocked", data.barrelUnlocked);
        PlayerPrefs.SetString("GunName", data.gunname);
        PlayerPrefs.SetInt("GunsUnlocked", data.gunsUnlocked);
        PlayerPrefs.SetFloat("FurthestDistance", data.furthestDistance);

        //PlayerPrefs.Save();
        //Debug.Log("Saved data with cash at £" + data.cash + ", skin at " + data.currentSkin + ", skins unlocked at " + data.skinUnlocked + ", barrel skin as " + data.barrelskin + ", barrels unlocked at " + data.barrelUnlocked + ", gun as " + data.gunname + ", guns unlocked at " + data.gunsUnlocked + " and furthest distance at " + data.furthestDistance);
    }

    //Loads previously-saved data
    public LevelManager.GameData load()
    {
        int cash = PlayerPrefs.GetInt("Cash", 0);
        string skin = PlayerPrefs.GetString("CurrentSkin", "bearskin");    
        int skinUnlocked = PlayerPrefs.GetInt("SkinUnlocked", 1);        
        string barrelskin = PlayerPrefs.GetString("BarrelSkin", "basic");
        int barrelUnlocked = PlayerPrefs.GetInt("BarrelUnlocked", 1);
        string gunname = PlayerPrefs.GetString("GunName", "Pistol");
        int gunsUnlocked = PlayerPrefs.GetInt("GunsUnlocked", 1);
        float furthestDistance = PlayerPrefs.GetFloat("FurthestDistance", 0);

        LevelManager.GameData data = new LevelManager.GameData(cash, skin, skinUnlocked, barrelskin, barrelUnlocked, gunname, gunsUnlocked, furthestDistance);
        return data;
    }

    //Deletes any existing save data
    public void deleteSave()
    {
        PlayerPrefs.DeleteAll();
    }
}
