// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace PorpoiseMobileApp.iOS
{
    [Register ("NavigateSettingsViewController")]
    partial class NavigateSettingsViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton openSettings { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (openSettings != null) {
                openSettings.Dispose ();
                openSettings = null;
            }
        }
    }
}