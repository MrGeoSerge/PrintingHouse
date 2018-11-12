using PrintingHouse.Domain.Entities.Reports;

namespace PrintingHouse.Domain.Abstract
{
	public interface IAssemblyDepartment
	{
		void MakeLamination();
		void MakePerforation();
		void MakeBinding();
		void MakePackaging();
		//void CalcTotalCostOfAssembly();
		AssemblyReport Report { get; }
	}
}
