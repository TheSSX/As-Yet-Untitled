using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsMenu : MonoBehaviour {

    private SoundSystem soundsystem;
    private MainMenuControlla menu;
    public Button back1, back2, back3, next1, next2, previous2, previous3;
    public GameObject panel1, panel2, panel3;

    // Use this for initialization
    void Start () {
        soundsystem = GameObject.Find("SoundSystem").GetComponent<SoundSystem>().getInstance();
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

    private void BackOnClick()
    {
        panel1.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);
        menu.back();
    }

    private void Next1OnClick()
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
    }

    private void Next2OnClick()
    {
        panel2.SetActive(false);
        panel3.SetActive(true);
    }

    private void Previous2OnClick()
    {
        panel2.SetActive(false);
        panel1.SetActive(true);
    }

    private void Previous3OnClick()
    {
        panel3.SetActive(false);
        panel2.SetActive(true);
    }
}
