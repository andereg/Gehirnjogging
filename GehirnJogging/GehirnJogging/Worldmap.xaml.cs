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

namespace GehirnJogging
{
    /// <summary>
    /// Interaktionslogik für Worldmap.xaml
    /// </summary>
    public partial class Worldmap : Window
    {
        public Worldmap()
        {
            InitializeComponent();
        }

        private void btnback(object sender, RoutedEventArgs e)
        {
            MainWindow startscreen = new MainWindow();
            this.Close();
            startscreen.Show();
        }

        private void BtnnewGame_Copy4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnStartLevel(object sender, RoutedEventArgs e)
        {
            Level level = new Level();
            this.Close();
            level.Show();
        }
    }
}
