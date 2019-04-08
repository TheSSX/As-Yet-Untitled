using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder : MonoBehaviour {

    private LevelManager.GameData data;
    public SaveLoad saveload;
    public ShopScript shop;

    // Use this for initialization
    void Start () {
        saveload = GameObject.Find("SaveLoadSystem").GetComponent<SaveLoad>();
        data = saveload.load();
        shop = GameObject.Find("ShopCanvas").GetComponent<ShopScript>();
        shop.setValues(data);
    }

    public LevelManager.GameData fetchData()
    {
        return data;
    }

    public void setData(LevelManager.GameData x)
    {
        data = x;
        saveGame();
        shop.setValues(data);
    }

    public void saveGame()
    {
        saveload.save(data);
    }
}
