using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GehirnJogging
{
    /// <summary>
    /// Interaktionslogik für Worldmap.xaml
    /// </summary>
    public partial class Worldmap : Window
    {
        int currentlvl = 1;
        int goallvl = 1;
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

        private void ArrowUp_Click(object sender, RoutedEventArgs e)
        {
            if(goallvl != 13)
            {
                goallvl = goallvl + 1;
                MoveTo(currentlvl, goallvl);
            }
        }

        public void MoveTo(int target, int Goal)
        {
            lbllevel.Content = goallvl;
            if(goallvl< 4)
            {
                lblSchwierigkeit.Content = "Easy";
            }
            if (goallvl < 10 && goallvl > 3)
            {
                lblSchwierigkeit.Content = "Medium";
            }
            if (goallvl > 9)
            {
                lblSchwierigkeit.Content = "Hard";
            }

            switch (goallvl)
            {
                case 1:
                    FrameByFrame(lvl1);
                    break;
                case 2:
                    FrameByFrame(lvl2);
                    break;
                case 3:
                    FrameByFrame(lvl3);
                    break;
                case 4:
                    FrameByFrame(lvl4);
                    break;
                case 5:
                    FrameByFrame(lvl5);
                    break;
                case 6:
                    FrameByFrame(lvl6);
                    break;
                case 7:
                    FrameByFrame(lvl7);
                    break;
                case 8:
                    FrameByFrame(lvl8);
                    break;
                case 9:
                    FrameByFrame(lvl9);
                    break;
                case 10:
                    FrameByFrame(lvl10);
                    break;
                case 11:
                    FrameByFrame(lvl11);
                    break;
                case 12:
                    FrameByFrame(lvl12);
                    break;
                case 13:
                    FrameByFrame(lvl13);
                    break;
            }
        }

        private void FrameByFrame(Image Goallvl)
        {

            Thickness thicknessCharakter = Character.Margin;
            Thickness thicknessLvl = Goallvl.Margin;
            double differenceLeft = thicknessCharakter.Left - thicknessLvl.Left;
            double differenceBottom = thicknessCharakter.Bottom - thicknessLvl.Bottom;
            for (int i = 0; i < 10; i++)
            {
                thicknessCharakter.Left = thicknessCharakter.Left - (differenceLeft / 10);
                thicknessCharakter.Bottom = thicknessCharakter.Bottom - (differenceBottom / 10);
                Character.Margin = thicknessCharakter;
            }
            
        }

        private void ArrowUp_Copy_Click(object sender, RoutedEventArgs e)
        {
            if(goallvl != 1)
            {
                goallvl = goallvl - 1;
                MoveTo(currentlvl, goallvl);
            }

        }
    }
}
