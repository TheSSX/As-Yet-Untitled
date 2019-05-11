using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinsMenu : MonoBehaviour {

    public Button bearskin, athlete, racecardriver, ninja, boxer, mrpresident, back, current;
    public Image athleteimage, racecardriverimage, ninjaimage, boxerimage, mrpresidentimage;
    public Text athletelocked, racecardriverlocked, ninjalocked, boxerlocked, mrpresidentlocked, athleteprice, racecardriverprice, ninjaprice, boxerprice, mrpresidentprice;

    public GameObject mainmenu;
    public DataHolder dataholder;

    public LevelManager.GameData data;       

    public ShopMenu.Purchase[] purchases;
    public SoundSystem ss;

    // Use this for initialization
    void Start () {

        dataholder = GameObject.Find("DataHolder").GetComponent<DataHolder>();
        athleteimage = GameObject.Find("AthleteImage").GetComponent<Image>();
        racecardriverimage = GameObject.Find("RacecarDriverImage").GetComponent<Image>();
        ninjaimage = GameObject.Find("NinjaImage").GetComponent<Image>();
        boxerimage = GameObject.Find("BoxerImage").GetComponent<Image>();
        mrpresidentimage = GameObject.Find("MrPresidentImage").GetComponent<Image>();
        athletelocked = GameObject.Find("AthleteLocked").GetComponent<Text>();
        racecardriverlocked = GameObject.Find("RacecarDriverLocked").GetComponent<Text>();
        ninjalocked = GameObject.Find("NinjaLocked").GetComponent<Text>();
        boxerlocked = GameObject.Find("BoxerLocked").GetComponent<Text>();
        mrpresidentlocked = GameObject.Find("MrPresidentLocked").GetComponent<Text>();
        athleteprice = GameObject.Find("AthletePrice").GetComponent<Text>();
        racecardriverprice = GameObject.Find("RacecarDriverPrice").GetComponent<Text>();
        ninjaprice = GameObject.Find("NinjaPrice").GetComponent<Text>();
        boxerprice = GameObject.Find("BoxerPrice").GetComponent<Text>();
        mrpresidentprice = GameObject.Find("MrPresidentPrice").GetComponent<Text>();

        bearskin.onClick.AddListener(BearskinOnClick);
        athlete.onClick.AddListener(AthleteOnClick);
        racecardriver.onClick.AddListener(RacecarDriverOnClick);
        ninja.onClick.AddListener(NinjaOnClick);
        boxer.onClick.AddListener(BoxerOnClick);
        mrpresident.onClick.AddListener(MrPresidentOnClick);
        back.onClick.AddListener(BackOnClick);

        GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        ss = GameObject.Find("SoundSystem").GetComponent<SoundSystem>().getInstance();
    }

    public void setValues(LevelManager.GameData x)
    {
        data = x;

        if (data.skinUnlocked > 1)
        {
            purchases = new ShopMenu.Purchase[data.skinUnlocked - 1];
            
            purchases[0] = new ShopMenu.Purchase(athleteimage, athletelocked, athleteprice);

            if (data.skinUnlocked > 2)
            {
                purchases[1] = new ShopMenu.Purchase(racecardriverimage, racecardriverlocked, racecardriverprice);
            }

            if (data.skinUnlocked > 3)
            {
                purchases[2] = new ShopMenu.Purchase(ninjaimage, ninjalocked, ninjaprice);
            }

            if (data.skinUnlocked > 4)
            {
                purchases[3] = new ShopMenu.Purchase(boxerimage, boxerlocked, boxerprice);
            }

            if (data.skinUnlocked > 5)
            {
                purchases[4] = new ShopMenu.Purchase(mrpresidentimage, mrpresidentlocked, mrpresidentprice);
            }

            for (int i = data.skinUnlocked - 2; i >= 0; i--)
            {
                purchases[i].unlock();
            }
        }

        if (data.currentSkin == "bearskin")
        {
            current = bearskin;
        }
        else if (data.currentSkin == "athlete")
        {
            current = athlete;
        }
        else if (data.currentSkin == "racecar driver")
        {
            current = racecardriver;
        }
        else if (data.currentSkin == "ninja")
        {
            current = ninja;
        }
        else if (data.currentSkin == "boxer")
        {
            current = boxer;
        }
        else if (data.currentSkin == "mr president")
        {
            current = mrpresident;
        }

        current.GetComponent<Image>().color = Color.cyan;
    }

    private void replaceCurrentButton(Button x)
    {
        current.GetComponent<Image>().color = Color.white;
        current = x;
        current.GetComponent<Image>().color = Color.cyan;
    }

    private void BearskinOnClick()
    {
        ss.playSound("menubutton");
        data = new LevelManager.GameData(data.cash, "bearskin", data.skinUnlocked, data.barrelskin, data.barrelUnlocked, data.gunname, data.gunsUnlocked, data.furthestDistance);
        replaceCurrentButton(bearskin);
        dataholder.setData(data);
    }

    private void AthleteOnClick()
    {
		if (data.cash >= 50000 && data.skinUnlocked < 2)
        {
            data = new LevelManager.GameData(data.cash - 50000, "athlete", 2, data.barrelskin, data.barrelUnlocked, data.gunname, data.gunsUnlocked, data.furthestDistance);
            replaceCurrentButton(athlete);
            dataholder.setData(data);
            purchases[0].unlock();
        }
        else if (data.skinUnlocked >= 2)
        {
            ss.playSound("menubutton");
            data = new LevelManager.GameData(data.cash, "athlete", data.skinUnlocked, data.barrelskin, data.barrelUnlocked, data.gunname, data.gunsUnlocked, data.furthestDistance);
            replaceCurrentButton(athlete);
            dataholder.setData(data);
        }
    }

    private void RacecarDriverOnClick()
    {
        if (data.cash >= 1000000 && data.skinUnlocked < 3)
        {
            data = new LevelManager.GameData(data.cash - 1000000, "racecar driver", 3, data.barrelskin, data.barrelUnlocked, data.gunname, data.gunsUnlocked, data.furthestDistance);
            replaceCurrentButton(racecardriver);
            dataholder.setData(data);
            purchases[1].unlock();
        }
        else if (data.skinUnlocked >= 3)
        {
            ss.playSound("menubutton");
            data = new LevelManager.GameData(data.cash, "racecar driver", data.skinUnlocked, data.barrelskin, data.barrelUnlocked, data.gunname, data.gunsUnlocked, data.furthestDistance);
            replaceCurrentButton(racecardriver);
            dataholder.setData(data);
        }
    }

    private void NinjaOnClick()
    {
        if (data.cash >= 25000000 && data.skinUnlocked < 4)
        {
            data = new LevelManager.GameData(data.cash - 25000000, "ninja", 4, data.barrelskin, data.barrelUnlocked, data.gunname, data.gunsUnlocked, data.furthestDistance);
            replaceCurrentButton(ninja);
            dataholder.setData(data);
            purchases[2].unlock();
        }
        else if (data.skinUnlocked >= 4)
        {
            ss.playSound("menubutton");
            data = new LevelManager.GameData(data.cash, "ninja", data.skinUnlocked, data.barrelskin, data.barrelUnlocked, data.gunname, data.gunsUnlocked, data.furthestDistance);
            replaceCurrentButton(ninja);
            dataholder.setData(data);
        }
    }

    private void BoxerOnClick()
    {
        if (data.cash >= 300000000 && data.skinUnlocked < 5)
        {
            data = new LevelManager.GameData(data.cash - 300000000, "boxer", 5, data.barrelskin, data.barrelUnlocked, data.gunname, data.gunsUnlocked, data.furthestDistance);
            replaceCurrentButton(boxer);
            dataholder.setData(data);
            purchases[3].unlock();
        }
        else if (data.skinUnlocked >= 5)
        {
            ss.playSound("menubutton");
            data = new LevelManager.GameData(data.cash, "boxer", data.skinUnlocked, data.barrelskin, data.barrelUnlocked, data.gunname, data.gunsUnlocked, data.furthestDistance);
            replaceCurrentButton(boxer);
            dataholder.setData(data);
        }
    }

    private void MrPresidentOnClick()
    {
        if (data.cash >= 1500000000 && data.skinUnlocked < 6)
        {
            data = new LevelManager.GameData(data.cash - 1500000000, "mr president", 6, data.barrelskin, data.barrelUnlocked, data.gunname, data.gunsUnlocked, data.furthestDistance);
            replaceCurrentButton(mrpresident);
            dataholder.setData(data);
            purchases[4].unlock();
        }
        else if (data.skinUnlocked >= 6)
        {
            ss.playSound("menubutton");
            data = new LevelManager.GameData(data.cash, "mr president", data.skinUnlocked, data.barrelskin, data.barrelUnlocked, data.gunname, data.gunsUnlocked, data.furthestDistance);
            replaceCurrentButton(mrpresident);
            dataholder.setData(data);
        }
    }

    private void BackOnClick()
    {
        ss.playSound("menubutton");
        gameObject.SetActive(false);
        mainmenu.SetActive(true);
    }
}
