using System;
using System.Collections.Generic;
using System.Text;
using Викторина.Data;
using System.IO;
using Викторина.Interfaces;
using Викторина.Models;

namespace Викторина.Cabinet.Quiz
{
    public class Questions
    {
        public static void StartHistoryQuiz(ICrud db, User user)
        {
            RunQuiz(db, user, "История", "History.txt");
        }

        public static void RunQuiz(ICrud db, User user, string topic, string filePath)
        {
            string fullPath = Path.GetFullPath(filePath);
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Файл не найден: {filePath}");
                Console.WriteLine($"Полный путь: {fullPath}");
                Console.WriteLine("Создайте файл или проверьте его расположение.");
                Console.ReadKey();
                return;
            }

            var lines = File.ReadAllLines(filePath);
            if (lines.Length == 0)
            {
                Console.WriteLine("Файл пуст!");
                Console.ReadKey();
                return;
            }
            int correctAnswersCount = 0;
            int totalQuestions = 0;

            Console.Clear();
            Console.WriteLine($"--- Викторина по теме: {topic} ---\n");

            for (int i = 0; i < lines.Length; i += 6)
            {
                if (i + 5 >= lines.Length) break;

                totalQuestions++;
                string question = lines[i];
                string[] options = { lines[i + 1], lines[i + 2], lines[i + 3], lines[i + 4] };
                string correctAnswer = lines[i + 5].Trim();

                Console.WriteLine($"Вопрос {totalQuestions}: {question}");
                for (int j = 0; j < 4; j++)
                {
                    Console.WriteLine($"{j + 1}. {options[j]}");
                }

                Console.Write("Ваш ответ (1-4): ");
                string? userChoice = Console.ReadLine();

                if (userChoice == correctAnswer)
                {
                    Console.WriteLine("Правильно!\n");
                    correctAnswersCount++;
                }
                else
                {
                    Console.WriteLine($"Неверно. Правильный ответ: {correctAnswer}\n");
                }
            }

            int scoreGained = correctAnswersCount * 10; // Например, 10 баллов за ответ
            user.Score += scoreGained;

            var result = new QuizResult
            {
                Id = Guid.NewGuid().ToString(),
                UserLogin = user.Login,
                Topic = topic,
                Date = DateTime.Now,
                TotalQuestions = totalQuestions,
                CorrectAnswers = correctAnswersCount,
                Score = scoreGained
            };

            user.Results.Add(result);
            db.Update(user);

            Console.WriteLine("Викторина окончена!");
            Console.WriteLine($"Правильных ответов: {correctAnswersCount} из {totalQuestions}");
            Console.WriteLine($"Заработано баллов: {scoreGained}");
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
