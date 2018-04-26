using BookProduction.Tasks;
using PrintingHouse.Domain.IssueParams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintingHouse.Domain.Processes.BookBinding
{
	//клеевой переплет
	public class Perfect : Binding
	{

		public Perfect(TaskToBind _taskToBind)
			: base(_taskToBind.PagesNumber, _taskToBind.PrintRun)
		{
			price = new Dictionary<int, double>();
			IssueFormat _issueFormat = _taskToBind.Format;

			if (_issueFormat.ToString() == "84*108/32" || _issueFormat.ToString() == "60*90/16" ||
				_issueFormat.ToString() == "60*84/16" || _issueFormat.ToString() == "70*90/16" ||
				_issueFormat.ToString() == "70*100/16")
			{
				price.Add(96, 0.40);
				price.Add(112, 0.48);
				price.Add(128, 0.51);
				price.Add(144, 0.55);
				price.Add(160, 0.58);
				price.Add(176, 0.63);
				price.Add(192, 0.66);
				price.Add(200, 0.67);
				price.Add(208, 0.69);
				price.Add(224, 0.72);
				price.Add(232, 0.73);
				price.Add(240, 0.74);
				price.Add(256, 0.80);
				price.Add(272, 0.83);
				price.Add(288, 0.85);
				price.Add(304, 0.88);
				price.Add(320, 0.92);
				price.Add(336, 0.96);
				price.Add(352, 1.07);
				price.Add(368, 1.11);
				price.Add(384, 1.16);
				price.Add(392, 1.17);
				price.Add(400, 1.18);
				price.Add(416, 1.24);
				price.Add(432, 1.28);
				price.Add(464, 1.38);
				price.Add(496, 1.46);
				price.Add(528, 1.54);
				price.Add(544, 1.57);
				price.Add(560, 1.62);
				price.Add(640, 1.84);
				price.Add(732, 2.52);
			}

			else if (_issueFormat.ToString() == "84*108/16" || _issueFormat.ToString() == "60*90/8" ||
				_issueFormat.ToString() == "60*84/8" || _issueFormat.ToString() == "70*90/8" ||
				_issueFormat.ToString() == "70*100/8")
			{
				price.Add(96, 0.48);
				price.Add(112, 0.58);
				price.Add(128, 0.65);
				price.Add(144, 0.69);
				price.Add(160, 0.73);
				price.Add(176, 0.80);
				price.Add(192, 0.83);
				price.Add(200, 0.84);
				price.Add(208, 0.87);
				price.Add(224, 0.89);
				price.Add(232, 0.91);
				price.Add(240, 0.95);
				price.Add(256, 0.99);
				price.Add(272, 1.02);
				price.Add(288, 1.07);
				price.Add(304, 1.11);
				price.Add(320, 1.16);
				price.Add(336, 1.18);
				price.Add(352, 1.33);
				price.Add(368, 1.39);
				price.Add(384, 1.44);
				price.Add(392, 1.47);
				price.Add(400, 1.49);
				price.Add(416, 1.54);
				price.Add(432, 1.58);
				price.Add(464, 1.71);
				price.Add(496, 1.82);
				price.Add(528, 1.91);
				price.Add(544, 1.98);
				price.Add(560, 2.02);
				price.Add(640, 2.31);
				price.Add(732, 3.15);
			}
			else throw new ArgumentOutOfRangeException("wrong format for perfect binding");

		}


	}
}
