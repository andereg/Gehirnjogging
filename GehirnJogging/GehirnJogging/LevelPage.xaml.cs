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
    /// Interaktionslogik für LevelPage.xaml
    /// </summary>
    public partial class LevelPage : Page
    {
        public LevelPage()
        {
            InitializeComponent();
            Start.GetNavigationService().Navigated += OnNavigated;
        }

        private void OnNavigated(object sender, NavigationEventArgs e)
        {
            label.Content = Player.GetInstance().PlayerName;
            music.playTheme();
            sounds.loadRunning();
        }


        Music music = new Music();
        Sound sounds = new Sound();
        bool isMusicPlaying = true;
        bool isSoundOn = true;
        int moveAmount = 5;
        bool animationCompleted = true;
        bool enemyDefeated = true;
        Random random = new Random();

        private void BtnPause_Click(object sender, RoutedEventArgs e)
        {
            btnPause.Visibility = Visibility.Hidden;
            GridPause.Visibility = Visibility.Visible;

        }

        private void SliderMusic_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            music.decreaseVolume(sliderMusic.Value / 10);

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
            music.stopTheme();
            sounds.stopRunning();
            Start.NavigateTo("worldpage");
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
            if (MarginBackground.Right < -200 && animationCompleted)
            {
                animationCompleted = false;
                for (int i = 0; i < 10; i++)
                {
                    MarginBackground.Left = MarginBackground.Left - amount;
                    MarginBackground.Right = MarginBackground.Right + amount;
                    Backgroundimage.Margin = MarginBackground;
                    await Task.Delay(10);
                }
                animationCompleted = true;
                sounds.stopRunning();
            }

            if (MarginBackground.Left < -1000)
            {
                ShowEnemy();
            }
        }

        private void keyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Left)
            {
                MoveLeft();
                sounds.resumeRunning();
            }

            if (e.Key == Key.Right)
            {
                MoveRight();
                sounds.resumeRunning();
            }
        }

        private async void MoveLeft()
        {
            if (!enemyDefeated) return;
            Thickness MarginCharacter = Character.Margin;
            if (MarginCharacter.Left > 180 && animationCompleted)
            {
                animationCompleted = false;
                for (int i = 0; i < 10; i++)
                {
                    MarginCharacter.Left = MarginCharacter.Left - moveAmount;
                    MarginCharacter.Right = MarginCharacter.Right + moveAmount;
                    Character.Margin = MarginCharacter;
                    await Task.Delay(10);
                }
                animationCompleted = true;
                sounds.stopRunning();
            }
        }

        private async void MoveRight()
        {
            if (!enemyDefeated) return;
            Thickness MarginCharacter = Character.Margin;
            if (MarginCharacter.Left < 500 && animationCompleted)
            {
                animationCompleted = false;
                for (int i = 0; i < 10; i++)
                {
                    MarginCharacter.Left = MarginCharacter.Left + moveAmount;
                    MarginCharacter.Right = MarginCharacter.Right - moveAmount;
                    Character.Margin = MarginCharacter;
                    await Task.Delay(10);
                }
                animationCompleted = true;
                sounds.stopRunning();
            }
            else MoveBackground(moveAmount);
        }

        private async void Attack_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                await Task.Delay(1);
            } while (animationCompleted == false);
            animationCompleted = false;
            Character.Visibility = Visibility.Hidden;
            CharacterAttack.Visibility = Visibility.Visible;
            Thickness MarginAttackAnimation = CharacterAttack.Margin;
            MarginAttackAnimation.Left = Character.Margin.Left;
            MarginAttackAnimation.Right = Character.Margin.Right;

            CharacterAttack.Margin = MarginAttackAnimation;

            await Task.Delay(600);
            AttackAnimation.Visibility = Visibility.Visible;

            await Task.Delay(400);
            Character.Visibility = Visibility.Visible;
            CharacterAttack.Visibility = Visibility.Hidden;

            await Task.Delay(600);
            AttackAnimation.Visibility = Visibility.Hidden;
            HurtEnemy();
            animationCompleted = true;
        }

        public void ShowEnemy()
        {
            KeyRight.Visibility = Visibility.Hidden;
            KeyLeft.Visibility = Visibility.Hidden;
            Attack.Visibility = Visibility.Visible;
            enemyDefeated = false;
            Minotaurus.Visibility = Visibility.Visible;
            PBarLifeEnemy.Visibility = Visibility.Visible;
            Enemy.GetInstance().Health = 100;
        }

        public async void HurtEnemy()
        {
            int damage = random.Next(7, 30);
            int rotating = random.Next(-30, 30);

            Enemy.GetInstance().Health = Enemy.GetInstance().Health - damage;
            if (Enemy.GetInstance().Health < 1) DefeatEnemy();

            PBarLifeEnemy.Value = PBarLifeEnemy.Value - damage;

            AttackDamage.Content = damage;
            AttackDamage.Visibility = Visibility.Visible;
      
            RotateTransform rotateTransform1 = new RotateTransform(rotating);
            AttackDamage.RenderTransform = rotateTransform1;

            Thickness attackDamage = new Thickness();
            attackDamage.Left = AttackDamage.Margin.Left - random.Next(-30, 30);
            attackDamage.Right = AttackDamage.Margin.Right - random.Next(-30, 30);
            attackDamage.Top = AttackDamage.Margin.Top - random.Next(-30, 30);
            attackDamage.Bottom = AttackDamage.Margin.Bottom - random.Next(-30, 30);

            await Task.Delay(400);
            AttackDamage.Visibility = Visibility.Hidden;

        }

        public void DefeatEnemy()
        {
            KeyRight.Visibility = Visibility.Visible;
            KeyLeft.Visibility = Visibility.Visible;
            Minotaurus.Visibility = Visibility.Hidden;
            PBarLifeEnemy.Visibility = Visibility.Hidden;
            enemyDefeated = true;
        }
    }
}

