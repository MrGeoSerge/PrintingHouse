using Foundation;
using System;
using UIKit;

using PrintingHouse.iOS_UI.Model;
using PrintingHouse.iOS_UI.Data;

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
            int pagesQnt = Int32.Parse(numberOfPagesTextField.Text);

            int printRun = Int32.Parse(printRunTextField.Text);

            var getPathFolderString = new GetPathFolderString();
            
            CalculationsManager calculationsManager = new CalculationsManager(getPathFolderString);
            resultsLabel.Text = calculationsManager.CalculateMyConspectusPrintingCost(pagesQnt, printRun);

            //resultsLabel.Text = (pagesQnt * printRun).ToString();

        }
    }
}