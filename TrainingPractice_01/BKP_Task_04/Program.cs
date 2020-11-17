using System;

public class Game
{
    public Game()
    {
        Random random = new Random();

        // Устанавливаем рандомное ХП и максимальное ХП героя.
        heroHP = random.Next(200, 300);
        maxHeroHP = random.Next(heroHP - 50, heroHP + 100);
        // Устанавливаем рандомное ХП босса.
        bossHP = random.Next(500, 800);
        // Рандомный первый ход.
        isHeroTurn = random.Next(2) == 1;
        //Устанавливаем показатели комбо на false.
        wasCyaneaeCasted = false;
        wasFeastCasted = false;
        wasSwordCasted = false;
    }

    public void Dialog()
    {
        Console.WriteLine("██████████████████████████▀████████████████████████████████████████████████████████████");
        Console.WriteLine("█▄─▄▄▀█▄─██─▄█▄─▀█▄─▄█─▄▄▄▄█▄─▄▄─█─▄▄─█▄─▀█▄─▄███▄─▀█▀─▄██▀▄─██─▄▄▄▄█─▄─▄─█▄─▄▄─█▄─▄▄▀█");
        Console.WriteLine("██─██─██─██─███─█▄▀─██─██▄─██─▄█▀█─██─██─█▄▀─█████─█▄█─███─▀─██▄▄▄▄─███─████─▄█▀██─▄─▄█");
        Console.WriteLine("▀▄▄▄▄▀▀▀▄▄▄▄▀▀▄▄▄▀▀▄▄▀▄▄▄▄▄▀▄▄▄▄▄▀▄▄▄▄▀▄▄▄▀▀▄▄▀▀▀▄▄▄▀▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀▀▄▄▄▀▀▄▄▄▄▄▀▄▄▀▄▄▀");
        Console.WriteLine("███████████████████████████████████████████████████████████████████████████████████████");

        Console.WriteLine("\nВы: \"Сегодня был неплохой рейд на подземелье, Кьянеа.\"" +
            "\nКьянеа: \"Вы как всегда великолепны, Мастер! Как вы раскидали тех гоблинов! Улёт!\"" +
            "\nВы: \"Ты тоже сегодня хорошо постаралась!\"" +
            "\nКьянеа: \"Вы меня смущаете, Мастер. Я путалась под ногами, не более.\"" +
            "\nВы: \"Не говори так, ты мне очень помогла.\"" +
            "\nКьянеа: \"К сожалению, я истратила весь свой запас маны за эти бои.\"" +
            "\nКьянеа: \"Долго же мне придётся восстанавливаться...\"" +
            "\nВы: \"Сейчас доберёмся до выхода и заскочим в столицу. Куплю тебе пару булочек.\"" +
            "\nКьянеа: \"Вы слишком добры ко мне...\"" +
            "\n*Ужасный рёв пронёсся по у выхода из подземелья*" +
            "\nВы: \"Ну не могло же всё быть так просто, и в правду.\"" +
            "\nКьянеа: \"Господин, что это?\"" +
            "\n*Кьянеа достала меч из ножен*" +
            "\nВы: \"Ты не способна сражаться, спрячься за тем монументом.\"" +
            "\nКьянеа \"Но, Мастер...\"" +
            "\nВы: \"Не волнуйся, я сам положу этого чудика.\"" +
            "\nКьянеа: \"Как прикажете...\"" +
            "\n*У ВЫХОДА ПОКАЗАЛСЯ ПРЕДВОДИТЕЛЬ ОРКОВ*" +
            "\nВы: \"Так вот, кто будет нашим боссом сегодня.\"" +
            "\nВы: \"Я как раз недостаточно размялся за сегодня, давай, нападай!\"" +
            "\n\n>> Нажмите ENTER для продолжения <<");
        Console.ReadKey();
        Console.Clear();
    }

    public bool Init()
    {
        if (heroHP <= 0)
        {
            Console.WriteLine("*Предводитель орков насмехается и приплясывает на вашем трупе под истошные крики Кьянеа*" +
                "\n\n  >>> ВЫ ПРОИГРАЛИ <<<");
            return false;
        }

        if (bossHP <= 0)
        {
            Console.WriteLine("Вы: \"Это было довольно просто. Хорошо, что нам попался такой слабый босс.\"" +
                "\nКьянеа: \"Мастер, Вы не правы! Он был очень силён!\"" +
                "\nВы: \"Может и так, может и так...\"" +
                "\nВы: \"В любом случае, давай выходить уже из этого подземелья.\"" +
                "\nКьянеа: \"Да, конечно!\"" +
                "\n\n  >>> ПОЗДРАВЛЯЕМ С ПОБЕДОЙ <<<");
            return false;
        }


        if (isHeroTurn)
        {
            Console.WriteLine(">> Вы: " + heroHP + "/" + maxHeroHP + " HP <<" +
            "\n>> Босс: " + bossHP + " HP <<\n");

            Cast();
        }
        else
        {
            Random random = new Random();

            int damage = random.Next(15, 75);

            heroHP -= damage;

            Console.WriteLine(" *Предводитель орков нанёс вам " + damage + " урона!*");

            Console.WriteLine(">> Вы: " + heroHP + "/" + maxHeroHP + " HP <<" +
            "\n>> Босс: " + bossHP + " HP <<\n");
        }

        // Чтобы прочитать результат.
        Console.WriteLine("\n>> Нажмите ENTER для продолжения <<");
        Console.ReadKey();

        // Передаём ход.
        isHeroTurn = !isHeroTurn;

        // Очищаем экран.
        Console.Clear();

        // TODO: Return false when HP <= 0
        return true;
    }

    private void Cast()
    {
        Console.WriteLine(" >> Выберите заклинание: <<" +
            "\n \"Огненный шар\" - наносит [40, 65] урона" +
            "\n \"Великое древо\" - восстанавливает [70, 100] здоровья" +
            "\n \"Удар мечом\" - наносит [30, 80] урона" +
            "\n \"Пир у капитана\" - наносит [30, 40] урона" +
            "\n \"Откуп смерти\" - может быть использовано только после \"Пир у капитана\", наносит [100, 120] урона" +
            "\n \"Тернистый щит\" - может быть использовано только после \"Удар мечом\", восстанавливает [40, 50] здоровья и наносит [20, 30] урона]" +
            "\n \"Кьянеа\" - наносит [10, 20] урона и восстанавливает [20, 30] здоровья" +
            "\n \"Мотивация\" - может быть использовано только после призыва \"Кьянеа\", наносит [70, 85] урона" +
            "\nВведите название заклинания ниже:");

        string spell = Console.ReadLine();
        Console.Write("\n*Вы использовали " + spell);

        Random random = new Random();
        int damage = 0;
        int heal = 0;

        switch (spell)
        {
            case "Огненный шар":
                damage = random.Next(40, 65);
                Console.WriteLine(" и нанесли " + damage + " урона!*");
                break;

            case "Великое древо":
                heal = random.Next(70, 100);
                Console.WriteLine(" и восстановили " + heal + " здоровья!*");
                break;

            case "Удар мечом":
                damage = random.Next(30, 80);
                Console.WriteLine(" и нанесли " + damage + " урона!*" +
                    "\nВы: \"Получай, нелепое создание!\"" +
                    "\nВы: *Главное не забыть про щит, а то урона от этого меча - кот наплакал...*");
                wasSwordCasted = true;
                break;

            case "Пир у капитана":
                damage = random.Next(30, 40);
                Console.WriteLine(" и нанесли " + damage + " урона!*" +
                    "\nДух капитана пиратов: \"Ё-хо-хо! Мужики, потрясём же костями за славного призывателя!\"");
                wasFeastCasted = true;
                break;

            case "Откуп смерти":
                if (!wasFeastCasted)
                {
                    Console.WriteLine(" и не нанесли урона!*" +
                        "\nДух капитана пиратов: \"Что за неумёха! Как я придам в жертву своих солдат, если ты их не призвал?\"" +
                        "\n*Вы не устроили капитану пир на прошлом ходу*" +
                        "\n*Урон не будет нанесён*");
                }
                else
                {
                    damage = random.Next(100, 120);
                    Console.WriteLine(" и нанесли " + damage + " урона!*" +
                        "\nДух капитана пиратов: \"Ну, спасибо, паренёк! Мы славно повеселились!\"");
                }
                wasFeastCasted = false;
                break;

            case "Тернистый щит":
                if (!wasSwordCasted)
                {
                    Console.WriteLine(" и не смогли призвать щит!*" +
                        "\nВы: \"Чёрт подери, я же не могу призвать щит до атаки! Всё время забываю!\"");
                }
                else
                {
                    damage = random.Next(20, 30);
                    heal = random.Next(40, 50);
                    Console.WriteLine(", нанесли " + damage + " урона и восстановили " + heal + " здоровья!*" +
                        "\nВы: \"Какая же полезная шмотка! Вот как её надо использовать!\"");
                }
                wasSwordCasted = false;
                break;

            case "Кьянеа":
                damage = random.Next(10, 20);
                heal = random.Next(20, 30);
                Console.WriteLine(", нанесли " + damage + " урона и восстановили " + heal + " здоровья!*" +
                    "\nКьянеа: \"Мастер, я ещё могу сражаться! Вы обязательно победите!\"");
                wasCyaneaeCasted = true;
                break;

            case "Мотивация":
                if (!wasCyaneaeCasted)
                {
                    Console.WriteLine(" и не нанесли урона!*" +
                        "\nКьянеа: \"Мастер! Я не успею! Подайте сигнал в следующий раз!\"" +
                        "\n*Вы не просили Кьянеа о помощи на прошлом ходу*" +
                        "\n*Урон не будет нанесён*");
                }
                else
                {
                    damage = random.Next(70, 85);
                    Console.WriteLine(" и нанесли " + damage + " урона!*" +
                        "\nКьянеа: \"Мастер, отлично сыграно! Вы великолепны!\"");
                }
                wasCyaneaeCasted = false;
                break;

            default:
                Console.WriteLine("*... " +
                    "\n*Похоже, Вы запутались в заклинаниях...*" +
                    "\n*Вы пропускаете ход!*");
                break;
        }

        bossHP -= damage;

        if (heroHP + heal > maxHeroHP)
        {
            heroHP = maxHeroHP;
        }
        else
        {
            heroHP += heal;
        }

    }

    // ХП героя.
    private int heroHP;
    private int maxHeroHP; // Максимальное здоровье героя.

    // ХП босса.
    private int bossHP;

    // Кто ходит (false - босс, true - герой).
    private bool isHeroTurn;

    // Проверка спеллов для комбо.
    private bool wasFeastCasted;   // Каст "Пир у капитана". 
    private bool wasSwordCasted;   // Каст "Удар мечом".
    private bool wasCyaneaeCasted; // Каст "Кьянеа".
}


namespace BKP_Task_04
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            // Диалог в начале боя.
            game.Dialog();

            // Сам процесс боёвки.
            while (game.Init()) ;

            // Чтобы удержать консольное окно открытым.
            Console.ReadKey();
        }
    }
}

/*
public class Character
{
    public Character(int HP, int MP)
    {
        Random random = new Random();
        m_HP = random.Next(HP - 50, HP + 50);
        m_MP = random.Next(MP - 100, MP + 100);
    }
    public void GetDamage(int damage)
    {
        m_HP -= damage;
    }
    public void Cast(string spell)
    {
        int damage = 0;
        Random random = new Random();

        switch (spell)
        {
            case "FireBlast":
                damage = random.Next(30, 40);
                break;
            case "IceBlast":
                damage = random.Next(50, 60);
                break;
            case "MassiveHeal":
                m_HP += 100;
                break;
        }

        GetDamage(damage);
    }

    public int m_HP { get; private set; } // Health.
    public int m_MP { get; private set; } // Mana.
}

public class Game
{
    public Game(Character hero, Character boss)
    {
        m_hero = hero;
        m_boss = boss;
        m_turn = 0;
    }

    private void Actions()
    {
        Console.WriteLine("");
    }

    public bool NextTurn()
    {
        Console.Clear();
        
        if (m_hero.m_HP <= 0)
        {
            Console.WriteLine(">> ГГ. Вас одолел босс! <<");
            return false;
        }

        if (m_boss.m_HP <= 0)
        {
            Console.WriteLine(">> ГГ. Вы победили босса! <<");
            return false;
        }
        
        m_turn++;
        Console.WriteLine(">> " + m_turn + "-й ход! <<" +
            "\n>> Вы: " + m_hero.m_HP + " HP, " + m_hero.m_MP + " MP <<" +
            "\n>> Босс: " + m_boss.m_HP + " HP, " + m_boss.m_MP + " MP <<");

        Console.WriteLine("Список заклинаний: " +
            "\n \"FireBlast\" - атакующее заклинание, поджигает врага и наносит периодический урон" +
            "\n \"IceBlast\" - атакующее заклинание, поджигает врага и уменьшает его урон на следующем ходу" +
            "\n \"MassiveHeal\" - восстанавливающее заклинание, хилит вас, но вы не можете акаковаь на этом ходу");

        return true;
    }

    private Character m_hero;
    private Character m_boss;
    private int m_turn;
}

namespace BKP_Task_04
{
    class Program
    {
        public static void InitDialog()
        {
            Console.WriteLine("██████████████████████████▀████████████████████████████████████████████████████████████");
            Console.WriteLine("█▄─▄▄▀█▄─██─▄█▄─▀█▄─▄█─▄▄▄▄█▄─▄▄─█─▄▄─█▄─▀█▄─▄███▄─▀█▀─▄██▀▄─██─▄▄▄▄█─▄─▄─█▄─▄▄─█▄─▄▄▀█");
            Console.WriteLine("██─██─██─██─███─█▄▀─██─██▄─██─▄█▀█─██─██─█▄▀─█████─█▄█─███─▀─██▄▄▄▄─███─████─▄█▀██─▄─▄█");
            Console.WriteLine("▀▄▄▄▄▀▀▀▄▄▄▄▀▀▄▄▄▀▀▄▄▀▄▄▄▄▄▀▄▄▄▄▄▀▄▄▄▄▀▄▄▄▀▀▄▄▀▀▀▄▄▄▀▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀▀▄▄▄▀▀▄▄▄▄▄▀▄▄▀▄▄▀");
            Console.WriteLine("███████████████████████████████████████████████████████████████████████████████████████");

            Console.WriteLine("\nВы: \"Сегодня был неплохой рейд на подземелье, Кьянеа.\"" +
                "\nКьянеа: \"Вы как всегда великолепны, Мастер! Как вы раскидали тех гоблинов! Улёт!\"" +
                "\nВы: \"Ты тоже сегодня хорошо постаралась!\"" +
                "\nКьянеа: \"Вы меня смущаете, Мастер. Я путалась под ногами, не более.\"" +
                "\nВы: \"Не говори так, ты мне очень помогла.\"" +
                "\nКьянеа: \"К сожалению, я истратила весь свой запас маны за эти бои.\"" +
                "\nКьянеа: \"Долго же мне придётся восстанавливаться...\"" +
                "\nВы: \"Сейчас доберёмся до выхода и заскочим в столицу. Куплю тебе пару булочек.\"" +
                "\nКьянеа: \"Вы слишком добры ко мне...\"" +
                "\n*Ужасный рёв пронёсся по у выхода из подземелья*" +
                "\nВы: \"Ну не могло же всё быть так просто, и в правду.\"" +
                "\nКьянеа: \"Господин, что это?\"" +
                "\n*Кьянеа достала меч из ножен*" +
                "\nВы: \"Ты не способна сражаться, спрячься за тем монументом.\"" +
                "\nКьянеа \"Но, Мастер...\"" +
                "\nВы: \"Не волнуйся, я сам положу этого чудика.\"" +
                "\nКьянеа: \"Как прикажете...\"" +
                "\n*У ВЫХОДА ПОКАЗАЛСЯ ПРЕДВОДИТЕЛЬ ОРКОВ*" +
                "\nВы: \"Так вот, кто будет нашим боссом сегодня.\"" +
                "\nВы: \"Я как раз недостаточно размялся за сегодня, давай, нападай!\"" +
                "\n\n>> Нажмите ENTER для продолжения <<");
            Console.ReadKey();
            Console.Clear();
        }


        static void Main(string[] args)
        {
            Console.Title = "Game of the year!";

            InitDialog();

            Character hero = new Character(200, 150);
            Character boss = new Character(500, 200);

            Game game = new Game(hero, boss);

            Console.WriteLine("Начальные значения ХП и МП: " +
            "\n>> Вы: " + hero.m_HP + " HP, " + hero.m_MP + " MP <<" +
            "\n>> Босс: " + boss.m_HP + " HP, " + boss.m_MP + " MP <<");

            while (game.NextTurn())
            {

            }

            Console.ReadKey();
        }
    }
}
*/