﻿using PrintingHouse.Domain.Entities;
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
		[HttpGet]
		public ActionResult ExerciseBookCalculations()
		{
            FillViewBagWithDropDowns(ViewBag);
			return View();
		}

		[HttpPost]
		public ActionResult ExerciseBookCalculations(BookModel bookModel)
		{
            FillViewBagWithDropDowns(ViewBag);

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

        private void FillViewBagWithDropDowns(dynamic viewBag)
        {
            List<PaperItem> IB_PaperTypes = new List<PaperItem>()
            {
                new PaperItem() {Id = PaperFullType.Offset_70, Name="офсет 70 г/м2 ролевой" },
                new PaperItem() {Id = PaperFullType.Newsprint_45, Name="газетка 45 г/м2" },
                new PaperItem() {Id = PaperFullType.Offset_60, Name="офсет 60 г/м2 ролевой" },
                new PaperItem() {Id = PaperFullType.Offset_80, Name="офсет 80 г/м2 листовой" }
            };
            viewBag.IB_PaperTypes = IB_PaperTypes;

            List<PaperItem> CoverPaperTypes = new List<PaperItem>()
            {
                new PaperItem() {Id = PaperFullType.CardboardСellulose_215, Name="картон целлюлоза 215 г/м2"},
                new PaperItem() {Id = PaperFullType.FoldingBoxboard_230, Name="хром-эрзац 230 г/м2" },
                new PaperItem() {Id = PaperFullType.CardboardAliaska_230, Name="картон Аляска 230 г/м2" }
            };
            viewBag.CoverPaperTypes = CoverPaperTypes;

            List<PaperItem> StickerPaperTypes = new List<PaperItem>()
            {
                new PaperItem() {Id = PaperFullType.SelfAdhensive, Name="самоклейка" },
            };
            viewBag.StickerPaperTypes = StickerPaperTypes;

            List<PrintingPressItem> IBPrintingPressTypes = new List<PrintingPressItem>()
            {
                new PrintingPressItem(){Id= PrintingPressType.Zirkon, Name = "Циркон"},
                new PrintingPressItem(){Id= PrintingPressType.Rapida, Name = "Рапида"}
            };
            viewBag.IB_PrintingPresses = IBPrintingPressTypes;

            List<PrintingPressItem> CoverPrintingPressTypes = new List<PrintingPressItem>()
            {
                new PrintingPressItem(){Id= PrintingPressType.Rapida, Name = "Рапида"},
                new PrintingPressItem(){Id= PrintingPressType.Shinohara, Name = "Шинохара"}
            };
            viewBag.Cover_PrintingPresses = CoverPrintingPressTypes;

            List<PrintingPressItem> StickerPrintingPressTypes = new List<PrintingPressItem>()
            {
                new PrintingPressItem(){Id= PrintingPressType.Shinohara, Name = "Шинохара"},
                new PrintingPressItem(){Id= PrintingPressType.Rapida, Name = "Рапида"}
            };
            viewBag.Sticker_PrintingPresses = StickerPrintingPressTypes;

        }
	}
}