using System.Collections.Generic;
using Викторина.Models;

namespace Викторина.Data
{
    public static class Test
    {
        public static List<QuestionModel> GetDefaultQuestions(string topicKey)
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
