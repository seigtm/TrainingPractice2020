﻿using System;

namespace BKP_Task_03
{
    class Program
    {
        static void Main(string[] args)
        {
            const string password = "admin";

            for (int i = 0; i < 3; ++i)
            {
                Console.WriteLine("Введите пароль: ");
                string userPassword = Console.ReadLine();

                if (password == userPassword)
                {
                    Console.WriteLine("Успешный вход!");
                    break;
                }
            }
            Console.ReadKey();
        }
    }
}
