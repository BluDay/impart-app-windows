﻿#pragma checksum "C:\Code\impart-app\src\BluDay.Impart.App.WinUI\BluDay.Impart.App.WinUI\UI\Controls\UserAvatar.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3E0E7DBBD21DDAB188E6DBFBC880C78260466268E9974AE42E5F91D002C27550"
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
    partial class UserAvatar : 
        global::Microsoft.UI.Xaml.Controls.UserControl, 
        global::Microsoft.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2312")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Microsoft_UI_Xaml_FrameworkElement_Height(global::Microsoft.UI.Xaml.FrameworkElement obj, global::System.Double value)
            {
                obj.Height = value;
            }
            public static void Set_Microsoft_UI_Xaml_FrameworkElement_Width(global::Microsoft.UI.Xaml.FrameworkElement obj, global::System.Double value)
            {
                obj.Width = value;
            }
            public static void Set_Microsoft_UI_Xaml_Controls_PersonPicture_ProfilePicture(global::Microsoft.UI.Xaml.Controls.PersonPicture obj, global::Microsoft.UI.Xaml.Media.ImageSource value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::Microsoft.UI.Xaml.Media.ImageSource) global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Microsoft.UI.Xaml.Media.ImageSource), targetNullValue);
                }
                obj.ProfilePicture = value;
            }
            public static void Set_Microsoft_UI_Xaml_Shapes_Shape_Fill(global::Microsoft.UI.Xaml.Shapes.Shape obj, global::Microsoft.UI.Xaml.Media.Brush value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::Microsoft.UI.Xaml.Media.Brush) global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::Microsoft.UI.Xaml.Media.Brush), targetNullValue);
                }
                obj.Fill = value;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2312")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class UserAvatar_obj1_Bindings :
            global::Microsoft.UI.Xaml.Markup.IDataTemplateComponent,
            global::Microsoft.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Microsoft.UI.Xaml.Markup.IComponentConnector,
            IUserAvatar_Bindings
        {
            private global::BluDay.Impart.App.WinUI.UI.Controls.UserAvatar dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Microsoft.UI.Xaml.Controls.PersonPicture obj2;
            private global::Microsoft.UI.Xaml.Shapes.Ellipse obj3;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj2HeightDisabled = false;
            private static bool isobj2WidthDisabled = false;
            private static bool isobj2ProfilePictureDisabled = false;
            private static bool isobj3FillDisabled = false;

            private UserAvatar_obj1_BindingsTracking bindingsTracking;

            public UserAvatar_obj1_Bindings()
            {
                this.bindingsTracking = new UserAvatar_obj1_BindingsTracking(this);
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 35 && columnNumber == 24)
                {
                    isobj2HeightDisabled = true;
                }
                else if (lineNumber == 36 && columnNumber == 24)
                {
                    isobj2WidthDisabled = true;
                }
                else if (lineNumber == 37 && columnNumber == 24)
                {
                    isobj2ProfilePictureDisabled = true;
                }
                else if (lineNumber == 44 && columnNumber == 18)
                {
                    isobj3FillDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 2: // BluDay.Impart.App.WinUI\UI\Controls\UserAvatar.xaml line 34
                        this.obj2 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.PersonPicture>(target);
                        break;
                    case 3: // BluDay.Impart.App.WinUI\UI\Controls\UserAvatar.xaml line 42
                        this.obj3 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Shapes.Ellipse>(target);
                        break;
                    default:
                        break;
                }
            }
                        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2312")]
                        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
                        public global::Microsoft.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target) 
                        {
                            return null;
                        }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
            }

            public void Recycle()
            {
                return;
            }

            // IUserAvatar_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.initialized = false;
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                if (newDataRoot != null)
                {
                    this.dataRoot = global::WinRT.CastExtensions.As<global::BluDay.Impart.App.WinUI.UI.Controls.UserAvatar>(newDataRoot);
                    return true;
                }
                return false;
            }

            public void Activated(object obj, global::Microsoft.UI.Xaml.WindowActivatedEventArgs data)
            {
                this.Initialize();
            }

            public void Loading(global::Microsoft.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::BluDay.Impart.App.WinUI.UI.Controls.UserAvatar obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_Height(obj.Height, phase);
                        this.Update_Avatar(obj.Avatar, phase);
                        this.Update_StatusColor(obj.StatusColor, phase);
                    }
                }
            }
            private void Update_Height(global::System.Double obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // BluDay.Impart.App.WinUI\UI\Controls\UserAvatar.xaml line 34
                    if (!isobj2HeightDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_FrameworkElement_Height(this.obj2, obj);
                    }
                    // BluDay.Impart.App.WinUI\UI\Controls\UserAvatar.xaml line 34
                    if (!isobj2WidthDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_FrameworkElement_Width(this.obj2, obj);
                    }
                }
            }
            private void Update_Avatar(global::Microsoft.UI.Xaml.Media.ImageSource obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // BluDay.Impart.App.WinUI\UI\Controls\UserAvatar.xaml line 34
                    if (!isobj2ProfilePictureDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Controls_PersonPicture_ProfilePicture(this.obj2, obj, null);
                    }
                }
            }
            private void Update_StatusColor(global::Microsoft.UI.Xaml.Media.SolidColorBrush obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // BluDay.Impart.App.WinUI\UI\Controls\UserAvatar.xaml line 42
                    if (!isobj3FillDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_UI_Xaml_Shapes_Shape_Fill(this.obj3, obj, null);
                    }
                }
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2312")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private class UserAvatar_obj1_BindingsTracking
            {
                private global::System.WeakReference<UserAvatar_obj1_Bindings> weakRefToBindingObj; 

                public UserAvatar_obj1_BindingsTracking(UserAvatar_obj1_Bindings obj)
                {
                    weakRefToBindingObj = new global::System.WeakReference<UserAvatar_obj1_Bindings>(obj);
                }

                public UserAvatar_obj1_Bindings TryGetBindingObject()
                {
                    UserAvatar_obj1_Bindings bindingObject = null;
                    if (weakRefToBindingObj != null)
                    {
                        weakRefToBindingObj.TryGetTarget(out bindingObject);
                        if (bindingObject == null)
                        {
                            weakRefToBindingObj = null;
                            ReleaseAllListeners();
                        }
                    }
                    return bindingObject;
                }

                public void ReleaseAllListeners()
                {
                    UpdateChildListeners_(null);
                }

                public void DependencyPropertyChanged_Height(global::Microsoft.UI.Xaml.DependencyObject sender, global::Microsoft.UI.Xaml.DependencyProperty prop)
                {
                    UserAvatar_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        global::BluDay.Impart.App.WinUI.UI.Controls.UserAvatar obj = sender as global::BluDay.Impart.App.WinUI.UI.Controls.UserAvatar;
                        if (obj != null)
                        {
                            bindings.Update_Height(obj.Height, DATA_CHANGED);
                        }
                    }
                }
                public void DependencyPropertyChanged_Avatar(global::Microsoft.UI.Xaml.DependencyObject sender, global::Microsoft.UI.Xaml.DependencyProperty prop)
                {
                    UserAvatar_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        global::BluDay.Impart.App.WinUI.UI.Controls.UserAvatar obj = sender as global::BluDay.Impart.App.WinUI.UI.Controls.UserAvatar;
                        if (obj != null)
                        {
                            bindings.Update_Avatar(obj.Avatar, DATA_CHANGED);
                        }
                    }
                }
                public void DependencyPropertyChanged_StatusColor(global::Microsoft.UI.Xaml.DependencyObject sender, global::Microsoft.UI.Xaml.DependencyProperty prop)
                {
                    UserAvatar_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        global::BluDay.Impart.App.WinUI.UI.Controls.UserAvatar obj = sender as global::BluDay.Impart.App.WinUI.UI.Controls.UserAvatar;
                        if (obj != null)
                        {
                            bindings.Update_StatusColor(obj.StatusColor, DATA_CHANGED);
                        }
                    }
                }
                private long tokenDPC_Height = 0;
                private long tokenDPC_Avatar = 0;
                private long tokenDPC_StatusColor = 0;
                public void UpdateChildListeners_(global::BluDay.Impart.App.WinUI.UI.Controls.UserAvatar obj)
                {
                    UserAvatar_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        if (bindings.dataRoot != null)
                        {
                            bindings.dataRoot.UnregisterPropertyChangedCallback(global::Microsoft.UI.Xaml.FrameworkElement.HeightProperty, tokenDPC_Height);
                            bindings.dataRoot.UnregisterPropertyChangedCallback(global::BluDay.Impart.App.WinUI.UI.Controls.UserAvatar.AvatarProperty, tokenDPC_Avatar);
                            bindings.dataRoot.UnregisterPropertyChangedCallback(global::BluDay.Impart.App.WinUI.UI.Controls.UserAvatar.StatusColorProperty, tokenDPC_StatusColor);
                        }
                        if (obj != null)
                        {
                            bindings.dataRoot = obj;
                            tokenDPC_Height = obj.RegisterPropertyChangedCallback(global::Microsoft.UI.Xaml.FrameworkElement.HeightProperty, DependencyPropertyChanged_Height);
                            tokenDPC_Avatar = obj.RegisterPropertyChangedCallback(global::BluDay.Impart.App.WinUI.UI.Controls.UserAvatar.AvatarProperty, DependencyPropertyChanged_Avatar);
                            tokenDPC_StatusColor = obj.RegisterPropertyChangedCallback(global::BluDay.Impart.App.WinUI.UI.Controls.UserAvatar.StatusColorProperty, DependencyPropertyChanged_StatusColor);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2312")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 3: // BluDay.Impart.App.WinUI\UI\Controls\UserAvatar.xaml line 42
                {
                    this.StatusEllipse = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Shapes.Ellipse>(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 3.0.0.2312")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Microsoft.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Microsoft.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1: // BluDay.Impart.App.WinUI\UI\Controls\UserAvatar.xaml line 2
                {                    
                    global::Microsoft.UI.Xaml.Controls.UserControl element1 = (global::Microsoft.UI.Xaml.Controls.UserControl)target;
                    UserAvatar_obj1_Bindings bindings = new UserAvatar_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                    global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element1, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}
