using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Thema", menuName = "Hue/Thema", order = 1)]
public class Thema : ScriptableObject
{
    public string themaName;
    public StoreDetail store;
    [Header("In Game")]
    public List<Sprite> cellSprite = new List<Sprite>();

    public Sprite normal;
    public Sprite mine;
    public Sprite flag;
    [Header("Interface")]
    public Color backgroundColor;
    public Sprite panelImage;
    public Color panelColor;
    public Color textColor;

  

    

    public Sprite backbutton;
    public Color areaColor;
    public Color iconColor;
    public Color flagAreaActive;

    public InterfaceSettings interfaceSettings;

}
[System.Serializable]
public class InterfaceSettings
{
    public Color panelColor,backgroundColor,textColor;
    public Sprite mantarLogo;
}
[System.Serializable]
public class StoreDetail
{
    public bool free;
    public string key;
    public string StoreID;
    [HideInInspector]
    public bool _have;
    [HideInInspector]
    public bool _use;
}
