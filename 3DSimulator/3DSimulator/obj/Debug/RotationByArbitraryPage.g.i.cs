﻿#pragma checksum "..\..\RotationByArbitraryPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "587E85A1D50A9DDD76D6FCFFDB8C1569DE86F75B"
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
using _3DSimulator;


namespace _3DSimulator {
    
    
    /// <summary>
    /// RotationByArbitraryPage
    /// </summary>
    public partial class RotationByArbitraryPage : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\RotationByArbitraryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Viewport3D viewPort3D;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\RotationByArbitraryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.Media3D.PerspectiveCamera mainCamera;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\RotationByArbitraryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.Media3D.DirectionalLight dirLight;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\RotationByArbitraryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.Media3D.GeometryModel3D cube;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\RotationByArbitraryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.Media3D.MeshGeometry3D meshMain;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\RotationByArbitraryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.Media3D.MeshGeometry3D line;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\RotationByArbitraryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox boxStartX;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\RotationByArbitraryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox boxStartY;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\RotationByArbitraryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox boxStartZ;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\RotationByArbitraryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox boxEndX;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\RotationByArbitraryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox boxEndY;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\RotationByArbitraryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox boxEndZ;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\RotationByArbitraryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button createAxisBtn;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\RotationByArbitraryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider sliderTethaAngle;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\RotationByArbitraryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox boxTethaAngle;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\RotationByArbitraryPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button animateBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/3DSimulator;component/rotationbyarbitrarypage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\RotationByArbitraryPage.xaml"
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
            this.viewPort3D = ((System.Windows.Controls.Viewport3D)(target));
            return;
            case 2:
            this.mainCamera = ((System.Windows.Media.Media3D.PerspectiveCamera)(target));
            return;
            case 3:
            this.dirLight = ((System.Windows.Media.Media3D.DirectionalLight)(target));
            return;
            case 4:
            this.cube = ((System.Windows.Media.Media3D.GeometryModel3D)(target));
            return;
            case 5:
            this.meshMain = ((System.Windows.Media.Media3D.MeshGeometry3D)(target));
            return;
            case 6:
            this.line = ((System.Windows.Media.Media3D.MeshGeometry3D)(target));
            return;
            case 7:
            this.boxStartX = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.boxStartY = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.boxStartZ = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.boxEndX = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.boxEndY = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.boxEndZ = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            this.createAxisBtn = ((System.Windows.Controls.Button)(target));
            
            #line 98 "..\..\RotationByArbitraryPage.xaml"
            this.createAxisBtn.Click += new System.Windows.RoutedEventHandler(this.createAxisBtn_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.sliderTethaAngle = ((System.Windows.Controls.Slider)(target));
            return;
            case 15:
            this.boxTethaAngle = ((System.Windows.Controls.TextBox)(target));
            return;
            case 16:
            this.animateBtn = ((System.Windows.Controls.Button)(target));
            
            #line 110 "..\..\RotationByArbitraryPage.xaml"
            this.animateBtn.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

