using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Controls the purchasing and switching of launchers
public class LaunchersMenu : MonoBehaviour {

    [SerializeField]
    private Button basic, gold, tank, samturret, missilelauncher, diamond, back, current;
    [SerializeField]
    private Image goldimage, tankimage, samturretimage, missilelauncherimage, diamondimage;
    [SerializeField]
    private Text goldlocked, goldprice, tanklocked, tankprice, samturretlocked, samturretprice, missilelauncherlocked, missilelauncherprice, diamondlocked, diamondprice;

    [SerializeField]
    private GameObject mainmenu;
    private DataHolder dataholder;
    private LevelManager.GameData data;	
    private ShopMenu.Purchase[] purchases;
    private SoundSystem ss;

    // Use this for initialization
    void Start () {

	    dataholder = GameObject.Find("DataHolder").GetComponent<DataHolder>();
	    goldimage = GameObject.Find("GoldImage").GetComponent<Image>();
	    tankimage = GameObject.Find("TankImage").GetComponent<Image>();
	    samturretimage = GameObject.Find("SAMTurretImage").GetComponent<Image>();
	    missilelauncherimage = GameObject.Find("MissileLauncherImage").GetComponent<Image>();
	    diamondimage = GameObject.Find("DiamondImage").GetComponent<Image>();
        goldlocked = GameObject.Find("GoldLocked").GetComponent<Text>();
        tanklocked = GameObject.Find("TankLocked").GetComponent<Text>();
        samturretlocked = GameObject.Find("SAMTurretLocked").GetComponent<Text>();
        missilelauncherlocked = GameObject.Find("MissileLauncherLocked").GetComponent<Text>();
        diamondlocked = GameObject.Find("DiamondLocked").GetComponent<Text>();
        goldprice = GameObject.Find("GoldPrice").GetComponent<Text>();
        tankprice = GameObject.Find("TankPrice").GetComponent<Text>();
        samturretprice = GameObject.Find("SAMTurretPrice").GetComponent<Text>();
        missilelauncherprice = GameObject.Find("MissileLauncherPrice").GetComponent<Text>();
        diamondprice = GameObject.Find("DiamondPrice").GetComponent<Text>();

        basic.onClick.AddListener(BasicOnClick);
	    gold.onClick.AddListener(GoldOnClick);
	    tank.onClick.AddListener(TankOnClick);
	    samturret.onClick.AddListener(SAMTurretOnClick);
	    missilelauncher.onClick.AddListener(MissileLauncherOnClick);
	    diamond.onClick.AddListener(DiamondOnClick);
	    back.onClick.AddListener(BackOnClick);

        GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        ss = SoundSystem.getInstance();
    }

    //Locks and unlocks the purchases based on the user's save data
    public void setValues(LevelManager.GameData x)
    {
        data = x;

        if (data.barrelUnlocked > 1)
        {
            purchases = new ShopMenu.Purchase[data.barrelUnlocked - 1];
            purchases[0] = new ShopMenu.Purchase(goldimage, goldlocked, goldprice);

            if (data.barrelUnlocked > 2)
            {
                purchases[1] = new ShopMenu.Purchase(tankimage, tanklocked, tankprice);
            }

            if (data.barrelUnlocked > 3)
            {
                purchases[2] = new ShopMenu.Purchase(samturretimage, samturretlocked, samturretprice);
            }

            if (data.barrelUnlocked > 4)
            {
                purchases[3] = new ShopMenu.Purchase(missilelauncherimage, missilelauncherlocked, missilelauncherprice);
            }

            if (data.barrelUnlocked > 5)
            {
                purchases[4] = new ShopMenu.Purchase(diamondimage, diamondlocked, diamondprice);
            }

            for (int i = data.barrelUnlocked - 2; i >= 0; i--)
            {
                purchases[i].unlock();
            }
        }

        if (data.barrelskin == "basic")
        {
            current = basic;
        }
        else if (data.barrelskin == "gold")
        {
            current = gold;
        }
        else if (data.barrelskin == "tank")
        {
            current = tank;
        }
        else if (data.barrelskin == "SAM turret")
        {
            current = samturret;
        }
        else if (data.barrelskin == "missile launcher")
        {
            current = missilelauncher;
        }
        else if (data.barrelskin == "diamond")
        {
            current = diamond;
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

    //If the basic cannon is selected
    private void BasicOnClick()
	{
        ss.playSound("menubutton");
        data = new LevelManager.GameData (data.cash, data.currentSkin, data.skinUnlocked, "basic", data.barrelUnlocked, data.gunname, data.gunsUnlocked, data.furthestDistance);
        replaceCurrentButton(basic);
        dataholder.setData(data);       
	}

    //If the gold cannon is selected
    private void GoldOnClick()
	{
	    if (data.cash >= 50000 && data.barrelUnlocked < 2)
	    {
	        data = new LevelManager.GameData(data.cash - 50000, data.currentSkin, data.skinUnlocked, "gold", 2, data.gunname, data.gunsUnlocked, data.furthestDistance);
            replaceCurrentButton(gold);
            dataholder.setData(data);
            purchases[0].unlock();
        }
        else if (data.barrelUnlocked >= 2)
        {
            ss.playSound("menubutton");
            data = new LevelManager.GameData(data.cash, data.currentSkin, data.skinUnlocked, "gold", data.barrelUnlocked, data.gunname, data.gunsUnlocked, data.furthestDistance);
            replaceCurrentButton(gold);
            dataholder.setData(data);
        }
    }

    //If the tank is selected
    private void TankOnClick()
    {
        if (data.cash >= 1000000 && data.barrelUnlocked < 3)
        {
            data = new LevelManager.GameData(data.cash - 1000000, data.currentSkin, data.skinUnlocked, "tank", 3, data.gunname, data.gunsUnlocked, data.furthestDistance);
            replaceCurrentButton(tank);
            dataholder.setData(data);
            purchases[1].unlock();
        }
        else if (data.barrelUnlocked >= 3)
        {
            ss.playSound("menubutton");
            data = new LevelManager.GameData(data.cash, data.currentSkin, data.skinUnlocked, "tank", data.barrelUnlocked, data.gunname, data.gunsUnlocked, data.furthestDistance);
            replaceCurrentButton(tank);
            dataholder.setData(data);
        }
    }

    //If the SAM turret is selected
    private void SAMTurretOnClick()
    {
        if (data.cash >= 25000000 && data.barrelUnlocked < 4)
        {
            data = new LevelManager.GameData(data.cash - 25000000, data.currentSkin, data.skinUnlocked, "SAM turret", 4, data.gunname, data.gunsUnlocked, data.furthestDistance);
            replaceCurrentButton(samturret);
            dataholder.setData(data);
            purchases[2].unlock();
        }
        else if (data.barrelUnlocked >= 4)
        {
            ss.playSound("menubutton");
            data = new LevelManager.GameData(data.cash, data.currentSkin, data.skinUnlocked, "SAM turret", data.barrelUnlocked, data.gunname, data.gunsUnlocked, data.furthestDistance);
            replaceCurrentButton(samturret);
            dataholder.setData(data);
        }
    }

    //If the missile launcher is selected
    private void MissileLauncherOnClick()
    {
        if (data.cash >= 300000000 && data.barrelUnlocked < 5)
        {
            data = new LevelManager.GameData(data.cash - 300000000, data.currentSkin, data.skinUnlocked, "missile launcher", 5, data.gunname, data.gunsUnlocked, data.furthestDistance);
            replaceCurrentButton(missilelauncher);
            dataholder.setData(data);
            purchases[3].unlock();
        }
        else if (data.barrelUnlocked >= 5)
        {
            ss.playSound("menubutton");
            data = new LevelManager.GameData(data.cash, data.currentSkin, data.skinUnlocked, "missile launcher", data.barrelUnlocked, data.gunname, data.gunsUnlocked, data.furthestDistance);
            replaceCurrentButton(missilelauncher);
            dataholder.setData(data);
        }
    }

    //If the diamond cannon is selected
    private void DiamondOnClick()
    {
        if (data.cash >= 1 && data.barrelUnlocked < 6)
        {
            data = new LevelManager.GameData(data.cash - 1, data.currentSkin, data.skinUnlocked, "diamond", 6, data.gunname, data.gunsUnlocked, data.furthestDistance);
            replaceCurrentButton(diamond);
            dataholder.setData(data);
            purchases[4].unlock();
        }
        else if (data.barrelUnlocked >= 6)
        {
            ss.playSound("menubutton");
            data = new LevelManager.GameData(data.cash, data.currentSkin, data.skinUnlocked, "diamond", data.barrelUnlocked, data.gunname, data.gunsUnlocked, data.furthestDistance);
            replaceCurrentButton(diamond);
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
