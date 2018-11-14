using PrintingHouse.Domain.Entities;
using PrintingHouse.Domain.Entities.Reports;
using PrintingHouse.Domain.Processes.PrintingHouseManagement;
using PrintingHouse.Domain.Specifications;
using PrintingHouse.WebUI.Data;
using PrintingHouse.WebUI.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PrintingHouse.WebUI.Controllers
{
	public class ExerciseBookPolygraphyFormController : Controller
    {
		// GET: PolygraphyForm
		//здесь начало приложения
		[HttpGet]
		public ActionResult ExerciseBookCalculations()
		{
			List<PaperItem> IB_PaperTypes = new List<PaperItem>()
			{
				new PaperItem() {Id = PaperFullType.Newsprint_45, Name="газетка 45 г/м2" },
				new PaperItem() {Id = PaperFullType.Offset_60, Name="офсет 60 г/м2" },
				new PaperItem() {Id = PaperFullType.Offset_80, Name="офсет 80 г/м2" }
			};
			ViewBag.IB_PaperTypes = IB_PaperTypes;

			List<PaperItem> CoverPaperTypes = new List<PaperItem>()
			{
				new PaperItem() {Id = PaperFullType.FoldingBoxboard_230, Name="хром-эрзац 230 г/м2" },
				new PaperItem() {Id = PaperFullType.CardboardAliaska_230, Name="картон Аляска 230 г/м2" }
			};
			ViewBag.CoverPaperTypes = CoverPaperTypes;

			List<PaperItem> StickerPaperTypes = new List<PaperItem>()
			{
				new PaperItem() {Id = PaperFullType.SelfAdhensive, Name="самоклейка" },
			};
			ViewBag.StickerPaperTypes = StickerPaperTypes;
			return View();
		}

		[HttpPost]
		public ActionResult ExerciseBookCalculations(BookModel bookModel)
		{
			List<PaperItem> IB_PaperTypes = new List<Models.PaperItem>()
			{
				new PaperItem() {Id = PaperFullType.Newsprint_45, Name="газетка 45 г/м2" },
				new PaperItem() {Id = PaperFullType.Offset_60, Name="офсет 60 г/м2" },
				new PaperItem() {Id = PaperFullType.Offset_80, Name="офсет 80 г/м2" }
			};
			ViewBag.IB_PaperTypes = IB_PaperTypes;

			List<PaperItem> CoverPaperTypes = new List<PaperItem>()
			{
				new PaperItem() {Id = PaperFullType.FoldingBoxboard_230, Name="хром-эрзац 230 г/м2" },
				new PaperItem() {Id = PaperFullType.CardboardAliaska_230, Name="картон Аляска 230 г/м2" }
			};
			ViewBag.CoverPaperTypes = CoverPaperTypes;

			List<PaperItem> StickerPaperTypes = new List<PaperItem>()
			{
				new PaperItem() {Id = PaperFullType.SelfAdhensive, Name="самоклейка" },
			};
			ViewBag.StickerPaperTypes = StickerPaperTypes;

			if (ModelState.IsValid)
			{
				// TODO: Unify these for lines into one class
				Book theBook = bookModel.CreateBook();

				DirectorOfTypography director = new DirectorOfTypography(theBook, new GetPathFolderString());
				PolygraphyCostReport report = director.MakeBook();
				ViewBag.Report = report;
				return View("ExerciseBookCalculations", bookModel);
			}
			return View("ExerciseBookCalculations");
		}

		public ActionResult Calculations(BookModel bookModel)
		{
			if (ModelState.IsValid)
			{
				Book theBook = bookModel.CreateBook();
				DirectorOfTypography director = new DirectorOfTypography(theBook, new GetPathFolderString());
				PolygraphyCostReport report = director.MakeBook();
				return PartialView(report);
			}
			return new EmptyResult();
		}

		public ActionResult DetailedCostReport(BookModel bookModel)
		{
			if (ModelState.IsValid)
			{
				// TODO: Unify these 4 lines into one class
				Book theBook = bookModel.CreateBook();
				DirectorOfTypography director = new DirectorOfTypography(theBook, new GetPathFolderString());
				PolygraphyCostReport report = director.MakeBook();
				return PartialView(report);
			}
			return new EmptyResult();
		}

	}
}