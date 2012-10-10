using System;
using System.Collections;
using System.Collections.Generic;


namespace CS541_Final_Project
{
    public class State
    {
        public int[][] Board = new int[8][];
        public List<State> Child { set; get; }
        public State Parent { get; set; }
        public int NextPlayer { get; set; }
        public List<int>[] AvailablePosition = new List<int>[2];

        public int EstValue;
        public int StableScore0;
        public int StableScore7;
        public int PositionScore0;
        public int PositionScore7;
        public int MobilityScore0;
        public int MobilityScore7;
        public int ChildGenerated;

        public State()
        {
            AvailablePosition[0] = new List<int>();
            AvailablePosition[1] = new List<int>();

            ChildGenerated = -1;

            Child = new List<State>();

            for (int i = 0; i < 8; i++)
            {
                this.Board[i] = new int[8];
                for (int j = 0; j < 8; j++)
                {
                    this.Board[i][j] = -1;
                }
            }
            EstValue = -5800;
        }

        public State(State Parents)
        {
            AvailablePosition[0] = new List<int>();
            AvailablePosition[1] = new List<int>();

            this.Parent = Parents;

            ChildGenerated = -1;

            Child = new List<State>();

            for (int i = 0; i < 8; i++)
            {
                this.Board[i] = new int[8];
                for (int j = 0; j < 8; j++)
                {
                    this.Board[i][j] = Parents.Board[i][j];
                }
            }

            EstValue = -5800;
            this.NextPlayer = 7 - Parents.NextPlayer;
        }

        public bool GenerateChild()
        {
            if (this.ChildGenerated != -1)
            {
                return false;
            }

            for (int i = 0; i < AvailablePosition[0].Count + 1; i++)//Initialize all the children
            {
                this.Child.Add(new State(this));
                this.Child[i].NextPlayer = 7 - this.NextPlayer;
            }

           /* if(AvailablePosition[0].Count == 0){//No next step to go
                this.Child[0].NextPlayer = 7-this.NextPlayer;
            }*/

            for (int i = 0; i < AvailablePosition[0].Count; i++)//initialzie all the non-null child
            {
                Rules.setChessCheck(this.AvailablePosition[0][i], this.AvailablePosition[1][i], this.NextPlayer, this.Child[i+1].Board, true);//update the board of its child
                Rules.getAvailableList(this.Child[i+1].NextPlayer, this.Child[i+1].Board, this.Child[i+1].AvailablePosition);//get child's available position list
                this.ChildGenerated = AvailablePosition[0].Count;
            }

            if (AvailablePosition[0].Count == 0)//No next step to go
            {
                //Rules.setChessCheck(this.AvailablePosition[0][i], this.AvailablePosition[1][i], this.NextPlayer, this.Child[i + 1].Board, true);//update the board of its child
                Rules.getAvailableList(this.Child[0].NextPlayer, this.Child[0].Board, this.Child[0].AvailablePosition);//get child's available position list
                this.ChildGenerated = 0;
            }
            return true;
        }

        public bool GenerateSingle(int given)
        {
            if (ChildGenerated >= given)//this child has been generated
            {
                return false;
            }
            if (this.AvailablePosition[0].Count > 0)
            {
                if (this.ChildGenerated < this.AvailablePosition[0].Count)
                {
                    if (this.ChildGenerated == -1)//No child has ever expanded
                    {
                        this.Child.Add(new State(this));//child[0]
                        ChildGenerated = 1;
                    }
                    else
                    {
                        ChildGenerated++;
                    }
                    this.Child.Add(new State(this));
                    Rules.setChessCheck(this.AvailablePosition[0][ChildGenerated-1], this.AvailablePosition[1][ChildGenerated-1], this.NextPlayer, this.Child[ChildGenerated].Board, true);//update the board of its child
                    Rules.getAvailableList(this.Child[ChildGenerated].NextPlayer, this.Child[ChildGenerated].Board, this.Child[ChildGenerated].AvailablePosition);//get child's available position list
                    return true;
                }
                else return false;
            }
            else
            {
                if (this.ChildGenerated == -1)//No Child has ever expanded
                {
                    ChildGenerated = 0;
                    this.Child.Add(new State(this));
                    Rules.getAvailableList(this.Child[0].NextPlayer, this.Child[0].Board, this.Child[0].AvailablePosition);//get child's available position list
                    return true;
                }
                else return false;
            }
        }

        public bool GenerateToAllChild()
        {
            if (ChildGenerated >= this.AvailablePosition[0].Count)
            {
                return false;
            }

            if (ChildGenerated != -1)
            {
                for (int i = (this.ChildGenerated + 1); i < this.AvailablePosition[0].Count + 1; i++)
                {
                    this.Child.Add(new State(this));
                    Rules.setChessCheck(this.AvailablePosition[0][i - 1], this.AvailablePosition[1][i - 1], this.NextPlayer, this.Child[i].Board, true);//update the board of its child
                    Rules.getAvailableList(this.Child[i].NextPlayer, this.Child[i].Board, this.Child[i].AvailablePosition);//get child's available position list

                }
                ChildGenerated = this.AvailablePosition[0].Count;
                return true;
            }

            else
            {
                GenerateChild();//Generate all the child
                return true;
            }
        }

        public void Disposing(State aState)
        {
            if (aState.Child.Count != 0)
            {
                for (int i = 0; i < aState.Child.Count; i++)
                {
                    Disposing(aState.Child[i]);
                    aState.Child[i] = null;
                }
            }
        }

        public void DisposeAllButOne(int NotDispose)
        {
            for (int i = 0; i < this.Child.Count; i++)
            {
                if (i != NotDispose)
                {
                    Disposing(this.Child[i]);
                    this.Child[i] = null;
                }
            }
            GC.Collect();
        }
    }
}