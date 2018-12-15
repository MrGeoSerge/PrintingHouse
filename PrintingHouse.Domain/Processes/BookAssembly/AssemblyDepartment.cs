using PrintingHouse.Domain.Abstract;
using PrintingHouse.Domain.Entities;
using PrintingHouse.Domain.Entities.Reports;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Processes.BookBinding;
using PrintingHouse.Domain.Specifications;
using System;

namespace PrintingHouse.Domain.Processes.BookAssembly
{
	public class AssemblyDepartment : IAssemblyDepartment
	{
		Book book;
		public AssemblyReport Report { get; }

		public AssemblyDepartment(Book book)
		{
			Report = new AssemblyReport();
			this.book = book;
		}

		public void MakeBinding()
		{
			TaskToBind taskToBind = new TaskToBind(book.BookParts[0].Format, book.BookParts[0].PagesNumber, book.PrintRun);
			Binding binding = new Binding(taskToBind.PagesNumber, taskToBind.PrintRun, book.BookParts[0].Format);
			//switch (book.BookAssembly.BindingType)
			//{
			//	case BindingType.PerfectBinding:
			//		binding = new Perfect(taskToBind);
			//		break;

			//	case BindingType.SaddleStitching:
			//		binding = new SaddleStitching(taskToBind);
			//		break;

			//	case BindingType.HardcoverBinding:
			//		binding = new HardCover(taskToBind);
			//		break;
   //             case BindingType.WithoutBinding:
   //                 binding = null;
   //                 break;
			//	default:
			//		throw new Exception("неправильно указан переплет");
			//}

            if (binding == null)
                Report.AddCostOfBinding(0.0);
            else
			    Report.AddCostOfBinding(binding.CalcCostOfBinding());
		}

		public void MakeLamination()
		{
            if(book.BookAssembly.LaminationType != LaminationType.withoutLamination)
            {
			    TaskToLamination taskToLamination = new TaskToLamination(book.BookParts[0].Format, book.BookAssembly.LaminationType, book.PrintRun);
			    Lamination lamination = new Lamination(taskToLamination);
			    Report.AddCostOfLamination(lamination.CalcCost());
            }
            else
            {
			    Report.AddCostOfLamination(0.0);
            }
		}

		public void MakePackaging()
		{
			TaskToPackage taskToPackage = new TaskToPackage(book.BookAssembly.BindingType, book.PrintRun);
			Packaging packaging = new Packaging(taskToPackage);
			Report.AddCostOfPackaging(packaging.CalcCostOfPackaging());
		}

		public void MakePerforation()
		{
			if (book.BookAssembly.Perforation != 0)
			{
				TaskToPerforation taskToPerforation = new TaskToPerforation(book.BookAssembly.Perforation, book.PrintRun,
							book.BookAssembly.BindingType, book.BookParts[0].PagesNumber);
				Perforation perforation = new Perforation(taskToPerforation);
				Report.AddCostOfPerforation(perforation.CalcCostOfPerforation());
			}
			else
			{
				Report.AddCostOfPerforation(0);
			}
		}

		//public void CalcTotalCostOfAssembly()
		//{
		//	Report.TotalCostOfAssembly;
		//}
	}
}

