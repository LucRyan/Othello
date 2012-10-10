using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS541_Final_Project
{
    class Alg_1
    {
        private static int[][] scoreList = new int[8][];
 
        public Alg_1()
        {
            for (int i = 0; i < 8; i++)
            {
                scoreList[i] = new int[8];
            }

            scoreList[0][0] = 20;
            scoreList[0][1] = -3;
            scoreList[0][2] = 11;
            scoreList[0][3] = 8;
            scoreList[0][4] = 8;
            scoreList[0][5] = 11;
            scoreList[0][6] = -3;
            scoreList[0][7] = 8;
            
            scoreList[1][0] = -3;
            scoreList[1][1] = -7;
            scoreList[1][2] = -4;
            scoreList[1][3] = 1;
            scoreList[1][4] = 1;
            scoreList[1][5] = -4;
            scoreList[1][6] = -7;
            scoreList[1][7] = -3;

            scoreList[2][0] = 11;
            scoreList[2][1] = -4;
            scoreList[2][2] = 2;
            scoreList[2][3] = 2;
            scoreList[2][4] = 2;
            scoreList[2][5] = 2;
            scoreList[2][6] = -4;
            scoreList[2][7] = 11;

            scoreList[3][0] = 8;
            scoreList[3][1] = 1;
            scoreList[3][2] = 2;
            scoreList[3][3] = 3;
            scoreList[3][4] = 3;
            scoreList[3][5] = 2;
            scoreList[3][6] = 1;
            scoreList[3][7] = 8;

            scoreList[4][0] = 8;
            scoreList[4][1] = 1;
            scoreList[4][2] = 2;
            scoreList[4][3] = 3;
            scoreList[4][4] = 3;
            scoreList[4][5] = 2;
            scoreList[4][6] = 1;
            scoreList[4][7] = 8;

            scoreList[5][0] = 11;
            scoreList[5][1] = -4;
            scoreList[5][2] = 2;
            scoreList[5][3] = 2;
            scoreList[5][4] = 2;
            scoreList[5][5] = 2;
            scoreList[5][6] = -4;
            scoreList[5][7] = 11;

            scoreList[6][0] = -3;
            scoreList[6][1] = -7;
            scoreList[6][2] = -4;
            scoreList[6][3] = 1;
            scoreList[6][4] = 1;
            scoreList[6][5] = -4;
            scoreList[6][6] = -7;
            scoreList[6][7] = -3;

            scoreList[7][0] = 20;
            scoreList[7][1] = -3;
            scoreList[7][2] = 11;
            scoreList[7][3] = 8;
            scoreList[7][4] = 8;
            scoreList[7][5] = 11;
            scoreList[7][6] = -3;
            scoreList[7][7] = 8;
        }

        public static int GetScore(int p,int[][] chessList)
        {
            for (int i = 0; i < 8; i++)
            {
                scoreList[i] = new int[8];
            }

            scoreList[0][0] = 20;
            scoreList[0][1] = -3;
            scoreList[0][2] = 11;
            scoreList[0][3] = 8;
            scoreList[0][4] = 8;
            scoreList[0][5] = 11;
            scoreList[0][6] = -3;
            scoreList[0][7] = 8;

            scoreList[1][0] = -3;
            scoreList[1][1] = -7;
            scoreList[1][2] = -4;
            scoreList[1][3] = 1;
            scoreList[1][4] = 1;
            scoreList[1][5] = -4;
            scoreList[1][6] = -7;
            scoreList[1][7] = -3;

            scoreList[2][0] = 11;
            scoreList[2][1] = -4;
            scoreList[2][2] = 2;
            scoreList[2][3] = 2;
            scoreList[2][4] = 2;
            scoreList[2][5] = 2;
            scoreList[2][6] = -4;
            scoreList[2][7] = 11;

            scoreList[3][0] = 8;
            scoreList[3][1] = 1;
            scoreList[3][2] = 2;
            scoreList[3][3] = 3;
            scoreList[3][4] = 3;
            scoreList[3][5] = 2;
            scoreList[3][6] = 1;
            scoreList[3][7] = 8;

            scoreList[4][0] = 8;
            scoreList[4][1] = 1;
            scoreList[4][2] = 2;
            scoreList[4][3] = 3;
            scoreList[4][4] = 3;
            scoreList[4][5] = 2;
            scoreList[4][6] = 1;
            scoreList[4][7] = 8;

            scoreList[5][0] = 11;
            scoreList[5][1] = -4;
            scoreList[5][2] = 2;
            scoreList[5][3] = 2;
            scoreList[5][4] = 2;
            scoreList[5][5] = 2;
            scoreList[5][6] = -4;
            scoreList[5][7] = 11;

            scoreList[6][0] = -3;
            scoreList[6][1] = -7;
            scoreList[6][2] = -4;
            scoreList[6][3] = 1;
            scoreList[6][4] = 1;
            scoreList[6][5] = -4;
            scoreList[6][6] = -7;
            scoreList[6][7] = -3;

            scoreList[7][0] = 20;
            scoreList[7][1] = -3;
            scoreList[7][2] = 11;
            scoreList[7][3] = 8;
            scoreList[7][4] = 8;
            scoreList[7][5] = 11;
            scoreList[7][6] = -3;
            scoreList[7][7] = 8;

            int Score = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (chessList[i][j] == p)
                    {
                        Score += scoreList[i][j];
                    }
                }
            }
            return Score;
        }

        public static int GetMaxScore(State PossibleState)
        {
            if (PossibleState.Child.Count == 1) return -20;//The enemy does not have any step to go
            else
            {
                int MaxScore = -50;
                for (int i = 1; i < PossibleState.Child.Count; i++)
                {
                    int ScoreGet=GetScore(PossibleState.NextPlayer,PossibleState.Board);
                    if (ScoreGet > MaxScore)
                    {
                        MaxScore = ScoreGet;
                    }
                }
                return MaxScore;
            }
        }

        public static int NextStep(State CurrentState)
        {
            if (CurrentState.Child.Count == 1) return 0;//no next step to go
            else
            {
                int CurrentMaxScore = 5000;
                int BestChild = -1;
                for (int i = 1; i < CurrentState.Child.Count; i++)
                {
                    int MaxScoreGet = GetMaxScore(CurrentState.Child[i]);
                    if (MaxScoreGet < CurrentMaxScore)//better because enemy get smaller score
                    {
                        BestChild = i;
                    }
                    else if (MaxScoreGet == CurrentMaxScore)//Two steps will result in enemy get same max score
                    {
                        if (Alg_1.GetScore(CurrentState.NextPlayer, CurrentState.Child[i].Board) > Alg_1.GetScore(CurrentState.NextPlayer, CurrentState.Child[BestChild].Board))//Better if it self get higher score
                        {
                            BestChild = i;
                        }

                    }
                }
                return BestChild;
            }
        }
    }
}


