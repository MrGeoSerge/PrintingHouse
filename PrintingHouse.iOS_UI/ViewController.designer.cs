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
        UIKit.UIButton calculateButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel costOfAssemblyLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel costOfMaterialsLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel costOfOneUnitLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel costOfPolygraphyLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel costOfPrintRunLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField numberOfPagesTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField printRunTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel resultsLabel { get; set; }

        [Action ("CalculateButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void CalculateButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (calculateButton != null) {
                calculateButton.Dispose ();
                calculateButton = null;
            }

            if (costOfAssemblyLabel != null) {
                costOfAssemblyLabel.Dispose ();
                costOfAssemblyLabel = null;
            }

            if (costOfMaterialsLabel != null) {
                costOfMaterialsLabel.Dispose ();
                costOfMaterialsLabel = null;
            }

            if (costOfOneUnitLabel != null) {
                costOfOneUnitLabel.Dispose ();
                costOfOneUnitLabel = null;
            }

            if (costOfPolygraphyLabel != null) {
                costOfPolygraphyLabel.Dispose ();
                costOfPolygraphyLabel = null;
            }

            if (costOfPrintRunLabel != null) {
                costOfPrintRunLabel.Dispose ();
                costOfPrintRunLabel = null;
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
        }
    }
}