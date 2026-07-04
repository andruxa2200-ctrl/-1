﻿﻿﻿﻿﻿﻿﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Викторина.Interfaces;

namespace Викторина.Models
{
    public class Methods
    {
        public static void AddRegistration(ICrud db)
        {
            UI.Clear();
            UI.Print("Регистрация\n");

            string firstName = ReadValidatedProperty("Введите Имя", (val) => !string.IsNullOrWhiteSpace(val), "Имя не может быть пустым.");
            string lastName = ReadValidatedProperty("Введите Фамилию", (val) => !string.IsNullOrWhiteSpace(val), "Фамилия не может быть пустым.");
            string email = ReadValidatedProperty("Введите Email", (val) => val.Contains("@") && val.Contains("."), "Введите корректный Email.");
            string login = ReadValidatedProperty("Введите Логин", (val) => 
            {
                if (val.Length < 2) return false;
                if (db.GetAll().Any(u => u.Login == val))
                {
                    UI.Error("Такой логин уже существует!");
                    return false;
                }
                return true;
            }, "Логин должен быть не менее 2 символов.");
            string password = ReadValidatedPassword("Введите Пароль", (val) => val.Length >= 4, "Пароль должен быть не менее 4 символов.");

            var user = new User();
            user.SetRegistrationData(firstName, lastName, email, login, password);

            db.Add(user);
            db.SaveChanges();
            UI.Success($"\nУчастник {user.FirstName} {user.LastName} успешно зарегистрирован!");
            UI.Print($"Дата регистрации: {user.RegistrationDate}");
            UI.WaitForKey();
        }


        private static string ReadValidatedProperty(string prompt, Func<string, bool> validator, string errorMsg)
        {
            while (true)
            {
                string value = UI.ReadString(prompt);
                if (validator(value)) return value;
                UI.Error(errorMsg);
            }
        }

        private static string ReadValidatedPassword(string prompt, Func<string, bool> validator, string errorMsg)
        {
            while (true)
            {
                string value = UI.ReadPassword(prompt);
                if (validator(value)) return value;
                UI.Error(errorMsg);
            }
        }
    }
}
