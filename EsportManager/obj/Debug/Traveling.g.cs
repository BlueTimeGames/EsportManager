﻿#pragma checksum "..\..\Traveling.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E4B672C2AA8A037D0C702C7D0B2D8297FBF03C88420F1F0CC6368663F54AD185"
//------------------------------------------------------------------------------
// <auto-generated>
//     Tento kód byl generován nástrojem.
//     Verze modulu runtime:4.0.30319.42000
//
//     Změny tohoto souboru mohou způsobit nesprávné chování a budou ztraceny,
//     dojde-li k novému generování kódu.
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
    /// Traveling
    /// </summary>
    public partial class Traveling : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\Traveling.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SectionsCB;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\Traveling.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GetHome;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Traveling.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Move;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Traveling.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CitiesCB;
        
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
            System.Uri resourceLocater = new System.Uri("/EsportManager;component/traveling.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Traveling.xaml"
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
            this.SectionsCB = ((System.Windows.Controls.ComboBox)(target));
            
            #line 10 "..\..\Traveling.xaml"
            this.SectionsCB.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SectionChange);
            
            #line default
            #line hidden
            return;
            case 2:
            this.GetHome = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\Traveling.xaml"
            this.GetHome.Click += new System.Windows.RoutedEventHandler(this.MovePlayersHome);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Move = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\Traveling.xaml"
            this.Move.Click += new System.Windows.RoutedEventHandler(this.MovePlayers);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CitiesCB = ((System.Windows.Controls.ComboBox)(target));
            
            #line 13 "..\..\Traveling.xaml"
            this.CitiesCB.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CityChange);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

