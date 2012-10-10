using System;
using System.Collections;
using System.Collections.Generic;

namespace CS541_Final_Project
{
	public class Rules
	{

		private int[][] ChessList = new int[8][];
	    private int player;

        public Rules()
        {
            for (int i = 0; i < 8; i++)
            {
                ChessList[i] = new int[8];
            }
        }

        public int checkBlackWin()
	    {
		int countB, countW;
		countB = countW = 0;
		for (int i = 0; i < 64; i++) 
		{
            // Count all the pieces in the board.
    			if (getChess(i % 8, i / 8) == 7) 
    			{ 
                   // Start from (0,0), (1,0), ... , (7,7). And Black is 7.
    				countB++;
    			} 
    			else if (getChess(i % 8, i / 8) == 0) 
    			{ 
                    // White is 0.
    				countW++;
    			}
		    }
		    return countB > countW ? 1 : (countB == countW ? 0 : -1); 
            // if Black win then return true (1), Lose (-1), Drawn (0). 
        }

        /*
        public static int getCornerX(int[][] board, int player)
        {
            int CornerX = 0;

          
            return CornerX;
        }

        */
       
        public static int countMyself(int[][] board, int player)
        {
            int countStone = 0;
            for (int i = 0; i < 64; i++)
            {
                if (board[i % 8][i / 8] == player)
                {
                    countStone++;
                }
            }
            return countStone; 
        }

        public static int countStep(int[][] board)
        {
            int countStone = 0;
            for (int i = 0; i < 64; i++)
            {
                if (board[i % 8][i / 8] == 7 || board[i % 8][i / 8] == 7)
                {
                    countStone++;
                } 
            }
            return countStone;
        }

	    public int getChess(int x, int y) 
	    { // Get the pieces in the position.
	    	return this.ChessList[x][y];
	    }

	    public void setChess(int index, int chess) 
	    { // Set the piece in the position by 0-63. Chess: 7 is Black - 0 is White.
	    	this.ChessList[index % 8][index / 8] = chess;
	    }

    	public void setChess(int x, int y, int chess) 
    	{ // Or set piece by (x,y).
	    	this.ChessList[x][y] = chess;
	    }

    	public void setChessList(int[][] chessList)
	    {
             // update the ChessList. All the pieces.
		    for (int i = 0; i < 8; i++) 
		    {
		    	for (int j = 0; j < 8; j++) 
			    {
			    	this.ChessList[i][j] = chessList[i][j];
			    }
		    }   
	    }

    	public int[][] getChessList() 
    	{ 
    		return this.ChessList;
    	}
    
    	public int getPlayer() 
    	{
    		return this.player;
    	}

    	public void setPlayer(int player) 
	    {
	    	this.player = player;
	    }

    	public void switchPlayer() 
    	{ // Player: 7 is black , 0 is white.
    		this.player = 7 - this.player;
    	}


	/**
	 * Check whether the player could place a stone on the board. (all the board)
	 * @param p The player id
	 * @param chessList Current status of the game.
	 * @return True, the Player could play; if False, verse vice.
	 */
    	public bool checkSetChess(int p, int[][] chessList) 
    	{
    		for (int i = 0; i < 8; i++) 
    		{
    			for (int j = 0; j < 8; j++) 
    			{
    				if (chessList[i][j] < 0 && setChessCheck(i, j, p, chessList,false)) 
    				{ // ChessList < 0 represent that position has no piece. False is check the current state.
    					return true;
    				}
    			}
    		}
    		return false;
    	}
    
    	public static int[][] getAvailable(int p, int[][] chessList) 
    	{
    		int[][] chessList2 = chessListClone(chessList);
    		for (int i = 0; i < 8; i++) 
    		{
    			for (int j = 0; j < 8; j++) 
    			{
    				if (chessList2[i][j] == -1 && setChessCheck(i, j, p, chessList2,false)) 
    				{
    					chessList2[i][j] = p == 0 ? -2 : -3; // Get the available position, then set value: Player white is -2, Player black is -3.
	    			}
	    		}
	    	}
	    	return chessList2;
	    }

        public static void getAvailableList(int p, int[][] chessList, List<int>[] AvaiPosList)
        {
            int[][] chessList2 = chessListClone(chessList);
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (chessList2[i][j] == -1 && setChessCheck(i, j, p, chessList2, false))
                    {
                        AvaiPosList[0].Add(i);
                        AvaiPosList[1].Add(j);
                    }
                }
            }
        }

	/**
	 * Check whether the player could place a stone on the board. (the specific position)
	 * @param x Position X
	 * @param y Position Y
	 * @param p Player's id
	 * @param chessList Current game status
	 * @param checkall If this is true, the chessList will be the next state.
	 * @return Return whether this position could place a stone.
	 */
    	public static bool setChessCheck(int x, int y, int p, int[][] chessList, bool checkall) 
    	{
    		int[][] chessList2 = checkall ? chessList : chessListClone(chessList); // Select the chesslist; if checkall is   
    		int[] xArr = {0, 7, x, x,											   // true then get the next state of Game.
        		x > y ? x - y : 0,
    			x > y ? 7 : 7 - y + x,
    			x > y ? (x + y >= 7 ? x + y - 7 : 0) : (x + y >= 7 ? 7 : x + y),
    			x > y ? (x + y >= 7 ? 7 : y + x) : (x + y >= 7 ? x + y - 7 : 0)};
    		int[] yArr = {y, y, 0, 7,
    			x > y ? 0 : y - x,
    			x > y ? 7 - x + y : 7,
    			x > y ? (x + y >= 7 ? 7 : y + x) : (x + y >= 7 ? x + y - 7 : 0),
    			x > y ? (x + y >= 7 ? x + y - 7 : 0) : (x + y >= 7 ? 7 : x + y)};
    		bool check = false;
    		if (chessList2[x][y] < 0) 
    		{
    			chessList2[x][y] = p;
    			for (int i = 0; i < xArr.Length; i++) 
    			{
    				if ((checkall || !check) && setChessCheck(xArr[i], yArr[i], x, y, p, chessList2)) 
    				{
    					check = true;
    					//Console.WriteLine(xArr[i]+","+ yArr[i]+"=>"+x+","+  y);
    					//printChessList(chessList2);
    				}
    			}
    		}
    		return check;
    		/*if((x==0 || chessList[x-1][y]==-1) &&  (x==7 || chessList[x+1][y]==-1) &&
    		(y==0 || chessList[x][y-1]==-1) && (y==7 || chessList[x][y+1]==-1)){
    		return false;
       		}*/
	    }

        public bool PutChess(int x, int y, int p)
        {
            int[] xArr = {0, 7, x, x,											   // true then get the next state of Game.
        		x > y ? x - y : 0,
    			x > y ? 7 : 7 - y + x,
    			x > y ? (x + y >= 7 ? x + y - 7 : 0) : (x + y >= 7 ? 7 : x + y),
    			x > y ? (x + y >= 7 ? 7 : y + x) : (x + y >= 7 ? x + y - 7 : 0)};
            int[] yArr = {y, y, 0, 7,
    			x > y ? 0 : y - x,
    			x > y ? 7 - x + y : 7,
    			x > y ? (x + y >= 7 ? 7 : y + x) : (x + y >= 7 ? x + y - 7 : 0),
    			x > y ? (x + y >= 7 ? x + y - 7 : 0) : (x + y >= 7 ? 7 : x + y)};
            bool check = false;
            if (ChessList[x][y] < 0)
            {
                ChessList[x][y] = p;
                for (int i = 0; i < xArr.Length; i++)
                {
                    if ((!check) && setChessCheck(xArr[i], yArr[i], x, y,p, ChessList))
                    {
                        check = true;
                        //Console.WriteLine(xArr[i] + "," + yArr[i] + "=>" + x + "," + y);
                        //printChessList(ChessList);
                    }
                }
                //ChessList[x][y] = -1;
            }
            return check;
        }


    	public static int[][] chessListClone(int[][] chessList) 
    	{
    		int[][] chessList2 = new int[8][];
    		for (int i = 0; i < 8; i++) 
	    	{
                chessList2[i] = new int[8];
    			for (int j = 0; j < 8; j++) 
    			{
    				chessList2[i][j] = chessList[i][j];
    			}
    		}
    		return chessList2;
    	}
    
    	private static bool setChessCheck(int x1, int y1, int x2, int y2, int p, int[][] chessList) 
    	{
    		//Console.WriteLine(" from " + x1 + "," + y1 + " to " + x2 + "," + y2 + " are check to player " + p);
    		int positionX, positionY;
    		positionX = positionY = -1;
    		if (chessList[x1][y1] == p && (x1 != x2 || y1 != y2)) 
    		{
    			positionX = x1;
    			positionY = y1;
    		}
    		do 
    		{
    			if (x1 - x2 > 1) 
    			{
    				x1--;
    			}
    			if (y1 - y2 > 1) 
    			{
    				y1--;
    			}
    
    			if (1 < x2 - x1) 
    			{
    				x1++;
    			}
    
    			if (1 < y2 - y1) 
    			{
    				y1++;
    			}
    
    			if (chessList[x1][y1] == p && (x1 != x2 || y1 != y2)) 
    			{
    				positionX = x1;
    				positionY = y1;
    			} 
                else if (chessList[x1][y1] <0 && (x1 != x2 || y1 != y2)) 
    			{
    				positionX = positionY = -1;
    			}
    			//Console.WriteLine("XXXX: " + x1 + "," + y1 + "is" + positionX + "," + positionY);
    		} 
		    while (Math.Abs(x1 - x2) > 1 || Math.Abs(y1 - y2) > 1);
    		if (positionX >= 0 && positionY >= 0 && (Math.Abs(positionX - x2) > 1 || Math.Abs(
    				positionY - y2) > 1)) 
    		{
    			setChess(positionX, positionY, x2, y2, p, chessList);
    			return true;
    		}
    		return false;
    	}

    	private static void setChess(int x1, int y1, int x2, int y2, int p, int[][] chessList) 
    	{
    		//Console.WriteLine(" from " + x1 + "," + y1 + " to " + x2 + "," + y2 + " are set to player " + p);
    		chessList[x1][y1] = p;
    		do 
    		{
    			if (x1 > x2)
    			{
    				x1--;
    			}
    			if (y1 > y2) 
    			{
    				y1--;
    			}
    
	    		if (x1 < x2) 
	    		{
	    			x1++;
	    		}
    
    			if (y1 < y2) 
    			{
    				y1++;
    			}
    			chessList[x1][y1] = p;
    		} 
    		while (x1 != x2 || y1 != y2);
    	}

    	private static void printChessList(int[][] chessList) 
    	{
    		Console.WriteLine("================");
    		for (int i = 0; i < 8; i++) 
	    	{
    			for (int j = 0; j < 8; j++) 
	    		{
		    		Console.WriteLine(chessList[i][j] + 1);
			    }
			Console.WriteLine();
    		}
		Console.WriteLine("================");
        }
    }
}