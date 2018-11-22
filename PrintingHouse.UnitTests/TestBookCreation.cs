using NUnit.Framework;
using PrintingHouse.Domain.Entities.Paper;
using PrintingHouse.Domain.Specifications;
using PrintingHouse.Domain.Entities.Reports;
using PrintingHouse.Domain.Entities;
using PrintingHouse.Domain.Entities.BookComponents;
using PrintingHouse.Domain.Processes.PrintingHouseManagement;
using PrintingHouse.UnitTests.Data;

namespace BookProduction.UnitTests
{
	[TestFixture]
	public class TestBookCreation
	{
		#region бумага
		//---------на 60*90 на циркон
		//газетка 59,3/45
		PaperInKg gazetka59_D45 = new PaperInKg(PaperType.Newsprint, 45, 17.613, "Волга", 59.3);
		//офсет 60/60
		PaperInKg offset60_D60 = new PaperInKg(PaperType.Offset, 60, 23.25, "Котлас", 60);

		//-----------на 70*100 на рапиду
		//офсет 70/60
		PaperInSheets offset70_100_D60 = new PaperInSheets(PaperType.Offset, 60, 1.2851, "Люмисет", 70, 100);
		//офсет 70/80
		PaperInSheets offset70_100_D80 = new PaperInSheets(PaperType.Offset, 80, 1.574716416, "Люмисет", 70, 100);

		//-----------на 84*108 на Коросет
		//газетка 84/43
		PaperInKg gazetka84_D43 = new PaperInKg(PaperType.Newsprint, 43, 15.965, "Коростышев", 84);
		//офсет 84/60
		PaperInKg offset84_D60 = new PaperInKg(PaperType.Offset, 60, 24.75, "Люмисет", 84);
		//офсет 84/80 на Шинохару
		PaperInSheets offset84_D80 = new PaperInSheets(PaperType.Offset, 80, 1.0345, "Котлас", 84, 56);


		//на обложку
		//Картон хр.-эрз.пл.230 70х100(Умка)
		PaperInSheets hrom_erzats230 = new PaperInSheets(PaperType.FoldingBoxboard, 230, 3.172, "Умка", 70, 100);


		//на вкладки
		//Самоклейка 45х64 пл.80 
		PaperInSheets samokleyka = new PaperInSheets(PaperType.SelfAdhensivePaper, 80, 3.9857, "Самоклейка", 64, 45);
		#endregion


		PolygraphyCostReport report;

		[SetUp]
		public void Initialize()
		{
		}


		[Test]
		public void MakeBookOSK002()
		{
			Book Kanikularia = new Book("ОСК002", "Подорож країною Канікулярія. 2 клас", 28000,
					new BookPart("InnerBlock", new IssueFormat(70, 100, 16), offset70_100_D60, new IssueColors(2, 2), 48, PrintingPressType.NotSelected),
					new BookPart("Cover", new IssueFormat(70, 100, 16), hrom_erzats230, new IssueColors(4, 1), 4, PrintingPressType.NotSelected),
					new BookPart("Nakleyki", new IssueFormat(70, 100, 16), samokleyka, new IssueColors(4, 0), 4, PrintingPressType.NotSelected),
					new BookAssembly(BindingType.SaddleStitching, LaminationType.Glossy, true));

			report = new DirectorOfTypography(Kanikularia, new Get_Old_PathFolderString()).MakeBook();

			Assert.AreEqual(4.67, report.CostOfPolygraphyPerOneItem, delta: 0.1);
		}

		[Test]
		public void MakeBook()
		{
			Book theBook = new Book("УММ034-д1", "Українська мова 8клас 2 семестр Нова програма Мій конспект", 1000,
				new BookPart("Внутренний блок", new IssueFormat(84, 108, 16),
				 new PaperInKg(PaperType.Newsprint, 45, 15.656, "Шклов", 84),
				 new IssueColors(1, 1), 88, PrintingPressType.NotSelected),
				 new BookPart("Обложка", new IssueFormat(84, 108, 16),
				 new PaperInSheets(PaperType.FoldingBoxboard, 230, 2.482, "Умка", 64, 90),
				 new IssueColors(4, 1), 4, PrintingPressType.NotSelected),
				 new BookAssembly(BindingType.SaddleStitching, LaminationType.Glossy, true, PerforationType.usual));

			DirectorOfTypography director = new DirectorOfTypography(theBook, new Get_Old_PathFolderString());
			PolygraphyCostReport report = director.MakeBook();

			Assert.AreEqual(7.59, report.CostOfPolygraphyPerOneItem, delta: 0.01);

		}
	}
}
