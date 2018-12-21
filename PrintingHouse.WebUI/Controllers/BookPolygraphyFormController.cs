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
	public class BookPolygraphyFormController : Controller
    {
		//[HttpGet]
		public ActionResult BookCalculations()
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

			return View();
		}

		public PartialViewResult CostReport(BookModel bookModel)
		{
			if (Request.IsAjaxRequest())
			{
				Book theBook = bookModel.CreateBook();
				DirectorOfTypography director = new DirectorOfTypography(theBook, new GetPathFolderString());
				PolygraphyCostReport report = director.MakeBook();
				return PartialView(report);
			}
			return PartialView();
		}

	}
}