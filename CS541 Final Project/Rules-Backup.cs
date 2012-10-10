using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CS541_Final_Project
{
    public class RulesBackup
    {
        public RulesBackup()
        {

        }
        
        public bool ChessIsValid(List<ChessItem> Chesses, ChessItem next)
        {
            return true;
        }

        public void Initial(List<ChessItem> Chesses)
        {
            var chesses = Chesses;
            for (int i = 0; i < 64; i++)
                chesses[i].Visible = false;
            chesses[27].ChessColor = ChessItem.cColor.white;
            chesses[27].Visible = true;
            chesses[36].ChessColor = ChessItem.cColor.white;
            chesses[36].Visible = true;

            chesses[28].ChessColor = ChessItem.cColor.black;
            chesses[28].Visible = true;
            chesses[35].ChessColor = ChessItem.cColor.black;
            chesses[35].Visible = true;
        }
    }
}