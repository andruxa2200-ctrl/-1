﻿﻿﻿﻿﻿﻿﻿﻿﻿using System;
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

            string firstName = UI.ReadValidated("Введите Имя", (val) => !string.IsNullOrWhiteSpace(val), "Имя не может быть пустым.");
            string lastName = UI.ReadValidated("Введите Фамилию", (val) => !string.IsNullOrWhiteSpace(val), "Фамилия не может быть пустым.");
            string email = UI.ReadValidated("Введите Email", (val) => val.Contains("@") && val.Contains("."), "Введите корректный Email.");
            string login = UI.ReadValidated("Введите Логин", (val) => 
            {
                if (val.Length < 2) return false;
                if (db.GetAll().Any(u => u.Login == val))
                {
                    UI.Error("Такой логин уже существует!");
                    return false;
                }
                return true;
            }, "Логин должен быть не менее 2 символов.");
            string password = UI.ReadValidated("Введите Пароль", (val) => val.Length >= 4, "Пароль должен быть не менее 4 символов.", true);

            var user = new User();
            user.SetRegistrationData(firstName, lastName, email, login, password);

            db.Add(user);
            db.SaveChanges();
            UI.Success($"\nУчастник {user.FirstName} {user.LastName} успешно зарегистрирован!");
            UI.Print($"Дата регистрации: {user.RegistrationDate}");
            UI.WaitForKey();
        }
    }
}
