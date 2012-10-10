using System;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CS541_Final_Project
{
    public class ChessItem
    {
        public ChessItem(Ellipse ChessShape)
        {
            this.ChessShape = ChessShape;
        }

        public enum cColor 
        {
            black,
            white
        }

        public int ChessNumber { get; set; }

        public Ellipse ChessShape { get; set; }

        public bool ShowShadow
        {
            get
            {
                if (ChessShape.Effect != null)
                    return true;
                else
                    return false;
            }
            set
            {
                if (value == true)
                {
                    System.Windows.Media.Effects.DropShadowEffect dropShadowEffect = new System.Windows.Media.Effects.DropShadowEffect();

                    dropShadowEffect.Opacity = 1;
                    dropShadowEffect.ShadowDepth = 5;
                    dropShadowEffect.BlurRadius = 5;
                    dropShadowEffect.Direction = 315;
                    dropShadowEffect.Color = Colors.Black;
                    ChessShape.Effect = dropShadowEffect;
                }
                else
                {
                    ChessShape.Effect = null;
                }
            }
        }
        
        public cColor ChessColor
        {
            get
            {
                if (ChessShape.Stroke == Brushes.White)
                    return cColor.black;
                else
                    return cColor.white;
            }
            set
            {
                if (value == cColor.black)
                {
                    //ChessShape.Fill = new SolidColorBrush() { Color = Color.FromArgb(255, 0, 0, 0) };

                    ImageBrush imB = new ImageBrush();
                    imB.ImageSource = new BitmapImage(new Uri(@"Images\BlackChess.png", UriKind.Relative));
                    ChessShape.Fill = imB;
                    ChessShape.Stroke = Brushes.White;
                }
                else if (value == cColor.white)
                {
                    //ChessShape.Fill = new SolidColorBrush() { Color = Color.FromArgb(255, 255, 255, 255) };
                    
                    ImageBrush imB = new ImageBrush();
                    imB.ImageSource = new BitmapImage(new Uri(@"Images\WhiteChess.png", UriKind.Relative));
                    ChessShape.Fill = imB;

                    ChessShape.Stroke = Brushes.Black;
                }
            }
        }

        public int ChessColorInt
        {
            get
            {
                if (this.ChessColor == cColor.black)
                {
                    return 7;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if (value == 7)
                    this.ChessColorInt = 7;
                else if (value == 0)
                    this.ChessColorInt = 0;
                else
                    this.ChessColorInt = 0;
                
            }
        }

        public bool Visible
        {
            get 
            {
                if (ChessShape.Visibility == Visibility.Visible)
                    return true;
                else
                    return false;
            }
            set
            {
                if (value == true)
                    ChessShape.Visibility = Visibility.Visible;
                else
                    ChessShape.Visibility = Visibility.Hidden;
            }
        }

        public bool Debugmode
        {
            get
            {
                if (this.ChessShape.Opacity == 0.5)
                    return true;
                else
                    return false;
            }
            set
            {
                if (value == true)
                    this.ChessShape.Opacity = 0.5;
                else
                    this.ChessShape.Opacity = 1.0;
            }
        }

    }
}