using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintingHouse.UnitTests.VerificationResults
{
	public class ShinoharaResult_Copy
	{
		public int FormPrice => 54;
		public int FittingPriceValue => 16;
		public double TechNeedsPrice => 3.2;
		public double ImpressionPrice => 0.037;
		public int PagesPerOneImposition => 2;
		public int ImposiotionsPerBook => 2;
		public double PrintingSheetsPerBook => 1;
		public int PrintingSheetsPerPrintRun => 1000;
		public int PrintingForms => 5;
		public int CostOfPrintingFoms => 270;
		public int Impressions => 5000;
		public double CostOfImpressions => 185;
		public double CostOfPrinting => 455;
		public int PaperConsumptionForTechnicalNeeds => 160;
		public int FittingOnPrintRun => 80;
		public int TotalPaperConsumptionInPressFormat => 1260;
		public int PressSheetFormat_Fraction => 8;//??
	}
}
