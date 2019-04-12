using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopMenu : MonoBehaviour {

    private LevelManager.GameData data;
    public Button skins, launchers, guns, exit;
    public GameObject skinsPanel, launchersPanel, gunsPanel;

    public void Start()
    {
        skins.onClick.AddListener(SkinsOnClick);
        launchers.onClick.AddListener(LaunchersOnClick);
        guns.onClick.AddListener(GunsOnClick);
        exit.onClick.AddListener(ExitOnClick);

        GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
    }

    private void SkinsOnClick()
    {
        gameObject.SetActive(false);
        skinsPanel.SetActive(true);
    }
    private void LaunchersOnClick()
    {
        gameObject.SetActive(false);
        launchersPanel.SetActive(true);
    }

    private void GunsOnClick()
    {
        gameObject.SetActive(false);
        gunsPanel.SetActive(true);
    }

    private void ExitOnClick()
    {
        SceneManager.LoadSceneAsync("Gameplay");
    }
}
