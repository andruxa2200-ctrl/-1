using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Викторина.Interfaces;

namespace Викторина.Cabinet
{
    public class Top
    {
        public static void ShowTop(ICrud db)
        {
            Console.Clear();
            Console.WriteLine("Показать Топ 20 участников: ");

            var allUser = db.GetAll();

            if (allUser == null || !allUser.Any())
            {
                Console.WriteLine("Нет зарегистрированых участников!");
                Console.WriteLine("\nНажмите Enter для возврата...");
                Console.ReadLine();
                return;
            }
            var top20 = allUser
                     .OrderByDescending(u => u.Score)
                     .Take(20)
                     .ToList();
            Console.WriteLine("Место | Имя | Фамилия | Баллы");

            int place = 1;
            foreach (var user in top20)
            {
                Console.WriteLine($"{place,4} | {user.FirstName,-10} | {user.LastName,-10} | {user.Score,5}");
                place++;
            }

            Console.WriteLine("\nНажмите Enter для возврата...");
            Console.ReadLine();

        }
    }
}

