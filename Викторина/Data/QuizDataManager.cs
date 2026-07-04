using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Викторина.Models;

namespace Викторина.Data
{
    public static class QuizDataManager
    {
        private static readonly string DirectoryPath = "Quizzes";

        public static List<QuestionModel> GetRandomQuestions(string topicKey, int count)
        {
            var allQuestions = LoadQuestions(topicKey);
            
            if (allQuestions.Count == 0) return new List<QuestionModel>();

            var random = new Random();
            return allQuestions.OrderBy(x => random.Next()).Take(count).ToList();
        }

        private static List<QuestionModel> LoadQuestions(string topicKey)
        {
            if (!Directory.Exists(DirectoryPath)) Directory.CreateDirectory(DirectoryPath);
            
            string filePath = Path.Combine(DirectoryPath, $"{topicKey}.json");

            if (!File.Exists(filePath))
            {
                var defaultQuestions = GetDefaultQuestions(topicKey);
                SaveQuestions(topicKey, defaultQuestions);
                return defaultQuestions;
            }

            try
            {
                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<QuestionModel>>(json) ?? new List<QuestionModel>();
            }
            catch
            {
                return new List<QuestionModel>();
            }
        }

        private static void SaveQuestions(string topicKey, List<QuestionModel> questions)
        {
            string filePath = Path.Combine(DirectoryPath, $"{topicKey}.json");
            string json = JsonSerializer.Serialize(questions, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        private static List<QuestionModel> GetDefaultQuestions(string topicKey)
        {
            var questions = new List<QuestionModel>();
            for (int i = 1; i <= 20; i++)
            {
                questions.Add(new QuestionModel 
                {
                    Text = $"Вопрос №{i} по теме {topicKey}?",
                    Options = new List<string> { "Вариант 1", "Вариант 2", "Вариант 3", "Вариант 4" },
                    CorrectIndex = 0
                });
            }
            return questions;
        }
    }
}


            string existingJson = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<QuestionModel>>(existingJson) ?? new List<QuestionModel>();
        }

        private static List<QuestionModel> GetDefaultQuestions(string topic)
        {
            return topic switch
            {
                "History" => new List<QuestionModel>
                {
                    new QuestionModel 
                    { 
                        Text = "В каком году распался СССР?",
                        Options = new List<string> { "1990", "1991", "1993", "1989" },
                        CorrectIndex = 1 
                    },
                    new QuestionModel 
                    { 
                        Text = "Кто был первым царем всея Руси?",
                        Options = new List<string> { "Петр I", "Иван IV Грозный", "Александр I",
                            "Николай II" }, CorrectIndex = 1 
                    }
                },
                "Geography" => new List<QuestionModel>
                {
                    new QuestionModel 
                    {
                        Text = "Самая длинная река в мире?",
                        Options = new List<string> { "Амазонка", "Нил", "Янцзы", "Миссисипи" },
                        CorrectIndex = 1 
                    },
                    new QuestionModel 
                    {
                        Text = "Столица Австралии?",
                        Options = new List<string> { "Сидней", "Мельбурн", "Канберра", "Перт" }, 
                        CorrectIndex = 2 
                    }
                },
                "Science" => new List<QuestionModel>
                {
                    new QuestionModel 
                    {
                        Text = "Химический символ золота?", 
                        Options = new List<string> { "Ag", "Fe", "Au", "Cu" }, 
                        CorrectIndex = 2 
                    },
                    new QuestionModel 
                    {
                        Text = "Сколько планет в Солнечной системе?", 
                        Options = new List<string> { "7", "8", "9", "10" }, 
                        CorrectIndex = 1 
                    }
                },
                _ => new List<QuestionModel>()
            };
        }
    }
}
