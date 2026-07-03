using System;
using System.Linq;
using Викторина.Interfaces;
using Викторина.Models;

namespace Викторина.Cabinet
{
    public class Results
    {
        public static void Show(ICrud db, User user)
        {       
           
                Console.Clear();
                Console.WriteLine("Показать мой результат: ");

                if (user.Results == null || !user.Results.Any())
                {
                    Console.WriteLine("У вас пока нет результатов.");
                    Console.WriteLine("Пройдите викторину, чтобы получить результаты!");
                    Console.WriteLine("\nНажмите Enter для возврата...");
                    Console.ReadLine();
                    return;

                }
            foreach (var result in user.Results.OrderByDescending(r => r.Date))
            {
                Console.WriteLine($"{result.Date.ToShortDateString()} | {result.Topic} | Количество вопросов: {result.TotalQuestions} | Правильные ответы: {result.CorrectAnswers} | Баллы: {result.Score}");
            }

            Console.WriteLine("\nНажмите Enter для возврата...");
            Console.ReadLine();
        }

    }
}


