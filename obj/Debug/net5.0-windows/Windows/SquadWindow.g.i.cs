﻿#pragma checksum "..\..\..\..\Windows\SquadWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7AE5DE222B45A9D902944F5101470C27617B32F5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.IconPacks;
using RugbyManagementSystem.Windows;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace RugbyManagementSystem.Windows {
    
    
    /// <summary>
    /// SquadWindow
    /// </summary>
    public partial class SquadWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.16.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/RugbyManagementSystem;component/windows/squadwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\SquadWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.16.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 16 "..\..\..\..\Windows\SquadWindow.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 50 "..\..\..\..\Windows\SquadWindow.xaml"
            ((MahApps.Metro.IconPacks.PackIconMaterial)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ButtonMinimize_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 58 "..\..\..\..\Windows\SquadWindow.xaml"
            ((MahApps.Metro.IconPacks.PackIconMaterial)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ButtonMaximize_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 65 "..\..\..\..\Windows\SquadWindow.xaml"
            ((MahApps.Metro.IconPacks.PackIconMaterial)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ButtonExit_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 81 "..\..\..\..\Windows\SquadWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BackBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

