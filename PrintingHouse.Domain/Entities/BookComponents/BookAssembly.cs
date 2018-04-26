using PrintingHouse.Domain.Specifications;

namespace PrintingHouse.Domain.Entities.BookComponents
{
	//сборка книги: переплет, упаковка, ламинация
	public class BookAssembly
	{
		public BindingType BindingType { private set; get; }
		public LaminationType LaminationType { private set; get; }
		public bool Packaging { private set; get; }
		public PerforationType Perforation { set; get; }

		public BookAssembly(BindingType _bindingType, LaminationType _laminationType, bool _packaging)
		{
			BindingType = _bindingType;
			LaminationType = _laminationType;
			Packaging = _packaging;
			Perforation = PerforationType.withoutPerforation;
		}
		public BookAssembly(BindingType _bindingType, LaminationType _laminationType, bool _packaging, PerforationType _perforation)
		{
			BindingType = _bindingType;
			LaminationType = _laminationType;
			Packaging = _packaging;
			Perforation = _perforation;
		}
	}

}
