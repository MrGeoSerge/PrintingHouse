using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintingHouse.Domain.BookAssembly
{
	public class AssemblyDepartment : IAssemblyDepartment
	{
		AssemblyReport assemblyReport;
		Book book;

		public AssemblyDepartment(Book book)
		{
			assemblyReport = new AssemblyReport();
			this.book = book;
		}

		public void MakeBinding()
		{
			TaskToBind taskToBind = new TaskToBind(book.BookParts[0].Format, book.BookParts[0].PagesNumber, book.PrintRun);
			Binding binding = null;
			switch (book.BookAssembly.BindingType)
			{
				case BindingType.PerfectBinding:
					binding = new Perfect(taskToBind);
					break;

				case BindingType.SaddleStitching:
					binding = new SaddleStitching(taskToBind);
					break;

				case BindingType.HardcoverBinding:
					binding = new HardCover(taskToBind);
					break;
				default:
					throw new Exception("неправильно указан переплет");
			}


			assemblyReport.AddCostOfBinding(binding.CalcCostOfBinding());
		}

		public void MakeLamination()
		{
			TaskToLamination taskToLamination = new TaskToLamination(book.BookParts[0].Format, book.BookAssembly.LaminationType, book.PrintRun);
			Lamination lamination = new Lamination(taskToLamination);
			assemblyReport.AddCostOfLamination(lamination.CalcCost());
		}

		public void MakePackaging()
		{
			TaskToPackage taskToPackage = new TaskToPackage(book.BookAssembly.BindingType, book.PrintRun);
			Packaging packaging = new Packaging(taskToPackage);
			assemblyReport.AddCostOfPackaging(packaging.CalcCostOfPackaging());
		}

		public void MakePerforation()
		{
			if (book.BookAssembly.Perforation != 0)
			{
				TaskToPerforation taskToPerforation = new TaskToPerforation(book.BookAssembly.Perforation, book.PrintRun,
						   book.BookAssembly.BindingType, book.BookParts[0].PagesNumber);
				Perforation perforation = new Perforation(taskToPerforation);
				assemblyReport.AddCostOfPerforation(perforation.CalcCostOfPerforation());
			}
			else
			{
				assemblyReport.AddCostOfPerforation(0);
			}
		}

		public void CalcTotalCostOfAssembly()
		{
			assemblyReport.CalcTotalCostOfAssembly();
		}

		public AssemblyReport GetReport()
		{
			return assemblyReport;
		}

	}

}
}
