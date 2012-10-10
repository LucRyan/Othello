using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CS541_Final_Project
{
    public class ChessAbs
    {
        Rules rules = new Rules();
        int Player = 0;
        int[][] ChessList = new int[8][];
        public ChessAbs(List<ChessItem> AllChess, int CurrentPlayer)
        {
            this.AllChess = AllChess;
            this.Player = CurrentPlayer;
            for (int i = 0; i < 8; i++)
            {
                ChessList[i] = new int[8];
                for (int j = 0; j < 8; j++)
                {
                    if (AllChess[i * 8 + j].Visible == false)
                    {
                        ChessList[i][j] = -1;
                    }
                    else
                    {
                        if (AllChess[i * 8 + j].ChessColor == ChessItem.cColor.black)
                        {
                            ChessList[i][j] = 7;
                        }
                        else
                        {
                            ChessList[i][j] = 0;
                        }
                    }
                }
            }
        }

        public bool ChessIsValid(ChessItem next)
        {
            Rules rules = new Rules();
            return false;
        }

        public List<ChessItem> AllChess {get;set;}

        //public int[] ShowAvailability()
        //{
        //    int[][] availableChess = Rules.getAvailable(this.Player,this.ChessList);
        //    int[] availableInt = new int[8];
        //    for (int i = 0; i < availableChess.Length;i++ )
        //    {

        //    }
        //}

        public int[][] GetChessIntArray(List<ChessItem> AllChesses)
        {
            ChessItem CI;
            int[][] ChessIntArray = new int[8][];
            for (int i = 0; i < 8; i++)
            {
                ChessIntArray[i] = new int[8];
                for (int j = 0; j < 8; j++)
                {
                    CI = AllChess[i * 8 + j];
                    if (CI.Visible == true)
                    {

                        if (CI.ChessColor == ChessItem.cColor.white)
                        {
                            ChessIntArray[i][j] = 0;
                        }
                        else
                        {
                            ChessIntArray[i][j] = 7;
                        }
                    }
                    else
                        ChessIntArray[i][j] = -1;
                }
            }
            return ChessIntArray;
        }
    }
}