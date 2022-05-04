using MahApps.Metro.IconPacks;
using RugbyManagementSystem.Database;
using RugbyManagementSystem.Database.Data;
using RugbyManagementSystem.Database.Models;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RugbyManagementSystem.Windows
{
    /// <summary>
    /// Interaction logic for CoachWindow.xaml
    /// </summary>
    public partial class CoachWindow : Window
    {
        private TeamModel team;
        private JuniorPlayerModel juniorPlayer;
        private PlayerModel adultPlayer;
        private int memberID;
        private string memberType;


        public CoachWindow()
        {
            InitializeComponent();
            DataContainer.UpdatePlayersList();
            UpdateTeamPlayers();
            UpdateTeamNames();

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
            if (PlayersBtn.IsChecked == true)
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
            TeamSquadView.Visibility = Visibility.Collapsed;

            // Gets clicked button and its Tag that is binded to user ID
            PackIconMaterial developmentButton = sender as PackIconMaterial;
            object[] identifier = developmentButton.Tag as object[];
            memberID = (int)identifier[0];
            memberType = (string)identifier[1];


            //Finds user with ID that is as same as ID in the button Tag property


            switch (memberType)
            {

                case "Junior Player":
                    {
                        foreach (JuniorPlayerModel x in DataContainer.JuniorPlayers)
                        {
                            if (x.ID == memberID)
                            {
                                juniorPlayer = x;
                                adultPlayer = null;
                                break;
                            }
                        }
                        break;
                    }
                case "Adult Player":
                    {
                        foreach (PlayerModel x in DataContainer.AdultPlayers)
                        {
                            if (x.ID == memberID)
                            {
                                adultPlayer = x;
                                juniorPlayer = null;
                                break;
                            }
                        }
                        break;
                    }
            }

            if (juniorPlayer != null)
            {
                PlayerNameBlock.Content = juniorPlayer.FullName;
                PassingStandardBox.Text = juniorPlayer.StandardPass.ToString();
                PassingSpinBox.Text = juniorPlayer.SpinPass.ToString();
                PassingPopBox.Text = juniorPlayer.PopPass.ToString();
                TacklingFrontBox.Text = juniorPlayer.FrontTackle.ToString();
                TacklingRearBox.Text = juniorPlayer.RearTackle.ToString();
                TacklingSideBox.Text = juniorPlayer.SideTackle.ToString();
                TacklingScrabbleBox.Text = juniorPlayer.ScrabbleTackle.ToString();
                KickingDropBox.Text = juniorPlayer.DropKick.ToString();
                KickingPuntBox.Text = juniorPlayer.PuntKick.ToString();
                KickingGrubberBox.Text = juniorPlayer.GrubberKick.ToString();
                KickingGoalBox.Text = juniorPlayer.GoalKick.ToString();
            }
            else if (adultPlayer != null)
            {
                PlayerNameBlock.Content = adultPlayer.FullName;
                PassingStandardBox.Text = adultPlayer.StandardPass.ToString();
                PassingSpinBox.Text = adultPlayer.SpinPass.ToString();
                PassingPopBox.Text = adultPlayer.PopPass.ToString();
                TacklingFrontBox.Text = adultPlayer.FrontTackle.ToString();
                TacklingRearBox.Text = adultPlayer.RearTackle.ToString();
                TacklingSideBox.Text = adultPlayer.SideTackle.ToString();
                TacklingScrabbleBox.Text = adultPlayer.ScrabbleTackle.ToString();
                KickingDropBox.Text = adultPlayer.DropKick.ToString();
                KickingPuntBox.Text = adultPlayer.PuntKick.ToString();
                KickingGrubberBox.Text = adultPlayer.GrubberKick.ToString();
                KickingGoalBox.Text = adultPlayer.GoalKick.ToString();
            }

            PlayerDevelopmentView.Visibility = Visibility.Visible;
        }
        private void EditPlayerDevelopmentBtn_Click(object sender, RoutedEventArgs e)
        {
            bool validation = true;                     // flag that indicates if validation proceess was succesfull

            if (CustomValidation.ValidateSkill("Standard Passing", PassingStandardBox.Text) == false)
            {
                validation = false;
            }
            else if(CustomValidation.ValidateSkill("Spin Passing", PassingSpinBox.Text) == false)
            {
                validation = false;
            }
            else if (CustomValidation.ValidateSkill("Pop Passing", PassingPopBox.Text) == false)
            {
                validation = false;
            }
            else if (CustomValidation.ValidateSkill("Front Tackling", TacklingFrontBox.Text) == false)
            {
                validation = false;
            }
            else if (CustomValidation.ValidateSkill("Rear Tackling", TacklingRearBox.Text) == false)
            {
                validation = false;
            }
            else if (CustomValidation.ValidateSkill("Side Tackling", TacklingSideBox.Text) == false)
            {
                validation = false;
            }
            else if (CustomValidation.ValidateSkill("Scrabble Tackling", TacklingScrabbleBox.Text) == false)
            {
                validation = false;
            }
            else if (CustomValidation.ValidateSkill("Drop Kicking", KickingDropBox.Text) == false)
            {
                validation = false;
            }
            else if (CustomValidation.ValidateSkill("Punt Kicking", KickingPuntBox.Text) == false)
            {
                validation = false;
            }
            else if (CustomValidation.ValidateSkill("Grubber Kicking", KickingGrubberBox.Text) == false)
            {
                validation = false;
            }
            else if (CustomValidation.ValidateSkill("Goal Kicking", KickingGoalBox.Text) == false)
            {
                validation = false;
            }


            if (validation == true)
            {

                switch (memberType)
                {
                    case "Junior Player":
                        {
                            DataContainer.dataBase.EditJuniorPlayerDevelopment(juniorPlayer.ID, Int32.Parse(PassingStandardBox.Text), Int32.Parse(PassingSpinBox.Text), Int32.Parse(PassingPopBox.Text), Int32.Parse(TacklingFrontBox.Text), Int32.Parse(TacklingRearBox.Text), Int32.Parse(TacklingSideBox.Text), Int32.Parse(TacklingScrabbleBox.Text), Int32.Parse(KickingDropBox.Text), Int32.Parse(KickingPuntBox.Text), Int32.Parse(KickingGrubberBox.Text), Int32.Parse(KickingGoalBox.Text));
                            DataContainer.UpdateJuniorPlayersList();
                            break;
                        }
                    case "Adult Player":
                        {
                            DataContainer.dataBase.EditPlayerDevelopment(adultPlayer.ID, Int32.Parse(PassingStandardBox.Text), Int32.Parse(PassingSpinBox.Text), Int32.Parse(PassingPopBox.Text), Int32.Parse(TacklingFrontBox.Text), Int32.Parse(TacklingRearBox.Text), Int32.Parse(TacklingSideBox.Text), Int32.Parse(TacklingScrabbleBox.Text), Int32.Parse(KickingDropBox.Text), Int32.Parse(KickingPuntBox.Text), Int32.Parse(KickingGrubberBox.Text), Int32.Parse(KickingGoalBox.Text));
                            DataContainer.UpdateAdultPlayersList();
                            break;
                        }
                }

                MessageBox.Show("Success");

                DataContainer.UpdatePlayersList();
                PlayersList.Items.Refresh();
                TeamSquadList.Items.Refresh();

                PlayerDevelopmentView.Visibility = Visibility.Collapsed;

                PlayersBtn.IsChecked = true;
                PlayersView.Visibility = Visibility.Visible;
            }
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
            UpdateTeamPlayers();
            UpdateTeamNames();
            PlayersList.Items.Refresh();
            SquadsList.Items.Refresh();
        }
        private void RemovePlayerFromSquad_Click(object sender, MouseButtonEventArgs e)
        {
            PackIconMaterial minusButton = sender as PackIconMaterial;
            object[] identifier = minusButton.Tag as object[];
            memberID = (int)identifier[0];
            memberType = (string)identifier[1];

            switch (memberType)
            {
                case "Junior Player":
                    {
                        DataContainer.dataBase.ChangeJuniorPlayerTeam(memberID, 0);
                        DataContainer.UpdateJuniorPlayersList();
                        MessageBox.Show("Success");
                        break;
                    }
                case "Adult Player":
                    {
                        DataContainer.dataBase.ChangePlayerTeam(memberID, 0);
                        DataContainer.UpdateAdultPlayersList();
                        MessageBox.Show("Success");
                        break;
                    }
            }

            DataContainer.UpdatePlayersList();
            DataContainer.UpdateTeamsList();
            UpdateTeamPlayers();
            UpdateTeamNames();
            PlayersList.Items.Refresh();
            SquadsList.Items.Refresh();
            TeamSquadList.Items.Refresh();

            TeamSquadView.Visibility = Visibility.Collapsed;
            SquadsView.Visibility = Visibility.Visible;

        }
        private void DisplayTeamSquadBtn_Click(object sender, MouseButtonEventArgs e)
        {

            SquadsBtn.IsChecked = false;
            SquadsView.Visibility = Visibility.Collapsed;

            PackIconMaterial btn = sender as PackIconMaterial;

            foreach (TeamModel x in DataContainer.Teams)
            {
                if ((int)btn.Tag == x.ID)
                {
                    team = x;
                }
            }
            TeamSquadList.ItemsSource = team.PlayersList;

            TeamSquadView.Visibility = Visibility.Visible;
        }
        private void UpdateTeamPlayers()
        {
            foreach (TeamModel x in DataContainer.Teams)
            {
                x.FindPlayers();
            }
        }
        private void UpdateTeamNames()
        {
            foreach (PlayerModel y in DataContainer.Players)
            {
                y.FindTeamName();
            }
        }
        private void LogOutBtn_Click(object sender, RoutedEventArgs e)
        {
            Window mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }
    }
}
