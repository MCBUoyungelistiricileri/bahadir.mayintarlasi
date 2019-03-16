using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AG_ThemaSelector : MonoBehaviour {

    public List<Thema> themaList = new List<Thema>();
    [HideInInspector]
    public Thema currentThema;

    public Image panel, background, bottomNavigation,backbutton,moveArea,mineArea,flagArea,timeArea,homeButton,homebutton2,replaybutton;

    public static AG_ThemaSelector Instance;
    void Start()
    {
        Instance = this;
        currentThema = themaList[PlayerPrefs.GetInt("MantarGames_Hue_Thema_Use")];

    }
	public void setThema()
    {
        if (currentThema.panelImage == null)
            panel.color = currentThema.panelColor;
        else
            panel.sprite = currentThema.panelImage;


        background.color = currentThema.backgroundColor;
        bottomNavigation.color = currentThema.panelColor;
        moveArea.color = currentThema.areaColor;
        moveArea.transform.GetChild(1).GetComponent<Image>().color = currentThema.iconColor;
        moveArea.transform.GetChild(0).GetComponent<Text>().color = currentThema.textColor;
        mineArea.color = currentThema.areaColor;
        mineArea.transform.GetChild(1).GetComponent<Image>().color = currentThema.iconColor;
        mineArea.transform.GetChild(0).GetComponent<Text>().color = currentThema.textColor;
        flagArea.color = currentThema.areaColor;
        flagArea.transform.GetChild(1).GetComponent<Image>().color = currentThema.iconColor;
        flagArea.transform.GetChild(0).GetComponent<Text>().color = currentThema.textColor;

        timeArea.color = currentThema.panelColor;
        timeArea.transform.GetChild(0).GetComponent<Text>().color = currentThema.textColor;


        homeButton.color = currentThema.areaColor;
        homeButton.transform.GetChild(0).GetComponent<Image>().color = currentThema.iconColor;

        homebutton2.color = currentThema.areaColor;
        homebutton2.transform.GetChild(0).GetComponent<Image>().color = currentThema.iconColor;

        replaybutton.color = currentThema.areaColor;
        replaybutton.transform.GetChild(0).GetComponent<Image>().color = currentThema.iconColor;

    }
}
