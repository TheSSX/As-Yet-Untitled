using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinsMenu : MonoBehaviour {

    public Button bearskin, athlete, back;
    public Image athleteimage;
    public Text athletelocked, athleteprice;

    public GameObject mainmenu;
    public DataHolder dataholder;

    public LevelManager.GameData data;       

    public ShopMenu.Purchase[] purchases;

    // Use this for initialization
    void Start () {

        dataholder = GameObject.Find("DataHolder").GetComponent<DataHolder>();
        athleteimage = GameObject.Find("AthleteImage").GetComponent<Image>();
        athletelocked = GameObject.Find("AthleteLocked").GetComponent<Text>();
        athleteprice = GameObject.Find("AthletePrice").GetComponent<Text>();

        bearskin.onClick.AddListener(BearskinOnClick);
        athlete.onClick.AddListener(AthleteOnClick);
        back.onClick.AddListener(BackOnClick);

        GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
    }

    public void setValues(LevelManager.GameData x)
    {
        data = x;

        if (data.skinUnlocked > 1)
        {
            purchases = new ShopMenu.Purchase[data.skinUnlocked - 1];
            
            purchases[0] = new ShopMenu.Purchase(athleteimage, athletelocked, athleteprice);

            for (int i = data.skinUnlocked - 2; i >= 0; i--)
            {
                purchases[i].unlock();
            }
        }
    }
	
	private void BearskinOnClick()
    {
        data = new LevelManager.GameData(data.cash, "bearskin", data.skinUnlocked, data.barrelskin, data.barrelUnlocked, data.gunname, data.gunsUnlocked);
        dataholder.setData(data);
    }

    private void AthleteOnClick()
    {
		if (data.cash >= 50000 && data.skinUnlocked < 2)
        {
            data = new LevelManager.GameData(data.cash - 50000, "athlete", 2, data.barrelskin, data.barrelUnlocked, data.gunname, data.gunsUnlocked);
            dataholder.setData(data);
            purchases[0].unlock();
        }
        else if (data.skinUnlocked >= 2)
        {
            data = new LevelManager.GameData(data.cash, "athlete", data.skinUnlocked, data.barrelskin, data.barrelUnlocked, data.gunname, data.gunsUnlocked);
            dataholder.setData(data);
        }
    }

    private void BackOnClick()
    {
        gameObject.SetActive(false);
        mainmenu.SetActive(true);
    }
}
