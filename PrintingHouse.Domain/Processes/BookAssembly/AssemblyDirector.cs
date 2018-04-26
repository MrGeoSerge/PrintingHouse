using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintingHouse.Domain.Processes.BookAssembly
{
	public class AssemblyDirector
	{
		IAssemblyDepartment assemblyDepartment;

		public AssemblyDirector(IAssemblyDepartment assemblyDepartment)
		{
			this.assemblyDepartment = assemblyDepartment;
		}

		public void Assemble()
		{
			assemblyDepartment.MakeLamination();
			assemblyDepartment.MakePerforation();
			assemblyDepartment.MakeBinding();
			assemblyDepartment.MakePackaging();
			assemblyDepartment.CalcTotalCostOfAssembly();
		}
	}
}
