﻿#pragma checksum "..\..\NewGame.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E491B14B5D5823D254727E7AC163749D0F7707B78CFC6056B8E2E23447707F0C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using EsportManager;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace EsportManager {
    
    
    /// <summary>
    /// NewGame
    /// </summary>
    public partial class NewGame : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\NewGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox GameNameTB;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\NewGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox NationsCB;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\NewGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TeamNameTW;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\NewGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox TeamListLB;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\NewGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button StartButton;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\NewGame.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox DatabaseComboBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/EsportManager;component/newgame.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\NewGame.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\NewGame.xaml"
            ((EsportManager.NewGame)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.GameNameTB = ((System.Windows.Controls.TextBox)(target));
            
            #line 12 "..\..\NewGame.xaml"
            this.GameNameTB.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.GameNameChange);
            
            #line default
            #line hidden
            return;
            case 3:
            this.NationsCB = ((System.Windows.Controls.ComboBox)(target));
            
            #line 13 "..\..\NewGame.xaml"
            this.NationsCB.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.NationChangeComboBox);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TeamNameTW = ((System.Windows.Controls.TextBox)(target));
            
            #line 14 "..\..\NewGame.xaml"
            this.TeamNameTW.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TeamNameChangeTextView);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TeamListLB = ((System.Windows.Controls.ListBox)(target));
            
            #line 15 "..\..\NewGame.xaml"
            this.TeamListLB.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TeamListLBClickInto);
            
            #line default
            #line hidden
            
            #line 15 "..\..\NewGame.xaml"
            this.TeamListLB.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.TeamListLB_MouseDown);
            
            #line default
            #line hidden
            
            #line 15 "..\..\NewGame.xaml"
            this.TeamListLB.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.TeamListLB_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.StartButton = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\NewGame.xaml"
            this.StartButton.Click += new System.Windows.RoutedEventHandler(this.StartGame);
            
            #line default
            #line hidden
            return;
            case 7:
            this.DatabaseComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 18 "..\..\NewGame.xaml"
            this.DatabaseComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DatabaseChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

