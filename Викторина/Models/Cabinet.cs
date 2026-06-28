using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Викторина.Interfaces;

namespace Викторина.Models
{
    public class Cabinet
    {
        public static void Show(ICrud db, Registration user)
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("Личный кабинет \n");
                Console.WriteLine($"Добро пожаловать, {user.FirstName} {user.LastName}!");

                Console.WriteLine($"Ваши баллы {user.Score} \n");

                Console.WriteLine("1. Новая викторина");
                Console.WriteLine("2. Мои результаты");
                Console.WriteLine("3. Топ - 20");
                Console.WriteLine("4. Настройки");
                Console.WriteLine("5. Выход из аккаунта");

                Console.WriteLine($"Выбирети пункт");
                string choice = Console.ReadLine();

                switch(choice) 
                {
                    case "1":
                        StartQuiz(db, user); 
                        break;




                }

            }

            //private static void StartQuiz(ICrud db, Registration user)
            //private static void ShowMyResults(ICrud db, Registration user)
            //private static void ShowTop20(ICrud db)
            
        }




    }
}
