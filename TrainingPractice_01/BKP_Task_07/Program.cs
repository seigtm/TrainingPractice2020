using System;

namespace BKP_Task_07
{
    class Program
    {
        // Функция заполнения массива случайными значениями.
        static void RandomFill(int[] array)
        {
            Random random = new Random();

            for (int i = 0; i < array.Length; ++i)
            {
                array[i] = random.Next();
            }
        }

        // Функция вывода массива в консольное окно программы.
        static void Print(int[] array)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                Console.WriteLine(i + " : " + array[i]);
            }
        }

        // Функция перемешивания элементов в массиве.
        static int[] Shuffle(int[] array)
        {
            Random random = new Random();

            // temporaryElement - временное хранилище значения перемещаемого элемента.
            // randomPosition - случайно вычисляемый индекс подстановки второго перемещаемого элемента.
            int temporaryElement, randomPosition;

            // Идём в цикле по массиву от его конца до начала.
            for (int i = array.Length - 1; i > 0; i--)
            {
                randomPosition = random.Next(i);
                temporaryElement = array[i];
                array[i] = array[randomPosition];
                array[randomPosition] = temporaryElement;
            }

            // Возвращаем перемешанный массив.
            return array;
        }

        // Главная функция программы.
        static void Main(string[] args)
        {
            // Ввод размерности массива.
            Console.WriteLine("Введите размерность массива!");
            uint arraySize = Convert.ToUInt32(Console.ReadLine());

            // Заполняем массив случайными числами.
            int[] array = new int[arraySize]; // Первоначальный массив.
            RandomFill(array);

            // Вывод исходного массива до перемешивания.
            Console.WriteLine("\nИсходный массив: ");
            Print(array);

            // Перемешивание элементов массива.
            Shuffle(array);

            // Вывод перемешанного массива.
            Console.WriteLine("\nПеремешанный массив: ");
            Print(array);

            // Чтобы программа не завершалась сразу после выполнения алгоритма.
            Console.ReadKey();
        }
    }
}
