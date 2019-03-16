using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AG_Store : MonoBehaviour {

    public List<Thema> themaList = new List<Thema>();

    public GameObject shopItem;
    public Transform spawnPoint;
	void Start ()
    {
        if(PlayerPrefs.GetInt("MantarGames_Hue_FirstLogin",0) == 0)
        {
            PlayerPrefs.SetInt("MantarGames_Hue_Thema_0", 1);
            PlayerPrefs.SetInt("MantarGames_Hue_Thema_1", 1);
            PlayerPrefs.SetInt("MantarGames_Hue_FirstLogin", 1);         
        }
		for(int i = 0; i<themaList.Count;i++)
        {
            AG_ShopItem item = Instantiate(shopItem, spawnPoint).GetComponent<AG_ShopItem>();
            item.headerText.text = themaList[i].themaName;
            item.headerText.color = themaList[i].interfaceSettings.textColor;
            item.buyText.color = themaList[i].interfaceSettings.textColor;
            item.buyPanel.color = themaList[i].interfaceSettings.panelColor;
            item.cellPanel.color = themaList[i].interfaceSettings.panelColor;
            item.headerPanel.color = themaList[i].interfaceSettings.panelColor;
            item.mainPanel.color = themaList[i].interfaceSettings.backgroundColor;

            for(int k = 0; k<8;k ++)
            {
                item.cellList[k].sprite = themaList[i].cellSprite[k + 1];
            }
            for (int k = 8; k < 16; k++)
            {
                item.cellList[k].sprite = themaList[i].normal;
            }
            item.cellList[8].sprite = themaList[i].cellSprite[0];
            item.cellList[9].sprite = themaList[i].flag;
            item.cellList[10].sprite = themaList[i].mine;
            
            if (PlayerPrefs.GetInt("MantarGames_Hue_Thema_"+i) == 1)
            {
                if (PlayerPrefs.GetInt("MantarGames_Hue_Thema_Use") == i)
                {
                    item.buyText.text = "Kullanılıyor";
                    item.buyText.transform.parent.GetComponent<Button>().onClick.RemoveAllListeners();
                    themaList[i].store._use = true;
                    themaList[i].store._have = true;
                }
                else
                {
                    item.buyText.text = "Kullan";
                    int id = i;
                    item.buyText.transform.parent.GetComponent<Button>().onClick.AddListener(delegate { buyItem(id); });
                    themaList[i].store._have = true;
                }
            }
            else
            {
                item.buyText.text = "Satın Al";
                int id = i;
                themaList[i].store._have = false;
                themaList[i].store._use = false;
                item.buyText.transform.parent.GetComponent<Button>().onClick.AddListener(delegate { buyItem(id); });
            }

        }

    }

    public void buyItem(int id)
    {
       
            if(themaList[id].store._have)
            {
                for(int i = 0; i< themaList.Count;i++)
                {
                    if(themaList[i].store._use)
                    {
                        themaList[i].store._use = false;
                        spawnPoint.GetChild(i).GetComponent<AG_ShopItem>().buyText.text = "Kullan";
                        spawnPoint.GetChild(i).GetComponent<AG_ShopItem>().buyText.transform.parent.GetComponent<Button>().onClick.AddListener(delegate { buyItem(i); });

                        PlayerPrefs.SetInt("MantarGames_Hue_Thema_Use", id);
                        themaList[id].store._use = true;
                        spawnPoint.GetChild(id).GetComponent<AG_ShopItem>().buyText.text = "Kullanılıyor";
                        spawnPoint.GetChild(id).GetComponent<AG_ShopItem>().buyText.transform.parent.GetComponent<Button>().onClick.RemoveAllListeners();
                        AG_MainMenuThema.Instance.setThema(id);
                        break;
                    }
                }

            }
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
