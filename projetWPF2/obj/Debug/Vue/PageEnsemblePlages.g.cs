﻿#pragma checksum "..\..\..\Vue\PageEnsemblePlages.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "29F6739B3A259C3E7450032863FF06A341FAA8EBEC2C6F464C821B9EB48D2A34"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

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
using projetWPF2;


namespace projetWPF2 {
    
    
    /// <summary>
    /// PageEnsemblePlages
    /// </summary>
    public partial class PageEnsemblePlages : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\Vue\PageEnsemblePlages.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listeEnsemble;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Vue\PageEnsemblePlages.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listeEnsemblePlages;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Vue\PageEnsemblePlages.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button supprimer_un_ensemble;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Vue\PageEnsemblePlages.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddEnsemble;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Vue\PageEnsemblePlages.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button supprimer_une_plage;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Vue\PageEnsemblePlages.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ajouter_une_plage;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Vue\PageEnsemblePlages.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Retour;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Vue\PageEnsemblePlages.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listePlages;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\Vue\PageEnsemblePlages.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nomEnsembleTextBox;
        
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
            System.Uri resourceLocater = new System.Uri("/projetWPF2;component/vue/pageensembleplages.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Vue\PageEnsemblePlages.xaml"
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
            this.listeEnsemble = ((System.Windows.Controls.ListView)(target));
            
            #line 14 "..\..\..\Vue\PageEnsemblePlages.xaml"
            this.listeEnsemble.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.listeEnsemblePlage_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.listeEnsemblePlages = ((System.Windows.Controls.ListView)(target));
            return;
            case 3:
            this.supprimer_un_ensemble = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\Vue\PageEnsemblePlages.xaml"
            this.supprimer_un_ensemble.Click += new System.Windows.RoutedEventHandler(this.supprimer_ensemble);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AddEnsemble = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\Vue\PageEnsemblePlages.xaml"
            this.AddEnsemble.Click += new System.Windows.RoutedEventHandler(this.AddEnsemble_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.supprimer_une_plage = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\Vue\PageEnsemblePlages.xaml"
            this.supprimer_une_plage.Click += new System.Windows.RoutedEventHandler(this.supprimerPlage);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ajouter_une_plage = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\Vue\PageEnsemblePlages.xaml"
            this.ajouter_une_plage.Click += new System.Windows.RoutedEventHandler(this.Ajouter_Plage);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Retour = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\Vue\PageEnsemblePlages.xaml"
            this.Retour.Click += new System.Windows.RoutedEventHandler(this.retour_back);
            
            #line default
            #line hidden
            return;
            case 8:
            this.listePlages = ((System.Windows.Controls.ListView)(target));
            return;
            case 9:
            this.nomEnsembleTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

