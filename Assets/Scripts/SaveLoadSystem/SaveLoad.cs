using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{

    private LevelManager.GameData data;

    public void Start()
    {
        ZPlayerPrefs.Initialize("$@M1amMYn@m£15S&m", "@5a1tYSALt5927");
    }

    public void save(LevelManager.GameData data)
    {
        ZPlayerPrefs.Initialize("$@M1amMYn@m£15S&m", "@5a1tYSALt5927");
        ZPlayerPrefs.SetInt("Cash", data.cash);
        ZPlayerPrefs.SetString("CurrentSkin", data.currentSkin);
        ZPlayerPrefs.SetInt("SkinUnlocked", data.skinUnlocked);
        ZPlayerPrefs.SetString("BarrelSkin", data.barrelskin);
        ZPlayerPrefs.SetInt("BarrelUnlocked", data.barrelUnlocked);
        ZPlayerPrefs.SetString("GunName", data.gunname);
        ZPlayerPrefs.SetInt("GunsUnlocked", data.gunsUnlocked);
        ZPlayerPrefs.SetFloat("FurthestDistance", data.furthestDistance);

        ZPlayerPrefs.Save();
        //Debug.Log("Saved data with cash at £" + data.cash + ", skin at " + data.currentSkin + ", skins unlocked at " + data.skinUnlocked + ", barrel skin as " + data.barrelskin + ", barrels unlocked at " + data.barrelUnlocked + ", gun as " + data.gunname + ", guns unlocked at " + data.gunsUnlocked + " and furthest distance at " + data.furthestDistance);
    }

    public LevelManager.GameData load()
    {
        ZPlayerPrefs.Initialize("$@M1amMYn@m£15S&m", "@5a1tYSALt5927");
        int cash = ZPlayerPrefs.GetInt("Cash", 0);
        string skin = ZPlayerPrefs.GetString("CurrentSkin", "bearskin");
        int skinUnlocked = ZPlayerPrefs.GetInt("SkinUnlocked", 1);
        string barrelskin = ZPlayerPrefs.GetString("BarrelSkin", "basic");
        int barrelUnlocked = ZPlayerPrefs.GetInt("BarrelUnlocked", 1);
        string gunname = ZPlayerPrefs.GetString("GunName", "Pistol");
        int gunsUnlocked = ZPlayerPrefs.GetInt("GunsUnlocked", 1);
        float furthestDistance = ZPlayerPrefs.GetFloat("FurthestDistance", 0);

        data = new LevelManager.GameData(cash, skin, skinUnlocked, barrelskin, barrelUnlocked, gunname, gunsUnlocked, furthestDistance);
        return data;
    }

    public void deleteSave()
    {
        ZPlayerPrefs.DeleteAll();
    }
}
