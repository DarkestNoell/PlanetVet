﻿#pragma checksum "..\..\..\Windows\PlanetVetWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0B6C4F0996A0407944C1AC9A830101E8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Capstone;
using MahApps.Metro.Controls;
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


namespace Capstone {
    
    
    /// <summary>
    /// PlanetVetWindow
    /// </summary>
    public partial class PlanetVetWindow : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\Windows\PlanetVetWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Appointments;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Windows\PlanetVetWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddNewClientButton;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Windows\PlanetVetWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ClientSearchButton;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Windows\PlanetVetWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button InventoryButton;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Windows\PlanetVetWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ReconfigureBusinessHoursWindow;
        
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
            System.Uri resourceLocater = new System.Uri("/Capstone;component/windows/planetvetwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\PlanetVetWindow.xaml"
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
            this.Appointments = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\Windows\PlanetVetWindow.xaml"
            this.Appointments.Click += new System.Windows.RoutedEventHandler(this.button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.AddNewClientButton = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\Windows\PlanetVetWindow.xaml"
            this.AddNewClientButton.Click += new System.Windows.RoutedEventHandler(this.AddNewClientButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ClientSearchButton = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\Windows\PlanetVetWindow.xaml"
            this.ClientSearchButton.Click += new System.Windows.RoutedEventHandler(this.ClientSearchButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.InventoryButton = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\Windows\PlanetVetWindow.xaml"
            this.InventoryButton.Click += new System.Windows.RoutedEventHandler(this.InventoryButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ReconfigureBusinessHoursWindow = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\Windows\PlanetVetWindow.xaml"
            this.ReconfigureBusinessHoursWindow.Click += new System.Windows.RoutedEventHandler(this.ReconfigureBusinessHoursWindow_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

