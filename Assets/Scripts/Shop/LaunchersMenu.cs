using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaunchersMenu : MonoBehaviour {

	public Button basic, gold, back;
    public Image goldimage;
    public Text goldlocked, goldprice;

    public GameObject mainmenu;
	public DataHolder dataholder;

	public LevelManager.GameData data;	

    private ShopMenu.Purchase[] purchases;

    // Use this for initialization
    void Start () {

	    dataholder = GameObject.Find("DataHolder").GetComponent<DataHolder>();
	    goldimage = GameObject.Find("GoldImage").GetComponent<Image>();
        goldlocked = GameObject.Find("GoldLocked").GetComponent<Text>();
        goldprice = GameObject.Find("GoldPrice").GetComponent<Text>();

        basic.onClick.AddListener(BasicOnClick);
	    gold.onClick.AddListener(GoldOnClick);
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

	private void BackOnClick()
	{
	gameObject.SetActive(false);
	mainmenu.SetActive(true);
	}
}
