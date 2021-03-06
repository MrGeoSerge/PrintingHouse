﻿using Foundation;
using System;
using UIKit;

using PrintingHouse.iOS_UI.Model;
using PrintingHouse.iOS_UI.Data;
using System.IO;
using PrintingHouse.Domain.Entities.Reports;

namespace PrintingHouse.iOS_UI
{
    public partial class ViewController : UIViewController
    {
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            // Perform any additional setup after loading the view, typically from a nib.

        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void CalculateButton_TouchUpInside(UIButton sender)
        {
            printRunTextField.ResignFirstResponder();

            int pagesQnt = Int32.Parse(numberOfPagesTextField.Text);

            int printRun = Int32.Parse(printRunTextField.Text);

            var getPathFolderString = new GetPathFolderString();
            
            CalculationsManager calculationsManager = new CalculationsManager(getPathFolderString);
            PolygraphyCostReport report = calculationsManager.CalculateMyConspectusPrintingCost(pagesQnt, printRun);


            costOfPolygraphyLabel.Text = report.CostOfPolygraphy.ToString("F");
            costOfMaterialsLabel.Text = report.CostOfMaterials.ToString("F");
            costOfAssemblyLabel.Text = report.CostOfAssembly.ToString("F");
            costOfPrintRunLabel.Text = report.CostOfPrintRun.ToString("F");
            costOfOneUnitLabel.Text = report.CostOfPolygraphyPerOneItem.ToString("F");


        }

    }
}