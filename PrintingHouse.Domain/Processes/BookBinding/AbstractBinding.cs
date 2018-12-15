using PrintingHouse.Domain.Entities.PriceLists;
using PrintingHouse.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintingHouse.Domain.Processes.BookBinding
{
	//абстрактный класс Переплет. 
	//От него будут наследоваться конкретные типы переплета
	public class Binding
	{
		//словарь для хранения данных прайса
		protected PerfectBindingPriceList price;
        
		//количество страниц
		protected int pagesNumber;
		protected int printRun;
        protected IssueFormat issueFormat;

		public Binding(int _pagesNumber, int _printRun, IssueFormat _issueFormat)
		{
			pagesNumber = _pagesNumber;
			printRun = _printRun;
            issueFormat = _issueFormat;
            GetPrice();
		}

        private void GetPrice(BindingType bindingType = BindingType.PerfectBinding)
        {
            var priceListHelper = new PriceListHelper<PerfectBindingPriceList>();


            price = priceListHelper.ReadFromFile("PerfectBindingPriceList");
        }

		public double CalcCostOfBinding()
		{
            if (this == null)
                return 0.0;


            BindingPriceList bindingPriceList = null;

            for (int i = 0; i < price.BindingPriceLists.Count; i++)
            {
                if (price.BindingPriceLists[i].StringIssueFormats.Contains(issueFormat.ToString()))
                {
                    bindingPriceList = price.BindingPriceLists[i];
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
