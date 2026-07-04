using System;
using Викторина.Interfaces;
using Викторина.Models;
using Викторина.Data;

namespace Викторина.Cabinet.Quiz
{
    public class QuizsGame
    {
        public static void Start(ICrud db, User user)
        {
            while (true)
            {
                try
                {
                    UI.Clear();
                    UI.Print("Выбор темы викторины\n");
                    UI.Print("1. История");
                    UI.Print("2. География");
                    UI.Print("3. Наука");
                    UI.Print("4. Назад");
                    UI.Print("");

                    string choice = UI.ReadString("Ваш выбор");

                    switch (choice)
                    {
                        case "1":
                            Questions.RunQuiz(db, user, "История", "History");
                            break;
                        case "2":
                            Questions.RunQuiz(db, user, "География", "Geography");
                            break;
                        case "3":
                            Questions.RunQuiz(db, user, "Наука", "Science");
                            break;
                        case "4":
                            return;
                        default:
                            UI.Error("Неверный выбор!");
                            UI.WaitForKey();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    UI.Error($"Ошибка в меню викторины: {ex.Message}");
                    UI.WaitForKey();
                }
            }
        }
    }
}
