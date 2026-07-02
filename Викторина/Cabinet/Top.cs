using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Викторина.Interfaces;
using Викторина.Models;

namespace Викторина.Cabinet
{
    public class Top
    {
        public static void ShowTop(ICrud db)
        {
            Console.Clear();
            Console.WriteLine("=== ТОП-20 УЧАСТНИКОВ ===\n");

            var allUsers = db.GetAll();

            if (allUsers == null || !allUsers.Any())
            {
                Console.WriteLine("Нет зарегистрированных участников!");
                Console.WriteLine("\nНажмите любую клавишу для возврата...");
                Console.ReadKey();
                return;
            }

            var top20 = allUsers
                     .OrderByDescending(u => u.Score)
                     .Take(20)
                     .ToList();

            Console.WriteLine("{0,-5} | {1,-15} | {2,-15} | {3,-6}", "№", "Логин", "Имя", "Баллы");
            Console.WriteLine(new string('-', 50));

            int place = 1;
            foreach (var user in top20)
            {
                Console.WriteLine("{0,-5} | {1,-15} | {2,-15} | {3,-6}", place, user.Login, user.FirstName, user.Score);
                place++;
            }

            Console.WriteLine("\nНажмите любую клавишу для возврата...");
            Console.ReadKey();
        }
    }
}

