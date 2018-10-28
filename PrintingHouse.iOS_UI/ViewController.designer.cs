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

namespace PrintingHouse.iOS_UI
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton addTextToFileButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton calculateButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel folderPathLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView folderPathTextView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField numberOfPagesTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField printRunTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel resultsLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel textFileContentLabel { get; set; }

        [Action ("AddTextToFileButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void AddTextToFileButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("CalculateButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void CalculateButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (addTextToFileButton != null) {
                addTextToFileButton.Dispose ();
                addTextToFileButton = null;
            }

            if (calculateButton != null) {
                calculateButton.Dispose ();
                calculateButton = null;
            }

            if (folderPathLabel != null) {
                folderPathLabel.Dispose ();
                folderPathLabel = null;
            }

            if (folderPathTextView != null) {
                folderPathTextView.Dispose ();
                folderPathTextView = null;
            }

            if (numberOfPagesTextField != null) {
                numberOfPagesTextField.Dispose ();
                numberOfPagesTextField = null;
            }

            if (printRunTextField != null) {
                printRunTextField.Dispose ();
                printRunTextField = null;
            }

            if (resultsLabel != null) {
                resultsLabel.Dispose ();
                resultsLabel = null;
            }

            if (textFileContentLabel != null) {
                textFileContentLabel.Dispose ();
                textFileContentLabel = null;
            }
        }
    }
}