using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AG_MainMenu : MonoBehaviour {

    public Image mainPlayButton,mainStoreButton,mainTuttorialButton,mainShareButton, closeButton,mantarLogo,hueLogo;
    public GameObject storeScrol;

    public Sprite balckSprite,minusSprite,plusSprite,backSprite,storeSprite,playSprite,shareSprite,tuttorialSprite;

    public int mineCount = 10;


    public AG_ObjectAnimation mainPanel,hueAnim,mantarAnim;
    void Awake()
    {
        Application.targetFrameRate = 60;
        mainPlayButton.GetComponent<Button>().onClick.RemoveAllListeners();
        mainPlayButton.GetComponent<Button>().onClick.AddListener(delegate { StartCoroutine(waitbuttonMainplay()); });
        mainStoreButton.GetComponent<Button>().onClick.AddListener(delegate { buttonMainShop(); });
        mainTuttorialButton.GetComponent<Button>().onClick.AddListener(delegate { buttonMainTuttorial(); });
        StartCoroutine(firstAnim());
    }
    void Start()
    {
       
    }

    IEnumerator firstAnim()
    {
        mainPanel.haricEkle(mainPanel.gameObject).hideAnimation(0);
        hueAnim.hideAnimation(0);
        mantarAnim.hideAnimation(0);
        yield return new WaitForSeconds(.5f);
        mainPanel.showAnimation(1);
        hueAnim.showAnimation(1);
        mantarAnim.showAnimation(1);
    }
    IEnumerator waitbuttonMainplay()
    {
        AG_MenuSound.Instance.soundClick();
        iTween.ScaleTo(mainPlayButton.gameObject, iTween.Hash("scale", new Vector3(0, 0, 0), "time", .5f, "easeType", iTween.EaseType.easeInElastic));
        iTween.RotateTo(mainPlayButton.gameObject, iTween.Hash("z", 270, "time", .5f, "easeType", iTween.EaseType.easeInElastic));
        yield return new WaitForSeconds(.5f);
        iTween.RotateTo(mainPlayButton.gameObject, iTween.Hash("z", 0, "time", .5f, "easeType", iTween.EaseType.easeOutElastic));
        iTween.ScaleTo(mainPlayButton.gameObject, iTween.Hash("scale", new Vector3(1, 1, 1), "time", .5f, "easeType", iTween.EaseType.easeOutElastic));
        mainPlayButton.sprite = balckSprite;
        mainPlayButton.transform.GetChild(0).gameObject.active = true;
        iTween.ScaleTo(mainStoreButton.gameObject, iTween.Hash("scale", new Vector3(0, 0, 0), "time", .5f, "easeType", iTween.EaseType.easeInElastic));
        iTween.ScaleTo(mainShareButton.gameObject, iTween.Hash("scale", new Vector3(0, 0, 0), "time", .5f, "easeType", iTween.EaseType.easeInElastic));
        iTween.ScaleTo(mainTuttorialButton.gameObject, iTween.Hash("scale", new Vector3(0, 0, 0), "time", .5f, "easeType", iTween.EaseType.easeInElastic));
        yield return new WaitForSeconds(.5f);
        
        iTween.ScaleTo(mainStoreButton.gameObject, iTween.Hash("scale", new Vector3(1,1,1), "time", .5f, "easeType", iTween.EaseType.easeOutElastic));
        iTween.ScaleTo(mainShareButton.gameObject, iTween.Hash("scale", new Vector3(1,1,1), "time", .5f, "easeType", iTween.EaseType.easeOutElastic));
        iTween.ScaleTo(mainTuttorialButton.gameObject, iTween.Hash("scale", new Vector3(1, 1, 1), "time", .5f, "easeType", iTween.EaseType.easeOutElastic));

        mainStoreButton.sprite = minusSprite;
        mainShareButton.sprite = plusSprite;
        mainPlayButton.sprite = balckSprite;
        mainTuttorialButton.sprite = backSprite;

        mainShareButton.GetComponent<Button>().onClick.RemoveAllListeners();
        mainShareButton.GetComponent<Button>().onClick.AddListener(delegate { plusMinusFunction(1); });

        mainStoreButton.GetComponent<Button>().onClick.RemoveAllListeners();
        mainStoreButton.GetComponent<Button>().onClick.AddListener(delegate { plusMinusFunction(-1); });


        mainTuttorialButton.GetComponent<Button>().onClick.RemoveAllListeners();
        mainTuttorialButton.GetComponent<Button>().onClick.AddListener(delegate {StartCoroutine( backButton()); });

        mainPlayButton.GetComponent<Button>().onClick.RemoveAllListeners();
        mainPlayButton.GetComponent<Button>().onClick.AddListener(delegate {StartCoroutine( buttonOpenGame()); });



    }
    public void buttonMainShop()
    {
        iTween.ScaleTo(storeScrol, iTween.Hash("y", 1, "time", 1, "delay", 1, "easeType", iTween.EaseType.easeOutElastic));
        iTween.ScaleTo(hueLogo.gameObject, iTween.Hash("scale", new Vector3(0,0,0), "time", 1, "easeType", iTween.EaseType.easeInElastic));
        iTween.ScaleTo(mainPlayButton.gameObject, iTween.Hash("scale", new Vector3(0, 0, 0), "time", .5f, "easeType", iTween.EaseType.easeInElastic));
        iTween.ScaleTo(mainStoreButton.gameObject, iTween.Hash("scale", new Vector3(0,0,0), "time", .5f,"delay",.5f, "easeType", iTween.EaseType.easeInElastic));
        iTween.ScaleTo(mainShareButton.gameObject, iTween.Hash("scale", new Vector3(0, 0, 0), "time", .5f, "delay", .5f, "easeType", iTween.EaseType.easeInElastic));
        iTween.ScaleTo(mainTuttorialButton.gameObject, iTween.Hash("scale", new Vector3(0, 0, 0), "time", .5f, "delay", .5f, "easeType", iTween.EaseType.easeInElastic));
        iTween.ScaleTo(closeButton.gameObject, iTween.Hash("scale", new Vector3(1,1,1), "time", .5f, "delay", .5f, "easeType", iTween.EaseType.easeOutElastic));

        mantarLogo.GetComponent<AG_ObjectAnimation>().hideAnimation();
        AG_MenuSound.Instance.soundClick();
    }
    public void openMainMenu()
    {
        iTween.ScaleTo(storeScrol, iTween.Hash("y", 0, "time", 1, "easeType", iTween.EaseType.easeInElastic));
        iTween.ScaleTo(hueLogo.gameObject, iTween.Hash("scale", new Vector3(1,1,1), "time", 1, "delay", 1, "easeType", iTween.EaseType.easeOutElastic));
        iTween.ScaleTo(mainPlayButton.gameObject, iTween.Hash("scale", new Vector3(1,1,1), "time", .5f, "delay", 1f, "easeType", iTween.EaseType.easeOutElastic));
        iTween.ScaleTo(mainStoreButton.gameObject, iTween.Hash("scale", new Vector3(1, 1, 1), "time", .5f, "delay", 1f, "easeType", iTween.EaseType.easeOutElastic));
        iTween.ScaleTo(mainShareButton.gameObject, iTween.Hash("scale", new Vector3(1, 1, 1), "time", .5f, "delay", 1f, "easeType", iTween.EaseType.easeOutElastic));
        iTween.ScaleTo(mainTuttorialButton.gameObject, iTween.Hash("scale", new Vector3(1, 1, 1), "time", .5f, "delay", 1f, "easeType", iTween.EaseType.easeOutElastic));
        iTween.ScaleTo(closeButton.gameObject, iTween.Hash("scale", new Vector3(0,0,0), "time", .5f, "easeType", iTween.EaseType.easeInElastic));

        mantarLogo.GetComponent<AG_ObjectAnimation>().showAnimation();
        AG_MenuSound.Instance.soundClick();
    }
    public void buttonMainTuttorial()
    {
        StartCoroutine(buttonMainTuttorialBekle());
        AG_MenuSound.Instance.soundClick();
    }
    IEnumerator buttonMainTuttorialBekle()
    {
        mainPanel.hideAnimation(1);
        hueAnim.hideAnimation(1);
        mantarAnim.hideAnimation(1);
        yield return new WaitForSeconds(1);
        Application.LoadLevel(2);
       
    }
    public void buttonMainShare()
    {

    }
    IEnumerator buttonOpenGame()
    {
        AG_MenuSound.Instance.soundClick();
        PlayerPrefs.SetInt("MantarGames_Hue_MineCount",mineCount);
        mainPlayButton.GetComponent<AG_ObjectAnimation>().hideAnimation();
        mainShareButton.GetComponent<AG_ObjectAnimation>().hideAnimation();
        mainStoreButton.GetComponent<AG_ObjectAnimation>().hideAnimation();
        mainTuttorialButton.GetComponent<AG_ObjectAnimation>().hideAnimation();
        mantarLogo.GetComponent<AG_ObjectAnimation>().hideAnimation();
        hueLogo.GetComponent<AG_ObjectAnimation>().hideAnimation();
        yield return new WaitForSeconds(1);
        Application.LoadLevel(1);
    }


    public void plusMinusFunction(int durum)
    {
        AG_MenuSound.Instance.soundClick();
        if (mineCount+durum >= 10 && mineCount+durum <=50)
        {
            mineCount += durum;
            mainPlayButton.transform.GetChild(0).GetComponent<Text>().text = mineCount.ToString();
        }
    }

    IEnumerator  backButton()
    {
        AG_MenuSound.Instance.soundClick();
        float animationTime = .3f;
        iTween.ScaleTo(mainTuttorialButton.gameObject, iTween.Hash("scale", new Vector3(0, 0, 0), "time", .5f, "easeType", iTween.EaseType.easeInElastic));
        iTween.ScaleTo(mainStoreButton.gameObject, iTween.Hash("scale", new Vector3(0, 0, 0), "time", .5f, "easeType", iTween.EaseType.easeInElastic));
        iTween.ScaleTo(mainShareButton.gameObject, iTween.Hash("scale", new Vector3(0, 0, 0), "time", .5f, "easeType", iTween.EaseType.easeInElastic));
        yield return new WaitForSeconds(.5f);

        iTween.ScaleTo(mainTuttorialButton.gameObject, iTween.Hash("scale", new Vector3(1,1,1), "time", .5f, "easeType", iTween.EaseType.easeOutElastic));
        iTween.ScaleTo(mainStoreButton.gameObject, iTween.Hash("scale", new Vector3(1,1,1), "time", .5f, "easeType", iTween.EaseType.easeOutElastic));
        iTween.ScaleTo(mainShareButton.gameObject, iTween.Hash("scale", new Vector3(1,1,1), "time", .5f, "easeType", iTween.EaseType.easeOutElastic));
        iTween.ScaleTo(mainPlayButton.gameObject, iTween.Hash("scale", new Vector3(0, 0, 0), "time", .5f, "easeType", iTween.EaseType.easeInElastic));
        mainTuttorialButton.sprite = tuttorialSprite;
        mainStoreButton.sprite = storeSprite;
        mainShareButton.sprite = shareSprite;

        yield return new WaitForSeconds(.5f);
        iTween.ScaleTo(mainPlayButton.gameObject, iTween.Hash("scale", new Vector3(1, 1, 1), "time", .5f, "easeType", iTween.EaseType.easeOutElastic));
        mainPlayButton.sprite = playSprite;
        mainPlayButton.transform.GetChild(0).gameObject.active = false;


        mainShareButton.GetComponent<Button>().onClick.RemoveAllListeners();
        mainShareButton.GetComponent<Button>().onClick.AddListener(delegate { buttonMainShare(); });

        mainStoreButton.GetComponent<Button>().onClick.RemoveAllListeners();
        mainStoreButton.GetComponent<Button>().onClick.AddListener(delegate { buttonMainShop(); });


        mainTuttorialButton.GetComponent<Button>().onClick.RemoveAllListeners();
        mainTuttorialButton.GetComponent<Button>().onClick.AddListener(delegate { buttonMainTuttorial(); });

        mainPlayButton.GetComponent<Button>().onClick.RemoveAllListeners();
        mainPlayButton.GetComponent<Button>().onClick.AddListener(delegate { StartCoroutine(waitbuttonMainplay()); });

    }
}
