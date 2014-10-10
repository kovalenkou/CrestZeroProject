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
using System.Windows.Shapes;

namespace CrestZeroProjectWpf
{
    /// <summary>
    /// Логика взаимодействия для ChooseWindow.xaml
    /// </summary>
    public partial class ChooseWindow : Window
    {
        int chooseGame;
        int chooseXO;
        public int ChooseGame { get { return this.chooseGame;} }
        public int ChooseXO { get { return this.chooseXO; } }


        public ChooseWindow()
        {
            InitializeComponent();
            this.rbX.Content = "Игрок 1 играет \"Х\"";
            this.rbO.Content = "Игрок 1 играет \"O\"";
        }

        private void rbO_Checked(object sender, RoutedEventArgs e)
        {
            if ((sender as RadioButton).Content.ToString().Contains("Х"))
            {
                this.chooseXO = 1;
            }
            else
            {
                this.chooseXO = 2;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PlOneName_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.rbX.Content = this.PlOneName.Text.ToString() + " играет \"Х\"";
            this.rbO.Content = this.PlOneName.Text.ToString() + " играет \"O\"";
        }

        private void rbPlPl_Checked(object sender, RoutedEventArgs e)
        {
            if ((sender as RadioButton).Content.ToString().Contains("Игрок №1 против Компьютера"))
            {
                this.chooseGame = 1;
                this.PlTwoName.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                this.chooseGame = 2;
                this.PlTwoName.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void PlTwoName_TextChanged(object sender, TextChangedEventArgs e)
        {
            ;
        }
    }
}
