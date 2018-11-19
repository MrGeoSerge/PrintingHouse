using PrintingHouse.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintingHouse.Domain.Entities.Paper
{
    public static class PaperProvider
    {
        public static AbstractPaper GetPaper(PaperFullType paperFullType)
        {
            AbstractPaper paper;

            switch (paperFullType)
            {
                //на внутренний блок
                case PaperFullType.Newsprint_45:
                    paper = new PaperInKg(PaperType.Newsprint, 43, 23.69, "Змиев", 60);
                    break;
                case PaperFullType.Offset_60:
                    paper = new PaperInKg(PaperType.Offset, 60, 32.0, "Коростышев", 59.4);
                    break;
                case PaperFullType.Offset_70:
                    paper = new PaperInKg(PaperType.Offset, 70, 27.4598, "Змиев", 54);
                    break;
                case PaperFullType.Offset_80:
                    paper = new PaperInSheets(PaperType.Offset, 80, 1.39246, "Котлас", 60, 90);
                    break;

                //на обложку
                case PaperFullType.FoldingBoxboard_230:
                    paper = new PaperInSheets(PaperType.FoldingBoxboard, 230, 3.68, "Умка", 64, 90);
                    break;
                case PaperFullType.CardboardAliaska_230:
                    paper = new PaperInSheets(PaperType.CardboardAliaska, 230, 5.3, "Unknown", 70, 100);
                    break;
                case PaperFullType.CardboardСellulose_215:
                    paper = new PaperInSheets(PaperType.CardboardСellulose, 300, 1.6068, "Unknown", 47, 55); //правильно 47.2 вместо 47
                    break;
                case PaperFullType.CoatedPaper_300:
                    paper = new PaperInSheets(PaperType.CoatedPaper, 300, 5.6444, "Unknown", 64, 90);
                    break;

                //наклейки
                case PaperFullType.SelfAdhensive:
                    paper = new PaperInSheets(PaperType.SelfAdhensivePaper, 80, 3.61, "Самоклейка 43х61 пл.80", 43, 61);
                    break;

                default:
                    throw new ArgumentOutOfRangeException("нераспознанная бумага");

            }

            return paper;
        }

    }
}
