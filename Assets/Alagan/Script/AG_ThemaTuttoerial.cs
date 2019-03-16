using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AG_ThemaTuttoerial : MonoBehaviour {

    public List<Thema> themaList = new List<Thema>();
    public Thema currentThema;
    public List<Text> textList = new List<Text>();
    public List<Image> normalCell = new List<Image>();
    public List<Image> colorPicker = new List<Image>();
    public Image panel1;
    public Image panel2;
    public Image panel3;
    public Image panel4;
    public Image area1, area2, area3, area4;
    public Image icon;
    public Image background;

    public List<Image> nullCell = new List<Image>();
    public List<Image> mineCell = new List<Image>();
    public List<Image> onemine = new List<Image>();
    public List<Image> twomine = new List<Image>();
    public List<Image> threeMine = new List<Image>();
    public void Awake()
    {
        currentThema = themaList[PlayerPrefs.GetInt("MantarGames_Hue_Thema_Use")];

        background.color = currentThema.backgroundColor;


        for(int i = 0; i<textList.Count;i++)
        {
            textList[i].color = currentThema.textColor;
        }
        for (int i = 0; i < normalCell.Count; i++)
        {
            normalCell[i].sprite = currentThema.normal;
        }
        panel1.color = currentThema.panelColor;
        panel2.color = currentThema.panelColor;
        panel3.color = currentThema.panelColor;
        panel4.color = currentThema.panelColor;

        area1.color = currentThema.areaColor;
        area2.color = currentThema.areaColor;
        area3.color = currentThema.areaColor;
        area4.color = currentThema.areaColor;

        icon.color = currentThema.iconColor;

        for (int i = 1; i<currentThema.cellSprite.Count;i++)
        {
            colorPicker[i - 1].sprite = currentThema.cellSprite[i];
        }
        colorPicker[colorPicker.Count - 1].sprite = currentThema.mine;

        for(int i = 0; i< nullCell.Count;i++)
        {
            nullCell[i].sprite = currentThema.cellSprite[0];
        }

        for (int i = 0; i < mineCell.Count; i++)
        {
            mineCell[i].sprite = currentThema.mine;
        }

        for (int i = 0; i < onemine.Count; i++)
        {
            onemine[i].sprite = currentThema.cellSprite[1];
        }

        for (int i = 0; i < twomine.Count; i++)
        {
            twomine[i].sprite = currentThema.cellSprite[2];
        }

        for (int i = 0; i < threeMine.Count; i++)
        {
            threeMine[i].sprite = currentThema.cellSprite[3];
        }

    }
}
