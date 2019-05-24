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
    /// In dieser Klasse werden die funktionalitäten der Worldmap definiert d.h. Funktionalitäten der Buttons, das Bewegen auf der map und Navigieren auf andere Pages sind hier definiert.
    /// </summary>
    public partial class Worldpage : Page
    {

        private int _currentlvl = 1;
        private int _goallvl = 1;
        private bool _animationCompleted = true;
        private Sound _sound = new Sound();

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
            _sound.loadRunning();
            if (Player.getInstance().level < 2)
            {
                GridManual.Visibility = Visibility.Visible;
            }
        }

        private void btnBack(object sender, RoutedEventArgs e)
        {
            Start.navigateTo("startpage");
            Start.resetPage("worldpage");

        }

        private async void btnStartLevel_Click(object sender, RoutedEventArgs e)
        {
            while(Character.Height > 0)
            {
                Thickness newCharacterMargin = Character.Margin;
                newCharacterMargin.Left += 0.4;
                newCharacterMargin.Bottom += 0.3;
                Character.Height--;
                Character.Margin = newCharacterMargin;
                await Task.Delay(10);
            }
            Player.getInstance().playingLevel = _currentlvl;
            Start.resetPage("worldpage");
            Start.navigateTo("levelpage");
        }

        private async void btnHolyCarrot_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            BtnHolyCarrot.Opacity = 1;
            Thickness thx = new Thickness(1920, 36, 0, 0);
            BtnHolyCarrot.Margin = thx;
            double random1left = random.Next(1100, 1300);
            double random1top = random.Next(200, 350);
            double random2left = random.Next(820, 1200);
            double random2top = random.Next(700, 1000);

            for (int i = 0; i < 100; i++)
            {
                Thickness CarrotMargin = BtnHolyCarrot.Margin;
                CarrotMargin.Left = CarrotMargin.Left - random1left / 100;
                CarrotMargin.Top = CarrotMargin.Top + random1top / 100;
                BtnHolyCarrot.Margin = CarrotMargin;
                await Task.Delay(10);
            }

            for (int i = 0; i < 100; i++)
            {
                Thickness CarrotMargin = BtnHolyCarrot.Margin;
                CarrotMargin.Left = CarrotMargin.Left - random2left / 100;
                CarrotMargin.Top = CarrotMargin.Top + random2top / 100;
                BtnHolyCarrot.Margin = CarrotMargin;
                await Task.Delay(10);
            }
        }

        private void arrowUp_Click(object sender, RoutedEventArgs e)
        {
            if (!_animationCompleted || _goallvl > Player.getInstance().level) return;
            if (_goallvl != 13)
            {
                _goallvl = _goallvl + 1;
                moveTo(_currentlvl, _goallvl);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="Goal"></param>
        private void moveTo(int target, int Goal)
        {
            if (!_animationCompleted) return;

            int maxLevel = Player.getInstance().level + 1;

            if (Goal > maxLevel)
            {
                return;
            }

            _animationCompleted = false;
            lbllevel.Content = _goallvl;
            if (_goallvl < 4)
            {
                lblSchwierigkeit.Content = "Easy";
            }
            if (_goallvl < 10 && _goallvl > 3)
            {
                lblSchwierigkeit.Content = "Medium";
            }
            if (_goallvl > 9)
            {
                lblSchwierigkeit.Content = "Hard";
            }

            Player.getInstance().playingLevel = _goallvl;

            switch (_goallvl)
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
            _sound.resumeRunning();
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
            _animationCompleted = true;
            _sound.stopRunning();
            _currentlvl = _goallvl;
        }

        private void arrowDown_Click(object sender, RoutedEventArgs e)
        {
            if (!_animationCompleted || _goallvl < 1 || _goallvl == 1 && _currentlvl == 1) return;
            if (_goallvl > 1)
            {
                _goallvl = _goallvl - 1;
            }
            moveTo(_currentlvl, _goallvl);

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

        private void ExitManual_Click(object sender, RoutedEventArgs e)
        {
            GridManual.Visibility = Visibility.Hidden;
        }
    }
}

