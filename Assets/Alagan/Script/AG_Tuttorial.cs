using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AG_Tuttorial : MonoBehaviour {

    public Thema currentThema;
    [Header("Part 1")]
    public List<Image> cellList = new List<Image>();
    public AG_ObjectAnimation part1,part2,huelogo,mantarlogo;
    public Button nextButton;
    public Sprite tick;
    [Header("Part 2")]
    public Transform part2Board;
    public List<Image> activeCell = new List<Image>();
    public Text flagCount;
    public Text moveCount;
    public GameObject hand;
    public GameObject flagArea;
    public GameObject tick2;

    public AG_ObjectAnimation canvas;
    int flagCounter;
    void Start()
    {

        StartCoroutine(startAnimation());

    }

    IEnumerator startAnimation()
    {
        Transform[] deneme = canvas.GetComponentsInChildren<Transform>();
        for (int i = 0; i < deneme.Length; i++)
        {
            if (deneme[i].tag != "NOHIDE")
            {
                if (deneme[i].GetComponent<Image>() != null)
                    deneme[i].GetComponent<Image>().color = new Color(deneme[i].GetComponent<Image>().color.r, deneme[i].GetComponent<Image>().color.g, deneme[i].GetComponent<Image>().color.b, 0);
                else if (deneme[i].GetComponent<Text>() != null)
                    deneme[i].GetComponent<Text>().color = new Color(deneme[i].GetComponent<Text>().color.r, deneme[i].GetComponent<Text>().color.g, deneme[i].GetComponent<Text>().color.b, 0);
            }
        }
        yield return new WaitForSeconds(.5f);
        part1.haricEkle(part1.gameObject).showAnimation();
        huelogo.showAnimation();
        mantarlogo.showAnimation();
        yield return new WaitForSeconds(1.2f);
        nextAnimation();
    }

    #region Part1
    public int animation;
    public void nextAnimation()
    {
        StartCoroutine(nextAnimationWait());
        animation++;
    }
    public IEnumerator nextAnimationWait()
    {
        switch (animation)
        {
            case 1:
                StartCoroutine(changeImageSprite(currentThema.mine, cellList[0], 1));
                StartCoroutine(changeImageSprite(currentThema.cellSprite[1], cellList[4], 1));
                StartCoroutine(changeImageSprite(currentThema.cellSprite[1], cellList[1], 1));
                StartCoroutine(changeImageSprite(currentThema.cellSprite[1], cellList[3], 1));
                break;
            case 2:
                StartCoroutine(changeImageSprite(currentThema.mine, cellList[1], 1));
                StartCoroutine(changeImageSprite(currentThema.cellSprite[1], cellList[2], 1));
                StartCoroutine(changeImageSprite(currentThema.cellSprite[2], cellList[3], 1));
                StartCoroutine(changeImageSprite(currentThema.cellSprite[2], cellList[4], 1));
                StartCoroutine(changeImageSprite(currentThema.cellSprite[1], cellList[5], 1));
                break;
            case 3:
                StartCoroutine(changeImageSprite(currentThema.mine, cellList[2], 1));
                StartCoroutine(changeImageSprite(currentThema.cellSprite[3], cellList[4], 1));
                StartCoroutine(changeImageSprite(currentThema.cellSprite[2], cellList[5], 1));
                break;
            case 4:
                StartCoroutine(changeImageSprite(currentThema.mine, cellList[5], 1));
                StartCoroutine(changeImageSprite(currentThema.cellSprite[4], cellList[4], 1));
                StartCoroutine(changeImageSprite(currentThema.cellSprite[1], cellList[7], 1));
                StartCoroutine(changeImageSprite(currentThema.cellSprite[1], cellList[8], 1));
                break;
            case 5:
                StartCoroutine(changeImageSprite(currentThema.mine, cellList[8], 1));
                StartCoroutine(changeImageSprite(currentThema.cellSprite[5], cellList[4], 1));
                StartCoroutine(changeImageSprite(currentThema.cellSprite[2], cellList[7], 1));
                break;
            case 6:

                StartCoroutine(changeImageSprite(currentThema.mine, cellList[7], 1));
                StartCoroutine(changeImageSprite(currentThema.cellSprite[6], cellList[4], 1));
                StartCoroutine(changeImageSprite(currentThema.cellSprite[1], cellList[6], 1));
                StartCoroutine(changeImageSprite(currentThema.cellSprite[3], cellList[3], 1));
                break;
            case 7:
                StartCoroutine(changeImageSprite(currentThema.mine, cellList[6], 1));
                StartCoroutine(changeImageSprite(currentThema.cellSprite[7], cellList[4], 1));
                StartCoroutine(changeImageSprite(currentThema.cellSprite[4], cellList[3], 1));
                break;
            case 8:
                StartCoroutine(changeImageSprite(currentThema.mine, cellList[3], 1));
                StartCoroutine(changeImageSprite(currentThema.cellSprite[8], cellList[4], 1));
                StartCoroutine(changeImageSprite(tick, nextButton.GetComponent<Image>(), 1));
                break;
            case 9:
                part1.hideAnimation();
                yield return new WaitForSeconds(1);
                part2.haricEkle(part2.gameObject).showAnimation();
                break;
        }
        nextButton.enabled = false;
        yield return new WaitForSeconds(1);
        nextButton.enabled = true;
    }


    IEnumerator changeImageSprite(Sprite newImage,Image icon,float animationTime,float delay = 0)
    {
        iTween.ScaleTo(icon.gameObject,iTween.Hash("scale",new Vector3(0,0,0),"time", animationTime/2,"delay", delay, "easeType",iTween.EaseType.easeInElastic));
        yield return new WaitForSeconds(animationTime / 2 + delay);
        iTween.ScaleTo(icon.gameObject, iTween.Hash("scale", new Vector3(1,1,1), "time", animationTime / 2, "easeType", iTween.EaseType.easeOutElastic));
        icon.sprite = newImage;
    }
    #endregion

    #region Part2
    public void activeCellClick(int index)
    {
        StartCoroutine(changeImageSprite(currentThema.flag, activeCell[index],1));
        activeCell[index].GetComponent<Button>().enabled = false;
        flagCounter++;
        flagCount.text = flagCounter.ToString();
        moveCount.text = flagCounter.ToString();
        if(flagCounter == 5)
        {
            for(int i = 0; i< part2Board.transform.childCount;i++)
            {
                StartCoroutine(changeImageSprite(currentThema.cellSprite[1], part2Board.transform.GetChild(i).GetComponent<Image>(),1, i * 0.01f));
            }
            iTween.ScaleTo(tick2, iTween.Hash("scale", new Vector3(1,1,1),"easeType",iTween.EaseType.easeOutElastic , "time", .5f));
            
        }
    }
    public void flagButton()
    {
        iTween.Stop(hand);
        hand.AddComponent<AG_ObjectAnimation>().hideAnimation();
        flagArea.GetComponent<Button>().enabled = false;

        for(int i = 0; i< activeCell.Count;i++)
        {
            activeCell[i].GetComponent<Button>().enabled = true;
            iTween.ScaleTo(activeCell[i].gameObject, iTween.Hash("scale", new Vector3(.8f, .8f, .8f), "loopType", iTween.LoopType.pingPong, "time", .5f));
        }
    }

    public void button2Tick()
    {
        StartCoroutine(changeScene());
    }
    IEnumerator changeScene()
    {
        part2.haricEkle(hand).hideAnimation();
        huelogo.hideAnimation();
        mantarlogo.hideAnimation();
        yield return new WaitForSeconds(1);
        Application.LoadLevel(0);
    }
    #endregion
}
