using PrintingHouse.UnitTests.Data;
using PrintingHouse.UnitTests.VerificationResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintingHouse.UnitTests.Helpers
{
	public class UpdatePrintingPressesResults
	{
		public void UpdateResults()
		{
			PrintingPressResult corosetResult = new PrintingPressResult();
			JsonHelper<PrintingPressResult>.WriteToFile(corosetResult, "CorosetResult");
		}
	}
}
