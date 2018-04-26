using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintingHouse.Domain.Paper
{
	public abstract class AbstractPaper
	{
		//вид бумаги: газетка и т. д.
		private PaperType kind;
		public PaperType Kind {
			get {
				return kind;
			}

			set {
				kind = value;
			}
		}

		//плотность бумаги г/м2
		int density;
		public int Density {
			get {
				return density;
			}

			set {
				density = value;
			}
		}


		//марка-производитель
		private string manufacturer;
		public string Manufacturer {
			get {
				return manufacturer;
			}

			set {
				manufacturer = value;
			}
		}

		//цена 
		double price;
		public double Price {
			get {
				return price;
			}

			set {
				price = value;
			}
		}

		public PaperUnit Unit;



		public override string ToString()
		{
			return Kind + "." + Density + " г/м2." +
				Manufacturer + ". Цена: " + Price + " грн.";
		}
	}
}
