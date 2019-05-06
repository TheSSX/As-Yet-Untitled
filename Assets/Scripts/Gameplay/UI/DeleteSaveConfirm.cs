using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
	}
	
	private void YesOnClick()
    {
        levelmanager.deleteSave();
    }

    private void NoOnClick()
    {
        results.noDelete();
    }
}
