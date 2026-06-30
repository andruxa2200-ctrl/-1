using System;
using System.Collections.Generic;
using System.Text;
using Викторина.Interfaces;
using Викторина.Models;

namespace Викторина.Cabinet
{
   public class Results
    {
        private static void Show(ICrud db, Registration user)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Показать мой результат: ");
                //var results = db.



            }
            Console.WriteLine("\nНажмите Enter для возврата...");
            Console.ReadLine();

        }

    }
}

