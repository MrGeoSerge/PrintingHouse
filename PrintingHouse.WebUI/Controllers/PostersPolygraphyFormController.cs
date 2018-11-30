using PrintingHouse.Domain.Entities;
using PrintingHouse.Domain.Entities.Reports;
using PrintingHouse.Domain.Processes.PrintingHouseManagement;
using PrintingHouse.Domain.Specifications;
using PrintingHouse.WebUI.Data;
using PrintingHouse.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrintingHouse.WebUI.Controllers
{
    public class PostersPolygraphyFormController : Controller
    {
        // GET: PostersPolygraphyForm
        [HttpGet]
		public ActionResult PostersCalculations()
		{
            FillViewBagWithDropDowns(ViewBag);
			return View();
		}

		[HttpPost]
		public ActionResult PostersCalculations(PostersModel postersModel)
		{
            FillViewBagWithDropDowns(ViewBag);

			if (ModelState.IsValid)
			{
				// TODO: Unify these for lines into one class
				Book theBook = postersModel.CreatePosters();

				DirectorOfTypography director = new DirectorOfTypography(theBook, new GetPathFolderString());
				PolygraphyCostReport report = director.MakeBook();
				ViewBag.Report = report;
				return View("PostersCalculations", postersModel);
			}
			return View("PostersCalculations");
		}

        private void FillViewBagWithDropDowns(dynamic viewBag)
        {
            List<PaperItem> PostersPaperTypes = new List<PaperItem>()
            {
                new PaperItem() {Id = PaperFullType.CoatedPaper_300, Name = "Меловка пл.300 64х90 гл"},
                new PaperItem() {Id = PaperFullType.CoatedPaper_200, Name = "Меловка пл.200 64х90 гл"},
                new PaperItem() {Id = PaperFullType.CardboardСellulose_215, Name="картон целлюлоза 215 г/м2"},
                new PaperItem() {Id = PaperFullType.FoldingBoxboard_230, Name="хром-эрзац 230 г/м2"},
                new PaperItem() {Id = PaperFullType.CardboardAliaska_230, Name="картон Аляска 230 г/м2"}
            };
            viewBag.PostersPaperTypes = PostersPaperTypes;

            List<PaperItem> InsertPaperTypes = new List<PaperItem>()
            {
                new PaperItem() {Id = PaperFullType.Offset_80, Name="офсет 80 г/м2 листовой" }
            };
            viewBag.InsertPaperTypes = InsertPaperTypes;

            List<PrintingPressItem> PostersPrintingPressTypes = new List<PrintingPressItem>()
            {
                new PrintingPressItem(){Id= PrintingPressType.Rapida, Name = "Рапида"},
                new PrintingPressItem(){Id= PrintingPressType.Shinohara, Name = "Шинохара"}
            };
            viewBag.PostersPrintingPresses = PostersPrintingPressTypes;

            List<PrintingPressItem> InsertPressTypes = new List<PrintingPressItem>()
            {
                new PrintingPressItem(){Id= PrintingPressType.Shinohara, Name = "Шинохара"},
                new PrintingPressItem(){Id= PrintingPressType.Zirkon, Name = "Циркон"},
                new PrintingPressItem(){Id= PrintingPressType.Rapida, Name = "Рапида"}
            };
            viewBag.InsertPrintingPresses = InsertPressTypes;


        }


        public ActionResult CostReport(PostersModel postersModel)
        {
            if (ModelState.IsValid)
            {
                Book theBook = postersModel.CreatePosters();
                DirectorOfTypography director = new DirectorOfTypography(theBook, new GetPathFolderString());
                PolygraphyCostReport report = director.MakeBook();
                return PartialView(report);
            }
            return new EmptyResult();
        }

        public ActionResult DetailedCostReport(PostersModel postersModel)
        {
            if (ModelState.IsValid)
            {
                // TODO: Unify these 4 lines into one class
                Book theBook = postersModel.CreatePosters();
                DirectorOfTypography director = new DirectorOfTypography(theBook, new GetPathFolderString());
                PolygraphyCostReport report = director.MakeBook();
                return PartialView(report);
            }
            return new EmptyResult();
        }


    }
}