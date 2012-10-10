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
using System.Windows.Threading;
using System.Net;
using System.Net.Sockets;

namespace CS541_Final_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public enum PlayerRole
        {
            Black,
            White
        }
        public List<Rectangle> listR = new List<Rectangle>();

        public List<ChessItem> listC = new List<ChessItem>();

        public PlayerRole CurrentPlayer = PlayerRole.White;

        private int counter = 0;
        public MainWindow()
        {
            InitializeComponent();
            this.MouseDown += delegate { DragMove(); };
            Ini();
            //Reset();

        }

        public State Start;
        public State Current;
        public State TempCurrent;
        public int Steps;// At beginnning, there are 4 chesses
        public Alg_2 MyAlg_2;

        public int BlackNumb = 0;
        public int WhiteNumb = 0;

        bool NextStateGet = false;

        //private static AutoResetEvent WaitEnemyInput = new AutoResetEvent(false);

        private void Ini()
        {
            chessBoard.Children.Clear();
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    Rectangle rect = new Rectangle();

                    chessBoard.Children.Add(rect);
                    rect.Width = 83;
                    rect.Height = 83;
                    SolidColorBrush scb = new SolidColorBrush();
                    scb.Color = Color.FromArgb(0, 0, 0, 255);
                    rect.Fill = scb;
                    rect.StrokeThickness = 2;
                    rect.Stroke = Brushes.Black;
                    rect.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    rect.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                    rect.MouseLeftButtonUp += new MouseButtonEventHandler(rect_MouseLeftButtonUp);
                    listR.Add(rect);


                    Ellipse elip = new Ellipse();
                    grid1.Children.Add(elip);
                    elip.Width = 70;
                    elip.Height = 70;
                    elip.Visibility = System.Windows.Visibility.Hidden;
                    elip.StrokeThickness = 0;
                    elip.Stroke = Brushes.Black;
                    Thickness margin = rect.Margin;
                    margin.Left = 84 * j + 7;
                    margin.Top = 84 * i + 7;
                    margin.Right = 0;
                    margin.Bottom = 0;
                    elip.Margin = margin;
                    elip.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                    elip.VerticalAlignment = System.Windows.VerticalAlignment.Top;


                    ChessItem CI = new ChessItem(elip);
                    CI.ChessColor = ChessItem.cColor.white;
                    CI.ChessNumber = i * 8 + j;
                    elip.ToolTip = CI.ChessNumber.ToString();

                    listC.Add(CI);
                }

        }

        void rect_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (counter < 64)
            {
                listC[counter].Visible = true;
                listC[counter].ChessColor = ChessItem.cColor.black;
                counter++;
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (counter < 64)
            {
                listC[counter].Visible = true;
                listC[counter].ChessColor = ChessItem.cColor.white;
                counter++;
            }
        }

        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 64; i++)
                listC[i].ShowShadow = true;
        }

        private void checkBox1_Unchecked(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 64; i++)
                listC[i].ShowShadow = false;
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            //this.Reset();
            this.Reset2();
        }

        private void Reset()
        {
            counter = 0;
            Steps = 4;
            Start = new State();
            Start.Board[3][3] = 0;
            Start.Board[4][3] = 7;
            Start.Board[4][4] = 0;
            Start.Board[3][4] = 7;
            if (CurrentPlayer == PlayerRole.White)
                Start.NextPlayer = 7;
            else
                Start.NextPlayer = 7;
            Rules.getAvailableList(Start.NextPlayer, Start.Board, Start.AvailablePosition);
            Start.GenerateChild();
            Current = Start;
            UpdateChessBoard(Current);
        }

        private void Reset2()
        {
            counter = 0;
            Steps = 4;
            Start = new State();
            MyAlg_2 = new Alg_2();
            Start.Board[3][3] = 0;
            Start.Board[4][3] = 7;
            Start.Board[4][4] = 0;
            Start.Board[3][4] = 7;
            if (CurrentPlayer == PlayerRole.White)
                Start.NextPlayer = 7;
            else
                Start.NextPlayer = 7;
            Rules.getAvailableList(Start.NextPlayer, Start.Board, Start.AvailablePosition);
            Current = Start;
            TempCurrent = Start;
            UpdateChessBoard(Current);
        }


        private void button5_Click(object sender, RoutedEventArgs e)
        {
            /*//counter = 0;
            Rules chessRule = new Rules();
            State Start = new State();
            Start.Board[3][3] = 7;
            Start.Board[4][3] = 0;
            Start.Board[4][4] = 7;
            Start.Board[3][4] = 0;
            Start.NextPlayer = 7;
            Rules.getAvailableList(Start.NextPlayer, Start.Board, Start.AvailablePosition);
            Start.GenerateChild();
            Current = Start;*/

            //Console.WriteLine(Start.AvailablePosition[0][0].ToString() + Start.AvailablePosition[0][1].ToString());

            for (int i = 0; i < Start.AvailablePosition[0].Count; i++)
            {
                //MessageBox.Show(Start.AvailablePosition[0][i].ToString() + "/ " + Start.AvailablePosition[1][i].ToString());
                if (this.CurrentPlayer == PlayerRole.White)
                {
                    ChessItem item = this.listC[Start.AvailablePosition[0][i] * 8 + Start.AvailablePosition[1][i]];
                    item.Debugmode = true;
                    item.Visible = true;
                    item.ChessColor = ChessItem.cColor.white;
                }
                else
                {
                    ChessItem item = this.listC[Start.AvailablePosition[0][i] * 8 + Start.AvailablePosition[1][i]];
                    item.Debugmode = true;
                    item.Visible = true;
                    item.ChessColor = ChessItem.cColor.black;
                }
            }
        }

        private void EnemyMatch(int x,int y)
        {
            bool WrongMove = false;
            if (Current.AvailablePosition[0].Count == 0)
            {
                //MessageBox.Show("You do not have move!");
                Current = Current.Child[0];//No chess to go;
                return;
            }

            for (int i = 0; i < Current.AvailablePosition[0].Count; i++)
             {
                if (Current.AvailablePosition[0][i] == x && Current.AvailablePosition[1][i] == y)
                {
                    Current = Current.Child[i + 1];//The current is updated to the enemy's finished state
                    return;
                }
            }
            if (WrongMove == false)//The enemy make wrong move;
            {
                MessageBox.Show("Your input is invalid, my victory!");
                if (Current.AvailablePosition[0].Count == 0)
                {
                    Current = Current.Child[0];//No chess to go;
                    return;
                }
                else
                {
                    Current = Current.Child[1];//The current is updated to the enemy's finished state
                    return;
                }
            }
            return;
        }

        private void ServerBegin(int total)
        {
            int x = total / 8;
            int y = total % 8;
            EnemyMatch(x, y);//Update current;
            UpdateChessBoard(Current);
            Current.GenerateChild();//Initialzie the states which self may put, the available position is also calculated
            Steps++;
            /*for (int i = 0; i < Current.Child.Count; i++)
            {
                Current.Child[i].GenerateChild();//Initialize all the enemy's state after each self state;
            }*/
        }

        private void ServerBegin2(int total)
        {
            int x = total / 8;
            int y = total % 8;
            EnemyMatch(x, y);//Update current;
            UpdateChessBoard(Current);
            //Current.GenerateChild();//Initialzie the states which self may put, the available position is also calculated
            Steps++;
            /*for (int i = 0; i < Current.Child.Count; i++)
            {
                Current.Child[i].GenerateChild();//Initialize all the enemy's state after each self state;
            }*/
        }





        private void ProcessNext()
        {
            int total = Int32.Parse(textBox1.Text);
            int x = total / 8;
            int y = total % 8;
            //int y = Int32.Parse(textBox2.Text);
            Steps+=2;
            int AssumeChild = 0;
            int nextMove = 0;
            if (Steps != 4)
            {
                EnemyMatch(x, y);//global "Current" is the enemy's state now, update enemy state's board;
            }

            Current.GenerateChild();//Initialzie the states which self may put, the available position is also calculated

            if (Current.AvailablePosition[0].Count != 0)
            {
                for (int i = 1; i < Current.AvailablePosition[0].Count + 1; i++)
                {
                    Current.Child[i].GenerateChild();//Initialize all the enemy's state after each self state;
                }

                AssumeChild = Alg_1.NextStep(Current);
                nextMove = Current.AvailablePosition[0][AssumeChild - 1] * 8 + Current.AvailablePosition[1][AssumeChild - 1];

                
            }
            else
            {
                Current.Child[0].GenerateChild();
                AssumeChild = 0;
                nextMove = 64;
                MessageBox.Show("I have no way to go");
                //Do not need to update the state;
            }
            Current = Current.Child[AssumeChild];

            NextStateGet = false;

            UpdateChessBoard(Current);
        }

        private int ProcessNext2()
        {
            int nextMove = 0;
            int totalNum = Int32.Parse(textBox1.Text);

            nextMove = MyAlg_2.ProcessNext(ref TempCurrent, Current, totalNum);//Go next 2 steps;
            Current = TempCurrent;//To avoid dynamic updating of "Current"
            UpdateChessBoard(Current);
            return nextMove;
        }

        private int Play2(int totalNum)
        {
            int nextMove = 0;
            nextMove = MyAlg_2.ProcessNext(ref TempCurrent, Current, totalNum);//Go next 2 steps;
            Current = TempCurrent;//To avoid dynamic updating of "Current"
            UpdateChessBoard(Current);
            return nextMove;
        }

        /*private void button6_Click(object sender, RoutedEventArgs e)
        {
            NextStateGet = true;
            if (Steps == 4)
            {
                ServerBegin(19);
                return;
            }
            ProcessNext();
            UpdateChessBoard(Current);
        }*/

        private void button6_Click(object sender, RoutedEventArgs e)//Alg_2
        {
            //UpdateChessBoard(Current);
            if (Steps == 4)
            {

                Current.GenerateChild();//Current=start
                ServerBegin2(19);
                UpdateChessBoard(Current);

                MyAlg_2.SetEnemy(0);//reset the enemy
                //MyAlg_2.InitTree(Current,Current);
                return;
            }
            ProcessNext2();
            //UpdateChessBoard(Current);
        }

        private int Play(int numReceived)
        {
            NextStateGet = true;
            int AssumeChild = 0 ;
            int nextMove = 0;
            int total = numReceived;
            int x = total / 8;
            int y = total % 8;
            //int y = Int32.Parse(textBox2.Text);
            Steps+=2;

            if (Steps != 4)
            {
                EnemyMatch(x, y);//global "Current" is the enemy's state now, update enemy state's board;
            }

            Current.GenerateChild();//Initialzie the states which self may put, the available position is also calculated

            if (Current.AvailablePosition[0].Count != 0)
            {
                for (int i = 1; i < Current.AvailablePosition[0].Count + 1; i++)
                {
                    Current.Child[i].GenerateChild();//Initialize all the enemy's state after each self state;
                }

                AssumeChild = Alg_1.NextStep(Current);
                nextMove = Current.AvailablePosition[0][AssumeChild - 1] * 8 + Current.AvailablePosition[1][AssumeChild - 1];
                
            }
            else
            {
                Current.Child[0].GenerateChild();
                AssumeChild = 0;
                nextMove = 64;
            }
            Current = Current.Child[AssumeChild];

            NextStateGet = false;

            UpdateChessBoard(Current);

            return nextMove;
        }

        private void UpdateChessBoard(State ShowState)
        {
            
            BlackNumb = 0;
            WhiteNumb = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (ShowState.Board[i][j] == -1)
                    {
                        listC[i * 8 + j].Visible = false;
                    }
                    else if (ShowState.Board[i][j] == 0)
                    {
                        listC[i * 8 + j].Visible = true;
                        listC[i * 8 + j].ChessColor = ChessItem.cColor.white;
                        listC[i * 8 + j].Debugmode = false;
                        WhiteNumb++;
                    }
                    else
                    {
                        listC[i * 8 + j].Visible = true;
                        listC[i * 8 + j].ChessColor = ChessItem.cColor.black;
                        listC[i * 8 + j].Debugmode = false;
                        BlackNumb++;
                    }
                }
            }
            for (int i = 0; i < ShowState.AvailablePosition[0].Count; i++)
            {
                if (ShowState.NextPlayer == 0)
                {
                    listC[(ShowState.AvailablePosition[0][i]) * 8 + ShowState.AvailablePosition[1][i]].Visible = true;
                    listC[(ShowState.AvailablePosition[0][i]) * 8 + ShowState.AvailablePosition[1][i]].ChessColor = ChessItem.cColor.white;
                    listC[(ShowState.AvailablePosition[0][i]) * 8 + ShowState.AvailablePosition[1][i]].Debugmode = true;
                }
                else
                {
                    listC[(ShowState.AvailablePosition[0][i]) * 8 + ShowState.AvailablePosition[1][i]].Visible = true;
                    listC[(ShowState.AvailablePosition[0][i]) * 8 + ShowState.AvailablePosition[1][i]].ChessColor = ChessItem.cColor.black;
                    listC[(ShowState.AvailablePosition[0][i]) * 8 + ShowState.AvailablePosition[1][i]].Debugmode = true;
                }
            }
            BlackNumberLabel.Text = BlackNumb.ToString();
            WhiteNumberLabel.Text = WhiteNumb.ToString();
            
            BlackNumberLabel_Copy.Text = BlackNumb.ToString();
            WhiteNumberLabel_Copy.Text = WhiteNumb.ToString();
            System.Windows.Media.Animation.Storyboard sdb = (System.Windows.Media.Animation.Storyboard)FindResource("ScoreUpdate");
            sdb.Begin();



            if (BlackNumb > WhiteNumb)
            {
                string packUri = "pack://application:,,,/CS541%20Final%20Project;component/Images/Smile.jpg";
                image1.Source = new ImageSourceConverter().ConvertFromString(packUri) as ImageSource;
            }
            else if (BlackNumb == WhiteNumb)
            {
                string packUri = "pack://application:,,,/CS541%20Final%20Project;component/Images/curious.jpg";
                image1.Source = new ImageSourceConverter().ConvertFromString(packUri) as ImageSource;
            }
            else
            {
                string packUri = "pack://application:,,,/CS541%20Final%20Project;component/Images/Worry.jpg";
                image1.Source = new ImageSourceConverter().ConvertFromString(packUri) as ImageSource;
            }
                
            AllowUIToUpdate();
        }

        private void button8_Click(object sender, RoutedEventArgs e)//Being a server
        {
            // 44 is the first number you are going to send.
            CurrentPlayer = PlayerRole.Black;
            Reset2();
            try
            {
                Current.GenerateChild();//Current=start
                ServerBegin2(19);
                UpdateChessBoard(Current);

                MyAlg_2.SetEnemy(0);//reset the enemy

                Socket soc = SocketServer.StartListening(19, int.Parse(textBox4.Text));
                //MyAlg_2.InitTree(Current, Current);

                int numget = SocketServer.Get(soc);
                while (true)
                {
                    int numSent = Play2(numget);
                    if (numget == 64 && numSent == 64)
                    {
                        MessageBox.Show("Game over!");
                        break;
                    }
                    if (numget == 64)
                        MessageBox.Show("I got one more move!");
                    //MessageBox.Show(numget.ToString()+"  "+numSent.ToString());
                    if (numSent == 64)
                        MessageBox.Show("I have no move to go....");
                    //AllowUIToUpdate();
                    //this.UpdateLayout();
                    numget = SocketServer.Send(soc, numSent);
                }
            }
            catch
            {
                MessageBox.Show("Please make sure the port number is correct and able to use."); 
            }
            
        }

        private void button7_Click(object sender, RoutedEventArgs e)//Being a client
        {
            CurrentPlayer = PlayerRole.White;
            Reset2();
           
            try
            {
                MyAlg_2.SetEnemy(7);//reset the enemy
               
                Socket soc = SocketClient.StartClient(textBox3.Text, int.Parse(textBox4.Text));
                int numget = SocketClient.Get(soc);

                //MyAlg_2.InitTree(Current, Current);

                int numFirst = numget;
                while (true)
                {
                    int numSent = Play2(numget);
                    if (numget == 64 && numSent == 64)
                    {
                        MessageBox.Show("Game over!");
                        break;
                    }
                    if (numget == 64)
                        MessageBox.Show("I got one more move!");
                    //MessageBox.Show(numget.ToString()+"  "+numSent.ToString());
                    if (numSent == 64)
                        MessageBox.Show("I have no move to go....");
                    //AllowUIToUpdate();
                    //this.UpdateLayout();
                    numget = SocketClient.Send(soc, numSent);
                }
            }
            catch
            {
                MessageBox.Show("Please make sure the IP address and port number are correct.");
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
                Application.Current.Shutdown();
            }
        }

        void AllowUIToUpdate()
        {

            DispatcherFrame frame = new DispatcherFrame();

            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Render, new DispatcherOperationCallback(delegate(object parameter)
            {

                frame.Continue = false;

                return null;

            }), null);

            Dispatcher.PushFrame(frame);

        }
    }
}
