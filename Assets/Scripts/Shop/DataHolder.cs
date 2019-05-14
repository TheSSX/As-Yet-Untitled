using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Holds the game data for all shop scripts to access universally
public class DataHolder : MonoBehaviour {

    [SerializeField]
    private GameObject skins, launchers, guns;
    private SkinsMenu skinsmenu;
    private LaunchersMenu launchersmenu;
    private GunsMenu gunsmenu;
    private LevelManager.GameData data;
    private SaveLoad saveload;
    private ShopScript shop;

    // Use this for initialization
    void Start () {
        saveload = GameObject.Find("SaveLoadSystem").GetComponent<SaveLoad>();
        skinsmenu = skins.GetComponent<SkinsMenu>();
        launchersmenu = launchers.GetComponent<LaunchersMenu>();
        gunsmenu = guns.GetComponent<GunsMenu>();
        shop = GameObject.Find("ShopCanvas").GetComponent<ShopScript>();

        data = saveload.load();
        skinsmenu.setValues(data);
        launchersmenu.setValues(data);
        gunsmenu.setValues(data);
        shop.setCash(data);
    }

    //Fetches the save data
    public LevelManager.GameData fetchData()
    {
        return data;
    }

    //Overwrites save data upon purchase or amendment of loadout
    public void setData(LevelManager.GameData x)
    {
        data = x;
        saveGame();
        skinsmenu.setValues(data);
        launchersmenu.setValues(data);
        gunsmenu.setValues(data);
        shop.setCash(data);
    }

    //Saves the data
    public void saveGame()
    {
        saveload.save(data);
    }
}
