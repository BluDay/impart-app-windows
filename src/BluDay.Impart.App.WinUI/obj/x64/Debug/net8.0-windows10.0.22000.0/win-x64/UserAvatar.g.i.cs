﻿#pragma checksum "C:\Code\impart-app\src\BluDay.Impart.App.WinUI\BluDay.Impart.App.WinUI\UI\Controls\UserAvatar.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3E0E7DBBD21DDAB188E6DBFBC880C78260466268E9974AE42E5F91D002C27550"
#pragma checksum "C:\Code\impart-app\src\BluDay.Impart.App.WinUI\UI\Controls\UserAvatar.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3E0E7DBBD21DDAB188E6DBFBC880C78260466268E9974AE42E5F91D002C27550"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BluDay.Impart.App.WinUI.UI.Controls
{
    partial class UserAvatar : global::Microsoft.UI.Xaml.Controls.UserControl
    {


#pragma warning disable 0169    //  Proactively suppress unused/uninitialized field warning in case they aren't used, for things like x:Name
#pragma warning disable 0649
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2312")]
        private global::Microsoft.UI.Xaml.Shapes.Ellipse StatusEllipse; 
#pragma warning restore 0649
#pragma warning restore 0169
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2312")]
        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2312")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent()
        {
            this.InitializeComponent(null);
        }

        /// <summary>
        /// InitializeComponent()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2312")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent(global::System.Uri resourceLocator)
        {
            if (_contentLoaded)
                return;

            _contentLoaded = true;

            if (resourceLocator == null)
            {
                resourceLocator = new global::System.Uri("ms-appx:///UserAvatar.xaml");
            }
            global::Microsoft.UI.Xaml.Application.LoadComponent(this, resourceLocator, global::Microsoft.UI.Xaml.Controls.Primitives.ComponentResourceLocation.Application);
        }

        partial void UnloadObject(global::Microsoft.UI.Xaml.DependencyObject unloadableObject);

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2312")]
        private interface IUserAvatar_Bindings
        {
            void Initialize();
            void Update();
            void StopTracking();
            void DisconnectUnloadedObject(int connectionId);
        }

        private interface IUserAvatar_BindingsScopeConnector
        {
            global::System.WeakReference Parent { get; set; }
            bool ContainsElement(int connectionId);
            void RegisterForElementConnection(int connectionId, global::Microsoft.UI.Xaml.Markup.IComponentConnector connector);
        }
#pragma warning disable 0169    //  Proactively suppress unused field warning in case Bindings is not used.
#pragma warning disable 0649
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2312")]
        private IUserAvatar_Bindings Bindings;
#pragma warning restore 0649
#pragma warning restore 0169
    }
}

