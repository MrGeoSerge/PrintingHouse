using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintingHouse.UnitTests.VerificationResults
{
	public class Rapida_60_90_CoverResult
	{
		public int FormPrice { get; set; }
		public int FittingPriceValue { get; set; }
		public double TechNeedsPrice { get; set; }
		public double ImpressionPrice { get; set; }
		public int PagesPerOneImposition { get; set; }
		public double ImposiotionsPerBook { get; set; }
		public double PrintingSheetsPerBook { get; set; }
		public int PrintingSheetsPerPrintRun { get; set; }
		public int PrintingForms { get; set; }
		public int CostOfPrintingFoms { get; set; }
		public int Impressions { get; set; }
		public double CostOfImpressions { get; set; }
		public double CostOfPrinting { get; set; }
		public int PaperConsumptionForTechnicalNeeds { get; set; }
		public int FittingOnPrintRun { get; set; }
		public int TotalPaperConsumptionInPressFormat { get; set; }
	}
}
