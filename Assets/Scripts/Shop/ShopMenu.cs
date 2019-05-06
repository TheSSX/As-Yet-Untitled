using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopMenu : MonoBehaviour {

    private LevelManager.GameData data;
    public Button skins, launchers, guns, exit;
    public GameObject skinsPanel, launchersPanel, gunsPanel;

    public struct Purchase
    {
        private Image image;
        private Text locked, price;

        public Purchase(Image x, Text y, Text z)
        {
            image = x;
            locked = y;
            price = z;

            Color originalcolour = image.color;
            originalcolour.a = 0.5f;
            image.color = originalcolour;
        }

        public void unlock()
        {
            Color originalcolour = image.color;
            originalcolour.a = 1;
            image.color = originalcolour; ;
            locked.text = "[Unlocked]";
            locked.color = new Color(0, 1, 0, 1);
            price.text = "";
        }
    }

    void Start()
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
