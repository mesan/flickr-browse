﻿

#pragma checksum "C:\Users\Sindre\Documents\Visual Studio 2012\Projects\Win8 Apps\FlickrBrowser\FlickrBrowser\Pages\BasePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A0B576B69299279FFB1058AA02302435"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FlickrBrowser.Pages
{
    partial class BasePage : global::FlickrBrowser.Common.LayoutAwarePage
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.AppBar defaultAppBar; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Button appBarBtnDownload; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Button appBarBtnRefresh; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private bool _contentLoaded;

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent()
        {
            if (_contentLoaded)
                return;

            _contentLoaded = true;
            global::Windows.UI.Xaml.Application.LoadComponent(this, new global::System.Uri("ms-appx:///Pages/BasePage.xaml"), global::Windows.UI.Xaml.Controls.Primitives.ComponentResourceLocation.Application);
 
            defaultAppBar = (global::Windows.UI.Xaml.Controls.AppBar)this.FindName("defaultAppBar");
            appBarBtnDownload = (global::Windows.UI.Xaml.Controls.Button)this.FindName("appBarBtnDownload");
            appBarBtnRefresh = (global::Windows.UI.Xaml.Controls.Button)this.FindName("appBarBtnRefresh");
        }
    }
}



