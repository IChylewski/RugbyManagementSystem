﻿using MahApps.Metro.IconPacks;
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
using System.Windows.Shapes;

namespace RugbyManagementSystem.Windows
{
    /// <summary>
    /// Interaction logic for CoachWindow.xaml
    /// </summary>
    public partial class CoachWindow : Window
    {
        public CoachWindow()
        {
            InitializeComponent();
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
