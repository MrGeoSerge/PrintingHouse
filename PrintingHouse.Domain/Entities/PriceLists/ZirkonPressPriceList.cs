using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace PrintingHouse.Domain.Entities.PriceLists
{
	//PressPrice - класс, где хранятся данные из прайса
	//ZirkonForta660

	public static class ZirkonPressPriceList
    {
        //4 параметра определяют прайс на печатную машину
        //стоимость изготовления формы (не зависит от тиража)
        static public double Form { set; get; }

        //приладка 
        static public int Fitting { set; get; }

        //технужды в процентах зависят от цветности
        static public Dictionary<string, double> TechNeeds { set; get; }

        //стоимость оттисков зависит от цветности
        static public Dictionary<string, double> Impression { set; get; }


        static ZirkonPressPriceList()
        {

            TechNeeds = new Dictionary<string, double>();

            Impression = new Dictionary<string, double>();

            try
            {
                ReadFromFile();
            }
            catch
            {
                Debug.WriteLine("файл zirkon.dat не найден ");
                
                //если не читается из файла, берем значения по умолчанию
                Form = 90;

                Fitting = 400;

                TechNeeds.Add("1+1", 4.7);
                TechNeeds.Add("2+2", 1.2);//+1.2% на каждый доп. цвет

                Impression.Add("1+1", 0.0367);
                Impression.Add("2+2", 0.0174);//+0.0174 на каждый доп. цвет
                WriteToFile();
            }
        }

        public static void WriteToFile()
        {
            //Создаем файл
            FileStream file = File.OpenWrite("zirkon.dat");

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
            FileStream file = File.OpenRead("zirkon.dat");
            BinaryReader reader = new BinaryReader(file);

            Form = reader.ReadDouble();
            Fitting = reader.ReadInt32();

            TechNeeds.Clear();
            int techNeedsCount = reader.ReadInt32();
            for (int i = 0; i < techNeedsCount; i++)
            {
                TechNeeds.Add(reader.ReadString(), reader.ReadDouble());
            }

            Impression.Clear();
            int impressionCount = reader.ReadInt32();
            for (int i = 0; i < impressionCount; i++)
            {
                Impression.Add(reader.ReadString(), reader.ReadDouble());
            }
            reader.Close();
            file.Close();
        }

    }
















}
