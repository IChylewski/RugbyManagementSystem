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

            // All data is refreshed when window opens
            DataContainer.UpdatePlayersList();
            UpdateTeamPlayers();
            UpdateTeamNames();

            PlayersList.ItemsSource = DataContainer.Players;
            SquadsList.ItemsSource = DataContainer.Teams;
            TeamSelection.ItemsSource = DataContainer.Teams;


        }

        // These are event handlers for window operations

        private void Border_MouseDown(Object sender, MouseButtonEventArgs e)   // When left mouse button is pressed on the border which is window background - window can be dragged
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void ButtonMinimize_Click(Object sender, MouseButtonEventArgs e)  // On click minimize window
        {
            this.WindowState = WindowState.Minimized;
        }
        private void ButtonMaximize_Click(Object sender, MouseButtonEventArgs e)   // On click window is maximazed and button icon and its event handler changed
        {
            PackIconMaterial maximizeIcon = sender as PackIconMaterial;
            this.WindowState = WindowState.Maximized;

            maximizeIcon.Kind = PackIconMaterialKind.WindowRestore;
            maximizeIcon.MouseDown -= ButtonMaximize_Click;
            maximizeIcon.MouseDown += ButtonRestore_Click;
        }
        private void ButtonRestore_Click(Object sender, MouseButtonEventArgs e)       // On click window is restored to its previous state and button icon and its event handler changed
        {
            PackIconMaterial restoreIcon = sender as PackIconMaterial;
            this.WindowState = WindowState.Normal;

            restoreIcon.Kind = PackIconMaterialKind.WindowMaximize;
            restoreIcon.MouseDown -= ButtonRestore_Click;
            restoreIcon.MouseDown += ButtonMaximize_Click;
        }
        private void ButtonExit_Click(Object sender, MouseButtonEventArgs e)      // On click exit application
        {
            System.Windows.Application.Current.Shutdown();
        }
        protected override void OnClosing(CancelEventArgs e)         // Closing window method must have been changed so it could be opened again after closing
        {
            this.Visibility = Visibility.Hidden;
            e.Cancel = true;
        }

        private void RadioBtn_Click(object sender, RoutedEventArgs e)              // Event handler for all left panel menu buttons 
        {                                                                          // Changes views on click
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
        private void PlayerDevelopmentBtn_Click(object sender, MouseButtonEventArgs e)   // Method that opens Player Development View on Click and fill boxes with data of specific player
        {
            PlayersBtn.IsChecked = false;
            PlayersView.Visibility = Visibility.Collapsed;
            TeamSquadView.Visibility = Visibility.Collapsed;

            // Gets clicked button and its Tag that is binded to user ID
            PackIconMaterial developmentButton = sender as PackIconMaterial;      // Gets clicked button
            object[] identifier = developmentButton.Tag as object[];              // Gets object "Identifier" from "Tag" property of icon that is clicked
            memberID = (int)identifier[0];            // 1st value of identifier is id of member
            memberType = (string)identifier[1];       // 2nd value of identifier is its type


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

            if (juniorPlayer != null)           // if found user is junior type fills with its data
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
            else if (adultPlayer != null)            // if found user is adult Type fills with its data
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
        private void EditPlayerDevelopmentBtn_Click(object sender, RoutedEventArgs e)      // This method validates new data and updates database
        {
            bool validation = true;                     // flag that indicates if validation proceess was successful

            if (CustomValidation.ValidateSkill("Standard Passing", PassingStandardBox.Text) == false)  // Static class that helps validation is used 
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


            if (validation == true)       // If validation passed
            {

                switch (memberType)      // Determine user type to check which table should be updated, pass values and Invoke updating methods
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

                DataContainer.UpdatePlayersList();       // After updating database refresh all lists
                PlayersList.Items.Refresh();         // Refresh ListView so new data can be displayed
                TeamSquadList.Items.Refresh();

                PlayerDevelopmentView.Visibility = Visibility.Collapsed;    // Change view

                PlayersBtn.IsChecked = true;
                PlayersView.Visibility = Visibility.Visible;
            }
        }
        private void AddPlayerToTeamBtn_Click(object sender, MouseButtonEventArgs e)    // Change to Add Player To Team View
        {
            PlayersBtn.IsChecked = false;
            PlayersView.Visibility = Visibility.Collapsed;

            PackIconMaterial plusButton = sender as PackIconMaterial;     // Saves information about player that is about to be added to team
            object[] identifier = plusButton.Tag as object[];
            memberID = (int)identifier[0];
            memberType = (string)identifier[1];

            TeamSelectionView.Visibility = Visibility.Visible;
        }
        private void AddPlayerToSquad_Click(object sender, MouseButtonEventArgs e)      // Event handler for changing players' team
        {
            StackPanel teamButton = sender as StackPanel;      // In that case button is entire row in the list view
            int teamID = (int)teamButton.Tag;

            switch (memberType)   // Determine which table should be updated
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

            TeamSelectionView.Visibility = Visibility.Collapsed;    // Refresh all lists

            PlayersView.Visibility = Visibility.Visible;
            PlayersBtn.IsChecked = true;

            DataContainer.UpdatePlayersList();
            UpdateTeamPlayers();
            UpdateTeamNames();
            PlayersList.Items.Refresh();
            SquadsList.Items.Refresh();
        }
        private void RemovePlayerFromSquad_Click(object sender, MouseButtonEventArgs e)  // Event handler for removing players' from team
        {
            PackIconMaterial minusButton = sender as PackIconMaterial;
            object[] identifier = minusButton.Tag as object[];
            memberID = (int)identifier[0];
            memberType = (string)identifier[1];

            switch (memberType)       // Determine which table should be updated
            {
                case "Junior Player":
                    {
                        DataContainer.dataBase.ChangeJuniorPlayerTeam(memberID, 0);   // Changes TeamID to 0 - because database primary key increments from 1 so 0 does not belong to any team
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

            DataContainer.UpdatePlayersList();       // All lists and list views are refreshed
            DataContainer.UpdateTeamsList();
            UpdateTeamPlayers();
            UpdateTeamNames();
            PlayersList.Items.Refresh();
            SquadsList.Items.Refresh();
            TeamSquadList.Items.Refresh();

            TeamSquadView.Visibility = Visibility.Collapsed;
            SquadsView.Visibility = Visibility.Visible;

        }
        private void DisplayTeamSquadBtn_Click(object sender, MouseButtonEventArgs e)        // Event handlers for checking current squad of the team
        {

            SquadsBtn.IsChecked = false;
            SquadsView.Visibility = Visibility.Collapsed;

            PackIconMaterial btn = sender as PackIconMaterial;

            foreach (TeamModel x in DataContainer.Teams)           // Finds infromation about team that was clicked
            {
                if ((int)btn.Tag == x.ID)
                {
                    team = x;
                }
            }
            TeamSquadList.ItemsSource = team.PlayersList;       // Sets listView item source to list of players that team contain

            TeamSquadView.Visibility = Visibility.Visible;
        }
        private void UpdateTeamPlayers()               // For each team in the list invoke method that finds all players that have TeamID property same as ID of specific team
        {
            foreach (TeamModel x in DataContainer.Teams)
            {
                x.FindPlayers();
            }
        }
        private void UpdateTeamNames()           // For each player in the list invoke method that finds team name of the team player belongs to 
        {
            foreach (PlayerModel y in DataContainer.Players)
            {
                y.FindTeamName();
            }
        }
        private void LogOutBtn_Click(object sender, RoutedEventArgs e)     // Event Handler for logging out
        {
            Window mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }
    }
}
