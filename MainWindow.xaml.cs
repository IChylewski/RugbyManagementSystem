using MahApps.Metro.IconPacks;
using RugbyManagementSystem.Database;
using RugbyManagementSystem.Database.Data;
using RugbyManagementSystem.Database.Models;
using RugbyManagementSystem.Windows;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RugbyManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Variables
        private DataContainer database = new DataContainer(); 
        private Window secWin;
        private Window coachWin;

        //Constructor
        public MainWindow()
        {
            InitializeComponent();
            secWin = new SecretaryWindow();
            coachWin = new CoachWindow();

            this.Close();
            secWin.Show();

        }

        //Methods

        // This function is invoked every time password box is changed
        private void OnPasswordChange(Object sender, RoutedEventArgs args)
        {
            if (PasswordBox.Password == "")                       // If PasswordBox is empty then hint is visible
            {
                PasswordHint.Visibility = Visibility.Visible;
            }
            else                                                  // If PasswordBox is not empty then hint is hidden
            {
                PasswordHint.Visibility = Visibility.Hidden;
            }

        }
        // This function is invoked when LogIn Button is clicked
        private void LogInBtn_Click(Object sender, RoutedEventArgs args)
        { 
            bool verified = false;                                 // flag that indicates if the details are verified

            foreach (UserModel user in database.Users)          /// Loops through users list to verify details
            {
                if (user.Login == LoginBox.Text)
                {
                    if (user.Password == PasswordBox.Password)
                    {
                        verified = true;
                        break;
                    }
                }
            }

            if (verified == true)                             // If details correct - checks which login has been used to determine which window should be opened
            {
                switch(LoginBox.Text)
                {
                    case "Coach":
                        {
                            this.Close();
                            coachWin.Show();
                            break;
                        }
                    case "Secretary":
                        {
                            this.Close();
                            secWin.Show();
                            break;
                        }
                }
            }    
            if (verified == false)                       // If details incorrect - display a message
            {
                MessageBox.Show("Wrong Details Please Try Again");
            }   
        }
        private void Border_MouseDown(Object sender, MouseButtonEventArgs e)        // Drags Window when MouseDown
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void ButtonMinimize_Click(Object sender, MouseButtonEventArgs e)    // Minimize Window onclick
        {
            this.WindowState = WindowState.Minimized;
        }
        private void ButtonMaximize_Click(Object sender, MouseButtonEventArgs e)    // Maximize Window On click and changes icon and setup new events
        {                                                                           // for restoring window to orginal size
            PackIconMaterial maximizeIcon = sender as PackIconMaterial;
            this.WindowState = WindowState.Maximized;

            maximizeIcon.Kind = PackIconMaterialKind.WindowRestore;
            maximizeIcon.MouseDown -= ButtonMaximize_Click;
            maximizeIcon.MouseDown += ButtonRestore_Click;
        }
        private void ButtonRestore_Click(Object sender, MouseButtonEventArgs e)     // Restores Window to previous size On click and changes icon and setup new events
        {                                                                           // for maximizing window
            PackIconMaterial restoreIcon = sender as PackIconMaterial;
            this.WindowState = WindowState.Normal;

            restoreIcon.Kind = PackIconMaterialKind.WindowMaximize;
            restoreIcon.MouseDown -= ButtonRestore_Click;
            restoreIcon.MouseDown += ButtonMaximize_Click;
        }
        private void ButtonExit_Click(Object sender, MouseButtonEventArgs e)      // Shutdowns application on click
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
