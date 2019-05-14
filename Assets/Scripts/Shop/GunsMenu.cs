using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Controls the purchasing and switching of guns
public class GunsMenu : MonoBehaviour
{
    [SerializeField]
    private Button pistol, shotgun, rifle, sniperrifle, rocketlauncher, goldendeagle, back, current;
    [SerializeField]
    private Image shotgunimage, rifleimage, sniperrifleimage, rocketlauncherimage, goldendeagleimage;
    [SerializeField]
    private Text shotgunlocked, shotgunprice, riflelocked, rifleprice, sniperriflelocked, sniperrifleprice, rocketlauncherlocked, rocketlauncherprice, goldendeaglelocked, goldendeagleprice;

    [SerializeField]
    private GameObject mainmenu;
    private DataHolder dataholder;
    private LevelManager.GameData data;       
    private ShopMenu.Purchase[] purchases;
    private SoundSystem ss;

    // Use this for initialization
    void Start()
    {
        dataholder = GameObject.Find("DataHolder").GetComponent<DataHolder>();
        shotgunimage = GameObject.Find("ShotgunImage").GetComponent<Image>();
        rifleimage = GameObject.Find("RifleImage").GetComponent<Image>();
        sniperrifleimage = GameObject.Find("SniperRifleImage").GetComponent<Image>();
        rocketlauncherimage = GameObject.Find("RocketLauncherImage").GetComponent<Image>();
        goldendeagleimage = GameObject.Find("GoldenDeagleImage").GetComponent<Image>();
        shotgunlocked = GameObject.Find("ShotgunLocked").GetComponent<Text>();
        riflelocked = GameObject.Find("RifleLocked").GetComponent<Text>();
        sniperriflelocked = GameObject.Find("SniperRifleLocked").GetComponent<Text>();
        rocketlauncherlocked = GameObject.Find("RocketLauncherLocked").GetComponent<Text>();
        goldendeaglelocked = GameObject.Find("GoldenDeagleLocked").GetComponent<Text>();
        shotgunprice = GameObject.Find("ShotgunPrice").GetComponent<Text>();
        rifleprice = GameObject.Find("RiflePrice").GetComponent<Text>();
        sniperrifleprice = GameObject.Find("SniperRiflePrice").GetComponent<Text>();
        rocketlauncherprice = GameObject.Find("RocketLauncherPrice").GetComponent<Text>();
        goldendeagleprice = GameObject.Find("GoldenDeaglePrice").GetComponent<Text>();

        pistol.onClick.AddListener(PistolOnClick);
        shotgun.onClick.AddListener(ShotgunOnClick);
        rifle.onClick.AddListener(RifleOnClick);
        sniperrifle.onClick.AddListener(SniperRifleOnClick);
        rocketlauncher.onClick.AddListener(RocketLauncherOnClick);
        goldendeagle.onClick.AddListener(GoldenDeagleOnClick);
        back.onClick.AddListener(BackOnClick);

        GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        ss = SoundSystem.getInstance();
    }

    //Locks and unlocks the purchases based on the user's save data
    public void setValues(LevelManager.GameData x)
    {
        data = x;

        if (data.gunsUnlocked > 1)
        {
            purchases = new ShopMenu.Purchase[data.gunsUnlocked - 1];

            purchases[0] = new ShopMenu.Purchase(shotgunimage, shotgunlocked, shotgunprice);

            if (data.gunsUnlocked > 2)
            {
                purchases[1] = new ShopMenu.Purchase(rifleimage, riflelocked, rifleprice);
            }

            if (data.gunsUnlocked > 3)
            {
                purchases[2] = new ShopMenu.Purchase(sniperrifleimage, sniperriflelocked, sniperrifleprice);
            }

            if (data.gunsUnlocked > 4)
            {
                purchases[3] = new ShopMenu.Purchase(rocketlauncherimage, rocketlauncherlocked, rocketlauncherprice);
            }

            if (data.gunsUnlocked > 5)
            {
                purchases[4] = new ShopMenu.Purchase(goldendeagleimage, goldendeaglelocked, goldendeagleprice);
            }

            for (int i = data.gunsUnlocked - 2; i >= 0; i--)
            {
                purchases[i].unlock();      //unlocks all items before the highest unlock
            }
        }      

        if (data.gunname == "Pistol")
        {
            current = pistol;
        }
        else if (data.gunname == "Shotgun")
        {
            current = shotgun;
        }
        else if (data.gunname == "Rifle")
        {
            current = rifle;
        }
        else if (data.gunname == "Sniper Rifle")
        {
            current = sniperrifle;
        }
        else if (data.gunname == "Rocket Launcher")
        {
            current = rocketlauncher;
        }
        else if (data.gunname == "Golden Deagle")
        {
            current = goldendeagle;
        }

        current.GetComponent<Image>().color = Color.cyan;
    }

    //Current indicates the user's current selection and highlights this in the menu by making it blue
    private void replaceCurrentButton(Button x)
    {
        current.GetComponent<Image>().color = Color.white;
        current = x;
        current.GetComponent<Image>().color = Color.cyan;
    }

    //If the pistol is selected
    private void PistolOnClick()
    {
        ss.playSound("menubutton");
        data = new LevelManager.GameData(data.cash, data.currentSkin, data.skinUnlocked, data.barrelskin, data.barrelUnlocked, "Pistol", data.gunsUnlocked, data.furthestDistance);
        replaceCurrentButton(pistol);
        dataholder.setData(data);
    }

    //If the shotgun is selected
    private void ShotgunOnClick()
    {
        if (data.cash >= 50000 && data.gunsUnlocked < 2)
        {
            data = new LevelManager.GameData(data.cash - 50000, data.currentSkin, data.skinUnlocked, data.barrelskin, data.barrelUnlocked, "Shotgun", 2, data.furthestDistance);
            replaceCurrentButton(shotgun);
            dataholder.setData(data);
            purchases[0].unlock();
        }
        else if (data.gunsUnlocked >= 2)
        {
            ss.playSound("menubutton");
            data = new LevelManager.GameData(data.cash, data.currentSkin, data.skinUnlocked, data.barrelskin, data.barrelUnlocked, "Shotgun", data.gunsUnlocked, data.furthestDistance);
            replaceCurrentButton(shotgun);
            dataholder.setData(data);
        }
    }

    //If the rifle is selected
    private void RifleOnClick()
    {
        if (data.cash >= 1000000 && data.gunsUnlocked < 3)
        {
            data = new LevelManager.GameData(data.cash - 1000000, data.currentSkin, data.skinUnlocked, data.barrelskin, data.barrelUnlocked, "Rifle", 3, data.furthestDistance);
            replaceCurrentButton(rifle);
            dataholder.setData(data);
            purchases[1].unlock();
        }
        else if (data.gunsUnlocked >= 3)
        {
            ss.playSound("menubutton");
            data = new LevelManager.GameData(data.cash, data.currentSkin, data.skinUnlocked, data.barrelskin, data.barrelUnlocked, "Rifle", data.gunsUnlocked, data.furthestDistance);
            replaceCurrentButton(rifle);
            dataholder.setData(data);
        }
    }

    //If the sniper rifle is selected
    private void SniperRifleOnClick()
    {
        if (data.cash >= 25000000 && data.gunsUnlocked < 4)
        {
            data = new LevelManager.GameData(data.cash - 25000000, data.currentSkin, data.skinUnlocked, data.barrelskin, data.barrelUnlocked, "Sniper Rifle", 4, data.furthestDistance);
            replaceCurrentButton(sniperrifle);
            dataholder.setData(data);
            purchases[2].unlock();
        }
        else if (data.gunsUnlocked >= 4)
        {
            ss.playSound("menubutton");
            data = new LevelManager.GameData(data.cash, data.currentSkin, data.skinUnlocked, data.barrelskin, data.barrelUnlocked, "Sniper Rifle", data.gunsUnlocked, data.furthestDistance);
            replaceCurrentButton(sniperrifle);
            dataholder.setData(data);
        }
    }

    //If the rocket launcher is selected
    private void RocketLauncherOnClick()
    {
        if (data.cash >= 300000000 && data.gunsUnlocked < 5)
        {
            data = new LevelManager.GameData(data.cash - 300000000, data.currentSkin, data.skinUnlocked, data.barrelskin, data.barrelUnlocked, "Rocket Launcher", 5, data.furthestDistance);
            replaceCurrentButton(rocketlauncher);
            dataholder.setData(data);
            purchases[3].unlock();
        }
        else if (data.gunsUnlocked >= 5)
        {
            ss.playSound("menubutton");
            data = new LevelManager.GameData(data.cash, data.currentSkin, data.skinUnlocked, data.barrelskin, data.barrelUnlocked, "Rocket Launcher", data.gunsUnlocked, data.furthestDistance);
            replaceCurrentButton(rocketlauncher);
            dataholder.setData(data);
        }
    }

    //If the golden deagle is selected
    private void GoldenDeagleOnClick()
    {
        if (data.cash >= 1500000000 && data.gunsUnlocked < 6)
        {
            data = new LevelManager.GameData(data.cash - 1500000000, data.currentSkin, data.skinUnlocked, data.barrelskin, data.barrelUnlocked, "Golden Deagle", 6, data.furthestDistance);
            replaceCurrentButton(goldendeagle);
            dataholder.setData(data);
            purchases[4].unlock();
        }
        else if (data.gunsUnlocked >= 6)
        {
            ss.playSound("menubutton");
            data = new LevelManager.GameData(data.cash, data.currentSkin, data.skinUnlocked, data.barrelskin, data.barrelUnlocked, "Golden Deagle", data.gunsUnlocked, data.furthestDistance);
            replaceCurrentButton(goldendeagle);
            dataholder.setData(data);
        }
    }

    //Returns to the main shop menu
    private void BackOnClick()
    {
        ss.playSound("menubutton");
        gameObject.SetActive(false);
        mainmenu.SetActive(true);
    }
}
