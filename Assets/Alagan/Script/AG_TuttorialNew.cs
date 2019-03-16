using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AG_TuttorialNew : MonoBehaviour {

    public GameObject panel1, panel2;
    public Transform topPoint, bottomPoint;
    public GameObject hueLogo;
    public AG_ThemaTuttoerial currentThema;
    [Header("Steps")]
    public GameObject step1;
    public GameObject step2;
    public GameObject step3;
    [Header("Step1")]
    public Transform cube1;
    public Text step1Text;
    public GameObject step1Button;
    [Header("Step3")]
    public GameObject step3Text;
    public GameObject bottomNav;
    public GameObject step3button1;
    public GameObject step3button2;
    public List<GameObject> mineList = new List<GameObject>();

    public GameObject hand;
    public Button flagButtonObject;
    public Text moveText;
    public GameObject bigCube;
    public int moveCount;
    public Image flagIcon;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1);

        if(PlayerPrefs.GetInt("MantarGames_Hue_FirstLogin") == 1)
        {
            iTween.MoveTo(panel2, iTween.Hash("position", topPoint.transform.position, "time", 1));
        }
        else
        {
            PlayerPrefs.SetInt("MantarGames_Hue_FirstLogin", 1);
            iTween.MoveTo(panel1, iTween.Hash("position", topPoint.transform.position, "time", 1));
        }
       
        iTween.ScaleTo(hueLogo, iTween.Hash("scale", new Vector3(1,1,1), "time", 1));
    }
    public void letsGoButton()
    {
        iTween.MoveTo(panel1,iTween.Hash("position",bottomPoint.transform.position,"time",1));
        iTween.MoveTo(panel2, iTween.Hash("position", topPoint.transform.position, "time", 1));
    }


    public void step1CellClick()
    {
        for(int i = 0; i<cube1.childCount;i++)
        {
            cube1.GetChild(i).GetComponent<Button>().enabled = false;
            StartCoroutine(cellAnimation1(cube1.GetChild(i).gameObject,i*0.2f));
        }
        StartCoroutine(textChange(step1Text, "Harika hiç mayın yok. Etrafında mayın olmayan hücreler, etrafında mayın olan hücrelere kadar otomatik olarak açılır",.7f,.5f));
        
    }

    IEnumerator cellAnimation1(GameObject obj,float delay)
    {
        iTween.ScaleTo(obj, iTween.Hash("scale", new Vector3(0, 0, 0),"time",.5f,"easeType",iTween.EaseType.easeInElastic,"delay",delay));
        yield return new WaitForSeconds(.5f+delay);
        obj.GetComponent<Image>().sprite = currentThema.currentThema.cellSprite[0];
        iTween.ScaleTo(obj, iTween.Hash("scale", new Vector3(1,1,1), "time", .5f, "easeType", iTween.EaseType.easeOutElastic));
    }

    IEnumerator textChange(Text text,string newText, float time,float delay)
    {
        iTween.ScaleTo(text.gameObject, iTween.Hash("scale", new Vector3(0, 0, 0), "time", time, "easeType", iTween.EaseType.easeInElastic,"delay", delay));
     
        yield return new WaitForSeconds(time+delay);
        text.text = newText;
        iTween.ScaleTo(text.gameObject, iTween.Hash("scale", new Vector3(1,1,1), "time", time, "easeType", iTween.EaseType.easeOutElastic));
        yield return new WaitForSeconds(1);
        iTween.ScaleTo(step1Button, iTween.Hash("scale", new Vector3(1, 1, 1), "time", time, "easeType", iTween.EaseType.easeOutElastic));
    }

    public void step1ButtonClick()
    {
        iTween.ScaleTo(step1, iTween.Hash("scale", new Vector3(0, 0, 0), "time", 1, "easeType", iTween.EaseType.easeInElastic));
        iTween.ScaleTo(step2, iTween.Hash("scale", new Vector3(1,1,1), "time", 1, "easeType", iTween.EaseType.easeOutElastic,"delay",1));
    }
    public void step2ButtonClick()
    {
        iTween.ScaleTo(step2, iTween.Hash("scale", new Vector3(0, 0, 0), "time", 1, "easeType", iTween.EaseType.easeInElastic));
        iTween.ScaleTo(step3, iTween.Hash("scale", new Vector3(1, 1, 1), "time", 1, "easeType", iTween.EaseType.easeOutElastic, "delay", 1));
    }

    public void step3Button1Click()
    {
        iTween.ScaleTo(step3Text, iTween.Hash("scale", new Vector3(0, 0, 0), "time", 1, "easeType", iTween.EaseType.easeInElastic));
        iTween.ScaleTo(step3button1, iTween.Hash("scale", new Vector3(0, 0, 0), "time", 1, "easeType", iTween.EaseType.easeInElastic));
        iTween.ScaleTo(bottomNav, iTween.Hash("scale", new Vector3(1, 1, 1), "time", 1, "easeType", iTween.EaseType.easeOutElastic,"delay",1));
        for (int i = 0; i < mineList.Count; i++)
        {
            StartCoroutine(changeMineCell(mineList[i].gameObject));
        }
      

    }

   

    IEnumerator changeMineCell(GameObject obj)
    {
        iTween.ScaleTo(obj, iTween.Hash("scale", new Vector3(0, 0, 0), "time", 1f, "easeType", iTween.EaseType.easeInElastic));
        yield return new WaitForSeconds(1f);
        obj.GetComponent<Image>().sprite = currentThema.currentThema.normal;
      
        iTween.ScaleTo(obj, iTween.Hash("scale", new Vector3(1, 1, 1), "time", 1f, "easeType", iTween.EaseType.easeOutElastic));

        iTween.ScaleTo(hand,iTween.Hash("scale",new Vector3(1.2f,1.2f,1.2f),"looptype",iTween.LoopType.pingPong,"time",.5f));
    }

   IEnumerator test(GameObject obj)
    {
        moveCount++;
        moveText.text = moveCount.ToString();
        obj.GetComponent<Image>().sprite = currentThema.currentThema.flag;

        if(moveCount == 6)
        {
            for(int i = 0; i< bigCube.transform.childCount;i++)
            {
               StartCoroutine (winGame(bigCube.transform.GetChild(i).gameObject,i*0.01f));
            }
            step3Text.GetComponent<Text>().text = "Tebrikler mini oyunu başarıyla tamamladın. Artık oyuna başlayabilirsin";
            iTween.ScaleTo(step3Text, iTween.Hash("scale", new Vector3(1, 1, 1), "time", 1, "easeType", iTween.EaseType.easeOutElastic,"delay",1));
            iTween.ScaleTo(step3button2, iTween.Hash("scale", new Vector3(1, 1, 1), "time", 1, "easeType", iTween.EaseType.easeOutElastic, "delay", 1));
            iTween.ScaleTo(bottomNav, iTween.Hash("scale", new Vector3(0,0,0), "time", 1, "easeType", iTween.EaseType.easeInElastic));
        }
     
        yield return null;
    }

    IEnumerator winGame(GameObject k,float delay)
    {
        iTween.ScaleTo(k, iTween.Hash("scale", new Vector3(0, 0, 0), "time", 1f, "easeType", iTween.EaseType.easeInElastic,"delay", delay));
        yield return new WaitForSeconds(1+ delay);
        k.GetComponent<Image>().sprite = currentThema.currentThema.cellSprite[1];
        iTween.ScaleTo(k, iTween.Hash("scale", new Vector3(1, 1, 1), "time", 1f, "easeType", iTween.EaseType.easeOutElastic));
    }
    public void flagButton()
    {
        flagButtonObject.enabled = false;
        for (int i = 0; i < mineList.Count; i++)
        {
            GameObject obj = mineList[i];
            mineList[i].AddComponent<Button>().onClick.AddListener(delegate { StartCoroutine(test(obj)); });
        }
        flagIcon.color = currentThema.currentThema.flagAreaActive;

        hand.active = false;
    }


    public void goToHome()
    {
        StartCoroutine(changeScene());
    }
    IEnumerator changeScene()
    {
        iTween.ScaleTo(hueLogo, iTween.Hash("scale", new Vector3(0, 0, 0)));
        iTween.MoveTo(panel2, iTween.Hash("position", bottomPoint.transform.position, "time", 1));
        yield return new WaitForSeconds(1);
        Application.LoadLevel(0);
    }
}
