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
            // Защита от Path Traversal
            if (string.IsNullOrWhiteSpace(topicKey) || topicKey.Any(c => Path.GetInvalidFileNameChars().Contains(c) || c == '.'))
            {
                throw new ArgumentException("Недопустимое название темы викторины.");
            }

            if (!Directory.Exists(DirectoryPath)) Directory.CreateDirectory(DirectoryPath);
            
            string filePath = Path.Combine(DirectoryPath, $"{topicKey}.json");

            if (!File.Exists(filePath))
            {
                var defaultQuestions = Test.GetDefaultQuestions(topicKey);
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
    }
}
