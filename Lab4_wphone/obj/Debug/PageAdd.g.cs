﻿#pragma checksum "c:\users\tolol\documents\visual studio 2015\Projects\Lab4_wphone\Lab4_wphone\PageAdd.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4E4FD5FF44FE7922477F92864C514266"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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


namespace Lab4_wphone {
    
    
    public partial class PageAdd : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.TextBlock ApplicationTitle;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBlock lblElem;
        
        internal System.Windows.Controls.TextBox txtElem;
        
        internal System.Windows.Controls.TextBox txtMoney;
        
        internal System.Windows.Controls.CheckBox checkActive;
        
        internal System.Windows.Controls.Button btnApply;
        
        internal System.Windows.Controls.Button btnCancel;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Lab4_wphone;component/PageAdd.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ApplicationTitle = ((System.Windows.Controls.TextBlock)(this.FindName("ApplicationTitle")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.lblElem = ((System.Windows.Controls.TextBlock)(this.FindName("lblElem")));
            this.txtElem = ((System.Windows.Controls.TextBox)(this.FindName("txtElem")));
            this.txtMoney = ((System.Windows.Controls.TextBox)(this.FindName("txtMoney")));
            this.checkActive = ((System.Windows.Controls.CheckBox)(this.FindName("checkActive")));
            this.btnApply = ((System.Windows.Controls.Button)(this.FindName("btnApply")));
            this.btnCancel = ((System.Windows.Controls.Button)(this.FindName("btnCancel")));
        }
    }
}

