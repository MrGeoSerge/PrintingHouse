using PrintingHouse.Domain.Entities.PriceLists;
using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Interfaces;
using PrintingHouse.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintingHouse.Domain.Processes.BookBinding
{
	public abstract class Binding
	{
        protected IGetPathFolder getPathFolder;

        protected BindingPriceList priceList;
        
        protected IssueFormat issueFormat;
		protected int pagesNumber;
		protected int printRun;
        protected BindingType bindingType;

		public Binding(IssueFormat _issueFormat, int _pagesNumber, int _printRun, BindingType _bindingType)
		{
            issueFormat = _issueFormat;
			pagesNumber = _pagesNumber;
			printRun = _printRun;
            bindingType = _bindingType;

            priceList = GetPriceList();
		}

		public Binding(TaskToBind _taskToBind, IGetPathFolder _getPathFolder)
		{
            issueFormat = _taskToBind.Format;
			pagesNumber = _taskToBind.PagesNumber;
			printRun = _taskToBind.PrintRun;
            bindingType = _taskToBind.BindingType;

            getPathFolder = _getPathFolder;

            priceList = GetPriceList();
		}

        protected abstract BindingPriceList GetPriceList();

		public double CalcCostOfBinding()
		{
            if (this == null)
                return 0.0;




            BindingPriceListItem bindingPriceList = null;

            for (int i = 0; i < priceList.BindingPriceListItems.Count; i++)
            {
                if (priceList.BindingPriceListItems[i].StringIssueFormats.Contains(issueFormat.ToString()))
                {
                    bindingPriceList = priceList.BindingPriceListItems[i];
                }
            }


			const int share = 8;
			while (pagesNumber > 16)
			{
				if (bindingPriceList !=null && bindingPriceList.Prices.ContainsKey(pagesNumber))
				{
					return bindingPriceList.Prices[pagesNumber] * printRun;
				}
				pagesNumber -= share;
			}

			throw new IndexOutOfRangeException("не нашли подходящее количество страниц");
		}
	}
}
