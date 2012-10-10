using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Sockets;

namespace CS541_Final_Project
{
    public class Alg_2
    {
        private int[][] scoreList = new int[8][];
        int SearchLeve;
        private int Enemy;

        public Alg_2()
        {
            SearchLeve = 10;
            Enemy = 0;//Must be changed;
            for (int i = 0; i < 8; i++)
            {
                scoreList[i] = new int[8];
            }

            scoreList[0][0] = 99;
            scoreList[0][1] = -8;
            scoreList[0][2] = 8;
            scoreList[0][3] = 6;
            scoreList[0][4] = 6;
            scoreList[0][5] = 8;
            scoreList[0][6] = -8;
            scoreList[0][7] = 99;

            scoreList[1][0] = -8;
            scoreList[1][1] = -24;
            scoreList[1][2] = -4;
            scoreList[1][3] = -3;
            scoreList[1][4] = -3;
            scoreList[1][5] = -4;
            scoreList[1][6] = -24;
            scoreList[1][7] = -8;

            scoreList[2][0] = 8;
            scoreList[2][1] = -4;
            scoreList[2][2] = 7;
            scoreList[2][3] = 4;
            scoreList[2][4] = 4;
            scoreList[2][5] = 7;
            scoreList[2][6] = -4;
            scoreList[2][7] = 8;

            scoreList[3][0] = 6;
            scoreList[3][1] = -3;
            scoreList[3][2] = 4;
            scoreList[3][3] = 0;
            scoreList[3][4] = 0;
            scoreList[3][5] = 4;
            scoreList[3][6] = -3;
            scoreList[3][7] = 6;

            scoreList[4][0] = 6;
            scoreList[4][1] = -3;
            scoreList[4][2] = 4;
            scoreList[4][3] = 0;
            scoreList[4][4] = 0;
            scoreList[4][5] = 4;
            scoreList[4][6] = -3;
            scoreList[4][7] = 6;

            scoreList[5][0] = 8;
            scoreList[5][1] = -4;
            scoreList[5][2] = 7;
            scoreList[5][3] = 4;
            scoreList[5][4] = 4;
            scoreList[5][5] = 7;
            scoreList[5][6] = -4;
            scoreList[5][7] = 8;

            scoreList[6][0] = -8;
            scoreList[6][1] = -24;
            scoreList[6][2] = -4;
            scoreList[6][3] = -3;
            scoreList[6][4] = -3;
            scoreList[6][5] = -4;
            scoreList[6][6] = -24;
            scoreList[6][7] = -8;

            scoreList[7][0] = 99;
            scoreList[7][1] = -8;
            scoreList[7][2] = 8;
            scoreList[7][3] = 6;
            scoreList[7][4] = 6;
            scoreList[7][5] = 8;
            scoreList[7][6] = -8;
            scoreList[7][7] = 99;
        }

        public void SetEnemy(int Enemyy)
        {
            this.Enemy = Enemyy;
        }

        public int GetPositionScore(State aState)
        {
            aState.PositionScore7 = 0;
            aState.PositionScore0 = 0;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (aState.Board[i][j] == Enemy)
                    {
                        aState.PositionScore7 += scoreList[i][j];
                    }
                }
            }

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (aState.Board[i][j] == 7 - Enemy)
                    {
                        aState.PositionScore0 += scoreList[i][j];
                    }
                }
            }

            return aState.PositionScore7 - aState.PositionScore0;
        }

        public void generateLevelChild(State aState,int currentLevel )
        {
            if (currentLevel == SearchLeve-1) return;
            aState.GenerateChild();

            if (aState.AvailablePosition[0].Count != 0)
            {
                for (int i = 1; i < aState.AvailablePosition[0].Count + 1; i++)
                {
                    generateLevelChild(aState.Child[i], currentLevel + 1);
                }
            }
            else//No step to go;
            {
                generateLevelChild(aState.Child[0], currentLevel + 1);
            }
        }

        private int Numberr1;
        private int Numberr2;
        private int Numberr3;

        public void AddTwoLevelChild(State aState, int CurrentLevel)
        {
            if (CurrentLevel == SearchLeve - 2)
            {
                aState.GenerateChild();
                Numberr1++;
                if (aState.AvailablePosition[0].Count != 0)
                {
                    for (int i = 1; i < aState.AvailablePosition[0].Count + 1; i++)
                    {
                        aState.Child[i].GenerateChild();
                        Numberr2++;
                        Numberr3 += aState.Child[i].AvailablePosition[0].Count;
                    }
                }
                else//No step to go;
                {
                    aState.Child[0].GenerateChild();
                    Numberr2++;
                }
                return;
            }
            else
            {
                if (aState.AvailablePosition[0].Count != 0)
                {
                    for (int i = 1; i < aState.AvailablePosition[0].Count + 1; i++)
                    {
                        AddTwoLevelChild(aState.Child[i], CurrentLevel + 1);
                    }
                }
                else//No step to go;
                {
                    AddTwoLevelChild(aState.Child[0], CurrentLevel + 1);
                }
            }
        }

        public double evaluation(State aState)
        {
            int step = Rules.countStep(aState.Board);

            double positionScore = (double)GetPositionScore(aState);
            double score = 0.0;
            double stableEnemy = (double)(stableCheck.stableCount(aState.Board, Enemy));
            double stableMe = (double)(stableCheck.stableCount(aState.Board, 7 - Enemy));

            double stable = stableEnemy - stableMe;

            double mobility = -(double)(aState.AvailablePosition[0].Count);
            double number = (double)(Rules.countMyself(aState.Board, Enemy));

                if (step <= 8)
                {
                    score = 1.0 * mobility + 2.0 * stable - 0.5 * number + 1.0 * positionScore;
                }
                else if (step >= 8 && step <= 48)
                {
                    score = 2.0 * mobility + 8.0 * stable - 0.5 * number + 4.0 * positionScore;
                }
                else if (step >= 48 && step <= 64)
                {
                    score = 1.0 * mobility + 3.0 * stable + 0.8 * number + 1.0 * positionScore;
                }
            return score;
            /*
            int[][] Corner = new int[8][];

            for (int i = 0; i < 8; i++)
            {
                Corner[i] = new int[8];
                for (int j = 0; j < 8; j++)
                {
                    Corner[i][j] = 0;
                }
            }

            Corner[0][0] = 8;
            Corner[0][1] = -4;
            Corner[1][0] = -4;
            Corner[1][1] = -6;
           
            Corner[0][7] = 8;
            Corner[1][7] = -4;
            Corner[0][6] = -4;
            Corner[1][6] = -6;
            
            Corner[7][0] = 8;
            Corner[6][0] = -4;
            Corner[7][1] = -4;
            Corner[6][1] = -6;
            
            Corner[7][7] = 8;
            Corner[7][6] = -4;
            Corner[6][7] = -4;
            Corner[6][6] = -6;
            */
        }

        public int GetLarger(int a, int b)
        {
            if (a >= b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        public int GetLess(int a, int b)
        {
            if (a <= b)
            {
                return a;
            }
            else
            {
                return b;
            }
        }

        public int Search(State aState, int depth, int pass)
        {
            int best_value = -5000;
            int best_value2 = 5000;
            if (depth == 0)
            {
                aState.EstValue = (int)evaluation(aState);
                return aState.EstValue;
            }
            for (int i = 1; i < aState.AvailablePosition[0].Count+1; i++)
            {
                int value=Search(aState.Child[i],depth-1,0);//Search the child
                if (aState.NextPlayer == Enemy)
                {
                    best_value = GetLarger(best_value, value);
                    aState.EstValue = best_value;
                }
                else
                {
                    best_value2 = GetLess(best_value2, value);
                    aState.EstValue = best_value2;
                }
            }
            if (aState.AvailablePosition[0].Count == 0)//No step to move next;
            {
                best_value = Search(aState.Child[0], depth - 1, 0);
                aState.EstValue = best_value;
            }
            return aState.EstValue;
        }

        public int NextStep(State aState)
        {
            int alpha =99600;
            int beta = -99600;
            int TopVal = alpha_beta(aState, ref alpha, ref beta, SearchLeve, 0);
            //int TopVal = Search(aState, SearchLeve, 0);
            for (int i = 1; i < aState.AvailablePosition[0].Count + 1; i++)
            {
                if (aState.Child[i].EstValue == TopVal)
                {
                    return i;
                }
            }
            return 0;
        }

        public State EnemyMatch(State Current, State aState, int x, int y)
        {
            State Current0;
            bool WrongMove = false;
            if (aState.AvailablePosition[0].Count == 0)
            {
                MessageBox.Show("You do not have move!");
                Current0 = aState.Child[0];//No chess to go;
                return Current0;
            }

            for (int i = 0; i < aState.AvailablePosition[0].Count; i++)
            {
                if (aState.AvailablePosition[0][i] == x && aState.AvailablePosition[1][i] == y)
                {
                    Current0 = aState.Child[i + 1];//The current is updated to the enemy's finished state
                    aState.DisposeAllButOne(i + 1);
                    return Current0;
                }
            }
            if (WrongMove == false)//The enemy make wrong move;
            {
                MessageBox.Show("Wrong Move! Go next Available!");
                if (aState.AvailablePosition[0].Count == 0)
                {
                    Current0 = aState.Child[0];//No chess to go;
                    return Current0;
                }
                else
                {
                    aState.DisposeAllButOne(1);
                    Current0 = aState.Child[1];//The current is updated to the enemy's finished state
                    return Current0;
                }
            }
            Current0 = aState;
            return Current0;
        }

        public int ProcessNext(ref State Current, State aState, int total)
        {
            int x = total / 8;
            int y = total % 8;
            //int y = Int32.Parse(textBox2.Text);
            int AssumeChild = 0;
            int nextMove = 0;

            aState.GenerateToAllChild();

            Current=EnemyMatch(Current,aState,x,y);//global "Current" is the enemy's state now, update enemy state's board;
  
            //AddTwoLevelChild(Current,0);//Initialzie the states which self may put, the available position is also calculated

            AssumeChild = NextStep(Current);

            if (AssumeChild != 0)
            {
                nextMove = Current.AvailablePosition[0][AssumeChild - 1] * 8 + Current.AvailablePosition[1][AssumeChild - 1];
            }
            else
            {
                MessageBox.Show("I have no way to go");
                nextMove = 64;
            }

            Current.DisposeAllButOne(AssumeChild);
            Current = Current.Child[AssumeChild];//update the current child;
            return nextMove;
        }

        public void InitTree(State Current, State aState)
        {
            Current = aState;
            generateLevelChild(Current, 0);
        }

        public int alpha_beta(State aState, ref int alpha, ref int beta, int depth, int passed)
        {
            int alpha_img=alpha;
            int beta_img=beta;
           
            int best_value1 = -50000;
            int best_value2 = 50000;

            if (depth == 0)
            {
                aState.EstValue = (int)evaluation(aState);
                return aState.EstValue;
            }
            for (int i = 1; i < aState.AvailablePosition[0].Count + 1; i++)
            {
                aState.GenerateSingle(i);//if this child has been generated, the function won't generate it more
                int value = alpha_beta(aState.Child[i], ref alpha_img, ref beta_img, depth - 1, 0);
               
                if (aState.NextPlayer != Enemy)//get min
                {
                    if (value < best_value2)//update best_value2
                    {
                        best_value2 = value;
                    }
                    if (best_value2 < beta )//pruning
                    {
                        aState.EstValue = best_value2;
                        return best_value2;
                    }
                }
                else//get max
                {
                    if (value > best_value1)
                    {
                        best_value1 = value;
                    }
                    if (best_value1 > beta)//pruning
                    {
                        aState.EstValue = best_value1;
                        return best_value1;
                    }
                }
            }

            if (aState.AvailablePosition[0].Count == 0)//No step to move next;
            {
                aState.GenerateSingle(0);
                int value = alpha_beta(aState.Child[0], ref beta_img, ref alpha_img, depth - 1, 0);
                if (aState.NextPlayer != Enemy)
                {
                    best_value2 = value;
                    aState.EstValue = best_value2;
                }
                else
                {
                    best_value1 = value;
                    aState.EstValue=best_value1;
                }
            }

            //Not pruning, change alpha and beta;
            if (aState.NextPlayer != Enemy)//get min
            {
                beta = best_value2;
                aState.EstValue = beta;
                return beta;
            }
            else
            {
                beta = best_value1;
                aState.EstValue = beta;
                return beta;
            }

        }
    }
}
