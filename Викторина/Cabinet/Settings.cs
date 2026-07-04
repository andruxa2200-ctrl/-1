﻿﻿﻿﻿﻿﻿﻿﻿﻿using System;
using System.ComponentModel.DataAnnotations;
using Викторина.Interfaces;
using Викторина.Models;

namespace Викторина.Cabinet
{
    public class Settings
    {
        
        public static void ChangePassword(ICrud db, User user)
        {
            while (true)
            {
                try
                {
                    UI.Clear();
                    UI.Print("Настройки профиля\n");
                    UI.Print($"Текущий пользователь: {user.FirstName} {user.LastName}");
                    UI.Print("1. Изменить Имя");
                    UI.Print("2. Изменить Фамилию");
                    UI.Print("3. Изменить пароль");
                    UI.Print("0. Назад");

                    string choice = UI.ReadString("Выберите пункт");

                    switch (choice)
                    {
                        case "1":
                            string newName = UI.ReadString("Введите новое Имя");
                            if (!string.IsNullOrWhiteSpace(newName))
                            {
                                user.UpdateProfile(newName, user.LastName);
                                db.Update(user);
                                db.SaveChanges();
                                UI.Success("Имя успешно изменено!");
                                UI.WaitForKey();
                            }
                            break;
                        case "2":
                            string newLastName = UI.ReadString("Введите новую Фамилию");
                            if (!string.IsNullOrWhiteSpace(newLastName))
                            {
                                user.UpdateProfile(user.FirstName, newLastName);
                                db.Update(user);
                                db.SaveChanges();
                                UI.Success("Фамилия успешно изменена!");
                                UI.WaitForKey();
                            }
                            break;

                        case "3":
                            UpdatePassword(db, user);
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
                    UI.Error($"Ошибка в настройках: {ex.Message}");
                    UI.WaitForKey();
                }
            }
        }

        private static void UpdatePassword(ICrud db, User user)
        {
            while (true)
            {
                string oldPassword = UI.ReadPassword("Введите старый пароль");

                if (user.Password != oldPassword)
                {
                    UI.Error("Неверный старый пароль!");
                    if (UI.ReadString("Попробовать снова? (y/n)").ToLower() != "y") return;
                    continue;
                }
                break;
            }

            while (true)
            {
                string newPassword = UI.ReadPassword("Введите новый пароль");
                
                if (newPassword.Length < 4)
                {
                    UI.Error("Пароль слишком короткий (минимум 4 символа)!");
                    if (UI.ReadString("Попробовать снова? (y/n)").ToLower() != "y") return;
                    continue;
                }

                string confirmPassword = UI.ReadPassword("Подтвердите новый пароль");

                if (newPassword != confirmPassword)
                {
                    UI.Error("Пароли не совпадают!");
                    if (UI.ReadString("Попробовать снова? (y/n)").ToLower() != "y") return;
                    continue;
                }

                user.ChangePassword(newPassword);
                db.Update(user);
                db.SaveChanges();

                UI.Success("Пароль успешно изменен!");
                UI.WaitForKey();
                break;
            }
        }
    }
}
