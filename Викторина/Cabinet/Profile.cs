﻿using System;
using System.Linq;
using Викторина.Cabinet.Quiz;
using Викторина.Interfaces;
using Викторина.Models;

namespace Викторина.Cabinet
{
    public class Profile
    {
        public static void Menu(ICrud db, User user)
        {
            while (true)
            {
                try
                {
                    UI.Clear();
                    UI.Print("Личный кабинет\n");
                    UI.Print($"Добро пожаловать, {user.FirstName} {user.LastName}!");
                    UI.Print($"Ваши баллы: {user.Score}\n");

                    UI.Print("1. Новая викторина");
                    UI.Print("2. Мои результаты");
                    UI.Print("3. Топ - 10");
                    UI.Print("4. Список участников");
                    UI.Print("5. Настройки");
                    UI.Print("6. Добавить вопросы (Тест)");
                    UI.Print("0. Выход из аккаунта");
                    UI.Print("");

                    string choice = UI.ReadString("Выберите пункт");

                    switch (choice)
                    {
                        case "1":
                            QuizsGame.Start(db, user);
                            break;
                        case "2":
                            Results.Show(db, user);
                            break;
                        case "3":
                            Top.ShowTop(db);
                            break;
                        case "4":
                            Show.All(db);
                            break;
                        case "5":
                            Settings.ChangePassword(db, user);
                            break;
                        case "6":
                            if (CheckAdminAccess(db))
                            {
                                AddTestQuestions();
                            }
                            break;
                        case "0":
                            return;

                        default:
                            UI.Error("Неверный выбор!");
                            UI.WaitForKey();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    UI.Error($"Произошла ошибка в личном кабинете: {ex.Message}");
                    UI.WaitForKey();
                }
            }
        }

        private static bool CheckAdminAccess(ICrud db)
        {
            UI.Clear();
            UI.Print("Доступ ограничен");
            UI.Print("Для входа в режим редактирования вопросов требуется пароль Администратора.\n");

            var admin = db.GetAll().FirstOrDefault(u => u.Login.Equals("Admin", StringComparison.OrdinalIgnoreCase));
            
            if (admin == null)
            {
                UI.Error("Пользователь 'Admin' не найден в системе. Доступ невозможен.");
                UI.WaitForKey();
                return false;
            }

            string password = UI.ReadPassword("Введите пароль Администратора");

            if (admin.Password == password)
            {
                UI.Success("Доступ разрешен!");
                UI.WaitForKey();
                return true;
            }
            else
            {
                UI.Error("Неверный пароль!");
                UI.WaitForKey();
                return false;
            }
        }

        private static void AddTestQuestions()
        {
            try
            {
                UI.Clear();
                UI.Print("Добавление тестовых вопросов\n");
                UI.Print("Выберите тему для добавления вопросов:");
                UI.Print("1. История");
                UI.Print("2. География");
                UI.Print("3. Наука");
                UI.Print("4. Отмена");

                string topicChoice = UI.ReadString("Ваш выбор");
                string topicKey = topicChoice switch
                {
                    "1" => "History",
                    "2" => "Geography",
                    "3" => "Science",
                    _ => ""
                };

                if (string.IsNullOrEmpty(topicKey)) return;

                var questions = Data.QuizDataManager.GetRandomQuestions(topicKey, 100); // Загружаем все текущие
                
                UI.Print($"\nТекущее количество вопросов в {topicKey}: {questions.Count}");
                int countToAdd = UI.ReadInt("Сколько вопросов добавить?", 1, 50);

                for (int i = 0; i < countToAdd; i++)
                {
                    UI.Print($"\nДобавление вопроса {i + 1}:");
                    var q = new Models.QuestionModel();
                    q.Text = UI.ReadString("Введите текст вопроса");
                    
                    for (int j = 0; j < 4; j++)
                    {
                        q.Options.Add(UI.ReadString($"Введите вариант ответа {j + 1}"));
                    }
                    
                    q.CorrectIndex = UI.ReadInt("Введите номер правильного ответа", 1, 4) - 1;
                    questions.Add(q);
                }

                string directoryPath = "Quizzes";
                string filePath = System.IO.Path.Combine(directoryPath, $"{topicKey}.json");
                string json = System.Text.Json.JsonSerializer.Serialize(questions, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
                System.IO.File.WriteAllText(filePath, json);

                UI.Success("\nВопросы успешно добавлены!");
                UI.WaitForKey();
            }
            catch (Exception ex)
            {
                UI.Error($"Ошибка при добавлении вопросов: {ex.Message}");
                UI.WaitForKey();
            }
        }
    }
}
