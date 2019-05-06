using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaunchersMenu : MonoBehaviour {

	public Button basic, gold, tank, samturret, back;
    public Image goldimage, tankimage, samturretimage;
    public Text goldlocked, goldprice, tanklocked, tankprice, samturretlocked, samturretprice;

    public GameObject mainmenu;
	public DataHolder dataholder;

	public LevelManager.GameData data;	

    private ShopMenu.Purchase[] purchases;

    // Use this for initialization
    void Start () {

	    dataholder = GameObject.Find("DataHolder").GetComponent<DataHolder>();
	    goldimage = GameObject.Find("GoldImage").GetComponent<Image>();
	    tankimage = GameObject.Find("TankImage").GetComponent<Image>();
	    samturretimage = GameObject.Find("SAMTurretImage").GetComponent<Image>();
        goldlocked = GameObject.Find("GoldLocked").GetComponent<Text>();
        tanklocked = GameObject.Find("TankLocked").GetComponent<Text>();
        samturretlocked = GameObject.Find("SAMTurretLocked").GetComponent<Text>();
        goldprice = GameObject.Find("GoldPrice").GetComponent<Text>();
        tankprice = GameObject.Find("TankPrice").GetComponent<Text>();
        samturretprice = GameObject.Find("SAMTurretPrice").GetComponent<Text>();

        basic.onClick.AddListener(BasicOnClick);
	    gold.onClick.AddListener(GoldOnClick);
	    tank.onClick.AddListener(TankOnClick);
	    samturret.onClick.AddListener(SAMTurretOnClick);
	    back.onClick.AddListener(BackOnClick);

        GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
    }

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

            for (int i = data.barrelUnlocked - 2; i >= 0; i--)
            {
                purchases[i].unlock();
            }
        }
    }

    private void BasicOnClick()
	{
	    data = new LevelManager.GameData (data.cash, data.currentSkin, data.skinUnlocked, "basic", data.barrelUnlocked, data.gunname, data.gunsUnlocked);
	    dataholder.setData(data);
	}

	private void GoldOnClick()
	{
	    if (data.cash >= 50000 && data.barrelUnlocked < 2)
	    {
	        data = new LevelManager.GameData(data.cash - 50000, data.currentSkin, data.skinUnlocked, "gold", 2, data.gunname, data.gunsUnlocked);
	        dataholder.setData(data);
            purchases[0].unlock();
        }
        else if (data.barrelUnlocked >= 2)
        {
            data = new LevelManager.GameData(data.cash, data.currentSkin, data.skinUnlocked, "gold", data.barrelUnlocked, data.gunname, data.gunsUnlocked);
            dataholder.setData(data);
        }
    }

    private void TankOnClick()
    {
        if (data.cash >= 1000000 && data.barrelUnlocked < 3)
        {
            data = new LevelManager.GameData(data.cash - 1000000, data.currentSkin, data.skinUnlocked, "tank", 3, data.gunname, data.gunsUnlocked);
            dataholder.setData(data);
            purchases[1].unlock();
        }
        else if (data.barrelUnlocked >= 3)
        {
            data = new LevelManager.GameData(data.cash, data.currentSkin, data.skinUnlocked, "tank", data.barrelUnlocked, data.gunname, data.gunsUnlocked);
            dataholder.setData(data);
        }
    }

    private void SAMTurretOnClick()
    {
        if (data.cash >= 25000000 && data.barrelUnlocked < 4)
        {
            data = new LevelManager.GameData(data.cash - 25000000, data.currentSkin, data.skinUnlocked, "SAM turret", 4, data.gunname, data.gunsUnlocked);
            dataholder.setData(data);
            purchases[2].unlock();
        }
        else if (data.barrelUnlocked >= 4)
        {
            data = new LevelManager.GameData(data.cash, data.currentSkin, data.skinUnlocked, "SAM turret", data.barrelUnlocked, data.gunname, data.gunsUnlocked);
            dataholder.setData(data);
        }
    }

    private void BackOnClick()
	{
	gameObject.SetActive(false);
	mainmenu.SetActive(true);
	}
}
