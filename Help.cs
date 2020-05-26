
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutCars
{
    class Help
    {
        public static void PrintToConsole(List<Car> list) 
        {
            int i = 0;
            foreach (var item in list)
            {
                Console.Write(String.Format("{0} - ", i));
                Console.WriteLine(item.ToString());
                i++;
            }
            Console.WriteLine(String.Format("Количество записей о машинах : {0}", i));
            Console.ReadLine();
            Console.WriteLine();
        }

        public static List<Car> InputData() // Выбор источника ввода и ввод данных
        {
            Console.WriteLine("Выберите источник для ввода информации. 1 - консоль, 2 - файл");
            int response;
            int.TryParse(Console.ReadLine(), out response);
            switch (response)
            {
                case 1:
                    return InputDataFromConsole();
                case 2:
                    string name;
                    return ChooseFile(out name).LoadFromFile(name);
                default:
                    throw new Exception("Введены неверные данные");
            }
        }

        public static List<Car> InputDataFromConsole() //Ввод данных из консоли
        {
            int response;
            List<Car> list = new List<Car>();
            do
            {
                Console.WriteLine("Введите информацию о машине");
                Console.WriteLine();
                SetCar(list);
                Console.WriteLine("Если хотите добавить еще один тур - нажмите любую клавишу, для отмены ввода нажмите 0");
                int.TryParse(Console.ReadLine(), out response);
            }
            while (response != 0);
            return list;
        }

        public static void SetCar(List<Car> list) //Создание объекта Tour_Info
        {
            Console.WriteLine("Введите марку");
            string brand = Console.ReadLine();
            Console.WriteLine("Введите модель");
            string model = Console.ReadLine();
            Console.WriteLine("Введите год выпуска");
            int year;
            int.TryParse(Console.ReadLine(), out year);
            Console.WriteLine("Введите объем двигателя");
            double volume;
            double.TryParse(Console.ReadLine(), out volume);
            Console.WriteLine("Введите пробег");
            int run;
            int.TryParse(Console.ReadLine(), out run);
            Console.WriteLine("Введите тип коробки передач");
            string transmition = Console.ReadLine();
            Console.ReadLine();

            Car tmp = new Car(brand, model, year, volume, run, transmition); 
            list.Add(tmp);
        }

        public static IFileManager ChooseFile(out string fName) 
        {
            Console.WriteLine("Введите имя файла: ");
            string responce = Console.ReadLine();
            fName = responce;
            return FileFactory.GetFile(Path.GetExtension(responce));
        }
    }
}
