using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CrestZeroProjectWpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int nextMove;
        int game;
        int symbPlOne;
        string symbol;
        List<Button> buttons = new List<Button>();
        Computer cpu = null;
        Player plOne = null;
        Player plTwo = null;
        int[,] arrWin = new int[8, 3] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 0, 4, 8 },
                                { 2, 4, 6 }, { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }};
        
        public MainWindow()
        {
            ChooseWindow chWin = new ChooseWindow();
            chWin.ShowDialog();
            this.game = chWin.ChooseGame;
            this.symbPlOne = chWin.ChooseXO;
            if (this.game == 1)
            {
                if (this.symbPlOne == 1)
                {
                    cpu = new Computer("O");
                    plOne = new Player(chWin.PlOneName.Text.ToString(), "X");
                    this.nextMove = 1;
                }
                else
                {
                    cpu = new Computer("X");
                    plOne = new Player(chWin.PlOneName.Text.ToString(), "O");
                    this.nextMove = 2;
                }
            }
            else
            {
                if (this.symbPlOne == 1)
                {
                    plOne = new Player(chWin.PlOneName.Text.ToString(), "X");
                    plTwo = new Player(chWin.PlTwoName.Text.ToString(), "O");
                    this.nextMove = 1;
                }
                else
                {
                    plOne = new Player(chWin.PlOneName.Text.ToString(), "O");
                    plTwo = new Player(chWin.PlTwoName.Text.ToString(), "X");
                    this.nextMove = 2;
                }
            }
            InitializeComponent();
            this.Next();
            


        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            //lbGameWin.Content += this.symbol;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).Content.ToString() == "")
            {
                (sender as Button).Content = this.symbol;

                foreach (var item in mainWinGrid.Children)
                {
                    if (item is Button)
                    {
                        this.buttons.Add((item as Button));
                    }
                }
                Uri u;
                if ((string)(sender as Button).Content == "X")
                {
                    u = new Uri(@"..\..\x.jpg", UriKind.RelativeOrAbsolute);
                }
                else
                {
                    u = new Uri(@"..\..\o.jpg", UriKind.RelativeOrAbsolute);
                }
                (sender as Button).Background = new ImageBrush(new BitmapImage(u));

                if (this.nextMove == 1)
                {
                    this.nextMove = 2;
                }
                else
                    this.nextMove = 1;

                this.Next();
            }
            
            //cpu.Move(this.buttons);
            //this.bt2.BeginInit();

            if (this.buttons[0].Content.ToString() != "" && this.buttons[0].Content == this.buttons[1].Content && this.buttons[1].Content == this.buttons[2].Content)
            {
                MessageBox.Show("You win!!!");
                return;
            }
            else if (this.buttons[3].Content.ToString() != "" && this.buttons[3].Content == this.buttons[4].Content && this.buttons[4].Content == this.buttons[5].Content)
            {
                MessageBox.Show("You win!!!");
                return;
            }
            else if (this.buttons[6].Content.ToString() != "" && this.buttons[6].Content == this.buttons[7].Content && this.buttons[7].Content == this.buttons[8].Content)
            {
                MessageBox.Show("You win!!!");
                return;
            }
            else if (this.buttons[0].Content.ToString() != "" && this.buttons[0].Content == this.buttons[3].Content && this.buttons[3].Content == this.buttons[6].Content)
            {
                MessageBox.Show("You win!!!");
                return;
            }
            else if (this.buttons[1].Content.ToString() != "" && this.buttons[1].Content == this.buttons[4].Content && this.buttons[4].Content == this.buttons[7].Content)
            {
                MessageBox.Show("You win!!!");
                return;
            }
            else if (this.buttons[2].Content.ToString() != "" && this.buttons[2].Content == this.buttons[5].Content && this.buttons[5].Content == this.buttons[8].Content)
            {
                MessageBox.Show("You win!!!");
                return;
            }
            else if (this.buttons[0].Content.ToString() != "" && this.buttons[0].Content == this.buttons[4].Content && this.buttons[4].Content == this.buttons[8].Content)
            {
                MessageBox.Show("You win!!!");
                return;
            }
            else if (this.buttons[2].Content.ToString() != "" && this.buttons[2].Content == this.buttons[4].Content && this.buttons[4].Content == this.buttons[6].Content)
            {
                MessageBox.Show("You win!!!");
                return;
            }
            else
            {
                if (this.buttons[0].Content.ToString() != "" && this.buttons[1].Content.ToString() != "" && this.buttons[2].Content.ToString() != ""
                    && this.buttons[3].Content.ToString() != "" && this.buttons[4].Content.ToString() != "" && this.buttons[5].Content.ToString() != ""
                    && this.buttons[6].Content.ToString() != "" && this.buttons[7].Content.ToString() != "" && this.buttons[8].Content.ToString() != ""
                    )
                {
                    MessageBox.Show("Ничья!!!");
                    this.lbGameWin.Content = "Ничья!!!";
                    return;
                }
            }
        }

        private void Next()
        {
            if (this.nextMove == 1)
            {
                this.lbGameWin.Content = "Следующий ход: " + plOne.Name + ", играет: " + plOne.ChooseXO;
                this.symbol = plOne.ChooseXO;
            }
            else
            {
                if (this.game == 1)
                {
                    lbGameWin.Content = "Следующий ход: " + cpu.Name + ", играет: " + cpu.ChooseXO;
                    this.symbol = cpu.ChooseXO;
                }
                else
                {
                    lbGameWin.Content = "Следующий ход: " + plTwo.Name + ", играет: " + plTwo.ChooseXO;
                    this.symbol = plTwo.ChooseXO;
                }
            }
        }


        

    }
}
