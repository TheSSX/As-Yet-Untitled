using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinsMenu : MonoBehaviour {

    public Button bearskin, athlete, back;
	public Text athletelocked, athleteprice;
    public GameObject mainmenu;
    public DataHolder dataholder;
    public LevelManager.GameData data;
    public Image athleteimage;
	private Color green;

    // Use this for initialization
    void Start () {

        dataholder = GameObject.Find("DataHolder").GetComponent<DataHolder>();
        athleteimage = GameObject.Find("AthleteImage").GetComponent<Image>();
		athletelocked = GameObject.Find ("AthleteLocked").GetComponent<Text>();
		athleteprice = GameObject.Find ("AthletePrice").GetComponent<Text>();

		green = new Color (0, 1, 0, 1);

        bearskin.onClick.AddListener(BearskinOnClick);
        athlete.onClick.AddListener(AthleteOnClick);
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
            Color originalcolour = athleteimage.color;
            originalcolour.a = 0.5f;
            athleteimage.color = originalcolour; ;
        }   
    }

	private void solidImage(Image x)
	{
		Color originalcolour = x.color;
		originalcolour.a = 1;
		x.color = originalcolour; ;
	}
	
	private void BearskinOnClick()
    {
        int x;

        if (1 < data.skinUnlocked)
        {
            x = data.skinUnlocked;
        }
        else
        {
            x = 1;
        }

        data = new LevelManager.GameData(data.cash, "bearskin", x, data.barrelskin, data.barrelUnlocked);
        dataholder.setData(data);
    }

    private void AthleteOnClick()
    {
		if (data.cash >= 50000 && data.skinUnlocked < 2)
        {
            int cash = data.cash - 50000;

            data = new LevelManager.GameData(cash, "athlete", 2, data.barrelskin, data.barrelUnlocked);
            dataholder.setData(data);

            athletelocked.text = "[Unlocked]";
            athletelocked.color = green;
            solidImage(athleteimage);
            athleteprice.text = "";
        }
        else if (data.skinUnlocked >= 2)
        {
            data = new LevelManager.GameData(data.cash, "athlete", data.skinUnlocked, data.barrelskin, data.barrelUnlocked);
            dataholder.setData(data);
        }
    }

    private void BackOnClick()
    {
        gameObject.SetActive(false);
        mainmenu.SetActive(true);
    }
}
