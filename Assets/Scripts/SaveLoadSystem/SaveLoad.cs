using System.Collections;
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

        ZPlayerPrefs.Save();
        Debug.Log("Saved data with cash at £" + data.cash + ", skin at " + data.currentSkin + " and skins unlocked at " + data.skinUnlocked);
    }

    public LevelManager.GameData load()
    {
        int cash = ZPlayerPrefs.GetInt("Cash", 0);
        /*if (cash == -1)
        {
            data = new LevelManager.GameData(-1, "bearskin", 1);
            return data;
        }*/

        string skin = ZPlayerPrefs.GetString("CurrentSkin", "bearskin");
        /*if (skin == null)
        {
            data = new LevelManager.GameData(-1, "bearskin", 1);
            return data;
        }*/

        int skinUnlocked = ZPlayerPrefs.GetInt("SkinUnlocked", 1);

        data = new LevelManager.GameData(cash, skin, skinUnlocked);
        return data;
    }

    public void deleteSave()
    {
        ZPlayerPrefs.DeleteAll();
    }
}
