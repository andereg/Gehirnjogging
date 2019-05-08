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
    /// Interaktionslogik für Start.xaml
    /// </summary>
    public partial class Start : Window
    {
        private static IDictionary<string, Page> _pages = new Dictionary<string, Page>();
        private static Frame _frame;

        /// <summary>
        /// Initialisiert das Fenster und addet jede Seite dem IDictionary _pages.
        /// Navigatet auf die Seite startpage
        /// </summary>
        public Start()
        {
            InitializeComponent();
            _frame = MainFrame;

            _pages.Add("startpage", new Startpage());
            _pages.Add("levelpage",new LevelPage());
            _pages.Add("worldpage", new Worldpage());

            MainFrame.NavigationService.Navigate(_pages["startpage"]);

        }

        /// <summary>
        /// Diese Methode führt einen zu einer anderen Page wenn man den richtigen Parameter hat.
        /// </summary>
        /// <param name="destinationPage"></param>
        public static void NavigateTo(string destinationPage)
        { 
            _frame.NavigationService.Navigate(_pages[destinationPage]);
        }

        /// <summary>
        /// Gibt den NavigationService von _frame zurück.
        /// </summary>
        /// <returns>NavigationService von _frame</returns>
        public static NavigationService GetNavigationService()
        {
            return _frame.NavigationService;
        }

        /// <summary>
        /// Diese Methode setzt die mitgegebene Seite auf Standard zurück.
        /// </summary>
        /// <param name="destinationPage"></param>
        public static void resetPage(string destinationPage)
        {
            _pages[destinationPage].DataContext = null;

            switch (destinationPage)
            {
                case "startpage":
                    _pages[destinationPage].DataContext = new Startpage();
                    break;
                case "levelpage":
                    _pages[destinationPage].DataContext = new LevelPage();
                    break;
                case "worldpage":
                    _pages[destinationPage].DataContext = new Worldpage();
                    break;
            }
        }
    }
}
