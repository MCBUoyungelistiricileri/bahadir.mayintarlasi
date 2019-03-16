using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AG_ObjectAnimation : MonoBehaviour {

	public void hideAnimation(float time = 1)
    {
        iTween.ValueTo(gameObject, iTween.Hash(  "from", 1, "to", 0, "time", time, "onupdatetarget", gameObject,"onupdate", "animationUpdater", "easetype", iTween.EaseType.linear ));
    }
    public void showAnimation(float time = 1)
    {
        iTween.ValueTo(gameObject, iTween.Hash("from", 0, "to", 1, "time", time, "onupdatetarget", gameObject, "onupdate", "animationUpdater", "easetype", iTween.EaseType.linear));
    }

    public List<GameObject> haric = new List<GameObject>();

    public AG_ObjectAnimation haricEkle(GameObject obj)
    {
        haric.Add(obj);
        return this;
    }
    public void animationUpdater(float a)
    {
        if (transform.tag != "NOHIDE" && haric.IndexOf(gameObject) == -1)
        
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, a);
            if (transform.childCount != 0)
            {
                Transform[] deneme = GetComponentsInChildren<Transform>();

                for (int i = 0; i < deneme.Length; i++)
                {
                    if (deneme[i].tag != "NOHIDE"&&haric.IndexOf(deneme[i].gameObject) == -1)
                    {
                        if (deneme[i].GetComponent<Image>() != null)
                            deneme[i].GetComponent<Image>().color = new Color(deneme[i].GetComponent<Image>().color.r, deneme[i].GetComponent<Image>().color.g, deneme[i].GetComponent<Image>().color.b, a);
                        else if (deneme[i].GetComponent<Text>() != null)
                            deneme[i].GetComponent<Text>().color = new Color(deneme[i].GetComponent<Text>().color.r, deneme[i].GetComponent<Text>().color.g, deneme[i].GetComponent<Text>().color.b, a);
                    }
                }
            }
        
    }






}
