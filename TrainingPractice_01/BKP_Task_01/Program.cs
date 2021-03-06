﻿using System;

namespace BKP_Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вы: \"Да уж, и в правду, тяжёлый вышел рейд сегодня...\"" +
                "\nКьянеа: \"И то верно, зато мы заработали много золота!\"" +
                "\nВы: \"Я совсем забыл! Мы же давно не обновляли наше оружие!\"" +
                "\nКьянеа: \"Точно, мастер! Мой меч уже разваливается...\"" +
                "\nВы: \"Значит решено. Сегодня заскочим к Саре по пути до дома.\"" +
                "\n*Вы заглядываете в кошелёк*" +
                "\n>>Введите количество золота в кошельке: ");
            double gold = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("\nВы: \"Да уж, не густо, но думаю даже в столице найдётся экипировка за такую цену...\"" +
                "\nКьянеа: \"Мастер, я надеюсь, вы не забыли, что в столице не принимают золотые монеты?\"" +
                "\nВы: \"Чёрт! Как я мог забыть. Ладно, я знаю здесь одного парня, который может обменять нам их на здешнюю валюту. Давай за мной.\"" +
                "\nКьянеа: \"Да-да, уже бегу!\"" +
                "\n\n*Вы вошли в лавку торговца магических предметов*" +
                "\nПродавец: \"Ты снова по обмену? Задолбал, Лоуренс, куда мне твои золотые девать?\"" +
                "\nВы: \"Умоляю, Дарвин, выручи! Обещаю, это последний раз!\"" +
                "\nПродавец: \"Ладно, что же мне с тобой поделать...\"" +
                "\nВы: \"Курс не изменился? Всё так же?\"" +
                "\nПродавец: \"Цену не сброшу.\"" +
                "\nВы: \"Дарвин, молю тебя! У меня всё плохо с финансами.\"" +
                "\nПродавец: \"Должен же быть предел твоей наглости! Ладно, предлагай цену...\"" +
                "\n>>Введите цену кристалла в золотых монетах: ");
            double crystalPrice = Convert.ToDouble(Console.ReadLine());

            double crystalsToBuy = 14;
            Console.WriteLine("\nПродавец: \"У меня есть только " + crystalsToBuy + " кристаллов в наличии. Давай своё золото сюда!\"" +
                "\nПродавец: \"И ради этого ты меня от работы отвлекал? Ладно уж, что поделать.\"" +
                "\nВы: \"Прости, Дарвин, это в последний раз...\"" +
                "\nПродавец: \"Да-да, я слышу это уже сотый раз.\"");
            double crystals = 0;
            bool canConvert = (crystalsToBuy * crystalPrice) <= gold;

            if (canConvert)
            {
                crystals = crystalsToBuy;
                gold -= crystalsToBuy * crystalPrice;
                Console.WriteLine("\nПродавец: \"Всё, вали давай. У меня и так дел по горло!\"");
            }
            else
            {
                Console.WriteLine("\nПродавец: \"Да у тебя же даже не хватает денег! Вали с глаз моих долой!\"");
            }

            Console.WriteLine("\n*Баланс: {0} кристаллов, {1} золота*", crystals, gold);

            Console.ReadKey();
        }
    }
}
