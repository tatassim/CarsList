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
        string path = @"C:\Users\hp\Desktop\Новая папка\AboutCars\"; // !!!!!!!!!!!!!!!!!!!!!!
        public List<Car> LoadFromFile(string fileName)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path + fileName, System.Text.Encoding.UTF8 ))
                {
                    List<Car> list = new List<Car>();
                    while (sr.Peek() > -1)
                    {
                        string brand = sr?.ReadLine();
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

            catch
            {
                throw new Exception("Такого файла не существует"); //жесткое исключение. Делал для проверки файла на существование, но для этого есть FileExists
            }

        }

        public void PrintToFile(List<Car> list, string fileName)
        {
            string writePath = @"C:\Users\hp\Desktop\Новая папка\AboutCars\";
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath + fileName, false, System.Text.Encoding.UTF8))
                {
                    foreach (var item in list)
                    {
                        sw.WriteLine(item.Brand);
                        sw.WriteLine(item.Model);
                        sw.WriteLine(item.Year_create.ToString());
                        sw.WriteLine(item.Volume.ToString()); //сделать отдельную функцию вывода данных
                        sw.WriteLine(item.Run.ToString());
                        sw.WriteLine(item.Transmition);
                        sw.WriteLine();
                    }
                    sw.Close();
                }
                Console.WriteLine("Запись выполнена"); //обращения к консоли не должно быть отсюда
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

