using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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

namespace GehirnJogging
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Player player = new Player();

        private void BtnloadGame_Click(object sender, RoutedEventArgs e)
        {
            Worldmap map = new Worldmap();
            this.Close();
            map.Show();
            player.PlayerName = nameinputtext.Text;
        }

        private void BtnnewGame_Click(object sender, RoutedEventArgs e)
        {
            NameInput.Visibility = Visibility.Visible;
            yourname.Visibility = Visibility.Visible;
            btnok.Visibility = Visibility.Visible;
            nameinputtext.Visibility = Visibility.Visible;
        }

        private void BtnuserdefinedGame_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void EndGame(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
