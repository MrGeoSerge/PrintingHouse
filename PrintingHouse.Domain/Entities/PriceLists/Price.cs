using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookProduction;
using BookProduction.BookComponents;
using BookProduction.Assembly;
using BookProduction.IssueParams;
using BookProduction.Paper;
using BookProduction.PriceLists;
using BookProduction.PrintingPresses;
using BookProduction.Tasks;
using BookProduction.TypographyManagement;

namespace BookProduction.PriceLists
{
    //прайс типографии реализован в виде словарей на разные услуги
    public static class Price
    {
        //перфорация
        static public Dictionary<string, double> Perforation;

        //упаковка
        static public Dictionary<string, double> Packaging;

        //ламинация
        static public Dictionary<string, double> Lamination;

        //-----------Переплет--------------
        //ПереплетСкоба для формата 60*90/16 и подобных
        static public Dictionary<string, double> SaddleStitching60_90_16;


        static Price()
        {
            #region Perforation
            Perforation = new Dictionary<string, double>();
            
            //При 1 типе переплета (скоба)
            //'Перфорация, грн до48 стр. офсет 65г,/м2 , грн. 0,059
            Perforation.Add("Staple_First_48pages_Block", 0.059);

            //'Перфорация, за каждые дополнительные 16 стр. офсет 65г,/м2 грн. 0,033
            Perforation.Add("Staple_additional_16pages_Block", 0.033);

            //При 3 типе переплета(клей)
            //'Перфорация за каждую тетрадь, грн 0,033
            Perforation.Add("Clue_forEach16pages_Block", 0.033);

            //При 1 типе переплета(скоба)
            //Упрощенная перфорация, грн до48 стр.офсет 65г,/ м2, грн. 0, 050
            Perforation.Add("Simplified_Staple_First_48pages_Block", 0.050);

            //Упрощенная перфорация, за каждые дополнительные 16 стр.офсет 65г,/ м2 грн. 0, 025
            Perforation.Add("Simplified_Staple_additional_16pages_Block", 0.025);

            //При 3 типе переплета(клей)
            //'Перфорация за каждую тетрадь, грн 0,025
            Perforation.Add("Simplified_Clue_forEach16pages_Block", 0.025);

            //количество страниц в тетради
            Perforation.Add("PagesInBlock", 16.0);

            #endregion

            #region Packaging
            //Упаковка
            Packaging = new Dictionary<string, double>();

            //Упаковка(книги на скобе) 0,012
            Packaging.Add("PriceForStaple", 0.012);

            //Упаковка(клей) 0,018
            Packaging.Add("PriceForClue", 0.018);

            #endregion

            #region Lamination
            //ламинация
            Lamination = new Dictionary<string, double>();

            //Ламинация  (с материалом), грн.глянцевая	матовая
            //А1                                    2,7     3,72
            //А2                                    1,35    1,86
            //А3                                    0,675   0,93
            //А4                                  0,34    0,465
            Lamination.Add("A1_Glossy", 2.7);
            Lamination.Add("A1_Matte", 3.72);
            Lamination.Add("A2_Glossy", 1.35);
            Lamination.Add("A2_Matte", 1.86);
            Lamination.Add("A3_Glossy", 0.675);
            Lamination.Add("A3_Matte", 0.93);
            Lamination.Add("A4_Glossy", 0.34);
            Lamination.Add("A4_Matte", 0.465);


            #endregion

  

        }

    }
}
