using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour {

    public DataHolder dataholder;
    public Text cash;
    public GameObject shopmenu, skinsmenu, launchersmenu;

	// Use this for initialization
	void Start () {

        dataholder = GameObject.Find("DataHolder").GetComponent<DataHolder>();
        shopmenu = GameObject.Find("ShopMenu");
        skinsmenu = GameObject.Find("SkinsMenu");
		launchersmenu = GameObject.Find("LaunchersMenu");

        skinsmenu.SetActive(false);
        shopmenu.SetActive(true);

		launchersmenu.transform.SetSiblingIndex(0);
        skinsmenu.transform.SetSiblingIndex(1);
        shopmenu.transform.SetSiblingIndex(2);
        cash.transform.SetAsLastSibling();
    }

    public void setValues(LevelManager.GameData data)
    { 
        cash.text = "Cash: £" + data.cash.ToString();
        skinsmenu.GetComponent<SkinsMenu>().setValues(data);
		launchersmenu.GetComponent<LaunchersMenu>().setValues(data);
    }
}
