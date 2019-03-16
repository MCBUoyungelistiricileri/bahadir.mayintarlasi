using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AG_Animation : MonoBehaviour {

    public static AG_Animation Instance;
    [Header("Open Cell Animation")]
    public iTween.EaseType hideAnimation;
    public iTween.EaseType showAnimation;
    public float animationTime;
    public float delayKat;
    void Start () {
        Instance = this;
	}
	
	
    public void mineClickAnimation(int row, int col)
    {
        delayKat = 0.01f;
        int counter = 0;
        for(int i = 0; i<AG_GameManager.Instance.rowCount;i++)
        {
            for (int k = 0; k < AG_GameManager.Instance.colCount; k++)
            {
                counter++;
                if (!mineCellControl(i,k))
                {
                   
                  
                    StartCoroutine(cellAnimation2(AG_GameManager.Instance.boardItem[i, k], .6f, counter * delayKat, AG_ThemaSelector.Instance.currentThema.cellSprite[7]));

                   // AG_GameManager.Instance.boardItem[i, k].GetComponent<AG_Cell>().hideCell(AG_ThemaSelector.Instance.currentThema.cellSprite[7], counter * delayKat);
                       
                    
                }
                else
                {
                    Debug.Log(counter * delayKat);
                    StartCoroutine(cellAnimation2(AG_GameManager.Instance.boardItem[i, k], .6f, counter * delayKat, AG_ThemaSelector.Instance.currentThema.mine));
                }
                AG_GameManager.Instance.boardItem[i, k].GetComponent<Button>().enabled = false;
            }
        }
        AG_Sound.Instance.soundError();
      
      
    }
    public bool mineCellControl(int row, int col)
    {
        bool durum = false;
        for(int i = 0; i< AG_GameManager.Instance.mineList.Count;i++)
        {
            if (AG_GameManager.Instance.mineList[i].row == row && AG_GameManager.Instance.mineList[i].col == col)
            {
                durum = true;
                break;
            }
        }
        return durum;
    }
    public void completeAnimation()
    {
        delayKat = 0.01f;
        int counter = 0;
        for (int i = 0; i < AG_GameManager.Instance.rowCount; i++)
        {
            for (int k = 0; k < AG_GameManager.Instance.colCount; k++)
            {
                counter++;
                StartCoroutine(cellAnimation2(AG_GameManager.Instance.boardItem[i, k], .6f, counter * delayKat, AG_ThemaSelector.Instance.currentThema.cellSprite[1]));
                AG_GameManager.Instance.boardItem[i, k].GetComponent<Button>().enabled = false;

                
            }
        }
    }
    public void openCellAnimation(List<OpenCell> list)
    {
        if (list.Count != 0)
        {
            Debug.Log(list.Count);
            if (list.Count == 2)
                AG_Sound.Instance.soundSingleBubble();
            else
                AG_Sound.Instance.soundMultipleBubble();


            delayKat = .4f / list.Count;
            for (int i = 1; i < list.Count; i++)
            {
                if (AG_GameManager.Instance.boardItem[list[i].row, list[i].col].GetComponent<AG_Cell>()._type != AG_Cell.cellType.flag)
                {
                    Image obj = AG_GameManager.Instance.boardItem[list[i].row, list[i].col];
                    int p = i;
                    StartCoroutine(cellAnimation(obj, .6f, i * delayKat, AG_ThemaSelector.Instance.currentThema.cellSprite[list[i].mineCount]));
                    AG_GameManager.Instance.boardItem[list[i].row, list[i].col].GetComponent<Button>().enabled = false;
                    //  obj.GetComponent<AG_Cell>().hideCell(, i * delayKat);
                }

            }
        }
    }

    public IEnumerator cellAnimation(Image obj,float aTime,float delay,Sprite p)
    {

        iTween.ScaleTo(obj.gameObject, iTween.Hash("scale",new Vector3(0,0,0),"time",aTime,"delay",delay,"easeType",iTween.EaseType.easeInElastic));
        yield return new WaitForSeconds(aTime+ delay);
        
        obj.sprite =p ;
        iTween.ScaleTo(obj.gameObject, iTween.Hash("scale", new Vector3(1,1,1), "time", aTime, "easeType", iTween.EaseType.easeOutElastic));
    }

    public IEnumerator cellAnimation2(Image obj, float aTime, float delay, Sprite p)
    {
        iTween.ScaleTo(obj.gameObject, iTween.Hash("scale", new Vector3(0, 0, 0), "time", aTime, "delay", delay, "easeType", iTween.EaseType.easeInElastic));
        yield return new WaitForSeconds(aTime + delay);

        obj.sprite = p;
        iTween.ScaleTo(obj.gameObject, iTween.Hash("scale", new Vector3(1, 1, 1), "time", aTime, "easeType", iTween.EaseType.easeOutElastic));
    }
}
