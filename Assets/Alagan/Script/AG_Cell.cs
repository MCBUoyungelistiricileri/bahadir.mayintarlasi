using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AG_Cell : MonoBehaviour {

    Sprite newImage;

    public enum cellType { normalCell, mineCell,nullCell,flag};
    public cellType _type;
    public int mineCount;
    public void hideCell(Sprite changeImage,float delay)
    {
        newImage = changeImage;
        GetComponent<Button>().enabled = false;
        iTween.ScaleTo(gameObject, iTween.Hash("scale", new Vector3(0, 0, 0),"delay",delay, "time", AG_Animation.Instance.animationTime/2, "easeType", AG_Animation.Instance.hideAnimation, "oncomplete", "hideComplate", "oncompletetarget", gameObject));

    }
    public void hideComplate()
    {
        showCell();
    }
    public void showCell()
    {
        GetComponent<Image>().sprite = newImage;
        iTween.ScaleTo(gameObject, iTween.Hash("scale", new Vector3(1,1,1), "time", AG_Animation.Instance.animationTime/2, "easeType", AG_Animation.Instance.showAnimation));

    }
}
