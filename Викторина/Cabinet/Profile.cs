using System;
using Викторина.Cabinet.Quiz;
using Викторина.Interfaces;
using Викторина.Models;

namespace Викторина.Cabinet
{
    public class Profile
    {
        public static void Show(ICrud db, User user)
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
                    UI.Print("3. Топ - 20");
                    UI.Print("4. Настройки");
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
                            Settings.ChangePassword(db, user);
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
    }
}
