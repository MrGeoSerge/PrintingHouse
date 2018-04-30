﻿using NUnit.Framework;
using PrintingHouse.Domain.Entities.BookComponents;
using PrintingHouse.Domain.Entities.Paper;
using PrintingHouse.Domain.Entities.PrintingPresses;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Specifications;
using PrintingHouse.UnitTests.VerificationResults;
using PrintingHouse.UnitTests.Data;

namespace PrintingHouse.UnitTests.PrintingPresses.Coroset
{

	[TestFixture]
	[Category("CorosetPlamag_84_108_InternalBlock")]
	public class CorosetPlamag_84_108_InternalBlock : PrintingPressTestBase
	{
		//imposition - спуск
		//impression - оттиск

		[SetUp]
		public override void Initialize()
		{
			//МДН7-д3
			printingPress = new CorosetPlamag(
				new TaskToPrint(
					new BookPart("InternalBlock",
						new IssueFormat(84, 108, 16), 
						new PaperInKg(PaperType.Newsprint, 45, 16.48, "Германия", 84),
						new IssueColors(1, 1), 
						152),
					1000));

			printingPressResult = JsonHelper<PrintingPressResult>.ReadFromFile("CorosetResult");
		}
	}
}


