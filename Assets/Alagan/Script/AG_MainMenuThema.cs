using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AG_MainMenuThema : MonoBehaviour {

    public static AG_MainMenuThema Instance;

    public Image background,mantarLogo;
	void Start () {
        Instance =  this ;
        Debug.Log(PlayerPrefs.GetInt("MantarGames_Hue_Thema_Use"));
        setThema(PlayerPrefs.GetInt("MantarGames_Hue_Thema_Use"));
	}
	
	public void setThema(int themaID)
    {
        Thema currentThema = GetComponent<AG_Store>().themaList[themaID];

        background.color = currentThema.interfaceSettings.backgroundColor;
        mantarLogo.sprite = currentThema.interfaceSettings.mantarLogo;

    }
}
