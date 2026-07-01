using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Викторина.Data;
using Викторина.Interfaces;


namespace Викторина.Models
{
    public class Menu
    {
        public static void Show()
        {
            ICrud db = new RegistrationRepository();
            db.Load();

            var menu = new Dictionary<string, Action>()
            {
             { "1. Регистрация", () => Methods.AddRegistration(db) },
             { "2. Вход (Логин)", () => Entrance.Login(db) },
             { "3. Выход", () => Environment.Exit(0) }         
            };
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Регистрация");
                foreach (var item in menu)
                {
                    Console.WriteLine(item.Key);
                }
                Console.WriteLine("Выберите пункт \n");
                string? choice = Console.ReadLine();

                bool found = false;
                foreach (var item in menu)
                {
                    if (item.Key.StartsWith(choice))
                    {
                        item.Value();
                        found = true;

                        if (choice != "3")
                        {
                            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                            Console.ReadKey();
                        }
                        break;
                    }
                }
                if (!found && choice != "3")
                {
                    Console.WriteLine("Неверный выбор!");
                    Console.ReadKey();
                }
            }
        }
    }
}