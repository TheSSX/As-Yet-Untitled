using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script for the panel confirming if the user wishes to delete their save data
public class DeleteSaveConfirm : MonoBehaviour {

    public Button yes, no;
    public LevelManager levelmanager;
    public ResultsCanvasControlla results;

	// Use this for initialization
	void Start () {
        yes.onClick.AddListener(YesOnClick);
        no.onClick.AddListener(NoOnClick);
        levelmanager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        results = GameObject.Find("ResultsCanvas").GetComponent<ResultsCanvasControlla>();

        GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);     //places the panel in the middle of the screen on launch
    }
	
    //Called when the yes button is pressed (delete data)
	private void YesOnClick()
    {
        levelmanager.deleteSave();
    }

    //Called when the no button is pressed (don't delete data)
    private void NoOnClick()
    {
        results.noDelete();
    }
}
