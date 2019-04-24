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
using System.Windows.Media.Animation;
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
        Sound sounds = new Sound();
        bool isMusicPlaying = true;
        bool isSoundOn = true;
        int moveAmount = 10;
        bool animationCompleted = true;

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
            music.decreaseVolume(sliderMusic.Value/10);
            
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

        private void KeyRight_Click(object sender, RoutedEventArgs e)
        {
            MoveRight();
        }

        private void KeyLeft_Click(object sender, RoutedEventArgs e)
        {
            MoveLeft();
        }

        private async void MoveBackground(int amount)
        {


            Thickness MarginBackground = Backgroundimage.Margin;
            if(MarginBackground.Right < -200 && animationCompleted)
            {
                animationCompleted = false;
                for(int i = 0; i<10; i++)
                {
                    MarginBackground.Left = MarginBackground.Left - amount;
                    MarginBackground.Right = MarginBackground.Right + amount;
                    Backgroundimage.Margin = MarginBackground;
                    await Task.Delay(100);
                }
                animationCompleted = true;
            }
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Left)
            {
                    MoveLeft();
                    sounds.playRunning();
            }

            if (e.Key == Key.Right)
            {
                    MoveRight();
                    sounds.playRunning();
            }
        }

        private async void MoveLeft()
        {
            Thickness MarginCharacter = Character.Margin;
            if (MarginCharacter.Left > 180 && animationCompleted)
            {
                animationCompleted = false;
                for (int i = 0; i < 10; i++)
                {
                    MarginCharacter.Left = MarginCharacter.Left - moveAmount;
                    MarginCharacter.Right = MarginCharacter.Right + moveAmount;
                    Character.Margin = MarginCharacter;
                    await Task.Delay(100);
                }
                animationCompleted = true;
            }
        }

        private async void MoveRight()
        {
            Thickness MarginCharacter = Character.Margin;
            if (MarginCharacter.Left < 500 && animationCompleted)
            {
                animationCompleted = false;
                for (int i = 0; i< 10; i++)
                {
                    MarginCharacter.Left = MarginCharacter.Left + moveAmount;
                    MarginCharacter.Right = MarginCharacter.Right - moveAmount;
                    Character.Margin = MarginCharacter;
                    await Task.Delay(100);
                }
                animationCompleted = true;
            }
            else MoveBackground(moveAmount);
        }

        private async void Attack_Click(object sender, RoutedEventArgs e)
        {
            Character.Visibility = Visibility.Hidden;
            CharacterAttack.Visibility = Visibility.Visible;
            Thickness MarginAttackAnimation = CharacterAttack.Margin;
            MarginAttackAnimation.Left = Character.Margin.Left;
            MarginAttackAnimation.Right = Character.Margin.Right;

            CharacterAttack.Margin = MarginAttackAnimation;

            await Task.Delay(1000);
            Character.Visibility = Visibility.Visible;
            CharacterAttack.Visibility = Visibility.Hidden;
        }
    }
}
