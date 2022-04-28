using MahApps.Metro.IconPacks;
using RugbyManagementSystem.Database.Data;
using System;
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
        private DataContainer dataContainer;
        public SecretaryWindow()
        {
            InitializeComponent();

            dataContainer = new DataContainer();

            MembersList.ItemsSource = dataContainer.Members;
            TeamsList.ItemsSource = dataContainer.Teams;
            EmailsList.ItemsSource = dataContainer.Members;
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

        private void RadioBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MembersBtn.IsChecked == true)
            {
                MembersView.Visibility = Visibility.Visible;

                TeamsView.Visibility = Visibility.Collapsed;
                EmailsView.Visibility = Visibility.Collapsed;
                AddNewMemberView.Visibility = Visibility.Collapsed;
                EditMemberView.Visibility = Visibility.Collapsed;
            }

            if (TeamsBtn.IsChecked == true)
            {
                TeamsView.Visibility = Visibility.Visible;

                MembersView.Visibility = Visibility.Collapsed;
                EmailsView.Visibility = Visibility.Collapsed;
            }

            if (EmailsBtn.IsChecked == true)
            {
                EmailsView.Visibility = Visibility.Visible;

                MembersView.Visibility = Visibility.Collapsed;
                TeamsView.Visibility = Visibility.Collapsed;
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
            MembersBtn.IsChecked = false;

            EditMemberView.Visibility = Visibility.Visible;
            MembersView.Visibility = Visibility.Collapsed;
        }
        private void TypeChoiceBox_Change(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = TypeChoiceBox.SelectedItem as ComboBoxItem;

            //MessageBox.Show(cbi.ToString());
            if(cbi.Content.ToString() == "Junior Player")
            {
                ConsentPanel.Visibility = Visibility.Visible;
            }
            else
            {
                ConsentPanel.Visibility = Visibility.Collapsed;
            }
        }
    }

}
