using System;
using System.IO;

public class Map
{
    // public:
    // Конструктор с параметрами.
    public Map(string mapName)
    {
        // Считываем мапу из файла.
        ReadMap(mapName);
        // Задаём изначальное ХП = 10.
        m_HP = 10;

        // Рисуем в самом начале мапу и ХП-бар.
        DrawMap();
        DrawBar();

        // Получаем положение ХП-бара в консоли.
        // (Пригодится, чтобы убавлять показатели ХП.)
        m_barX = Console.CursorLeft + 10; // по количеству символов нужно сделать +10 по X.
        m_barY = Console.CursorTop - 1;   // и -1 по Y.
    }

    public bool Init()
    {

        // Если у персонажа закончилось ХП.
        if (m_HP <= 0)
        {
            return false;
        }

        // Если персонаж встал на символ % (выход).
        if (m_map[m_performerY, m_performerX] == '%')
        {
            return false;
        }

        // Выполняем передвижение персонажа.
        Move();

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
            Console.ReadKey();
            System.Environment.Exit(0);
        }
    }

    // Проверка наличия врага на координатах.
    private void CheckEnemy(int Y, int X)
    {
        // Если на положении, куда двигается персонаж, стоит враг.
        if (m_map[Y, X] == '!')
        {
            // Снимаем 1 HP.
            m_HP--;
            // В ХП-баре убираем один символ ХП - решётку #.
            Console.SetCursorPosition(m_barX--, m_barY);
            Console.Write('_');
        }

        // Если наш враг - наш след (иронично).
        if (m_map[Y, X] == '▼')
        {
            Console.Clear();
            Console.WriteLine(" **    ВЫ ВСТАЛИ НА СВОЙ СЛЕД!   **" +
                            "\n >> До свидания! Спасибо за игру! << ");
            Console.ReadKey();
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
                    // Проверяем наличие врага на координате.
                    CheckEnemy(m_performerY + 1, m_performerX);

                    // Графически меняем положение персонажа.
                    Console.SetCursorPosition(m_performerX, m_performerY);
                    // Рисуем след за персонажем.
                    Console.Write('▼');
                    m_map[m_performerY, m_performerX] = '▼';
                    Console.SetCursorPosition(m_performerX, ++m_performerY);
                    Console.Write('■'); // Рисуем новое положение персонажа.

                    // Проверяем, оказался ли наш персонаж на выходе.
                    CheckExit(m_performerY, m_performerX);
                }
                break;

            case ConsoleKey.UpArrow:
                // Если персонаж двигается не в стену.
                if (m_map[m_performerY - 1, m_performerX] != '*')
                {
                    // Проверяем наличие врага на координате.
                    CheckEnemy(m_performerY - 1, m_performerX);

                    // Графически меняем положение персонажа.
                    Console.SetCursorPosition(m_performerX, m_performerY);
                    // Рисуем след за персонажем.
                    Console.Write('▼');
                    m_map[m_performerY, m_performerX] = '▼';
                    Console.SetCursorPosition(m_performerX, --m_performerY);
                    Console.Write('■');

                    // Проверяем, оказался ли наш персонаж на выходе.
                    CheckExit(m_performerY, m_performerX);
                }
                break;

            case ConsoleKey.LeftArrow:
                // Если персонаж двигается не в стену.
                if (m_map[m_performerY, m_performerX - 1] != '*')
                {
                    // Проверяем наличие врага на координате.
                    CheckEnemy(m_performerY, m_performerX - 1);

                    // Графически меняем положение персонажа.
                    Console.SetCursorPosition(m_performerX, m_performerY);
                    // Рисуем след за персонажем.
                    Console.Write('▼');
                    m_map[m_performerY, m_performerX] = '▼';
                    Console.SetCursorPosition(--m_performerX, m_performerY);
                    Console.Write('■');

                    // Проверяем, оказался ли наш персонаж на выходе.
                    CheckExit(m_performerY, m_performerX);

                }
                break;

            case ConsoleKey.RightArrow:
                // Если персонаж двигается не в стену.
                if (m_map[m_performerY, m_performerX + 1] != '*')
                {
                    // Проверяем наличие врага на координате.
                    CheckEnemy(m_performerY, m_performerX + 1);

                    // Графически меняем положение персонажа.
                    Console.SetCursorPosition(m_performerX, m_performerY);
                    // Рисуем след за персонажем.
                    Console.Write('▼');
                    m_map[m_performerY, m_performerX] = '▼';
                    Console.SetCursorPosition(++m_performerX, m_performerY);
                    Console.Write('■');

                    // Проверяем, оказался ли наш персонаж на выходе.
                    CheckExit(m_performerY, m_performerX);
                }
                break;

            case ConsoleKey.Escape:
                Console.Clear();
                Console.WriteLine(" >> До свидания! Спасибо за игру! << ");
                Console.ReadKey();
                System.Environment.Exit(0);
                break;

            default:
                break;
        }
    }


    // private fields:
    // Мапа.
    private char[,] m_map;
    // Положение персонажа в мапе в консоли по X и Y.
    private int m_performerX, m_performerY;
    // Положение ХП-бара в консольном окне по X и Y.
    private int m_barX, m_barY;
    // ХП персонажа.
    private int m_HP;
}

namespace BKP_Task_05
{
    class Program
    {
        static void Main(string[] args)
        {
            // Правила игры.
            Console.WriteLine(">>>              Правила игры                        <<<" +
                            "\n> Всё достаточно просто!                               <" +
                            "\n> Двигайте персонажа на клавиши стрелок                <" +
                            "\n> Клавиша ESC - выход из программы                     <" +
                            "\n> Доступные пути на карте отображаются символом #      <" +
                            "\n> Стены - *, ловушки (наносят урон) - !, ваш герой - ■ <" +
                            "\n> Ваш персонаж оставляет за собой след!                <" +
                            "\n> Если вы попытаетесь повернуть назад, то проиграете!  <" +
                            "\n>>>      МУЖИКИ НЕ ОБОРАЧИВАЮТСЯ НА ВЗРЫВЫ!          <<<" +
                            "\n> Если вы потеряете всё ХП, то проиграете!             <" +
                            "\n> Необходимо дойти до финиша (символ %)                <" +
                            "\n***             УДАЧНОЙ ИГРЫ!                        ***" +
                            "\n\n     > ...Нажмите ENTER для продолжения... < ");

            Console.ReadKey();
            Console.Clear();

            // Создаём экземпляр класса карты (я решил не делать лабиринт, хотя на него похоже).
            // В конструктор передаём название текстового файла с мапой.
            Map map = new Map("map");

            // Цикл выполнения игры.
            while (map.Init()) ;
            // Внутри Init() программа сама завершит свою работу, если
            //  герой встанет на свой след или пройдёт игру.
            // Потому, в данном случае, цикл завершится только если
            //  ХП персонажа опустится до нуля.

            // После чего выведется такое сообщение поражения:
            Console.Clear();
            Console.WriteLine(" >> Вы проиграли! Спасибо за игру! << ");

            Console.ReadKey();
        }
    }
}


/*
             Мапа:

    ************************
    *■**************#####***
    *#********###!###***!***
    *#********#*****#***!***
    *###!!!!**#*****#***#***
    ***#***#**!*****#####***
    ***#***#**!*****#***#***
    ***#***#**!**#**###!!***
    ***#***#**#**#**#***#***
    ***!***#**#**#**#***#***
    ***#***####**#**##**#***
    **##****#****#***#**#***
    *##*****##!###***##!##%*
    ************************
*/