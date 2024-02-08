using System.Security.Cryptography;
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
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button[] buttons;
        int time = 0;
        bool teamPlayer = true;
        bool wl;
        int[,] winComb = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 1, 4, 7 }, { 2, 5, 8 }, { 3, 6, 9 }, { 1, 5, 9 }, { 3, 5, 7 } };
        Random random = new Random();

        public void Clear()
        {
            TextB.Text = string.Empty;
            for (int i = 0; i < 9; i++)
            {
                buttons[i].Content = " ";
                buttons[i].IsEnabled = true;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            buttons = new Button[9] { _1, _2, _3, _4, _5, _6, _7, _8, _9 };
            for (int i = 0; i < 9; i++)
            {
                buttons[i].Content = " ";
                buttons[i].IsEnabled = false;
            }
            Restart.IsEnabled = false;
        }

        private bool Win()
        {
            for (int i = 0; i < 8; i++)
            {
                int a = (winComb[i, 0]) - 1;
                int b = (winComb[i, 1]) - 1;
                int c = (winComb[i, 2]) - 1;

                if (buttons[a].Content.ToString() == "X" && buttons[b].Content.ToString() == "X" && buttons[c].Content.ToString() == "X")
                {
                    TextB.Text = "Победил X!";
                    for (int f = 0; f < 9; f++)
                    {
                        buttons[f].IsEnabled = false;
                    }
                    return wl = true;
                }
                else if (buttons[a].Content.ToString() == "O" && buttons[b].Content.ToString() == "O" && buttons[c].Content.ToString() == "O")
                {
                    TextB.Text = "Победил O!";
                    for (int f = 0; f < 9; f++)
                    {
                        buttons[f].IsEnabled = false;
                    }
                    return wl = true;
                }

            }
            return wl = false;
        }

        private void _1_Res(object sender, RoutedEventArgs e)
        {
            time = 0;
            Clear();
            teamPlayer = !teamPlayer;
            if (teamPlayer != true)
            {
                int nom = random.Next(0, 9);
                buttons[nom].Content = "X";
                buttons[nom].IsEnabled = false;
            }
        }

        private void _1_Click(object sender, RoutedEventArgs e)
        {
            time += 2;
           
            if (teamPlayer == true)
            {

                (sender as Button).Content = "X";
                (sender as Button).IsEnabled = false;

                if (!Win() && time != 10)
                {

                    int nom = random.Next(0, 9);
                    while (buttons[nom].IsEnabled == false)
                    {
                        nom = random.Next(0, 9);
                    }
                    buttons[nom].Content = "O";
                    buttons[nom].IsEnabled = false;

                }
                Win();

                if (time == 10 && !Win())
                {
                    TextB.Text = "Ничья!";
                    for (int f = 0; f < 9; f++)
                    {
                        buttons[f].IsEnabled = false;
                    }
                    return;
                }
            }
            else if (teamPlayer == false)
            {
                int nom = random.Next(0, 9);

                while (buttons[nom].IsEnabled == false)
                {
                     nom = random.Next(0, 9);
                }
                buttons[nom].Content = "X";
                buttons[nom].IsEnabled = false;

                Win();

                (sender as Button).Content = "O";
                (sender as Button).IsEnabled = false;

                Win();
                if (time == 10 && !Win())
                {
                    TextB.Text = "Ничья!";
                    for (int f = 0; f < 9; f++)
                    {
                        buttons[f].IsEnabled = false;
                    }
                    return;
                }
                
            }
        }

        private void Player_Click(object sender, RoutedEventArgs e)
        {
            time = 0;
            teamPlayer = !teamPlayer;

            if (teamPlayer == false)
            {
                (sender as Button).Content = "O";
            }
            else if (teamPlayer == true)
            {
                (sender as Button).Content = "X";
            }
                
            
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            time = 0;
            Clear();
            Restart.IsEnabled = true;
            if(teamPlayer != true)
            {
                int nom = random.Next(0, 9);
                buttons[nom].Content = "X";
                buttons[nom].IsEnabled = false;
            }
        }
    }
}