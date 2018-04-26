using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintingHouse.Domain.Abstract
{
	interface IAssemblyDepartment
	{
		void MakeLamination();
		void MakePerforation();
		void MakeBinding();
		void MakePackaging();
		void CalcTotalCostOfAssembly();
		AssemblyReport GetReport();
	}
}
