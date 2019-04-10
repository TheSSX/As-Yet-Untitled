using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaunchersMenu : MonoBehaviour {

	public Button basic, gold, back;
	public GameObject mainmenu;
	public DataHolder dataholder;
	public LevelManager.GameData data;
	public Image goldimage;

	// Use this for initialization
	void Start () {

	dataholder = GameObject.Find("DataHolder").GetComponent<DataHolder>();
	goldimage = GameObject.Find("GoldImage").GetComponent<Image>();

	basic.onClick.AddListener(BasicOnClick);
	gold.onClick.AddListener(GoldOnClick);
	back.onClick.AddListener(BackOnClick);
	}

	public void setValues(LevelManager.GameData x)
	{
	data = x;
	opaqueImages();
	}

	//Need to change this to apply to all applicable images
	private void opaqueImages()
	{     
	if (data.skinUnlocked == 1)
	{
	Color originalcolour = goldimage.color;
	originalcolour.a = 0.5f;
	goldimage.color = originalcolour; ;
	}   
	}

	private void BasicOnClick()
	{
	data = new LevelManager.GameData (data.cash, data.currentSkin, data.skinUnlocked, "basic");
	dataholder.setData(data);
	}

	private void GoldOnClick()
	{
	if (data.cash >= 50000)
	{
	int cash = data.cash - 50000;

	data = new LevelManager.GameData(cash, data.currentSkin, data.skinUnlocked, "gold");
	dataholder.setData(data);
	}
	}

	private void BackOnClick()
	{
	gameObject.SetActive(false);
	mainmenu.SetActive(true);
	}
}
