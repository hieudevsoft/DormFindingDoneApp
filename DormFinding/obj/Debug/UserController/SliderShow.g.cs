﻿#pragma checksum "..\..\..\UserController\SliderShow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CC6D12340D175A93587FB2CA2581581A5807463C6AD887347AC8398DBCB15369"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DormFinding;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace DormFinding {
    
    
    /// <summary>
    /// SliderShow
    /// </summary>
    public partial class SliderShow : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\UserController\SliderShow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPrevSLiderShow;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\UserController\SliderShow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border borderImageSlider;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\UserController\SliderShow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.ImageBrush imageSlider;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\UserController\SliderShow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel slideText1;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\UserController\SliderShow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel SlideText2;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\..\UserController\SliderShow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNextSLiderShow;
        
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
            System.Uri resourceLocater = new System.Uri("/DormFinding;component/usercontroller/slidershow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserController\SliderShow.xaml"
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
            this.btnPrevSLiderShow = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\UserController\SliderShow.xaml"
            this.btnPrevSLiderShow.Click += new System.Windows.RoutedEventHandler(this.btnPrevSLiderShow_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.borderImageSlider = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.imageSlider = ((System.Windows.Media.ImageBrush)(target));
            return;
            case 4:
            this.slideText1 = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 5:
            this.SlideText2 = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 6:
            this.btnNextSLiderShow = ((System.Windows.Controls.Button)(target));
            
            #line 100 "..\..\..\UserController\SliderShow.xaml"
            this.btnNextSLiderShow.Click += new System.Windows.RoutedEventHandler(this.btnNextSLiderShow_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
