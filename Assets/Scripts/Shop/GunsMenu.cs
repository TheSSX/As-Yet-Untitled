using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunsMenu : MonoBehaviour
{
    public Button pistol, shotgun, back;
    public Image shotgunimage;
    public Text shotgunlocked, shotgunprice;

    public GameObject mainmenu;
    public DataHolder dataholder;

    public LevelManager.GameData data;       

    public ShopMenu.Purchase[] purchases;

    // Use this for initialization
    void Start()
    {
        dataholder = GameObject.Find("DataHolder").GetComponent<DataHolder>();
        //shotgunimage = GameObject.Find("ShotgunImage").GetComponent<Image>();
        //shotgunlocked = GameObject.Find("ShotgunLocked").GetComponent<Text>();
        //shotgunprice = GameObject.Find("ShotgunPrice").GetComponent<Text>();

        pistol.onClick.AddListener(PistolOnClick);
        shotgun.onClick.AddListener(ShotgunOnClick);
        back.onClick.AddListener(BackOnClick);

        GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
    }

    public void setValues(LevelManager.GameData x)
    {
        data = x;

        if (data.gunsUnlocked > 1)
        {
            purchases = new ShopMenu.Purchase[data.gunsUnlocked - 1];
            purchases[0] = new ShopMenu.Purchase(shotgunimage, shotgunlocked, shotgunprice);

            for (int i = data.gunsUnlocked - 2; i >= 0; i--)
            {
                purchases[i].unlock();
            }
        }
    }

    private void PistolOnClick()
    {
        data = new LevelManager.GameData(data.cash, data.currentSkin, data.skinUnlocked, data.barrelskin, data.barrelUnlocked, "Pistol", data.gunsUnlocked);
        dataholder.setData(data);
    }

    private void ShotgunOnClick()
    {
        if (data.cash >= 50000 && data.gunsUnlocked < 2)
        {
            data = new LevelManager.GameData(data.cash - 50000, data.currentSkin, data.skinUnlocked, data.barrelskin, data.barrelUnlocked, "Shotgun", 2);
            dataholder.setData(data);
            purchases[0].unlock();
        }
        else if (data.gunsUnlocked >= 2)
        {
            data = new LevelManager.GameData(data.cash, data.currentSkin, data.skinUnlocked, data.barrelskin, data.barrelUnlocked, "Shotgun", data.gunsUnlocked);
            dataholder.setData(data);
        }
    }

    private void BackOnClick()
    {
        gameObject.SetActive(false);
        mainmenu.SetActive(true);
    }
}
