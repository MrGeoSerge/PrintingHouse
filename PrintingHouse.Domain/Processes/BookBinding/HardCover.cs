//using PrintingHouse.Domain.Entities.Tasks;
//using PrintingHouse.Domain.Specifications;
//using System.Collections.Generic;

//namespace PrintingHouse.Domain.Processes.BookBinding
//{
//	public class HardCover : Binding
//	{
//		public HardCover(TaskToBind _taskToBind)
//			: base(_taskToBind.PagesNumber, _taskToBind.PrintRun)
//		{
//			price = new Dictionary<int, double>();
//			IssueFormat _issueFormat = _taskToBind.Format;
//			if (_issueFormat.ToString() == "84*108/32" || _issueFormat.ToString() == "60*90/16" ||
//				 _issueFormat.ToString() == "60*84/16" || _issueFormat.ToString() == "70*90/16" ||
//				 _issueFormat.ToString() == "70*100/16")
//			{
//				price.Add(128, 1.68);
//				price.Add(160, 1.82);
//				price.Add(192, 1.98);
//				price.Add(224, 2.12);
//				price.Add(256, 2.28);
//				price.Add(288, 2.42);
//				price.Add(320, 2.59);
//				price.Add(352, 2.72);
//				price.Add(384, 2.89);
//				price.Add(416, 3.04);
//				price.Add(448, 3.19);
//				price.Add(480, 3.34);
//				price.Add(512, 3.49);
//				price.Add(544, 3.64);
//				price.Add(576, 3.80);
//				price.Add(608, 3.95);
//				price.Add(640, 4.10);
//				price.Add(672, 4.25);
//				price.Add(704, 4.40);
//				price.Add(736, 4.55);
//				price.Add(768, 4.70);
//				price.Add(800, 4.85);
//				price.Add(832, 4.96);
//				price.Add(864, 5.16);
//				price.Add(896, 5.31);
//				price.Add(928, 5.46);
//				price.Add(960, 5.61);
//				price.Add(992, 5.76);
//				price.Add(1024, 5.93);
//				price.Add(1056, 6.06);
//				price.Add(1088, 6.23);
//			}
//			else if (_issueFormat.ToString() == "84*108/16" || _issueFormat.ToString() == "60*90/8" ||
//			 _issueFormat.ToString() == "60*84/8" || _issueFormat.ToString() == "70*90/8" ||
//			 _issueFormat.ToString() == "70*100/8")
//			{

//				price.Add(128, 1.98);
//				price.Add(160, 2.12);
//				price.Add(192, 2.28);
//				price.Add(224, 2.42);
//				price.Add(256, 2.59);
//				price.Add(288, 2.72);
//				price.Add(320, 2.89);
//				price.Add(352, 3.04);
//				price.Add(384, 3.19);
//				price.Add(416, 3.34);
//				price.Add(448, 3.49);
//				price.Add(480, 3.64);
//				price.Add(512, 3.80);
//				price.Add(544, 3.95);
//				price.Add(576, 4.10);
//				price.Add(608, 4.25);
//				price.Add(640, 4.40);
//				price.Add(672, 4.55);
//				price.Add(704, 4.70);
//				price.Add(736, 4.85);
//				price.Add(768, 5.01);
//				price.Add(800, 5.16);
//				price.Add(832, 5.31);
//				price.Add(864, 5.46);
//				price.Add(896, 5.61);
//				price.Add(928, 5.76);
//				price.Add(960, 5.93);
//				price.Add(992, 6.06);
//				price.Add(1024, 6.23);
//				price.Add(1056, 6.37);
//				price.Add(1088, 6.53);
//			}
//		}
//	}
//}
