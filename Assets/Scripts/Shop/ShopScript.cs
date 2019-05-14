using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Coordinates the passing of data and the order of menus. Displays the user's cash up the top right of the screen at all times
public class ShopScript : MonoBehaviour {

    private DataHolder dataholder;
    [SerializeField]
    private Text cash;
    private GameObject shopmenu, skinsmenu, launchersmenu, gunsmenu;
    private SoundSystem ss;

	// Use this for initialization
	void Start () {

        ss = SoundSystem.getInstance();
        dataholder = GameObject.Find("DataHolder").GetComponent<DataHolder>();
        shopmenu = GameObject.Find("ShopMenu");
        skinsmenu = GameObject.Find("SkinsMenu");
		launchersmenu = GameObject.Find("LaunchersMenu");
		gunsmenu = GameObject.Find("GunsMenu");

        skinsmenu.SetActive(false);
        launchersmenu.SetActive(false);
        gunsmenu.SetActive(false);
        shopmenu.SetActive(true);

        gunsmenu.transform.SetSiblingIndex(0);
		launchersmenu.transform.SetSiblingIndex(1);
        skinsmenu.transform.SetSiblingIndex(2);
        shopmenu.transform.SetSiblingIndex(3);
        cash.transform.SetAsLastSibling();

        ss.playShopMusic();
    }

    public void setCash(LevelManager.GameData data)
    { 
        cash.text = "Cash: £" + data.cash.ToString();
    }
}
