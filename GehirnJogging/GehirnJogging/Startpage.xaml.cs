using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using DB_GehirnJogging;
using DB_GehirnJogging.Repositories;
using Repositories.Abstract;

namespace GehirnJogging
{
    /// <summary>
    /// Interaktionslogik für Startpage.xaml
    /// </summary>
    public partial class Startpage : Page
    {

        private Player _player = Player.GetInstance();

        /// <summary>
        /// Nach einem Navigieren auf diese Seite, löst es ein neues Event aus, welche die private Methode OnNavigated ausführt
        /// </summary>
        public Startpage()
        {
            InitializeComponent();
            Start.GetNavigationService().Navigated += OnNavigated;
        }

        private void OnNavigated(object sender, NavigationEventArgs e)
        {
            nameinputtext.Text = null;
            GridNewGame.Visibility = Visibility.Hidden;
        }    

        private void BtnNewPlayer_Click(object sender, RoutedEventArgs e)
        {
            CharakterRepository charakterRepository = new CharakterRepository(new GehirnjoggingEntities());
            if(charakterRepository.CharacternameExists(nameinputtext.Text))
            {
                lblusernameAlreadyGiven.Visibility = Visibility.Visible;
                return;
            }
            Player.GetInstance().PlayerName = nameinputtext.Text;

            charakterRepository.createNewUser(nameinputtext.Text);
            Start.NavigateTo("worldpage");
            Start.resetPage("startpage");
        }

        private void BtnnewGame_Click(object sender, RoutedEventArgs e)
        {
            GridNewGame.Visibility = Visibility.Visible;
        }

        private void EndGame(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ExitNewWorld_Click(object sender, RoutedEventArgs e)
        {
            GridNewGame.Visibility = Visibility.Hidden;
        }
    }
}
