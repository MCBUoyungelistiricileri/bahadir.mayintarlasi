using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class AG_MineSwipper : MonoBehaviour
{
	public Cell[,] board;
	public bool _firstClick = false;
	public int mineCount;
    public int rowCount, colCount;

    public Action<int,int> OnMine;
    public Action<int, int,int> OnOpenCell;
    public Action<List<Cell_Data>> OnPlaceMine;
    public void createBoard(int row, int col,int mineCount)
	{
		board = new Cell[row, col];
		this.mineCount = mineCount;
        rowCount = row;
        colCount = col;
        for(int i = 0; i<row;i++)
        {
            for(int k = 0; k<col;k++)
            {
                board[i, k] = new Cell();
                board[i, k]._cellType = Cell.cellType.normal;
            }
        }
	}

	public void onClick(int row,int col)
	{
       
		if (!_firstClick)
		{
            _firstClick = true;
            placeMine(row,col);

        }
        cellControl(row, col);
    }
    private void cellControl(int row , int col)
    {
        if(board[row,col]._cellType == Cell.cellType.mine)
        {
            OnMine(row, col);
        }
        else
        {
            int cellMineCount = 0;
            for(int i = -1; i<=1;i++)
            {
                for(int k = -1; k<=1;k++)
                {
                   

                    if(row+i >=0 && row+i <= rowCount-1 && col+k >= 0 && col+k <= colCount-1&&(i != 0 || k != 0))
                    {
                        
                            if (board[row + i, col + k]._cellType == Cell.cellType.mine)
                                cellMineCount++;
                        
                    }

                }
            }
            board[row, col].mineCount = cellMineCount;
            board[row , col ].control = true;
            OnOpenCell(row,col, cellMineCount);

            cevreKontrol(row, col);
        }

         
    }
    

    public void cevreKontrol(int row, int col)
    {

        int cellMineCount = 0;
        for (int i = -1; i <= 1; i++)
        {
            for (int k = -1; k <= 1; k++)
            {


                if (row + i >= 0 && row + i <= rowCount - 1 && col + k >= 0 && col + k <= colCount - 1 && (i != 0 || k != 0))
                {
                    if (board[row + i, col + k]._cellType == Cell.cellType.mine)
                        cellMineCount++;

                }

            }
        }
        board[row, col].mineCount = cellMineCount;
        board[row, col].control = true;
        OnOpenCell(row, col, cellMineCount);

        if (cellMineCount == 0)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int k = -1; k <= 1; k++)
                {


                    if (row + i >= 0 && row + i <= rowCount - 1 && col + k >= 0 && col + k <= colCount - 1 && (i != 0 || k != 0))
                    {

                        if (board[row + i, col + k]._cellType != Cell.cellType.mine && board[row + i, col + k].control == false)
                            cevreKontrol(row + i, col + k);

                    }

                }
            }
        }

    }
	private void placeMine(int currentRow, int currentCol)
	{
		int g_minecount = mineCount;
        List<Cell_Data> mineList = new List<Cell_Data>();
		while (g_minecount > 0)
		{
            int rand1 = UnityEngine.Random.Range(0,rowCount);
            int rand2 = UnityEngine.Random.Range(0, colCount);

            if(rand1 != currentRow && rand2 != currentCol && board[rand1,rand2]._cellType != Cell.cellType.mine)
            {
                board[rand1, rand2]._cellType = Cell.cellType.mine;
                mineList.Add(new Cell_Data(rand1, rand2));
                g_minecount--;
            }
		}
        OnPlaceMine(mineList);
	}
}

public class Cell
{
	public int mineCount;
	public bool control;
	public enum cellType { mine,normal };

	public cellType _cellType = cellType.normal;

}
public class Cell_Data
{
    public int row, col;

    public Cell_Data(int row, int col)
    {
        this.row = row;
        this.col = col;
    }
}