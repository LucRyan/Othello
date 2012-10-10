using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Shapes;

namespace CS541_Final_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class ChessBoard
    {
        public bool Visible
        {
            get
            {
                if (Shape.Visibility == Visibility.Visible)
                    return true;
                else
                    return false;
            }
            set
            {
                if (Visible == true)
                    Shape.Visibility = Visibility.Visible;
                else
                    Shape.Visibility = Visibility.Hidden;
            }
        }

        public int Number { get; set; }

        public Rectangle Shape { get; set; }
    }
}