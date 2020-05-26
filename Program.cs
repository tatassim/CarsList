using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutCars
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> list = Help.InputData();
            Help.PrintToConsole(list);
            int responce;
            do
            {
                Console.WriteLine("Что вы хотите сделать?" +
                    "\n1 - Добавить инфо о машине" +
                    "\n2 - Выполнить поиск машин по дате, пробегу и типу коробки передач" +
                    "\n3 - Сохранить все данные в файл" +
                    "\n4 - Удалить данные о машине" +
                    "\n0 - Завершение работы");
                int.TryParse(Console.ReadLine(), out responce);
                switch (responce)
                {
                    case 1:
                        list = list.Concat(Help.InputData()).ToList();
                        Help.PrintToConsole(list);
                        break;
                    case 2:
                        List<Car> sortedList = SortTours(list);
                        Help.PrintToConsole(sortedList);
                        break;
                    case 3:
                        string name;
                        IFileManager file = Help.ChooseFile(out name);
                        file.PrintToFile(list, name);
                        break;
                    case 4:
                        Console.ReadLine();
                        Console.WriteLine("Выберите какой элемент удалить, начиная с 0");
                        int resp;
                        int.TryParse(Console.ReadLine(), out resp);
                        list.RemoveAt(resp);
                        Console.WriteLine("Удаление завершено");
                        Console.ReadLine();
                        Help.PrintToConsole(list);
                        break;
                }
            }
            while (responce != 0);
        }

        static List<Car> SortTours(List<Car> list)
        {
            Console.WriteLine("Введите год выпуска");
            int year;
            int.TryParse(Console.ReadLine(), out year);
            Console.WriteLine();

            Console.WriteLine("Введите пробег");
            int run;
            int.TryParse(Console.ReadLine(), out run);
            Console.WriteLine();

            Console.WriteLine("Введите тип коробки передач");
            string transmition = Console.ReadLine();

            List<Car> sortedList = list.Where(cn => cn.Transmition == transmition.Trim(' ') && (cn.Year_create > year) && (cn.Run < run))
                                 .OrderBy(item => item.Volume)
                                 .ToList();
            return sortedList;
        }
    }
    }

