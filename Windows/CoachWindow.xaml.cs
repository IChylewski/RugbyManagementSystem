using MahApps.Metro.IconPacks;
using RugbyManagementSystem.Database.Data;
using RugbyManagementSystem.Database.Models;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace RugbyManagementSystem.Windows
{
    /// <summary>
    /// Interaction logic for CoachWindow.xaml
    /// </summary>
    public partial class CoachWindow : Window
    {
        MemberModel member;
        int memberID;
        string memberType;

        public CoachWindow()
        {
            InitializeComponent();
            DataContainer.UpdatePlayersList();

            PlayersList.ItemsSource = DataContainer.Players;
            SquadsList.ItemsSource = DataContainer.Teams;
            TeamSelection.ItemsSource = DataContainer.Teams;


        }



        private void Border_MouseDown(Object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void ButtonMinimize_Click(Object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void ButtonMaximize_Click(Object sender, MouseButtonEventArgs e)
        {
            PackIconMaterial maximizeIcon = sender as PackIconMaterial;
            this.WindowState = WindowState.Maximized;

            maximizeIcon.Kind = PackIconMaterialKind.WindowRestore;
            maximizeIcon.MouseDown -= ButtonMaximize_Click;
            maximizeIcon.MouseDown += ButtonRestore_Click;
        }
        private void ButtonRestore_Click(Object sender, MouseButtonEventArgs e)
        {
            PackIconMaterial restoreIcon = sender as PackIconMaterial;
            this.WindowState = WindowState.Normal;

            restoreIcon.Kind = PackIconMaterialKind.WindowMaximize;
            restoreIcon.MouseDown -= ButtonRestore_Click;
            restoreIcon.MouseDown += ButtonMaximize_Click;
        }
        private void ButtonExit_Click(Object sender, MouseButtonEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            e.Cancel = true;
        }

        private void RadioBtn_Click(object sender, RoutedEventArgs e)
        {
            if(PlayersBtn.IsChecked == true)
            {
                PlayersView.Visibility = Visibility.Visible;

                SquadsView.Visibility = Visibility.Collapsed;
                PlayerDevelopmentView.Visibility = Visibility.Collapsed;
                TeamSelectionView.Visibility = Visibility.Collapsed;
                TeamSquadView.Visibility = Visibility.Collapsed;
            }

            if (SquadsBtn.IsChecked == true)
            {
                SquadsView.Visibility = Visibility.Visible;

                PlayersView.Visibility = Visibility.Collapsed;
                PlayerDevelopmentView.Visibility = Visibility.Collapsed;
                TeamSelectionView.Visibility = Visibility.Collapsed;
                TeamSquadView.Visibility = Visibility.Collapsed;
            }
        }
        private void PlayerDevelopmentBtn_Click(object sender, MouseButtonEventArgs e)
        {
            PlayersBtn.IsChecked = false;
            PlayersView.Visibility = Visibility.Collapsed;

            PlayerDevelopmentView.Visibility = Visibility.Visible;
        }
        private void AddPlayerToTeamBtn_Click(object sender, MouseButtonEventArgs e)
        {
            PlayersBtn.IsChecked = false;
            PlayersView.Visibility = Visibility.Collapsed;

            PackIconMaterial plusButton = sender as PackIconMaterial;
            object[] identifier = plusButton.Tag as object[];
            memberID = (int)identifier[0];
            memberType = (string)identifier[1];

            TeamSelectionView.Visibility = Visibility.Visible;
        }
        private void AddPlayerToSquad_Click(object sender, MouseButtonEventArgs e)
        {
            StackPanel teamButton = sender as StackPanel;
            int teamID = (int)teamButton.Tag;
            switch (memberType)
            {
                case "Junior Player":
                    {
                        DataContainer.dataBase.ChangeJuniorPlayerTeam(memberID, teamID);
                        DataContainer.UpdateJuniorPlayersList();
                        DataContainer.UpdateTeamsList();
                        MessageBox.Show("Success");
                        break;
                    }
                case "Adult Player":
                    {
                        DataContainer.dataBase.ChangePlayerTeam(memberID, teamID);
                        DataContainer.UpdateAdultPlayersList();
                        DataContainer.UpdateTeamsList();
                        MessageBox.Show("Success");
                        break;
                    }
            }

            TeamSelectionView.Visibility = Visibility.Collapsed;

            PlayersView.Visibility = Visibility.Visible;
            PlayersBtn.IsChecked = true;

            DataContainer.UpdatePlayersList();
            PlayersList.Items.Refresh();
        }
        private void DisplayTeamSquadBtn_Click(object sender, MouseButtonEventArgs e)
        {
            SquadsBtn.IsChecked = false;
            SquadsView.Visibility = Visibility.Collapsed;

            TeamSquadView.Visibility = Visibility.Visible;
        }
    }
}
