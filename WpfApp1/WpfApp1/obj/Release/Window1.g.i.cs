﻿#pragma checksum "..\..\Window1.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CC4E4BF4DFFE7C7AABE5462E334D28DF5BE31B8E36AE5C02E664C6A39F3286EB"
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
    /// Window1
    /// </summary>
    public partial class Window1 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl dayTabs;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox Dag1;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox Dag2;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox Dag3;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button teamEdit;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox fishList;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxFishTypes;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FishWeightTextBox;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonAddFish;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonRemoveFish;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\Window1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonPrintOptions;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp1;component/window1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Window1.xaml"
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
            this.dayTabs = ((System.Windows.Controls.TabControl)(target));
            
            #line 23 "..\..\Window1.xaml"
            this.dayTabs.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DayTabs_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Dag1 = ((System.Windows.Controls.ListBox)(target));
            
            #line 25 "..\..\Window1.xaml"
            this.Dag1.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Dag1_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Dag2 = ((System.Windows.Controls.ListBox)(target));
            
            #line 37 "..\..\Window1.xaml"
            this.Dag2.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Dag2_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Dag3 = ((System.Windows.Controls.ListBox)(target));
            
            #line 49 "..\..\Window1.xaml"
            this.Dag3.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Dag3_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.teamEdit = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\Window1.xaml"
            this.teamEdit.Click += new System.Windows.RoutedEventHandler(this.TeamEdit_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.fishList = ((System.Windows.Controls.ListBox)(target));
            return;
            case 7:
            this.ComboBoxFishTypes = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.FishWeightTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 84 "..\..\Window1.xaml"
            this.FishWeightTextBox.KeyDown += new System.Windows.Input.KeyEventHandler(this.FishWeightTextBox_KeyDown);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ButtonAddFish = ((System.Windows.Controls.Button)(target));
            
            #line 108 "..\..\Window1.xaml"
            this.ButtonAddFish.Click += new System.Windows.RoutedEventHandler(this.ButtonAddFish_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.ButtonRemoveFish = ((System.Windows.Controls.Button)(target));
            
            #line 109 "..\..\Window1.xaml"
            this.ButtonRemoveFish.Click += new System.Windows.RoutedEventHandler(this.ButtonRemoveFish_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.ButtonPrintOptions = ((System.Windows.Controls.Button)(target));
            
            #line 110 "..\..\Window1.xaml"
            this.ButtonPrintOptions.Click += new System.Windows.RoutedEventHandler(this.ButtonPrintOptions_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
