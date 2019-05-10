﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using Repositories.Abstract;

namespace GehirnJogging
{
    /// <summary>
    /// Interaktionslogik für Startpage.xaml
    /// </summary>
    public partial class Startpage : Page
    {

        private Player _player = Player.GetInstance();
        private int _scrollValue = 1;
        private int _maxButtons;
        private bool _spielstandLoaded = false;

        /// <summary>
        /// Nach einem Navigieren auf diese Seite, löst es ein neues Event aus, welche die private Methode OnNavigated ausführt
        /// </summary>
        public Startpage()
        {
            InitializeComponent();
            Start.GetNavigationService().Navigated += OnNavigated;
        }

        private void OnNavigated(object sender, NavigationEventArgs e)
        {
            nameinputtext.Text = null;
            GridNewGame.Visibility = Visibility.Hidden;
        }

        private void BtnNewPlayer_Click(object sender, RoutedEventArgs e)
        {
            lblusernameAlreadyGiven.Visibility = Visibility.Hidden;
            lblusernameCantBeEmpty.Visibility = Visibility.Hidden;

            CharakterRepository charakterRepository = new CharakterRepository(new GehirnjoggingEntities());
            if (nameinputtext.Text.Equals(""))
            {
                lblusernameCantBeEmpty.Visibility = Visibility.Visible;
                return;
            }
            if (charakterRepository.CharacternameExists(nameinputtext.Text))
            {
                lblusernameAlreadyGiven.Visibility = Visibility.Visible;
                return;
            }
            Player.GetInstance().PlayerName = nameinputtext.Text;

            charakterRepository.createNewUser(nameinputtext.Text);
            navigateToWorldpage();
        }

        private void navigateToWorldpage()
        {
            Start.NavigateTo("worldpage");
            Start.resetPage("startpage");
        }

        private void BtnnewGame_Click(object sender, RoutedEventArgs e)
        {
            GridNewGame.Visibility = Visibility.Visible;
        }

        private void EndGame(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ExitNewWorld_Click(object sender, RoutedEventArgs e)
        {
            GridNewGame.Visibility = Visibility.Hidden;
        }

        private void BtnloadGame_Click(object sender, RoutedEventArgs e)
        {
            CharakterRepository ctx = new CharakterRepository(new GehirnjoggingEntities());
            _maxButtons = ctx.countCharakters();

            int marginTop = 333;
            GridLoadGame.Visibility = Visibility.Visible;
            Button btn;
            List<String> CharacterNames = ctx.getCharakterNames();
            List<int> CharacterStages = ctx.getCharakterStages();
            string playerName;
            int playerStage;
            if (_spielstandLoaded) return;

            for (int i = 0; i < _maxButtons; i++)
            {
                playerName = CharacterNames[i];
                playerStage = CharacterStages[i];
                if (i > 4)
                {
                    btn = new Button { HorizontalAlignment = HorizontalAlignment.Left, TabIndex = playerStage, Name ="B" + playerName ,Tag = i + 1, FontSize = 30, Content = playerName + " Stage " + playerStage, FontWeight = FontWeights.Bold, Background = Brushes.LightYellow, BorderBrush = Brushes.Black, BorderThickness = new Thickness(8), Margin = new Thickness(585, marginTop, 0, 0), Visibility = Visibility.Hidden, VerticalAlignment = VerticalAlignment.Top, Width = 765, Height = 74 };
                }
                else
                {
                    btn = new Button { HorizontalAlignment = HorizontalAlignment.Left, TabIndex = playerStage, Name = "B"+ playerName, Tag = i + 1, FontSize = 30, Content = playerName + " Stage " + playerStage, FontWeight = FontWeights.Bold, Background = Brushes.LightYellow, BorderBrush = Brushes.Black, BorderThickness = new Thickness(8), Margin = new Thickness(585, marginTop, 0, 0), VerticalAlignment = VerticalAlignment.Top, Width = 765, Height = 74};
                }

                btn.Click += new RoutedEventHandler(loadGame);

                this.GridSpielstandButtons.Children.Add(btn);
                marginTop = marginTop + 80;
            }
            _spielstandLoaded = true;
        }

        private void loadGame(object sender, RoutedEventArgs e)
        {
            Player.GetInstance().Level = (sender as Button).TabIndex -1;
            string Charactername = (sender as Button).Name;
            Charactername = Charactername.Remove(0, 1);
            Player.GetInstance().PlayerName = Charactername;
            navigateToWorldpage();
        }

        private void ExitLoadGame_Click(object sender, RoutedEventArgs e)
        {
            GridLoadGame.Visibility = Visibility.Hidden;
        }

        private void ArrowUp_Click(object sender, RoutedEventArgs e)
        {
            if (_scrollValue == 1)
            {
                return;
            }
            foreach (Button spielstand in GridSpielstandButtons.Children)
            {
                if (spielstand.Tag.GetHashCode() == _scrollValue - 1)
                {
                    spielstand.Visibility = Visibility.Visible;
                }
                if (spielstand.Tag.GetHashCode() == _scrollValue + 4)
                {
                    spielstand.Visibility = Visibility.Hidden;
                }
            }
            Thickness GridSpielstandButtonsmarginTop = GridSpielstandButtons.Margin;
            GridSpielstandButtonsmarginTop.Top = GridSpielstandButtonsmarginTop.Top + 80;
            GridSpielstandButtons.Margin = GridSpielstandButtonsmarginTop;

            _scrollValue--;

        }

        private void ArrowDown_Click(object sender, RoutedEventArgs e)
        {

            if (_scrollValue + 4 == _maxButtons)
            {
                return;
            }

            foreach (Button spielstand in GridSpielstandButtons.Children)
            {
                if (spielstand.Tag.GetHashCode() == _scrollValue)
                {
                    spielstand.Visibility = Visibility.Hidden;
                }
                if (spielstand.Tag.GetHashCode() == _scrollValue + 5)
                {
                    spielstand.Visibility = Visibility.Visible;
                }
            }
            Thickness GridSpielstandButtonsmarginTop = GridSpielstandButtons.Margin;
            GridSpielstandButtonsmarginTop.Top = GridSpielstandButtonsmarginTop.Top - 80;
            GridSpielstandButtons.Margin = GridSpielstandButtonsmarginTop;

            _scrollValue++;
        }
    }
}
