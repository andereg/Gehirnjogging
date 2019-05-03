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

namespace GehirnJogging
{
    /// <summary>
    /// Interaktionslogik für Startpage.xaml
    /// </summary>
    public partial class Startpage : Page
    {

        private Player _player = Player.GetInstance();

        /// <summary>
        /// 
        /// </summary>
        public Startpage()
        {
            InitializeComponent();
        }     

        private void BtnloadGame_Click(object sender, RoutedEventArgs e)
        {
            Player.GetInstance().PlayerName = nameinputtext.Text;
            Start.NavigateTo("worldpage");
            Start.resetPage("startpage");
        }

        private void BtnnewGame_Click(object sender, RoutedEventArgs e)
        {
            NameInput.Visibility = Visibility.Visible;
            yourname.Visibility = Visibility.Visible;
            btnok.Visibility = Visibility.Visible;
            nameinputtext.Visibility = Visibility.Visible;
            exitNewWorld.Visibility = Visibility.Visible;
        }

        private void EndGame(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ExitNewWorld_Click(object sender, RoutedEventArgs e)
        {
            NameInput.Visibility = Visibility.Hidden;
            yourname.Visibility = Visibility.Hidden;
            btnok.Visibility = Visibility.Hidden;
            nameinputtext.Visibility = Visibility.Hidden;
            exitNewWorld.Visibility = Visibility.Hidden;
        }
    }
}
