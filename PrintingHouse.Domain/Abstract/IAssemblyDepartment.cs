using PrintingHouse.Domain.Entities.Reports;

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
