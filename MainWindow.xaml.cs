using MahApps.Metro.IconPacks;
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


        public MainWindow()
        {
            InitializeComponent();
            Window SecWin = new SecretaryWindow();
            Window CoachWin = new CoachWindow();
            this.Close();
            SecWin.Show();
        }

        private void OnPasswordChange(Object sender, RoutedEventArgs args)
        {
            if (PasswordBox.Password == "")
            {
                PasswordHint.Visibility = Visibility.Visible;
            }
            else
            {
                PasswordHint.Visibility = Visibility.Hidden;
            }

        }
        private void OnLogInClick(Object sender, RoutedEventArgs args)
        {
            MessageBox.Show(PasswordBox.Password.ToString());
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
    }
}
