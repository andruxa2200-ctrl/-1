using System;
using System.Collections.Generic;
using Викторина.Data;
using Викторина.Interfaces;

namespace Викторина.Models
{
    public class Menu
    {
        public static void Show()
        {
            ICrud db = new RegistrationRepository();
           
            var menuActions = new Dictionary<string, Action>()
            {
                { "1", () => Methods.AddRegistration(db) },
                { "2", () => Entrance.Login(db) },
                { "0", () => Environment.Exit(0) }
            };

            while (true)
            {
                try
                {
                    UI.Clear();
                    UI.Print("Главное меню");
                    UI.Print("1. Регистрация");
                    UI.Print("2. Вход (Логин)");
                    UI.Print("0. Выход");
                    UI.Print("");

                    string choice = UI.ReadString("Выберите пункт");

                    if (menuActions.TryGetValue(choice, out Action? action))
                    {
                        action();
                        if (choice != "0") UI.WaitForKey();
                    }
                    else
                    {
                        UI.Error("Неверный выбор! Пожалуйста, выберите пункт из списка.");
                        UI.WaitForKey();
                    }
                }
                catch (Exception ex)
                {
                    UI.Error($"Произошла непредвиденная ошибка: {ex.Message}");
                    UI.WaitForKey();
                }
            }
        }
    }
}
