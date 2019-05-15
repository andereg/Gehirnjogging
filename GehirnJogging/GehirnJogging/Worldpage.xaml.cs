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
    /// Interaktionslogik für Worldpage.xaml
    /// </summary>
    public partial class Worldpage : Page
    {
        /// <summary>
        /// Nach einem Navigieren auf diese Seite, löst es ein neues Event aus, welche die private Methode onNavigated ausführt 
        /// </summary>
        public Worldpage()
        {
            InitializeComponent();
            Start.getNavigationService().Navigated += onNavigated;
        }

        private void onNavigated(object sender, NavigationEventArgs e)
        {
            Charactername.Content = Player.getInstance().playerName;
            sound.loadRunning();
        }

        int currentlvl = 1;
        int goallvl = 1;
        bool animationCompleted = true;
        Sound sound = new Sound();

        private void btnBack(object sender, RoutedEventArgs e)
        {
            Start.navigateTo("startpage");
            Start.resetPage("worldpage");

        }

        private void btnStartLevel(object sender, RoutedEventArgs e)
        {
            Start.resetPage("levelpage");
            Start.navigateTo("levelpage");
        }

        private void arrowUp_Click(object sender, RoutedEventArgs e)
        {
            if (!animationCompleted || goallvl > Player.getInstance().level) return;
            if (goallvl != 13)
            {
                goallvl = goallvl + 1;
                moveTo(currentlvl, goallvl);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="Goal"></param>
        private void moveTo(int target, int Goal)
        {
            if (!animationCompleted) return;

            int maxLevel = Player.getInstance().level + 1;

            if (Goal > maxLevel)
            {
                return;
            }

            animationCompleted = false;
            lbllevel.Content = goallvl;
            if (goallvl < 4)
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
                    frameByFrame(lvl1);
                    break;
                case 2:
                    frameByFrame(lvl2);
                    break;
                case 3:
                    frameByFrame(lvl3);
                    break;
                case 4:
                    frameByFrame(lvl4);
                    break;
                case 5:
                    frameByFrame(lvl5);
                    break;
                case 6:
                    frameByFrame(lvl6);
                    break;
                case 7:
                    frameByFrame(lvl7);
                    break;
                case 8:
                    frameByFrame(lvl8);
                    break;
                case 9:
                    frameByFrame(lvl9);
                    break;
                case 10:
                    frameByFrame(lvl10);
                    break;
                case 11:
                    frameByFrame(lvl11);
                    break;
                case 12:
                    frameByFrame(lvl12);
                    break;
                case 13:
                    frameByFrame(lvl13);
                    break;
            }
        }

        private async void frameByFrame(Image Goallvl)
        {
            Character.Visibility = Visibility.Hidden;
            CharacterWalking.Visibility = Visibility.Visible;

            Thickness thicknessCharakter = Character.Margin;
            Thickness thicknessLvl = Goallvl.Margin;
            double differenceLeft = thicknessCharakter.Left - thicknessLvl.Left;
            double differenceBottom = thicknessCharakter.Bottom - thicknessLvl.Bottom;
            sound.resumeRunning();
            for (int i = 0; i < 100; i++)
            {
                await Task.Delay(10);
                thicknessCharakter.Left = thicknessCharakter.Left - (differenceLeft / 100);
                thicknessCharakter.Bottom = thicknessCharakter.Bottom - (differenceBottom / 100);
                CharacterWalking.Margin = thicknessCharakter;
                Charactername.Margin = thicknessCharakter;
            }

            Character.Margin = CharacterWalking.Margin;
            Character.Visibility = Visibility.Visible;
            CharacterWalking.Visibility = Visibility.Hidden;
            animationCompleted = true;
            sound.stopRunning();
        }

        private void arrowDown_Click(object sender, RoutedEventArgs e)
        {
            if (!animationCompleted || goallvl < 1 || goallvl == 1 && currentlvl == 1) return;
            if (goallvl > 1)
            {
                goallvl = goallvl - 1;
            }
            moveTo(currentlvl, goallvl);

        }

        private void keyEvent(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                arrowUp_Click(sender, e);
            }

            if (e.Key == Key.Down)
            {
                arrowDown_Click(sender, e);
            }
        }
    }
}

