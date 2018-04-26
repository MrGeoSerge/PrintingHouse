using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace PrintingHouse.Domain.Entities.PriceLists
{
	//PressPrice - класс, где хранятся данные из прайса
	//ZirkonForta660
	public static class CorosetPressPriceList
    {
        //4 параметра определяют прайс на печатную машину
        //стоимость изготовления формы (не зависит от тиража)
        static public double Form { set; get; }

        //приладка (зависит от цветности) - и от тиража, то есть, если технужды > 0, приладка = 0
        static public int Fitting { set; get; }

        //технужды в процентах зависят от цветности
        static public Dictionary<string, double> TechNeeds { set; get; }

        //стоимость оттисков зависит от цветности
        static public Dictionary<string, double> Impression { set; get; }


        static CorosetPressPriceList()
        {

            TechNeeds = new Dictionary<string, double>();

            Impression = new Dictionary<string, double>();

            try
            {
                ReadFromFile();
            }
            catch
            {
                Debug.WriteLine("файл coroset.dat не найден");
                Form = 126;

                Fitting = 400;

                TechNeeds.Add("1+1", 4.7);
                TechNeeds.Add("2+2", 1.2);//+1.2% на каждый доп. цвет

                Impression.Add("1+1", 0.0735);
                Impression.Add("2+2", 0.035);//+0.0174 на каждый доп. цвет
                WriteToFile();

            }

        }

        public static void WriteToFile()
        {
            //Создаем файл
            FileStream file = File.OpenWrite("coroset.dat");

            //Сообщаем с файлом БинариРайтер
            BinaryWriter writer = new BinaryWriter(file);

            //записываем данные в файл
            writer.Write(Form);
            writer.Write(Fitting);

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
            FileStream file = File.OpenRead("coroset.dat");
            BinaryReader reader = new BinaryReader(file);

            Form = reader.ReadDouble();
            Fitting = reader.ReadInt32();

            TechNeeds.Clear();
            int TechNeedsCount = reader.ReadInt32();
            for (int i = 0; i < TechNeedsCount; i++)
            {
                TechNeeds.Add(reader.ReadString(), reader.ReadDouble());
            }

            Impression.Clear();
            int ImpressionCount = reader.ReadInt32();
            for (int i = 0; i < ImpressionCount; i++)
            {
                Impression.Add(reader.ReadString(), reader.ReadDouble());
            }
            reader.Close();
            file.Close();
        }


    }
















}
