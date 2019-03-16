using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AG_GameManager : MonoBehaviour {

    public AG_MineSwipper game;
    public AG_ThemaSelector thema;
    [Header("Game Settings")]
    public int mineCount;
    public int rowCount;
    public int colCount;

    public GameObject prefab;
    public GridLayoutGroup content;
    public RectTransform board;

    public Image[,] boardItem;
    public List<OpenCell> openList = new List<OpenCell>();
    public List<Cell_Data> mineList = new List<Cell_Data>();
    public static AG_GameManager Instance;

    [Header("Game Interface")]
    public Text textMoveCount;
    public Text textMineCount;
    public Text textFlagCount;
    public Text textTime;
    public Image areaFlag;
    public int moveCount = 0;
    public int flagCount = 0;
    public float time = 0;
    public bool timerStop = false;
    public bool flagMode = false;

    public GameObject mainPanel;

    public GameObject bottomMain;
    public GameObject bottomEnd;
    public GameObject gamePanel;
    void Start () {
        mineCount = PlayerPrefs.GetInt("MantarGames_Hue_MineCount");
        Instance = this;
        game = new AG_MineSwipper();
        game.createBoard(rowCount, colCount, mineCount);
        game.OnMine = OnMine;
        game.OnOpenCell = OnOpenCell;
        game.OnPlaceMine = OnPlaceMine;

        boardItem = new Image[rowCount, colCount];
        textMineCount.text = mineCount.ToString();
        textFlagCount.text = flagCount.ToString();
        createBoard();
        timerStop = true;
        StartCoroutine(anim());
        

    }
    IEnumerator anim()
    {
        Transform[] deneme = gamePanel.GetComponentsInChildren<Transform>();
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
        yield return new WaitForSeconds(1);
       

      
        gamePanel.GetComponent<AG_ObjectAnimation>().showAnimation();
        yield return new WaitForSeconds(1);
        timerStop = false;
    }
	void Update()
    {
        if (!timerStop)
        {
            time += Time.deltaTime;

            textTime.text = ((int)time / 60).ToString("00") + ":" + ((int)time % 60).ToString("00");
        }
    }
	
    public void createBoard()
    {
        float space = (content.GetComponent<RectTransform>().rect.width / 10) / (colCount - 1);

        float size = (content.GetComponent<RectTransform>().rect.width - (content.GetComponent<RectTransform>().rect.width / 10)) / colCount;


        content.cellSize = new Vector2(size, size);
        content.spacing = new Vector2(space, space);


        board.sizeDelta = new Vector2(board.sizeDelta.x, (size * (rowCount + 1)) + (space * (colCount + 1)));

        for (int  i = 0;i<rowCount;i++)
        {
            for(int k =0; k<colCount; k++)
            {
                Button button =  Instantiate(prefab, content.transform).GetComponent<Button>();
                boardItem[i, k] = button.GetComponent<Image>();
                int a = i;
                int p = k;
                button.onClick.AddListener(delegate { CellClick(a,p); });
                button.GetComponent<Image>().sprite = thema.currentThema.normal;

               
            }
        }
        thema.setThema();
    }
    public void gameCompleteControl()
    {
        int count = 0;
        for(int i = 0; i< mineList.Count;i++)
        {
           if( boardItem[mineList[i].row, mineList[i].col].GetComponent<AG_Cell>()._type == AG_Cell.cellType.flag)
            {
                count++;
            }
        }

        if(count == mineCount)
        {
            AG_Animation.Instance.completeAnimation();
            iTween.ScaleTo(bottomMain, iTween.Hash("y", 0, "time", .15f, "easeType", iTween.EaseType.easeInQuad));
            iTween.ScaleTo(bottomEnd, iTween.Hash("y", 1, "time", .15f, "easeType", iTween.EaseType.easeInOutQuad));
            timerStop = true;
        }
    }
    #region Game Event
    public void OnMine(int row, int col)
    {
        timerStop = true;
        AG_Animation.Instance.mineClickAnimation(row,col);
        iTween.ScaleTo(bottomMain, iTween.Hash("y", 0, "time", .15f, "easeType", iTween.EaseType.easeInQuad));
        iTween.ScaleTo(bottomEnd, iTween.Hash("y", 1, "time", .15f, "easeType", iTween.EaseType.easeInOutQuad));
    }
    public void OnOpenCell(int row, int col, int mineCount)
    {
        openList.Add(new OpenCell(row, col, mineCount));
    }
    public void OnPlaceMine(List<Cell_Data> list)
    {
        mineList = list;
    }
    IEnumerator bekle()
    {
        yield return new WaitForSeconds(.01f);
        AG_Animation.Instance.openCellAnimation(openList);
        openList.Clear();

    }
    #endregion


    #region ButtonClick
    public void flagModeChange()
    {
        if(flagMode == true)
        {
            areaFlag.transform.GetChild(1).GetComponent<Image>().color = AG_ThemaSelector.Instance.currentThema.iconColor;
            flagMode = false;
        }
        else
        {
            areaFlag.transform.GetChild(1).GetComponent<Image>().color = AG_ThemaSelector.Instance.currentThema.flagAreaActive;
            flagMode = true;
        }
    }

    void CellClick(int a, int p)
    {
        if(!flagMode)
        {
            if (boardItem[a, p].GetComponent<AG_Cell>()._type != AG_Cell.cellType.flag)
            {
                game.onClick(a, p);
                moveCount++;
                textMoveCount.text = moveCount.ToString();
                StartCoroutine(bekle());
            }
        }
        else
        {
           
          
            textMoveCount.text = moveCount.ToString();
            if (boardItem[a, p].GetComponent<AG_Cell>()._type == AG_Cell.cellType.flag)
            {
                moveCount++;
                boardItem[a, p].GetComponent<Image>().sprite = AG_ThemaSelector.Instance.currentThema.normal;
                boardItem[a, p].GetComponent<AG_Cell>()._type = AG_Cell.cellType.normalCell;
                flagCount--;
            }
            else if(boardItem[a, p].GetComponent<Image>().sprite == AG_ThemaSelector.Instance.currentThema.normal)
            {
                moveCount++;
                boardItem[a, p].GetComponent<Image>().sprite = AG_ThemaSelector.Instance.currentThema.flag;
                boardItem[a, p].GetComponent<AG_Cell>()._type = AG_Cell.cellType.flag;
                AG_Sound.Instance.soundFlag();
                gameCompleteControl();
                flagCount++;
            }
            textFlagCount.text = flagCount.ToString();
              

        }
    }


    public void buttonHome()
    {
        StartCoroutine(changeScene(0));
    }
    public void buttonReplay()
    {
        StartCoroutine(changeScene(1));
    }
    IEnumerator changeScene(int ID)
    {
        gamePanel.GetComponent<AG_ObjectAnimation>().hideAnimation();
        yield return new WaitForSeconds(2);
        Application.LoadLevel(ID);
    }
    #endregion




}

public class OpenCell
{
    public int row, col, mineCount;


    public OpenCell(int row, int col, int mineCount)
    {
        this.row = row;
        this.col = col;
        this.mineCount = mineCount;
    }

}
