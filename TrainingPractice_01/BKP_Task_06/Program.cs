using System;

namespace BKP_Task_06
{
    class Program
    {
        static void Main(string[] args)
        {
            // Выбранный пункт в меню.
            short menuAction;

            // Массивы.
            string[] fullNames = new string[0]; // Массив ФИО.
            string[] positions = new string[0]; // Массив должностей.


            while (true)
            {
                // Очищаем консольное окно.
                Console.Clear();

                // Выводим меню на экран.
                PrintMenu();

                // Выбор пункта меню.
                menuAction = Convert.ToInt16(Console.ReadLine());

                // Выполнение соответствующего действия.
                switch (menuAction)
                {
                    case 1:
                        AddDosier(ref fullNames, ref positions);
                        break;

                    case 2:
                        PrintDosiers(ref fullNames, ref positions);
                        break;

                    case 3:
                        DeleteDosier(ref fullNames, ref positions);
                        break;

                    case 4:
                        SearchByLastName(ref fullNames, ref positions);
                        break;

                    case 5:
                        System.Environment.Exit(0);
                        break;

                    default:
                        System.Environment.Exit(1);
                        break;
                }

                Console.WriteLine("Нажмите любую клавишу...");
                Console.ReadKey();
            }
        }

        static void PrintMenu()
        {
            Console.Write("Отдел кадров" +
                "\n1 - добавить досье" +
                "\n2 - вывести все досье" +
                "\n3 - удалить досье" +
                "\n4 - поиск по фамилии" +
                "\n5 - выход из программы" +
                "\n\nВыберите пункт меню: ");
        }

        // Функция добавления досье.
        static void AddDosier(ref string[] fullNames, ref string[] positions)
        {
            // Изменение размера массива.
            Array.Resize(ref fullNames, fullNames.Length + 1);
            Array.Resize(ref positions, positions.Length + 1);

            string fullName = "";

            Console.WriteLine("\nДобавление досье:" +
                "\n\nВведите фамилию: ");
            fullName += Console.ReadLine() + ' ';

            Console.WriteLine("Введите имя: ");
            fullName += Console.ReadLine() + ' ';

            Console.WriteLine("Введите отчество: ");
            fullName += Console.ReadLine();

            Console.WriteLine("Введите должность: ");
            positions[^1] = Console.ReadLine(); // ^1 = (array.Length - 1)
            fullNames[^1] = fullName;           // ^1 = (array.Length - 1)

            Console.WriteLine("Данные занесены успешно!!!");
        }

        // Функция вывода списка всех досье в консольное окно.
        static void PrintDosiers(ref string[] fullNames, ref string[] positions)
        {
            if (fullNames.Length <= 0)
            {
                Console.WriteLine("Отсутствуют какие-либо досье");
                return;
            }

            Console.WriteLine("Вывод всех досье");
            for (uint i = 0; i < fullNames.Length; i++)
            {
                Console.WriteLine(Convert.ToString(i + 1) + '\t' + fullNames[i] + '\t' + positions[i]);
            }
        }

        // Функция удаления определённого досье.
        static void DeleteDosier(ref string[] fullNames, ref string[] positions)
        {
            if (fullNames.Length <= 0)
            {
                Console.WriteLine("Отсутствуют какие-либо досье");
                return;
            }

            Console.WriteLine("Введите номер досье для удаления: ");
            int deleteID = Convert.ToInt32(Console.ReadLine());

            if (deleteID > fullNames.Length || deleteID < 1)
            {
                Console.WriteLine("Досье с таким номером не существует");
                return;
            }

            deleteID--;

            // Перемещаем в массивах элементы.
            // {1, 2, 3, 4, 5}, удаляем 2, -> {1, 3, 4, 5, 5}.
            Array.Copy(fullNames, deleteID + 1, fullNames, deleteID, fullNames.Length - deleteID - 1);
            Array.Copy(positions, deleteID + 1, positions, deleteID, positions.Length - deleteID - 1);

            // Изменяем размер массива, тем самым отсекая последний.
            // {1, 3, 4, 5, 5} -> {1, 3, 4, 5}.
            Array.Resize(ref fullNames, fullNames.Length - 1);
            Array.Resize(ref positions, positions.Length - 1);

            Console.WriteLine("Досье удалено успешно!!!");
        }

        // Функция поиска по фамилии.
        static void SearchByLastName(ref string[] fullNames, ref string[] positions)
        {
            if (fullNames.Length <= 0)
            {
                Console.WriteLine("Отсутствуют какие-либо досье");
                return;
            }

            Console.WriteLine("Введите фамилию для поиска: ");
            string fullName = Console.ReadLine();

            // Нумерация в списке.
            uint listIndex = 0;

            for (uint i = 0; i < fullNames.Length; i++)
            {
                if (fullNames[i].StartsWith(fullName))
                {
                    listIndex++;
                    Console.WriteLine(Convert.ToString(listIndex) + '\t' + fullNames[i] + '\t' + positions[i]);
                }
            }
            Console.WriteLine("Количество сотрудников с фамилией " + fullName + " - " + listIndex);
        }
    }
}
