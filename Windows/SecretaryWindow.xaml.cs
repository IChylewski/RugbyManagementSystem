using MahApps.Metro.IconPacks;
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
    /// Interaction logic for SecretaryWindow.xaml
    /// </summary>
    public partial class SecretaryWindow : Window
    {
        // Variables
        //private DataContainer dataContainer;
        //private MemberModel member;
        private CoachModel coach;
        private JuniorPlayerModel juniorPlayer;
        private PlayerModel adultPlayer;
        private TeamModel team;

        // Constructor
        public SecretaryWindow()
        {
            InitializeComponent();
            DataContainer.UpdateMembersList();
           

            MembersList.ItemsSource = DataContainer.Members;
            TeamsList.ItemsSource = DataContainer.Teams;
            EmailsList.ItemsSource = DataContainer.Members;



        }


        // Methods

        // These methods are event handlers for window operations
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
        // These methods are event handlers for changing views
        private void RadioBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MembersBtn.IsChecked == true)
            {
                MembersView.Visibility = Visibility.Visible;

                TeamsView.Visibility = Visibility.Collapsed;
                EmailsView.Visibility = Visibility.Collapsed;

                AddNewMemberView.Visibility = Visibility.Collapsed;
                EditMemberView.Visibility = Visibility.Collapsed;
                AddNewTeamView.Visibility = Visibility.Collapsed;
                EditTeamView.Visibility = Visibility.Collapsed;
            }

            if (TeamsBtn.IsChecked == true)
            {
                TeamsView.Visibility = Visibility.Visible;

                MembersView.Visibility = Visibility.Collapsed;
                EmailsView.Visibility = Visibility.Collapsed;

                AddNewMemberView.Visibility = Visibility.Collapsed;
                EditMemberView.Visibility = Visibility.Collapsed;

                AddNewTeamView.Visibility = Visibility.Collapsed;
                EditTeamView.Visibility = Visibility.Collapsed;
            }

            if (EmailsBtn.IsChecked == true)
            {
                EmailsView.Visibility = Visibility.Visible;

                MembersView.Visibility = Visibility.Collapsed;
                TeamsView.Visibility = Visibility.Collapsed;

                AddNewMemberView.Visibility = Visibility.Collapsed;
                EditMemberView.Visibility = Visibility.Collapsed;

                AddNewTeamView.Visibility = Visibility.Collapsed;
                EditTeamView.Visibility = Visibility.Collapsed;
            }
        }
        private void AddMemberBtn_Click(object sender, MouseButtonEventArgs e)
        {
            MembersBtn.IsChecked = false;

            AddNewMemberView.Visibility = Visibility.Visible;
            MembersView.Visibility = Visibility.Collapsed;
        }
        private void EditMemberBtn_Click(object sender, MouseButtonEventArgs e)
        {

            // Changes to view to Edit Member View
            MembersBtn.IsChecked = false;
            EditMemberView.Visibility = Visibility.Visible;
            MembersView.Visibility = Visibility.Collapsed;

            // Gets clicked button and its Tag that is binded to user ID
            PackIconMaterial editButton = sender as PackIconMaterial;
            object[] identifier = editButton.Tag as object[];
            int memberID = (int)identifier[0];
            string memberType = (string)identifier[1];

            //Finds user with ID that is as same as ID in the button Tag property


            switch (memberType)
            {
                case "Coach":
                    {
                        foreach (CoachModel x in DataContainer.Coaches)
                        {
                            if (x.ID == memberID)
                            {
                                coach = x;
                                adultPlayer = null;
                                juniorPlayer = null;
                                break;
                            }
                        }
                        break;
                    }
                case "Junior Player":
                    {
                        foreach (JuniorPlayerModel x in DataContainer.JuniorPlayers)
                        {
                            if (x.ID == memberID)
                            {
                                juniorPlayer = x;
                                adultPlayer = null;
                                coach = null;
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
                                coach = null;
                                juniorPlayer = null;
                                break;
                            }
                        }
                        break;
                    }
            }

            //Fills text boxes with details of found member

            if (coach != null)
            {
                EditTypeChoiceBox.SelectedIndex = 2;
                EditFirstNameBox.Text = coach.FirstName;
                EditLastNameBox.Text = coach.LastName;
                EditEmailBox.Text = coach.Email;
                EditDOBPicker.SelectedDate = DateTime.Parse(coach.DOB);
                EditPhoneNumberBox.Text = coach.PhoneNumber;


            }
            else if (adultPlayer != null)
            {
                EditTypeChoiceBox.SelectedIndex = 0;
                EditFirstNameBox.Text = adultPlayer.FirstName;
                EditLastNameBox.Text = adultPlayer.LastName;
                EditEmailBox.Text = adultPlayer.Email;
                EditDOBPicker.SelectedDate = DateTime.Parse(adultPlayer.DOB);
                EditPhoneNumberBox.Text = adultPlayer.PhoneNumber;

                PlayerOnlyPanel.Visibility = Visibility.Visible;

                EditSRUNumberBox.Text = adultPlayer.SRUNumber;
            }
            else if (juniorPlayer != null)
            {
                EditTypeChoiceBox.SelectedIndex = 1;
                EditFirstNameBox.Text = juniorPlayer.FirstName;
                EditLastNameBox.Text = juniorPlayer.LastName;
                EditEmailBox.Text = juniorPlayer.Email;
                EditDOBPicker.SelectedDate = DateTime.Parse(juniorPlayer.DOB);
                EditPhoneNumberBox.Text = juniorPlayer.PhoneNumber;

                PlayerOnlyPanel.Visibility = Visibility.Visible;
                EditConsentPanel.Visibility = Visibility.Visible;

                EditSRUNumberBox.Text = juniorPlayer.SRUNumber;


                switch (juniorPlayer.Consent)
                {
                    case "Yes":
                        {
                            EditConsentChoiceBox.SelectedIndex = 0;
                            break;
                        }
                    case "No":
                        {
                            EditConsentChoiceBox.SelectedIndex = 1;
                            break;
                        }
                }
            }
        }
        private void AddNewTeamBtn_Click(object sender, MouseButtonEventArgs e)
        {
            TeamsView.Visibility = Visibility.Collapsed;
            TeamsBtn.IsChecked = false;

            AddNewTeamView.Visibility = Visibility.Visible;
        }
        private void EditTeamBtn_Click(object sender, MouseButtonEventArgs e)
        {
            TeamsView.Visibility = Visibility.Collapsed;
            TeamsBtn.IsChecked = false;

            EditTeamView.Visibility = Visibility.Visible;

            PackIconMaterial editTeamButton = sender as PackIconMaterial;
            int teamID = (int)editTeamButton.Tag;

            //Finds user with ID that is as same as ID in the button Tag property

            foreach (TeamModel x in DataContainer.Teams)
            {
                if (x.ID == teamID)
                {
                    team = x;
                }
            }

            EditTeamNameBox.Text = team.Name;
        }
        private void TypeChoiceBox_Change(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = TypeChoiceBox.SelectedItem as ComboBoxItem;

            if (cbi != null)
            {
                if (cbi.Content.ToString() == "Junior Player" || cbi.Content.ToString() == "Adult Player")
                {
                    PlayerOnlyPanel.Visibility = Visibility.Visible;

                    if (cbi.Content.ToString() == "Junior Player")                      // if Junior Player type is selected panel showing consent combo box is displayed
                    {
                        ConsentPanel.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        ConsentPanel.Visibility = Visibility.Collapsed;
                    }
                }
                if (cbi.Content.ToString() == "Coach")
                {
                    PlayerOnlyPanel.Visibility = Visibility.Collapsed;
                }
            }


        }
        private void EditTypeChoiceBox_Change(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = EditTypeChoiceBox.SelectedItem as ComboBoxItem;

            if (cbi != null)
            {
                if (cbi.Content.ToString() == "Junior Player" || cbi.Content.ToString() == "Adult Player")
                {
                    EditPlayerOnlyPanel.Visibility = Visibility.Visible;

                    if (cbi.Content.ToString() == "Junior Player")                      // if Junior Player type is selected panel showing consent combo box is displayed
                    {
                        EditConsentPanel.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        EditConsentPanel.Visibility = Visibility.Collapsed;
                    }

                }
                if (cbi.Content.ToString() == "Coach")
                {
                    EditPlayerOnlyPanel.Visibility = Visibility.Collapsed;
                }
            }


        }
        private void CreateMemberBtn_Click(object sender, RoutedEventArgs e)
        {

            bool validation = true;                     // flag that indicates if validation proceess was succesfull

            ComboBoxItem typeCbi = TypeChoiceBox.SelectedItem as ComboBoxItem;

            switch (typeCbi.Content.ToString())
            {
                case "Coach":
                    {
                        if (TypeChoiceBox.SelectedItem == null)
                        {
                            validation = false;
                        }
                        else if (FirstNameBox.Text == "")
                        {
                            validation = false;
                        }
                        else if (LastNameBox.Text == "")
                        {
                            validation = false;
                        }
                        else if (EmailBox.Text == "")
                        {
                            validation = false;
                        }
                        else if (DOBPicker.SelectedDate == null)
                        {
                            validation = false;
                        }
                        else if (PhoneNumberBox.Text == "")
                        {
                            validation = false;
                        }
                        break;
                    }
                case "Adult Player":
                    {
                        if (TypeChoiceBox.SelectedItem == null)
                        {
                            validation = false;
                        }
                        else if (FirstNameBox.Text == "")
                        {
                            validation = false;
                        }
                        else if (LastNameBox.Text == "")
                        {
                            validation = false;
                        }
                        else if (EmailBox.Text == "")
                        {
                            validation = false;
                        }
                        else if (DOBPicker.SelectedDate == null)
                        {
                            validation = false;
                        }
                        else if (PhoneNumberBox.Text == "")
                        {
                            validation = false;
                        }
                        else if (SRUNumberBox.Text == "" && PlayerOnlyPanel.Visibility == Visibility.Visible)
                        {
                            validation = false;
                        }
                        break;
                    }
                case "Junior Player":
                    {
                        if (TypeChoiceBox.SelectedItem == null)
                        {
                            validation = false;
                        }
                        else if (FirstNameBox.Text == "")
                        {
                            validation = false;
                        }
                        else if (LastNameBox.Text == "")
                        {
                            validation = false;
                        }
                        else if (EmailBox.Text == "")
                        {
                            validation = false;
                        }
                        else if (DOBPicker.SelectedDate == null)
                        {
                            validation = false;
                        }
                        else if (PhoneNumberBox.Text == "")
                        {
                            validation = false;
                        }
                        else if (SRUNumberBox.Text == "" && PlayerOnlyPanel.Visibility == Visibility.Visible)
                        {
                            validation = false;
                        }
                        else if (ConsentChoiceBox.SelectedItem == null && ConsentPanel.Visibility == Visibility.Visible)
                        {
                            validation = false;
                        }
                        break;
                    }
            }


            if (validation == true)
            {
                string typeString = typeCbi.Content.ToString();

                DateTime selectedDate = (DateTime)DOBPicker.SelectedDate;
                string DOB = selectedDate.ToString("dd/MM/yyyy");

                ComboBoxItem consentCbi;
                string consent;

                switch (typeString)
                {
                    case "Coach":
                        {
                            DataContainer.dataBase.AddNewCoach(FirstNameBox.Text, LastNameBox.Text, EmailBox.Text, DOB, PhoneNumberBox.Text);
                            DataContainer.UpdateCoachesList();
                            break;
                        }
                    case "Junior Player":
                        {
                            consentCbi = (ComboBoxItem)ConsentChoiceBox.SelectedItem;
                            consent = consentCbi.Content.ToString();

                            DataContainer.dataBase.AddNewJuniorPlayer(FirstNameBox.Text, LastNameBox.Text, EmailBox.Text, DOB, PhoneNumberBox.Text, SRUNumberBox.Text, consent);
                            DataContainer.UpdateJuniorPlayersList();
                            break;
                        }
                    case "Adult Player":
                        {
                            DataContainer.dataBase.AddNewPlayer(FirstNameBox.Text, LastNameBox.Text, EmailBox.Text, DOB, PhoneNumberBox.Text, SRUNumberBox.Text);
                            DataContainer.UpdateAdultPlayersList();
                            break;
                        }
                }

                MessageBox.Show("Success");
                FinishCreatingMember();
            }
            else
            {
                MessageBox.Show("Incorrect Credentials");
            }
        }
        private void FinishCreatingMember()
        {
            TypeChoiceBox.SelectedItem = null;
            FirstNameBox.Text = "";
            LastNameBox.Text = "";
            EmailBox.Text = "";
            DOBPicker.SelectedDate = null;
            PhoneNumberBox.Text = "";
            SRUNumberBox.Text = "";
            ConsentChoiceBox.SelectedItem = null;

            DataContainer.UpdateMembersList();
            MembersList.Items.Refresh();
            EmailsList.Items.Refresh();

            AddNewMemberView.Visibility = Visibility.Collapsed;

            MembersBtn.IsChecked = true;
            MembersView.Visibility = Visibility.Visible;


        }

        private void EditMemberDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            bool validation = true;                     // flag that indicates if validation proceess was succesfull

            ComboBoxItem typeCbi = EditTypeChoiceBox.SelectedItem as ComboBoxItem;

            switch (typeCbi.Content.ToString())
            {
                case "Coach":
                    {
                        if (EditTypeChoiceBox.SelectedItem == null)
                        {
                            validation = false;
                        }
                        else if (EditFirstNameBox.Text == "")
                        {
                            validation = false;
                        }
                        else if (EditLastNameBox.Text == "")
                        {
                            validation = false;
                        }
                        else if (EditEmailBox.Text == "")
                        {
                            validation = false;
                        }
                        else if (EditDOBPicker.SelectedDate == null)
                        {
                            validation = false;
                        }
                        else if (EditPhoneNumberBox.Text == "")
                        {
                            validation = false;
                        }
                        break;
                    }
                case "Adult Player":
                    {
                        if (EditTypeChoiceBox.SelectedItem == null)
                        {
                            validation = false;
                        }
                        else if (EditFirstNameBox.Text == "")
                        {
                            validation = false;
                        }
                        else if (EditLastNameBox.Text == "")
                        {
                            validation = false;
                        }
                        else if (EditEmailBox.Text == "")
                        {
                            validation = false;
                        }
                        else if (EditDOBPicker.SelectedDate == null)
                        {
                            validation = false;
                        }
                        else if (EditPhoneNumberBox.Text == "")
                        {
                            validation = false;
                        }
                        else if (EditSRUNumberBox.Text == "" && EditPlayerOnlyPanel.Visibility == Visibility.Visible)
                        {
                            validation = false;
                        }
                        break;
                    }
                case "Junior Player":
                    {
                        if (EditTypeChoiceBox.SelectedItem == null)
                        {
                            validation = false;
                        }
                        else if (EditFirstNameBox.Text == "")
                        {
                            validation = false;
                        }
                        else if (EditLastNameBox.Text == "")
                        {
                            validation = false;
                        }
                        else if (EditEmailBox.Text == "")
                        {
                            validation = false;
                        }
                        else if (EditDOBPicker.SelectedDate == null)
                        {
                            validation = false;
                        }
                        else if (EditPhoneNumberBox.Text == "")
                        {
                            validation = false;
                        }
                        else if (EditSRUNumberBox.Text == "" && EditPlayerOnlyPanel.Visibility == Visibility.Visible)
                        {
                            validation = false;
                        }
                        else if (EditConsentChoiceBox.SelectedItem == null && EditConsentPanel.Visibility == Visibility.Visible)
                        {
                            validation = false;
                        }
                        break;
                    }
            }


            if (validation == true)
            {
                string typeString = typeCbi.Content.ToString();

                DateTime selectedDate = (DateTime)EditDOBPicker.SelectedDate;
                string DOB = selectedDate.ToString("dd/MM/yyyy");

                ComboBoxItem consentCbi;
                string consent;

                switch (typeString)
                {
                    case "Coach":
                        {
                            DataContainer.dataBase.EditCoach(coach.ID, EditFirstNameBox.Text, EditLastNameBox.Text, EditEmailBox.Text, DOB, EditPhoneNumberBox.Text);
                            DataContainer.UpdateCoachesList();
                            break;
                        }
                    case "Junior Player":
                        {
                            consentCbi = (ComboBoxItem)EditConsentChoiceBox.SelectedItem;
                            consent = consentCbi.Content.ToString();

                            DataContainer.dataBase.EditJuniorPlayer(juniorPlayer.ID, EditFirstNameBox.Text, EditLastNameBox.Text, EditEmailBox.Text, DOB, EditPhoneNumberBox.Text, EditSRUNumberBox.Text, consent);
                            DataContainer.UpdateJuniorPlayersList();
                            break;
                        }
                    case "Adult Player":
                        {
                            DataContainer.dataBase.EditPlayer(adultPlayer.ID, EditFirstNameBox.Text, EditLastNameBox.Text, EditEmailBox.Text, DOB, EditPhoneNumberBox.Text, EditSRUNumberBox.Text);
                            DataContainer.UpdateAdultPlayersList();
                            break;
                        }
                }

                MessageBox.Show("Success");
                FinishEditingMember();
            }
            else
            {
                MessageBox.Show("Incorrect Credentials");
            }

        }
        private void FinishEditingMember()
        {
            EditTypeChoiceBox.SelectedItem = null;
            EditFirstNameBox.Text = "";
            EditLastNameBox.Text = "";
            EditEmailBox.Text = "";
            EditDOBPicker.SelectedDate = null;
            EditPhoneNumberBox.Text = "";
            EditSRUNumberBox.Text = "";
            EditConsentChoiceBox.SelectedItem = null;

            DataContainer.UpdateMembersList();
            MembersList.Items.Refresh();
            EmailsList.Items.Refresh();

            EditMemberView.Visibility = Visibility.Collapsed;

            MembersBtn.IsChecked = true;
            MembersView.Visibility = Visibility.Visible;

        }

        private void DeleteMemberBtn_Click(object sender, MouseButtonEventArgs e)
        {
            // Gets clicked button and its Tag that is binded to user ID
            PackIconMaterial editButton = sender as PackIconMaterial;
            object[] identifier = editButton.Tag as object[];
            int memberID = (int)identifier[0];
            string memberType = (string)identifier[1];

            //Finds user with ID that is as same as ID in the button Tag property


            switch (memberType)
            {
                case "Coach":
                    {
                        DataContainer.dataBase.DeleteCoach(memberID);
                        DataContainer.UpdateCoachesList();
                        break;
                    }
                case "Junior Player":
                    {
                        DataContainer.dataBase.DeleteJuniorPlayer(memberID);
                        DataContainer.UpdateJuniorPlayersList();
                        break;
                    }
                case "Adult Player":
                    {
                        DataContainer.dataBase.DeletePlayer(memberID);
                        DataContainer.UpdateAdultPlayersList();
                        break;
                    }
            }

            MessageBox.Show("Success");
            DataContainer.UpdateMembersList();
            MembersList.Items.Refresh();
            EmailsList.Items.Refresh();
        }

        private void CreateTeamBtn_Click(object sender, RoutedEventArgs e)
        {

            bool validation = true;                     // flag that indicates if validation proceess was succesfull

            if (TeamNameBox.Text == "")
            {
                validation = false;
            }

            if (validation == true)
            {
                DataContainer.dataBase.AddNewTeam(TeamNameBox.Text);

                MessageBox.Show("Success");
                FinishCreatingTeam();
            }
            else
            {
                MessageBox.Show("Incorrect Credentials");
            }
        }
        private void FinishCreatingTeam()
        {
            TeamNameBox.Text = "";

            DataContainer.UpdateTeamsList();
            TeamsList.Items.Refresh();

            AddNewTeamView.Visibility = Visibility.Collapsed;

            TeamsBtn.IsChecked = true;
            TeamsView.Visibility = Visibility.Visible;

        }

        private void EditTeamDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            bool validation = true;                     // flag that indicates if validation proceess was succesfull

            if (EditTeamNameBox.Text == "")
            {
                validation = false;
            }

            if (validation == true)
            {
                DataContainer.dataBase.EditTeam(team.ID, EditTeamNameBox.Text);

                MessageBox.Show("Success");
                FinishEditingTeam();
            }
            else
            {
                MessageBox.Show("Incorrect Credentials");
            }
        }
        private void FinishEditingTeam()
        {
            EditTeamNameBox.Text = "";

            DataContainer.UpdateTeamsList();
            TeamsList.Items.Refresh();

            EditTeamView.Visibility = Visibility.Collapsed;

            TeamsBtn.IsChecked = true;
            TeamsView.Visibility = Visibility.Visible;

        }
        private void DeleteTeamBtn_Click(object sender, MouseButtonEventArgs e)
        {
            // Gets clicked button and its Tag that is binded to user ID
            PackIconMaterial deleteButton = sender as PackIconMaterial;
            int teamID = (int)deleteButton.Tag;

            DataContainer.dataBase.DeleteTeam(teamID);

            DataContainer.UpdateTeamsList();
            TeamsList.Items.Refresh();
            MessageBox.Show("Success");
        }
        private void CopyToClipBoardBtn_Click(object sender, MouseButtonEventArgs e)
        {
            // Gets clicked button and its Tag that is binded to user ID
            // Gets clicked button and its Tag that is binded to user ID
            PackIconMaterial editButton = sender as PackIconMaterial;
            object[] identifier = editButton.Tag as object[];
            int memberID = (int)identifier[0];
            string memberType = (string)identifier[1];

            //Finds user with ID that is as same as ID in the button Tag property


            switch (memberType)
            {
                case "Coach":
                    {
                        foreach (CoachModel x in DataContainer.Coaches)
                        {
                            if (x.ID == memberID)
                            {
                                Clipboard.SetText(x.Email);
                                MessageBox.Show("Email copied to clipboard");
                                break;
                            }
                        }
                        break;
                    }
                case "Junior Player":
                    {
                        foreach (JuniorPlayerModel x in DataContainer.JuniorPlayers)
                        {
                            if (x.ID == memberID)
                            {
                                Clipboard.SetText(x.Email);
                                MessageBox.Show("Email copied to clipboard");
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
                                Clipboard.SetText(x.Email);
                                MessageBox.Show("Email copied to clipboard");
                                break;
                            }
                        }
                        break;
                    }



            }
        }
        private void LogOutBtn_Click(object sender, RoutedEventArgs e)
        {
            Window mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            e.Cancel = true;
        }

       
    }

}