using System;
using System.Collections.Generic;
using System.Text;
using Викторина.Data;
using Викторина.Interfaces;
using Викторина.Models;

namespace Викторина.Cabinet.Quiz
{
    public class QuizsGame
    {
        public static void Start(ICrud db, User user)
        {
            Console.Clear();
            Console.WriteLine("Новая викторина: ");

            Console.WriteLine("Выберите тему:");
            Console.WriteLine("1. История");
            Console.WriteLine("2. География");
            Console.WriteLine("3. Наука");   
            Console.WriteLine("4. Назад");

            Console.Write("Ваш выбор: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Questions.StartHistoryQuiz(db, user);
                    break;
                case "2":
                    StartGeographyQuiz(db, user);
                    break;
                case "3":
                    StartScienceQuiz(db, user);
                    break;
                case "4":
                    return;
                default:            
                    break;
            }
        }

        private static void StartGeographyQuiz(ICrud db, User user) { }
        private static void StartScienceQuiz(ICrud db, User user) { }
    }
}