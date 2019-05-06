using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour {

    public DataHolder dataholder;
    public Text cash;
    public GameObject shopmenu, skinsmenu, launchersmenu, gunsmenu;

	// Use this for initialization
	void Start () {

        dataholder = GameObject.Find("DataHolder").GetComponent<DataHolder>();
        shopmenu = GameObject.Find("ShopMenu");
        skinsmenu = GameObject.Find("SkinsMenu");
		launchersmenu = GameObject.Find("LaunchersMenu");
		gunsmenu = GameObject.Find("GunsMenu");
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
    }

    public void setValues(LevelManager.GameData data)
    { 
        cash.text = "Cash: £" + data.cash.ToString();
        skinsmenu.GetComponent<SkinsMenu>().setValues(data);
		launchersmenu.GetComponent<LaunchersMenu>().setValues(data);
        gunsmenu.GetComponent<GunsMenu>().setValues(data);
    }
}
