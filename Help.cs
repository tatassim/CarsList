
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutCars
{
    
    public class Help
    {
        const string path = @"C:\Users\hp\Desktop\Новая папка\AboutCars\"; //ввести путь с константой
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


        public static List<Car> InputData() 
        {
            Console.WriteLine("Что вы хотите сделать? " +
                "\n1 - Ввести данные о машинах с консоли, " +
                "\n2 - Открыть файл");
            int response;
            int.TryParse(Console.ReadLine(), out response);
            switch (response)
            {
                case 1:
                    return InputDataFromConsole();
                case 2:
                    string name;
                    return ChooseFile(out name).LoadFromFile(path+name);
                default:
                    throw new Exception("Введены неверные данные");
            }
        }

        public static List<Car> InputDataFromConsole() 
        {
            int response;
            List<Car> list = new List<Car>();
            do
            {
                Console.WriteLine("Введите информацию о машине");
                Console.WriteLine();
                list.Add(SetCar());
                //добавление в лист отдельно от создания объекта

                Console.WriteLine("Если хотите добавить еще одну машину - нажмите любую клавишу, для отмены ввода нажмите 0");
                int.TryParse(Console.ReadLine(), out response);
            }
            while (response != 0);
            return list;
        }

        public static Car SetCar()
        { 
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
            Console.Write("Введите тип коробки передач");
            Console.WriteLine("Введите число 1-Автоматическая, 2 - Ручная, 3 - Смешанная ");
            transmitionKind transmition = StringToKind(Console.ReadLine());
            Console.ReadLine();

            Car tmp = new Car(brand, model, year, volume, run, transmition);
            return tmp;
        }

        public static Car EditCar(List <Car> list, int resp)
        {
            list.RemoveAt(resp);

            Console.WriteLine("Введите новые данные: ");
            Console.ReadLine();
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
            Console.Write("Введите тип коробки передач");
            Console.WriteLine("Введите число 1-Автоматическая, 2 - Ручная, 3 - Смешанная ");
            transmitionKind transmition = StringToKind(Console.ReadLine());
            Console.ReadLine();

            Car test = new Car(brand, model, year, volume, run, transmition);
            return test;
        }

        public static IFileManager ChooseFile(out string fName) 
        {
            Console.WriteLine("Введите имя файла: ");
            string responce = Console.ReadLine();
            fName = responce;
            if (File.Exists(path + fName))
            {
                return FileFactory.GetFile(Path.GetExtension(responce));
            }
            else
            {
                Console.WriteLine("Такого файла не существует!");
                return ChooseFile(out fName);
            }
                    
        }

        public static string KindToString(transmitionKind kind)
        {
            if (kind == transmitionKind.Automatic)
            {
                return "Автоматическая";
            }
            if (kind == transmitionKind.Mechanic)
            {
                return "Механическая";
            }
            if (kind == transmitionKind.Mixed)
            {
                return "Вариатор";
            }
            return "Неизвестно";
        }

        public static transmitionKind StringToKind(string kind)
        {
            int test;
            if (Int32.TryParse(kind, out test))
            {
                switch (test)
                {
                    case 1:
                        return transmitionKind.Automatic;
                    case 2:
                        return transmitionKind.Mechanic;
                    case 3:
                        return transmitionKind.Mixed;
                    default:
                        throw new Exception("Данные о таком типе коробке передач не найдены");
                }
            }
            else
            {
                throw new Exception("Введено не число!");
            }
        }
    }
}
