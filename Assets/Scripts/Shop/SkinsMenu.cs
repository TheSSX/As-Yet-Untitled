using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinsMenu : MonoBehaviour {

    public Button bearskin, athlete, back;
    public GameObject mainmenu;
    public DataHolder dataholder;
    public LevelManager.GameData data;
    public Image athleteimage;

    // Use this for initialization
    void Start () {

        dataholder = GameObject.Find("DataHolder").GetComponent<DataHolder>();
        athleteimage = GameObject.Find("AthleteImage").GetComponent<Image>();

        bearskin.onClick.AddListener(BearskinOnClick);
        athlete.onClick.AddListener(AthleteOnClick);
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
            Color originalcolour = athleteimage.color;
            originalcolour.a = 0.5f;
            athleteimage.color = originalcolour; ;
        }   
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

        data = new LevelManager.GameData(data.cash, "bearskin", x, data.barrelskin);
        dataholder.setData(data);
    }

    private void AthleteOnClick()
    {
        if (data.cash >= 50000)
        {
            int cash = data.cash - 50000;

            int x;

            if (2 < data.skinUnlocked)
            {
                x = data.skinUnlocked;
            }
            else
            {
                x = 2;
            }

            data = new LevelManager.GameData(cash, "athlete", x, data.barrelskin);
            dataholder.setData(data);
        }
    }

    private void BackOnClick()
    {
        gameObject.SetActive(false);
        mainmenu.SetActive(true);
    }
}
