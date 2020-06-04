using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutCars
{
   
    class Program
    {
        const string path = @"C:\Users\hp\Desktop\Новая папка\AboutCars\";
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
                    "\n4 - Редактировать данные о машине  " +
                    "\n5 - Удалить данные о машине  " +
                    "\n0 - Завершение работы");
                int.TryParse(Console.ReadLine(), out responce);
                switch (responce)
                {
                    case 1:
                        list = list.Concat(Help.InputData()).ToList();
                        Help.PrintToConsole(list);
                        break;
                    case 2:
                        Console.WriteLine("Будет выведена информация о машинах, которые были " +
                            "\nвыпущены после определенной даты, имеют пробег меньше заданного и" +
                            "\nзаданный тип коробки передач, упорядочив по объему двигателя");
                        Console.ReadLine();
                        List<Car> sortedList = SortCars(list);
                        Help.PrintToConsole(sortedList);
                        break;
                    case 3:
                        string name;
                        IFileManager file = Help.ChooseFile(out name);
                        file.PrintToFile(list, path+ name);
                        Console.WriteLine("Запись выполнена");
                        break;
                    case 4:
                        Console.ReadLine();
                        Console.WriteLine("Выберите какой элемент вы хотите редактрировать, начиная с 0");
                        int edIndex;
                        int.TryParse(Console.ReadLine(), out edIndex);
                        list.Insert(edIndex, Help.EditCar(list, edIndex));
                        Console.WriteLine("Редактирование завершено");
                        Console.ReadLine();
                        Help.PrintToConsole(list);
                        break;

                    case 5:
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

        static List<Car> SortCars(List<Car> list)
        {
            Console.WriteLine("Введите год выпуска");
            int year;
            int.TryParse(Console.ReadLine(), out year);
            Console.WriteLine();

            Console.WriteLine("Введите пробег");
            int run;
            int.TryParse(Console.ReadLine(), out run);
            Console.WriteLine();

            Console.Write("Введите тип коробки передач");
            Console.WriteLine("Введите число 1-Автоматическая, 2 - Ручная, 3 - Смешанная ");
            transmitionKind transmition = Help.StringToKind(Console.ReadLine());

            List<Car> sortedList = list.Where(cn => cn.Transmition == transmition && (cn.Year_create > year) && (cn.Run < run))
                                 .OrderBy(item => item.Volume)
                                 .ToList();
            return sortedList;
        }
    }
    }

