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
        //int count = 0;
        string symbol;
        List<Button> buttons = new List<Button>();
        
        public MainWindow()
        {
            ChooseWindow chWin = new ChooseWindow();
            chWin.ShowDialog();
            //this.symbol = chWin.Symbol;
            if (chWin.ChooseGame == 1)
            {
                if (chWin.ChooseXO == 1)
                {
                    Computer cpu = new Computer("O");
                    Player plOne = new Player(chWin.PlOneName.Text.ToString(), "X");
                    lbGameWin.Content = "Следующий ход: " + plOne.Name + ", играет: " + plOne.ChooseXO;
                    this.symbol = plOne.ChooseXO;
                }
                else
                {
                    Computer cpu = new Computer("X");
                    Player plOne = new Player(chWin.PlOneName.Text.ToString(), "O");
                    lbGameWin.Content = "Следующий ход: " + cpu.Name + ", играет: " + cpu.ChooseXO;
                    this.symbol = cpu.ChooseXO;
                }
            }
            else
            {
                if (chWin.ChooseXO == 1)
                {
                    Player plOne = new Player(chWin.PlOneName.Text.ToString(), "X");
                    Player plTwo = new Player(chWin.PlTwoName.Text.ToString(), "O");
                    lbGameWin.Content = "Следующий ход: " + plOne.Name + ", играет: " + plOne.ChooseXO;
                    this.symbol = plOne.ChooseXO;
                }
                else
                {
                    Player plOne = new Player(chWin.PlOneName.Text.ToString(), "O");
                    Player plTwo = new Player(chWin.PlTwoName.Text.ToString(), "X");
                    lbGameWin.Content = "Следующий ход: " + plTwo.Name + ", играет: " + plTwo.ChooseXO;
                    this.symbol = plTwo.ChooseXO;
                }
            }
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            lbGameWin.Content += this.symbol;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            (sender as Button).Content = this.symbol;
            
            foreach (var item in mainWinGrid.Children)
            {
                if (item is Button)
                {
                    this.buttons.Add((item as Button));
                    //count++;
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



            //if (this.buttons[0].Content == this.buttons[2].Content)
            //    MessageBox.Show("You win!!!");
        }
    }
}
