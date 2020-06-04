using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutCars
{
    class TextFile:IFileManager
    {
        public List<Car> LoadFromFile(string fileName)
        { 
            using (StreamReader sr = new StreamReader(fileName, System.Text.Encoding.UTF8))
            {
                List<Car> list = new List<Car>();
                while (sr.Peek() > -1)
                {
                    string brand = sr.ReadLine(); 
                    string model = sr?.ReadLine();
                    int year;
                    int.TryParse(sr?.ReadLine(), out year);
                    double volume;
                    double.TryParse(sr?.ReadLine(), out volume);
                    int run;
                    int.TryParse(sr?.ReadLine(), out run);
                    string transmition = sr?.ReadLine();
                    sr?.ReadLine();
                    Car tmp = new Car(brand, model, year, volume, run, transmition);
                    list.Add(tmp);
                }
                sr.Close();
                return list;
            }
        }

        public void PrintToFile(List<Car> list, string fileName)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName, false, System.Text.Encoding.UTF8))
                {
                    foreach (var item in list)
                    {
                        PrintToSW(item, sw);
                    } 
                    sw.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void PrintToSW(Car test, StreamWriter sw)
        {
            sw.WriteLine(test.Brand);
            sw.WriteLine(test.Model);
            sw.WriteLine(test.Year_create.ToString());
            sw.WriteLine(test.Volume.ToString());
            sw.WriteLine(test.Run.ToString());
            sw.WriteLine(test.Transmition);
            sw.WriteLine();
        }

    }
}

