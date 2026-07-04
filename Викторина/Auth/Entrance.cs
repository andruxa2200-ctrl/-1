﻿using System;
using System.Linq;
using Викторина.Cabinet;
using Викторина.Interfaces;

namespace Викторина.Models
{
    public class Entrance
    {
        public static void Login(ICrud db)
        {
            while (true)
            {
                try
                {
                    UI.Clear();
                    UI.Print("Вход в систему\n");

                    string login = UI.ReadString("Введите Login");
                    string password = UI.ReadPassword("Введите Password");

                    var user = db.GetAll().FirstOrDefault(x => x.Login == login);

                    if (user == null)
                    {
                        UI.Error("Пользователь с таким Login не найден!");
                        if (UI.ReadString("Попробовать снова? (y/n)").ToLower() != "y") return;
                        continue;
                    }

                    if (user.Password == password)
                    {
                        UI.Success($"Вход выполнен! Добро пожаловать, {user.FirstName}!");
                        UI.WaitForKey();
                        Profile.Menu(db, user);
                        break;
                    }
                    else
                    {
                        UI.Error("Неправильный пароль!");
                        if (UI.ReadString("Попробовать снова? (y/n)").ToLower() != "y") return;
                    }
                }
                catch (Exception ex)
                {
                    UI.Error($"Ошибка при входе: {ex.Message}");
                    if (UI.ReadString("Попробовать снова? (y/n)").ToLower() != "y") return;
                }
            }
        }
    }
}
