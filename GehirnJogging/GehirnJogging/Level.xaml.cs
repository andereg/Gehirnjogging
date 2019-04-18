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
    /// Interaktionslogik für Level.xaml
    /// </summary>
    public partial class Level : Window
    {
        Music music = new Music();
        bool isMusicPlaying = true;
        bool isSoundOn = true;

        public Level()
        {
            InitializeComponent();
            music.playTheme();
        }

        private void BtnPause_Click(object sender, RoutedEventArgs e)
        {
            btnPause.Visibility = Visibility.Hidden;
            GridPause.Visibility = Visibility.Visible;
            
        }

        private void SliderMusic_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void SliderSounds_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void BtnMusicOnOFf_Click(object sender, RoutedEventArgs e)
        {
            string on = "Music On";
            string off = "Music Off";

            if (isMusicPlaying)
            {
                btnMusicOnOFf.Content = on;
                music.stopTheme();
                isMusicPlaying = false;
            }
            else
            {
                btnMusicOnOFf.Content = off;
                music.resumeTheme();
                isMusicPlaying = true;
            }
        }

        private void BtnSoundsOnOff_Click(object sender, RoutedEventArgs e)
        {
            string on = "Sound On";
            string off = "Sound Off";

            if (isSoundOn)
            {
                btnSoundsOnOff.Content = on;
                music.stopTheme();
                isSoundOn = false;
            }
            else
            {
                btnSoundsOnOff.Content = off;
                music.resumeTheme();
                isSoundOn = true;
            }

        }

        private void BtnResume(object sender, RoutedEventArgs e)
        {
            GridPause.Visibility = Visibility.Hidden;
            btnPause.Visibility = Visibility.Visible;

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Worldmap map = new Worldmap();
            this.Close();
            music.stopTheme();
            map.Show();
        }
    }
}
