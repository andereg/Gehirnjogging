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
using DB_GehirnJogging;
using DB_GehirnJogging.Repositories;

namespace GehirnJogging
{
    public partial class LevelPage : Page
    {
        /// <summary>
        /// Nach einem Navigieren auf diese Seite, löst es ein neues Event aus, welche die private Methode onNavigated ausführt 
        /// </summary>
        public LevelPage()
        {
            InitializeComponent();
            Start.getNavigationService().Navigated += onNavigated;
        }

        private async void onNavigated(object sender, NavigationEventArgs e)
        {
            music.playTheme();
            sounds.loadRunning();

            Player.getInstance().health = 100;
            PBarCharacterHealth.Value = Player.getInstance().health;
            PBarCharacterHealth.Maximum = Player.getInstance().health;
            if (Player.getInstance().playingLevel > 1)
            {
                string imagenr = "Level" + Convert.ToString(Player.getInstance().playingLevel) + ".png";
                Backgroundimage.Source = new BitmapImage(new Uri(@"\Images\Backgrounds\" + imagenr, UriKind.Relative));
            }
            PBarTimer.Maximum = 200 - Player.getInstance().playingLevel * 10;
            _maxTime = PBarTimer.Maximum;
            PBarTimer.Value = _maxTime;
            lblLevelX.Content = "Level " + Player.getInstance().playingLevel;

            fadeLabelIn(lblLevelX);
        }

        Music music = new Music();
        Sound sounds = new Sound();
        bool isMusicPlaying = true;
        int moveAmount = 5;
        bool animationCompleted = true;
        bool enemyDefeated = true;
        private Thickness MarginEnemy;
        private double _differenceEnemyToCharacter;
        private double _maxTime;
        private int _numberOfDefeatedEnemys;
        private bool _levelCompleted = false;
        private int _questionAnswer;
        private bool _questionAnswered = false;



        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            btnPause.Visibility = Visibility.Hidden;
            GridPause.Visibility = Visibility.Visible;
        }

        private void sliderMusic_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            music.changeVolume(sliderMusic.Value / 10);

        }

        private void btnMusicOnOFf_Click(object sender, RoutedEventArgs e)
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

        private void btnResume_Click(object sender, RoutedEventArgs e)
        {
            GridPause.Visibility = Visibility.Hidden;
            btnPause.Visibility = Visibility.Visible;
            startTimer();

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            music.stopTheme();
            sounds.stopRunning();
            Start.navigateTo("worldpage");
            Start.resetPage("levelpage");
        }

        private void keyRight_Click(object sender, RoutedEventArgs e)
        {
            if (animationCompleted) moveRight();
        }

        private void keyLeft_Click(object sender, RoutedEventArgs e)
        {
            if (animationCompleted) moveLeft();
        }

        private async void moveBackground(int amount)
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
                    switchCharacterAnimationFromStandToRun(true);
                    await Task.Delay(10);
                }
                animationCompleted = true;
                sounds.stopRunning();
                switchCharacterAnimationFromStandToRun(false);
            }

            if (MarginBackground.Left < -3700)
            {
                completeLevel();
                sounds.stopRunning();
            }

            Random random = new Random();
            if (MarginBackground.Left < -1000 && _numberOfDefeatedEnemys < 1)
            {
                Enemy.getInstance().Health = 20 + Player.getInstance().playingLevel * 2 - random.Next(-10 , 10);
                showEnemy();
            }
            if (MarginBackground.Left < -2500 && _numberOfDefeatedEnemys < 2)
            {
                Enemy.getInstance().Health = 20 + Player.getInstance().playingLevel * 4 - -random.Next(-20, 10);
                showEnemy();
            }
            if (MarginBackground.Left < -3500 && _numberOfDefeatedEnemys < 3)
            {
                Enemy.getInstance().Health = 50 + Player.getInstance().playingLevel * 4 - -random.Next(-20, 10);
                showEnemy();
            }
        }

        private async void completeLevelAnimation()
        {
            Thickness newCharacterMargin = Character.Margin;
            for (int i = 0; i < 100; i++)
            {
                newCharacterMargin.Left += 5;
                newCharacterMargin.Right -= 2;
                Character.Margin = newCharacterMargin;
                await Task.Delay(10);
            }
        }

        private async void completeLevel()
        {
            if (!_levelCompleted)
            {
                completeLevelAnimation();
                fadeLabelIn(lblLevelCompleted);

                await Task.Delay(2000);
                LevelCompleted.Visibility = Visibility.Visible;
                Backgroundimage.Visibility = Visibility.Hidden;
                fadeImageIn(Background2);
                sounds.playCompleteLevel();
                CharakterRepository ctx = new CharakterRepository(new GehirnjoggingEntities());
                if (Player.getInstance().level == Player.getInstance().playingLevel)
                {
                    ctx.incrementStageByName(Player.getInstance().playerName);
                    Player.getInstance().level++;
                }
                _levelCompleted = true;
            }
            else return;
        }

        private void keyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Right)
            {
                if (animationCompleted)
                {
                    moveRight();
                }
            }

            if (e.Key == Key.Left)
            {
                if (animationCompleted)
                {
                    moveLeft();
                }
            }
        }

        private async void moveLeft()
        {
            sounds.resumeRunning();
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
                    switchCharacterAnimationFromStandToRun(true);
                    await Task.Delay(10);
                }
                animationCompleted = true;
                sounds.stopRunning();
                switchCharacterAnimationFromStandToRun(false);
            }
        }

        private void switchCharacterAnimationFromStandToRun(bool forward)
        {
            if (forward)
            {
                CharacterRuns.Margin = Character.Margin;
                CharacterRuns.Visibility = Visibility.Visible;
                Character.Visibility = Visibility.Hidden;
            }
            else
            {
                CharacterRuns.Visibility = Visibility.Hidden;
                Character.Visibility = Visibility.Visible;
            }
        }


        private async void moveRight()
        {
            if (!enemyDefeated) return;
            sounds.resumeRunning();
            Thickness MarginCharacter = Character.Margin;
            if (MarginCharacter.Left < 500 && animationCompleted)
            {
                animationCompleted = false;
                for (int i = 0; i < 10; i++)
                {
                    MarginCharacter.Left = MarginCharacter.Left + moveAmount;
                    MarginCharacter.Right = MarginCharacter.Right - moveAmount;
                    Character.Margin = MarginCharacter;
                    switchCharacterAnimationFromStandToRun(true);
                    await Task.Delay(10);
                }
                animationCompleted = true;
                sounds.stopRunning();
                switchCharacterAnimationFromStandToRun(false);
            }
            else moveBackground(moveAmount);
        }

        private async void attackEnemy()
        {
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
            hurtEnemy();
            animationCompleted = true;
        }
        /// <summary>
        /// 
        /// </summary>
        private async void showEnemy()
        {
            KeyRight.Visibility = Visibility.Hidden;
            KeyLeft.Visibility = Visibility.Hidden;
            enemyDefeated = false;
            EnemyStanding.Visibility = Visibility.Visible;
            PBarLifeEnemy.Visibility = Visibility.Visible;
            BorderLifeEnemy.Visibility = Visibility.Visible;
            sounds.stopRunning();
            PBarLifeEnemy.Value = Enemy.getInstance().Health;
            PBarLifeEnemy.Maximum = Enemy.getInstance().Health;
            MarginEnemy = EnemyStanding.Margin;
            await Task.Delay(1000);
            showQuestion();

        }

        /// <summary>
        /// 
        /// </summary>
        private async void hurtEnemy()
        {
            CharakterRepository ctx = new CharakterRepository(new GehirnjoggingEntities());
            Random random = new Random();
            int randomDamage = random.Next(-7, 7);
            randomDamage = ctx.getAttackDamageByName(Player.getInstance().playerName) - randomDamage;
            int rotating = random.Next(-30, 30);
            Enemy.getInstance().Health = Enemy.getInstance().Health - randomDamage;
            if (Enemy.getInstance().Health < 1) defeatEnemy();

            PBarLifeEnemy.Value = Enemy.getInstance().Health;

            AttackDamageCharacter.Content = randomDamage;
            AttackDamageCharacter.Visibility = Visibility.Visible;

            RotateTransform rotateTransform1 = new RotateTransform(rotating);
            AttackDamageCharacter.RenderTransform = rotateTransform1;

            Thickness attackDamage = new Thickness();
            attackDamage.Left = EnemyStanding.Margin.Left - random.Next(-30, 30);
            attackDamage.Right = EnemyStanding.Margin.Right - random.Next(-30, 30);
            attackDamage.Top = AttackDamageCharacter.Margin.Top - random.Next(-30, 30);
            attackDamage.Bottom = AttackDamageCharacter.Margin.Bottom - random.Next(-30, 30);

            await Task.Delay(400);
            fadeLabelOut(AttackDamageCharacter);
            if (Enemy.getInstance().Health > 0)
            {
                await Task.Delay(1000);
                showQuestion(); ;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private async void hurtCharacter()
        {
            Random random = new Random();
            int damage = random.Next(7, 30);
            int rotating = random.Next(-30, 30);

            Player.getInstance().health = Player.getInstance().health - damage;
            if (Player.getInstance().health < 1) defeatCharacter();
            PBarCharacterHealth.Value = Player.getInstance().health;

            AttackDamageEnemy.Content = damage;
            AttackDamageEnemy.Visibility = Visibility.Visible;

            RotateTransform rotateTransform1 = new RotateTransform(rotating);
            AttackDamageEnemy.RenderTransform = rotateTransform1;
            Thickness attackDamage = new Thickness();
            attackDamage.Left = Character.Margin.Left - random.Next(-30, 30);
            attackDamage.Right = Character.Margin.Right - random.Next(-30, 30);
            attackDamage.Top = AttackDamageEnemy.Margin.Top - random.Next(-30, 30);
            attackDamage.Bottom = AttackDamageEnemy.Margin.Bottom - random.Next(-30, 30);

            await Task.Delay(400);
            fadeLabelOut(AttackDamageEnemy);
            if (Player.getInstance().health > 0)
            {
                await Task.Delay(1500);
                showQuestion();
            }
        }

        private void showQuestion()
        {
            _questionAnswered = false;
            Random random = new Random();

            Question.Visibility = Visibility.Visible;
            QuestionRepository questionRepository = new QuestionRepository(new GehirnjoggingEntities());
            List<string> questions = questionRepository.getQuestions();

            int questionnumber = random.Next(0, questions.Count);
            questioncontent.Content = questions[questionnumber];

            List<int> answers = questionRepository.getAnswers();
            _questionAnswer = answers[questionnumber];
            startTimer();

        }

        private async void startTimer()
        {
            sounds.playTimer();
            for (int i = 0; i < PBarTimer.Maximum; i++)
            {
                await Task.Delay(100);
                PBarTimer.Value--;
                if (_questionAnswered)
                {
                    await Task.Delay(1000);
                    sounds.stopTimer();
                    return;
                }
            }
            fadeImageIn(imageIconFalse);
            sounds.stopTimer();
            sounds.playFalseAnswer();
            await Task.Delay(1000);
            Question.Visibility = Visibility.Hidden;
            PBarTimer.Value = _maxTime;
            imageIconFalse.Visibility = Visibility.Hidden;
            enemyAttacks();
        }


        private async void defeatEnemy()
        {
            KeyRight.Visibility = Visibility.Visible;
            KeyLeft.Visibility = Visibility.Visible;
            EnemyStanding.Visibility = Visibility.Hidden;
            PBarLifeEnemy.Visibility = Visibility.Hidden;
            BorderLifeEnemy.Visibility = Visibility.Hidden;

            EnemyDies.Margin = EnemyStanding.Margin;
            EnemyDies.Visibility = Visibility.Visible;
            await Task.Delay(600);
            EnemyDies.Visibility = Visibility.Hidden;
            EnemyDiesFrameOnly.Margin = EnemyStanding.Margin;
            EnemyDiesFrameOnly.Visibility = Visibility.Visible;
            enemyDefeated = true;
            _numberOfDefeatedEnemys++;

            fadeImageOut(EnemyDiesFrameOnly);
        }

        private async void defeatCharacter()
        {
            Character.Visibility = Visibility.Hidden;
            GridGameOver.Visibility = Visibility.Visible;
            CharacterDies.Margin = Character.Margin;
            CharacterDies.Visibility = Visibility.Visible;
            await Task.Delay(700);
            CharacterDies.Visibility = Visibility.Hidden;
            CharacterDiesFrameOnly.Margin = Character.Margin;
            CharacterDiesFrameOnly.Visibility = Visibility.Visible;

            fadeImageOut(CharacterDiesFrameOnly);
        }

        private async void enemyAttacks()
        {
            EnemyStanding.Visibility = Visibility.Hidden;
            moveEnemy(true);
            do
            {
                await Task.Delay(10);
            } while (animationCompleted == false);
            animationCompleted = false;
            EnemyAttackAnimation.Visibility = Visibility.Visible;
            await Task.Delay(800);
            EnemyAttackAnimation.Visibility = Visibility.Hidden;
            hurtCharacter();
            animationCompleted = true;
            moveEnemy(false);
        }

        private async void moveEnemy(bool forward)
        {
            animationCompleted = false;
            EnemyWalking.Visibility = Visibility.Visible;
            Thickness thicknessCharakter = new Thickness();
            if (forward)
            {
                thicknessCharakter = Character.Margin;
                _differenceEnemyToCharacter = 400;
            }
            else _differenceEnemyToCharacter = -400;
            Thickness thicknessEnemy = EnemyWalking.Margin;
            Thickness thicknessEnemyHealthBar = PBarLifeEnemy.Margin;
            sounds.resumeRunning();

            for (int i = 0; i < 100; i++)
            {
                await Task.Delay(10);
                thicknessEnemy.Left = thicknessEnemy.Left - (_differenceEnemyToCharacter / 100);
                thicknessEnemy.Right = thicknessEnemy.Right + (_differenceEnemyToCharacter / 100);
                thicknessEnemyHealthBar.Left = thicknessEnemyHealthBar.Left - (_differenceEnemyToCharacter / 100);
                thicknessEnemyHealthBar.Right = thicknessEnemyHealthBar.Right + (_differenceEnemyToCharacter / 100);
                EnemyWalking.Margin = thicknessEnemy;
                PBarLifeEnemy.Margin = thicknessEnemyHealthBar;
                BorderLifeEnemy.Margin = thicknessEnemyHealthBar;
            }
            sounds.stopRunning();
            animationCompleted = true;
            EnemyWalking.Visibility = Visibility.Hidden;
            if (!forward)
            {
                EnemyStanding.Visibility = Visibility.Visible;
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            music.stopTheme();
            sounds.stopRunning();
            Start.navigateTo("startpage");
        }

        private async void fadeImageOut(Image image)
        {
            for (int i = 0; i < 200; i++)
            {
                await Task.Delay(20);
                image.Opacity = image.Opacity - 0.005;
            }

            image.Visibility = Visibility.Hidden;
            image.Opacity = 1;
        }

        private async void fadeImageIn(Image image)
        {
            image.Opacity = 0;
            image.Visibility = Visibility.Visible;
            for (int i = 0; i < 100; i++)
            {
                await Task.Delay(2);
                image.Opacity = image.Opacity + 0.01;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        private async void fadeLabelOut(Label label)
        {
            for (int i = 0; i < 100; i++)
            {
                await Task.Delay(5);
                label.Opacity = label.Opacity - 0.01;
            }
            label.Visibility = Visibility.Hidden;
            label.Opacity = 1;
        }

        private async void fadeLabelIn(Label label)
        {
            label.Visibility = Visibility.Visible;
            label.Opacity = 0;
            for (int i = 0; i < 50; i++)
            {
                await Task.Delay(5);
                label.Opacity = label.Opacity + 0.02;
            }
            await Task.Delay(6000);
            fadeLabelOut(lblLevelX);
        }

        private async void submitAnswerButton_Click(object sender, RoutedEventArgs e)
        {
            _questionAnswered = true;
            if (questionAnswer.Text.Equals(_questionAnswer.ToString()))
            {
                fadeImageIn(imageIconRight);
                sounds.playCorrectAnswer();
                await Task.Delay(1000);
                Question.Visibility = Visibility.Hidden;
                imageIconRight.Visibility = Visibility.Hidden;
                attackEnemy();
            }
            else
            {
                fadeImageIn(imageIconFalse);
                sounds.playFalseAnswer();
                await Task.Delay(1000);
                Question.Visibility = Visibility.Hidden;
                imageIconFalse.Visibility = Visibility.Hidden;
                enemyAttacks();
            }
            PBarTimer.Value = _maxTime;
            questionAnswer.Text = "";
        }

        private void btnBackToWorldMap_Click(object sender, RoutedEventArgs e)
        {
            music.stopTheme();
            sounds.stopRunning();
            Start.navigateTo("worldpage");
            Start.resetPage("levelpage");
        }
    }
}

