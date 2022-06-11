﻿#pragma checksum "..\..\CrosshairSettings.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "57B929C355305AF7DD5B351DCA08ACE0DA44B15AB7CA8F1D7DC7E561B568A541"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Reticle;
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


namespace Reticle {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 52 "..\..\CrosshairSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ReticleImagePreview;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\CrosshairSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel PresetPanel;
        
        #line default
        #line hidden
        
        /// <summary>
        /// AlwaysOnTopCheckbox Name Field
        /// </summary>
        
        #line 83 "..\..\CrosshairSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.CheckBox AlwaysOnTopCheckbox;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\CrosshairSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button HotKeyModToggleButton;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\CrosshairSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button HotKeyToggleButton;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\CrosshairSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider xslider;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\CrosshairSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider yslider;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\CrosshairSettings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button StartCrosshairButton;
        
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
            System.Uri resourceLocater = new System.Uri("/CrosshairOverlay;component/crosshairsettings.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CrosshairSettings.xaml"
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
            
            #line 7 "..\..\CrosshairSettings.xaml"
            ((Reticle.MainWindow)(target)).Closed += new System.EventHandler(this.Window_Closed);
            
            #line default
            #line hidden
            
            #line 8 "..\..\CrosshairSettings.xaml"
            ((Reticle.MainWindow)(target)).Deactivated += new System.EventHandler(this.Window_Deactivated);
            
            #line default
            #line hidden
            
            #line 8 "..\..\CrosshairSettings.xaml"
            ((Reticle.MainWindow)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.Window_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ReticleImagePreview = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            
            #line 56 "..\..\CrosshairSettings.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ChooseReticleImage_Button);
            
            #line default
            #line hidden
            return;
            case 4:
            this.PresetPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 5:
            
            #line 64 "..\..\CrosshairSettings.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.UsePresetButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 68 "..\..\CrosshairSettings.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.UsePresetButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 72 "..\..\CrosshairSettings.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.UsePresetButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 76 "..\..\CrosshairSettings.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.UsePresetButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.AlwaysOnTopCheckbox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 10:
            this.HotKeyModToggleButton = ((System.Windows.Controls.Button)(target));
            
            #line 106 "..\..\CrosshairSettings.xaml"
            this.HotKeyModToggleButton.Click += new System.Windows.RoutedEventHandler(this.SetHotKeyModifier_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.HotKeyToggleButton = ((System.Windows.Controls.Button)(target));
            
            #line 108 "..\..\CrosshairSettings.xaml"
            this.HotKeyToggleButton.Click += new System.Windows.RoutedEventHandler(this.SetHotKey_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.xslider = ((System.Windows.Controls.Slider)(target));
            
            #line 112 "..\..\CrosshairSettings.xaml"
            this.xslider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.Slider_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 13:
            this.yslider = ((System.Windows.Controls.Slider)(target));
            
            #line 113 "..\..\CrosshairSettings.xaml"
            this.yslider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.Slider_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 14:
            this.StartCrosshairButton = ((System.Windows.Controls.Button)(target));
            
            #line 121 "..\..\CrosshairSettings.xaml"
            this.StartCrosshairButton.Click += new System.Windows.RoutedEventHandler(this.StartRecticleButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

