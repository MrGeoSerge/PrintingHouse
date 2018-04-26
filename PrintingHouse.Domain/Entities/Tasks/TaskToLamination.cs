using System;
using PrintingHouse.Domain.Specifications;

namespace PrintingHouse.Domain.Entities.Tasks
{

	public class TaskToLamination
    {
        public PaperFormat LaminationFormat { set; get; }
        public int PrintRun { set; get; }

        public LaminationType LaminationType { set; get; }

        public TaskToLamination(IssueFormat _issueFormat, LaminationType _laminationType, int _printRun)
        {
            string issueFormat = _issueFormat.ToString();

            switch (issueFormat)
            {
                case "60*90/16":
                case "60*84/16":
                case "70*90/16":
                case "70*100/16":
                case "84*108/32":
                    LaminationFormat = PaperFormat.A4;
                    break;
                case "60*90/8":
                case "60*84/8":
                case "70*90/8":
                case "70*100/8":
                case "84*108/16":
                    LaminationFormat = PaperFormat.A3;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("для этого формата не прописана ламинация");
            }

            LaminationType = _laminationType;
            PrintRun = _printRun;
        }
    }
}
