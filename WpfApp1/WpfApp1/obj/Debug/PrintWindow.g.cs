﻿#pragma checksum "..\..\PrintWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E550C9C9A3A2C72822D81022ADEB218921DA8BD3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using WpfApp1;


namespace WpfApp1 {
    
    
    /// <summary>
    /// PrintWindow
    /// </summary>
    public partial class PrintWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\PrintWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox HeaderText;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\PrintWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonStartPrint;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\PrintWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox printFish;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\PrintWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PrintTeamInfo;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\PrintWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox printPersonalInf;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\PrintWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DayPrint;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\PrintWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox teamChoise;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\PrintWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox teamDay;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp1;component/printwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PrintWindow.xaml"
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
            this.HeaderText = ((System.Windows.Controls.TextBox)(target));
            
            #line 16 "..\..\PrintWindow.xaml"
            this.HeaderText.KeyDown += new System.Windows.Input.KeyEventHandler(this.HeaderText_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 40 "..\..\PrintWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_ChangeHeader);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 41 "..\..\PrintWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_SponsorButton);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ButtonStartPrint = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\PrintWindow.xaml"
            this.ButtonStartPrint.Click += new System.Windows.RoutedEventHandler(this.ButtonStartPrint_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.printFish = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 6:
            this.PrintTeamInfo = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\PrintWindow.xaml"
            this.PrintTeamInfo.Click += new System.Windows.RoutedEventHandler(this.PrintTeamInfo_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.printPersonalInf = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 8:
            this.DayPrint = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\PrintWindow.xaml"
            this.DayPrint.Click += new System.Windows.RoutedEventHandler(this.DayPrint_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.teamChoise = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            this.teamDay = ((System.Windows.Controls.ComboBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

