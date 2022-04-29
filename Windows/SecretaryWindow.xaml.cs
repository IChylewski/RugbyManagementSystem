using MahApps.Metro.IconPacks;
using RugbyManagementSystem.Database;
using RugbyManagementSystem.Database.Data;
using RugbyManagementSystem.Database.Models;
using System;
using System.Globalization;
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
        private DataContainer dataContainer;
        private MemberModel member;

        // Constructor
        public SecretaryWindow()
        {
            InitializeComponent();

            dataContainer = new DataContainer();

            MembersList.ItemsSource = dataContainer.Members;
            TeamsList.ItemsSource = dataContainer.Teams;
            EmailsList.ItemsSource = dataContainer.Members;



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
            int memberID = (int)editButton.Tag;

            //Finds user with ID that is as same as ID in the button Tag property
            
            foreach (MemberModel x in dataContainer.Members)
            {
                if (x.ID == memberID)
                {
                    member = x;
                }
            }

            //Fills text boxes with details of found member

            switch(member.Type)
            {
                case "Adult Player":
                    {
                        EditTypeChoiceBox.SelectedIndex = 0;
                        break;
                    }
                case "Junior Player":
                    {
                        EditTypeChoiceBox.SelectedIndex = 1;
                        break;
                    }
                case "Coach":
                    {
                        EditTypeChoiceBox.SelectedIndex = 2;
                        break;
                    }
            }

            EditFirstNameBox.Text = member.FirstName;
            EditLastNameBox.Text = member.LastName;
            EditEmailBox.Text = member.Email;
            EditDOBPicker.SelectedDate = DateTime.Parse(member.DOB);
            EditPhoneNumberBox.Text = member.PhoneNumber;
            EditSRUNumberBox.Text = member.SRUNumber;

            switch(member.Consent)
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
                case "Not required":
                    {
                        break;
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
        }
        private void TypeChoiceBox_Change(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = TypeChoiceBox.SelectedItem as ComboBoxItem;

            if(cbi != null)
            {
                if (cbi.Content.ToString() == "Junior Player")                      // if Junior Player type is selected panel showing consent combo box is displayed
                {
                    ConsentPanel.Visibility = Visibility.Visible;
                }
                else
                {
                    ConsentPanel.Visibility = Visibility.Collapsed;
                }
            }
   
        }
        private void EditTypeChoiceBox_Change(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = EditTypeChoiceBox.SelectedItem as ComboBoxItem;

            if (cbi != null)
            {
                if (cbi.Content.ToString() == "Junior Player")                      // if Junior Player type is selected panel showing consent combo box is displayed
                {
                    EditConsentPanel.Visibility = Visibility.Visible;
                }
                else
                {
                    EditConsentPanel.Visibility = Visibility.Collapsed;
                }
            }

        }


        private void CreateMemberBtn_Click(object sender, RoutedEventArgs e)
        {

            bool validation = true;                     // flag that indicates if validation proceess was succesfull

            if(TypeChoiceBox.SelectedItem == null)
            {
                validation = false;
            }
            else if(FirstNameBox.Text == "")
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
            else if (SRUNumberBox.Text == "")
            {
                validation = false;
            }
            else if (ConsentChoiceBox.SelectedItem == null && ConsentPanel.Visibility == Visibility.Visible)
            {
                validation = false;
            }
            if (validation == true)
            {
                ComboBoxItem typeCbi = (ComboBoxItem)TypeChoiceBox.SelectedItem;
                string typeString = typeCbi.Content.ToString();
                

                DateTime selectedDate = (DateTime)DOBPicker.SelectedDate;
                string DOB = selectedDate.ToString("dd/MM/yyyy");

                ComboBoxItem consentCbi;
                string consent;

                if(ConsentChoiceBox.SelectedItem != null)
                {
                    consentCbi = (ComboBoxItem)ConsentChoiceBox.SelectedItem;
                    consent = consentCbi.Content.ToString();
                }
                else
                {
                    consent = "Not required";
                }


                dataContainer.dataBase.AddNewMember(FirstNameBox.Text, LastNameBox.Text, EmailBox.Text, DOB, typeString, PhoneNumberBox.Text, SRUNumberBox.Text, consent);

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

            AddNewMemberView.Visibility = Visibility.Collapsed;

            MembersBtn.IsChecked = true;
            MembersView.Visibility = Visibility.Visible;

        }

        private void EditMemberDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            bool validation = true;                     // flag that indicates if validation proceess was succesfull

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
            else if (EditSRUNumberBox.Text == "")
            {
                validation = false;
            }
            else if (EditConsentChoiceBox.SelectedItem == null && EditConsentPanel.Visibility == Visibility.Visible)
            {
                validation = false;
            }
            if (validation == true)
            {
                ComboBoxItem typeCbi = (ComboBoxItem)EditTypeChoiceBox.SelectedItem;
                string editTypeString = typeCbi.Content.ToString();


                DateTime selectedDate = (DateTime)EditDOBPicker.SelectedDate;
                string editDOB = selectedDate.ToString("dd/MM/yyyy");

                ComboBoxItem consentCbi;
                string editConsent;

                if (EditConsentChoiceBox.SelectedItem != null)
                {
                    consentCbi = (ComboBoxItem)EditConsentChoiceBox.SelectedItem;
                    editConsent = consentCbi.Content.ToString();
                }
                else
                {
                    editConsent = "Not required";
                }

                dataContainer.dataBase.EditMember(member.ID, EditFirstNameBox.Text, EditLastNameBox.Text, EditEmailBox.Text, editDOB, editTypeString, EditPhoneNumberBox.Text, EditSRUNumberBox.Text, editConsent);

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

            EditMemberView.Visibility = Visibility.Collapsed;

            MembersBtn.IsChecked = true;
            MembersView.Visibility = Visibility.Visible;

        }

        private void DeleteMemberBtn_Click(object sender, MouseButtonEventArgs e)
        {
            // Gets clicked button and its Tag that is binded to user ID
            PackIconMaterial deleteButton = sender as PackIconMaterial;
            int memberID = (int)deleteButton.Tag;

            dataContainer.dataBase.DeleteMember(memberID);

            MessageBox.Show("Success");
        }
    }

}
