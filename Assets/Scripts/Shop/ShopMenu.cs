using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Controls the main shop menu
public class ShopMenu : MonoBehaviour {

    private LevelManager.GameData data;
    [SerializeField]
    private Button skins, launchers, guns, exit;
    [SerializeField]
    private GameObject skinsPanel, launchersPanel, gunsPanel;
    private SoundSystem ss;

    //Struct used to contain data about all possible items and purchases. Contains their image, text showing if they are locked and their price
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
            image.color = originalcolour;       //by default, purchased are greyed out and locked
        }

        //Unlocks a purchase by restoring it to full colour and marking it unlocked
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

        ss = SoundSystem.getInstance();
    }

    //Takes the player to the skins menu
    private void SkinsOnClick()
    {
        ss.playSound("menubutton");
        gameObject.SetActive(false);
        skinsPanel.SetActive(true);
    }

    //Takes the player to the launchers menu
    private void LaunchersOnClick()
    {
        ss.playSound("menubutton");
        gameObject.SetActive(false);
        launchersPanel.SetActive(true);
    }

    //Takes the player to the guns menu
    private void GunsOnClick()
    {
        ss.playSound("menubutton");
        gameObject.SetActive(false);
        gunsPanel.SetActive(true);
    }

    //Exits back to gameplay
    private void ExitOnClick()
    {
        ss.playSound("menubutton");
        ss.playMusic("Gameplay");
        SceneManager.LoadSceneAsync("Gameplay");
    }
}
