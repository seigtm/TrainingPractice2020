using System;
using System.IO;

public class Labyrinth
{
    // public:
    // Конструктор с параметрами.
    public Labyrinth(string mapName)
    {
        // Считываем мапу из файла.
        ReadMap(mapName);
        // Задаём изначальное ХП = 10.
        m_HP = 10;
    }

    public bool Init()
    {
        // Рисуем мапу и ХП-бар в начале каждого хода.
        DrawMap();
        DrawBar();

        // Если у персонажа закончилось ХП.
        if (m_HP <= 0)
        {
            return false;
        }

        // Если персонаж встал на символ % (конца лабиринта).
        if (m_map[m_performerY, m_performerX] == '%')
        {
            return false;
        }

        // Выполняем передвижение персонажа.
        Move();

        // TODO: Рандомно двигаем врагов. (возможно не нужно, буду делать ловушки)

        // Чистим консоль после каждого хода.
        Console.Clear();

        return true;
    }


    //private:
    // Метод чтения мапы из файла.
    private void ReadMap(string mapName)
    {
        m_performerX = 0;
        m_performerY = 0;

        string[] newFile = File.ReadAllLines($"maps/{mapName}.txt");
        m_map = new char[newFile.Length, newFile[0].Length];

        for (int i = 0; i < m_map.GetLength(0); i++)
        {
            for (int j = 0; j < m_map.GetLength(1); j++)
            {
                m_map[i, j] = newFile[i][j];

                // ■ - символ персонажа.
                if (m_map[i, j] == '■')
                {
                    // Задаём начальные позиции.
                    m_performerX = i;
                    m_performerY = j;
                }
            }
        }
    }

    // Метод рисования мапы в консоли.
    private void DrawMap()
    {
        for (int i = 0; i < m_map.GetLength(0); i++)
        {
            for (int j = 0; j < m_map.GetLength(1); j++)
            {
                Console.Write(m_map[i, j]);
            }
            Console.WriteLine();
        }
    }

    // Метод рисования ХП-бара в консоли.
    private void DrawBar()
    {
        // >>>HP BAR<<<
        // [####______]
        Console.Write(">>>HP BAR<<<" +
            "\n[");

        for (byte i = 0; i < m_HP; i++)
        {
            Console.Write('#');
        }

        Console.WriteLine(']');
    }

    // Проверка на нахождение персонажа на выходе.
    private void CheckExit(int Y, int X)
    {
        if (m_map[Y, X] == '%')
        {
            Console.WriteLine(" >>> ВЫ ПОБЕДИЛИ! <<<");
            System.Environment.Exit(0);
        }
    }

    // Обработка нажатия клавиш.
    private void Move()
    {
        ConsoleKeyInfo key;

        key = Console.ReadKey();
        switch (key.Key)
        {
            case ConsoleKey.DownArrow:
                // Если персонаж двигается не в стену.
                if (m_map[m_performerY + 1, m_performerX] != '*')
                {
                    // Если на положении, куда двигается персонаж, стоит враг.
                    if (m_map[m_performerY + 1, m_performerX] == '!')
                    {
                        // Снимаем 1 HP.
                        m_HP--;
                    }

                    // Графически меняем положение персонажа.
                    m_map[m_performerY, m_performerX] = ' ';
                    m_map[++m_performerY, m_performerX] = '■';

                    // Проверяем, оказался ли наш персонаж на выходе.
                    CheckExit(m_performerY, m_performerX);
                }
                break;

            case ConsoleKey.UpArrow:
                // Если персонаж двигается не в стену.
                if (m_map[m_performerY - 1, m_performerX] != '*')
                {
                    // Если на положении, куда двигается персонаж, стоит враг.
                    if (m_map[m_performerY - 1, m_performerX] == '!')
                    {
                        // Снимаем 1 HP.
                        m_HP--;
                    }

                    // Графически меняем положение персонажа.
                    m_map[m_performerY, m_performerX] = ' ';
                    m_map[--m_performerY, m_performerX] = '■';

                    // Проверяем, оказался ли наш персонаж на выходе.
                    CheckExit(m_performerY, m_performerX);
                }
                break;

            case ConsoleKey.LeftArrow:
                // Если персонаж двигается не в стену.
                if (m_map[m_performerY, m_performerX - 1] != '*')
                {
                    // Если на положении, куда двигается персонаж, стоит враг.
                    if (m_map[m_performerY, m_performerX - 1] == '!')
                    {
                        // Снимаем 1 HP.
                        m_HP--;
                    }

                    // Графически меняем положение персонажа.
                    m_map[m_performerY, m_performerX] = ' ';
                    m_map[m_performerY, --m_performerX] = '■';

                    // Проверяем, оказался ли наш персонаж на выходе.
                    CheckExit(m_performerY, m_performerX);
                    //Console.SetCursorPosition(m_performerX, m_performerY);
                }
                break;

            case ConsoleKey.RightArrow:
                // Если персонаж двигается не в стену.
                if (m_map[m_performerY, m_performerX + 1] != '*')
                {
                    // Если на положении, куда двигается персонаж, стоит враг.
                    if (m_map[m_performerY, m_performerX + 1] == '!')
                    {
                        // Снимаем 1 HP.
                        m_HP--;
                    }

                    // Графически меняем положение персонажа.
                    m_map[m_performerY, m_performerX] = ' ';
                    m_map[m_performerY, ++m_performerX] = '■';

                    // Проверяем, оказался ли наш персонаж на выходе.
                    CheckExit(m_performerY, m_performerX);
                }
                break;

            case ConsoleKey.F1:
                // Показать правильный маршрут лабиринта.
                break;

            case ConsoleKey.Escape:
                System.Environment.Exit(0);
                break;

            default:
                break;
        }
    }


    // private fields:
    // Мапа лабиринта.
    private char[,] m_map;
    // Положение персонажа в мапе в консоли по X и Y.
    private int m_performerX, m_performerY;
    // ХП персонажа.
    private int m_HP;
}

namespace BKP_Task_05
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаём экземпляр класса лабиринта.
            // В конструктор передаём название текстового файла с мапой.
            Labyrinth labyrinth = new Labyrinth("map");

            // Цикл выполнения игры.
            while (labyrinth.Init()) ;

            // Чтобы консольное окно не закрывалось после завершения программы.
            Console.ReadKey();
        }
    }
}
