﻿#pragma checksum "E:\My Files\Documents\Visual Studio 2010\Projects\pollAp 1_1\pollAp\login.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8B16981772F924A5560E78B500F563CD"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace pollAp {
    
    
    public partial class login : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.TextBlock PageTitle;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBox user_name;
        
        internal System.Windows.Controls.TextBlock userNameTextBlock;
        
        internal System.Windows.Controls.TextBox password;
        
        internal System.Windows.Controls.TextBlock passwordTextBlock;
        
        internal System.Windows.Controls.Button signInButton;
        
        internal System.Windows.Controls.TextBlock textBlock1;
        
        internal System.Windows.Controls.Button createAccountButton;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/pollAp;component/login.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.PageTitle = ((System.Windows.Controls.TextBlock)(this.FindName("PageTitle")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.user_name = ((System.Windows.Controls.TextBox)(this.FindName("user_name")));
            this.userNameTextBlock = ((System.Windows.Controls.TextBlock)(this.FindName("userNameTextBlock")));
            this.password = ((System.Windows.Controls.TextBox)(this.FindName("password")));
            this.passwordTextBlock = ((System.Windows.Controls.TextBlock)(this.FindName("passwordTextBlock")));
            this.signInButton = ((System.Windows.Controls.Button)(this.FindName("signInButton")));
            this.textBlock1 = ((System.Windows.Controls.TextBlock)(this.FindName("textBlock1")));
            this.createAccountButton = ((System.Windows.Controls.Button)(this.FindName("createAccountButton")));
        }
    }
}
