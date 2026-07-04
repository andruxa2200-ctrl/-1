﻿using System;
using Викторина.Interfaces;
using Викторина.Models;
using Викторина.Data;

namespace Викторина.Cabinet.Quiz
{
    public class Questions
    {
        public static void RunQuiz(ICrud db, User user, string topicName, string topicKey)
        {
            try
            {
                // Получаем 10 случайных вопросов из 20 доступных в JSON
                var questions = QuizDataManager.GetRandomQuestions(topicKey, 10);
                
                if (questions.Count == 0)
                {
                    UI.Error("Вопросы для этой темы не найдены или файл поврежден!");
                    UI.WaitForKey();
                    return;
                }

                int correctAnswersCount = 0;
                UI.Clear();
                UI.Print($"--- Викторина по теме: {topicName} ---\n");
                UI.Print("Вам предстоит ответить на 10 случайных вопросов.\n");

                for (int i = 0; i < questions.Count; i++)
                {
                    var q = questions[i];
                    UI.Print($"Вопрос {i + 1} из {questions.Count}: {q.Text}");
                    
                    for (int j = 0; j < q.Options.Count; j++)
                    {
                        UI.Print($"{j + 1}. {q.Options[j]}");
                    }

                    int userChoice = UI.ReadInt("Ваш ответ", 1, q.Options.Count);

                    if (userChoice - 1 == q.CorrectIndex)
                    {
                        UI.Success("Правильно!\n");
                        correctAnswersCount++;
                    }
                    else
                    {
                        UI.Error($"Неверно. Правильный ответ: {q.Options[q.CorrectIndex]}\n");
                    }
                }

                FinishQuiz(db, user, topicName, correctAnswersCount, questions.Count);
            }
            catch (Exception ex)
            {
                UI.Error($"Произошла ошибка во время викторины: {ex.Message}");
                UI.WaitForKey();
            }
        }

        private static void FinishQuiz(ICrud db, User user, string topic, int correctCount, int totalCount)
        {
            int scoreGained = correctCount * 10;
            user.Score += scoreGained;

            var result = new QuizResult
            {
                Id = Guid.NewGuid().ToString(),
                UserLogin = user.Login,
                Topic = topic,
                Date = DateTime.Now,
                TotalQuestions = totalCount,
                CorrectAnswers = correctCount,
                Score = scoreGained
            };

            user.Results.Add(result);
            db.Update(user);

            UI.Print("Викторина окончена");
            UI.Print($"Правильных ответов: {correctCount} из {totalCount}");
            UI.Success($"Заработано баллов: {scoreGained}");
            UI.WaitForKey();
        }
    }
}
