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
        /// 
        /// </summary>
        public Worldpage()
        {
            InitializeComponent();
            Start.GetNavigationService().Navigated += OnNavigated;
        }

        private void OnNavigated(object sender, NavigationEventArgs e)
        {
            Charactername.Content = Player.GetInstance().PlayerName;
            sound.loadRunning();
        }

        int currentlvl = 1;
        int goallvl = 1;
        bool animationCompleted = true;
        Sound sound = new Sound();

        private void btnback(object sender, RoutedEventArgs e)
        {
            Start.NavigateTo("startpage");
            Start.resetPage("worldpage");

        }

        private void BtnStartLevel(object sender, RoutedEventArgs e)
        {
            Start.NavigateTo("levelpage");
        }

        private void ArrowUp_Click(object sender, RoutedEventArgs e)
        {
            if (!animationCompleted || goallvl > Player.GetInstance().Level + 1) return;
            if (goallvl != 13)
            {
                goallvl = goallvl + 1;
                MoveTo(currentlvl, goallvl);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="Goal"></param>
        private void MoveTo(int target, int Goal)
        {
            if (!animationCompleted) return;

            int maxLevel = Player.GetInstance().Level + 1;

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

        private async void FrameByFrame(Image Goallvl)
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

        private void ArrowDown_Click(object sender, RoutedEventArgs e)
        {
            if (!animationCompleted) return;
            if (goallvl != 1 && goallvl != 0)
            {
                goallvl = goallvl - 1;
                MoveTo(currentlvl, goallvl);
            }
        }

        private void keyEvent(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                ArrowUp_Click(sender, e);
            }

            if (e.Key == Key.Down)
            {
                ArrowDown_Click(sender, e);
            }
        }
    }
}

