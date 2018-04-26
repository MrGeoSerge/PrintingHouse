using PrintingHouse.Domain.Entities.Tasks;
using PrintingHouse.Domain.Specifications;
using System;
using System.Collections.Generic;

namespace PrintingHouse.Domain.Processes.BookBinding
{
	public class SaddleStitching : Binding
	{
		public SaddleStitching(TaskToBind _taskToBind)
			: base(_taskToBind.PagesNumber, _taskToBind.PrintRun)
		{
			price = new Dictionary<int, double>();
			IssueFormat _issueFormat = _taskToBind.Format;

			if (_issueFormat.ToString() == "84*108/32" || _issueFormat.ToString() == "60*90/16" ||
				_issueFormat.ToString() == "60*84/16" || _issueFormat.ToString() == "70*90/16" ||
				_issueFormat.ToString() == "70*100/16")
			{
				price.Add(32, 0.106);
				price.Add(40, 0.117);
				price.Add(48, 0.131);
				price.Add(56, 0.131);
				price.Add(64, 0.131);
				price.Add(72, 0.144);
				price.Add(80, 0.144);
				price.Add(88, 0.144);
				price.Add(96, 0.158);
				price.Add(104, 0.158);
				price.Add(112, 0.182);
				price.Add(120, 0.182);
				price.Add(128, 0.209);
				price.Add(136, 0.209);
				price.Add(144, 0.209);
				price.Add(152, 0.209);
				price.Add(160, 0.223);
			}
			else if (_issueFormat.ToString() == "84*108/16" || _issueFormat.ToString() == "60*90/8" ||
			   _issueFormat.ToString() == "60*84/8" || _issueFormat.ToString() == "70*90/8" ||
			   _issueFormat.ToString() == "70*100/8")
			{

				price.Add(32, 0.124);
				price.Add(40, 0.141);
				price.Add(48, 0.153);
				price.Add(64, 0.153);
				price.Add(72, 0.171);
				price.Add(80, 0.171);
				price.Add(96, 0.186);
				price.Add(112, 0.218);
				price.Add(128, 0.248);
				price.Add(144, 0.248);
				price.Add(160, 0.264);

			}
			else throw new ArgumentOutOfRangeException("wrong format for saddle stitching");
		}

	}
}
