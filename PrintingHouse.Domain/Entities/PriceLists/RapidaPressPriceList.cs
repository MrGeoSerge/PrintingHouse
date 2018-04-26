using System;
using System.Collections;
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
using System.IO;
using System.Diagnostics;

namespace BookProduction.PriceLists
{
    //PressPrice - класс, где хранятся данные из прайса
    public static class RapidaPressPriceList
    {
        //4 параметра определяют прайс на печатную машину
        //стоимость изготовления формы (не зависит от тиража)
        static public double Form { set; get; }

        //приладка (зависит от цветности) - и от тиража, то есть, если технужды > 0, приладка = 0
        static public Dictionary<string, double> Fitting { set; get; }

        //технужды в процентах зависят от тиража
        static public Dictionary<int, double> TechNeeds { set; get; }

        //стоимость оттисков зависит от тиража
        static public Dictionary<int, double> Impression { set; get; }


        static RapidaPressPriceList()
        {

            Fitting = new Dictionary<string, double>();

            TechNeeds = new Dictionary<int, double>();

            Impression = new Dictionary<int, double>();
            try
            {
                ReadFromFile();
            }
            catch(Exception ex)
            {
                Debug.WriteLine("файл rapida.dat не найден ");
                Debug.WriteLine(ex);

                Form = 108.0;

                Fitting.Add("4+0", 300);
                Fitting.Add("4+1", 300);
                Fitting.Add("2+2", 300);
                Fitting.Add("4+2", 350);
                Fitting.Add("4+4", 350);

                TechNeeds.Add(2999, 0);
                TechNeeds.Add(Int32.MaxValue, 8.0);

                Impression.Add(999, 0.132);
                Impression.Add(2999, 0.059);
                Impression.Add(4999, 0.050);
                Impression.Add(9999, 0.037);
                Impression.Add(Int32.MaxValue, 0.037);
            }

        }

        public static void WriteToFile()
        {
            FileStream file = File.OpenWrite("rapida.dat");
            BinaryWriter writer = new BinaryWriter(file);

            writer.Write(Form);

            writer.Write(Fitting.Count);
            foreach (var item in Fitting)
            {
                writer.Write(item.Key.ToString());
                writer.Write(item.Value);
            }

            writer.Write(TechNeeds.Count);
            foreach (var item in TechNeeds)
            {
                writer.Write(item.Key);
                writer.Write(item.Value);
            }

            writer.Write(Impression.Count);
            foreach (var item in Impression)
            {
                writer.Write(item.Key);
                writer.Write(item.Value);
            }

            writer.Close();
            file.Close();
        }

        public static void ReadFromFile()
        {
            FileStream file = File.OpenRead("rapida.dat");
            BinaryReader reader = new BinaryReader(file);

            Form = reader.ReadDouble();

            Fitting.Clear();
            int fittingCount = reader.ReadInt32();
            for (int i = 0; i < fittingCount; i++)
            {
                Fitting.Add(reader.ReadString(), reader.ReadDouble());
            }

            TechNeeds.Clear();
            int techNeedsCount = reader.ReadInt32();
            for (int i = 0; i < techNeedsCount; i++)
            {
                TechNeeds.Add(reader.ReadInt32(), reader.ReadDouble());
            }

            Impression.Clear();
            int impressionCount = reader.ReadInt32();
            for (int i = 0; i < impressionCount; i++)
            {
                Impression.Add(reader.ReadInt32(), reader.ReadDouble());
            }

            reader.Close();
            file.Close();
        }
    }
















}
