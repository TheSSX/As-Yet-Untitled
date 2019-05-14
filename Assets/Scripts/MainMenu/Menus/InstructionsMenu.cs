using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Controls the instructions menu
public class InstructionsMenu : MonoBehaviour {

    private SoundSystem ss;
    private MainMenuControlla menu;
    [SerializeField]
    private Button back1, back2, back3, next1, next2, previous2, previous3;
    [SerializeField]
    private GameObject panel1, panel2, panel3;

    // Use this for initialization
    void Start () {
        ss = SoundSystem.getInstance();
        menu = GameObject.Find("Canvas").GetComponent<MainMenuControlla>();

        back1.onClick.AddListener(BackOnClick);
        back2.onClick.AddListener(BackOnClick);
        back3.onClick.AddListener(BackOnClick);
        next1.onClick.AddListener(Next1OnClick);
        next2.onClick.AddListener(Next2OnClick);
        previous2.onClick.AddListener(Previous2OnClick);
        previous3.onClick.AddListener(Previous3OnClick);

        panel1.SetActive(true);
        panel2.SetActive(false);
        panel3.SetActive(false);

        panel1.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        panel2.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        panel3.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
    }

    //Returns to main menu
    private void BackOnClick()
    {
        ss.playSound("menubutton");
        panel1.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);
        menu.back();
    }

    //Scrolls through instructions
    private void Next1OnClick()
    {
        ss.playSound("menubutton");
        panel1.SetActive(false);
        panel2.SetActive(true);
    }

    //Scrolls through instructions
    private void Next2OnClick()
    {
        ss.playSound("menubutton");
        panel2.SetActive(false);
        panel3.SetActive(true);
    }

    //Scrolls through instructions
    private void Previous2OnClick()
    {
        ss.playSound("menubutton");
        panel2.SetActive(false);
        panel1.SetActive(true);
    }

    //Scrolls through instructions
    private void Previous3OnClick()
    {
        ss.playSound("menubutton");
        panel3.SetActive(false);
        panel2.SetActive(true);
    }
}
