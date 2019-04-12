using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaunchersMenu : MonoBehaviour {

	public Button basic, gold, back;
    public Text goldlocked, goldprice;
    public GameObject mainmenu;
	public DataHolder dataholder;
	public LevelManager.GameData data;
	public Image goldimage;
    private Color green;

    // Use this for initialization
    void Start () {

	    dataholder = GameObject.Find("DataHolder").GetComponent<DataHolder>();
	    goldimage = GameObject.Find("GoldImage").GetComponent<Image>();
        goldlocked = GameObject.Find("GoldLocked").GetComponent<Text>();
        goldprice = GameObject.Find("GoldPrice").GetComponent<Text>();

        green = new Color(0, 1, 0, 1);

        basic.onClick.AddListener(BasicOnClick);
	    gold.onClick.AddListener(GoldOnClick);
	    back.onClick.AddListener(BackOnClick);

        GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
    }

	public void setValues(LevelManager.GameData x)
	{
	    data = x;
	    transparentImages();
	}

	//Need to change this to apply to all applicable images
	private void transparentImages()
	{     
	    if (data.skinUnlocked == 1)
	    {
	        Color originalcolour = goldimage.color;
	        originalcolour.a = 0.5f;
	        goldimage.color = originalcolour; ;
	    }   
	}

    private void solidImage(Image x)
    {
        Color originalcolour = x.color;
        originalcolour.a = 1;
        x.color = originalcolour; ;
    }

    private void BasicOnClick()
	{
	    data = new LevelManager.GameData (data.cash, data.currentSkin, data.skinUnlocked, "basic", data.barrelUnlocked);
	    dataholder.setData(data);
	}

	private void GoldOnClick()
	{
	    if (data.cash >= 50000 && data.barrelUnlocked < 2)
	    {
	        int cash = data.cash - 50000;

	        data = new LevelManager.GameData(cash, data.currentSkin, data.skinUnlocked, "gold", 2);
	        dataholder.setData(data);

            goldlocked.text = "[Unlocked]";
            goldlocked.color = green;
            solidImage(goldimage);
            goldprice.text = "";
        }
        else if (data.barrelUnlocked >= 2)
        {
            data = new LevelManager.GameData(data.cash, data.currentSkin, data.skinUnlocked, "gold", data.barrelUnlocked);
            dataholder.setData(data);
        }
    }

	private void BackOnClick()
	{
	gameObject.SetActive(false);
	mainmenu.SetActive(true);
	}
}
