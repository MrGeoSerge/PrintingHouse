using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintingHouse.Domain.Processes.BookBinding
{
	//абстрактный класс Переплет. 
	//От него будут наследоваться конкретные типы переплета
	public abstract class Binding
	{
		//словарь для хранения данных прайса
		protected Dictionary<int, double> price;

		//количество страниц
		protected int pagesNumber;
		protected int printRun;

		public Binding(int _pagesNumber, int _printRun)
		{
			pagesNumber = _pagesNumber;
			printRun = _printRun;
		}

		public double CalcCostOfBinding()
		{
			const int share = 8;
			double costValue;
			while (pagesNumber < 800)
			{
				if (price.TryGetValue(pagesNumber, out costValue))
				{
					return costValue * printRun;
				}
				pagesNumber += share;
			}

			throw new IndexOutOfRangeException("не нашли подходящее количество страниц");

		}

	}
}
