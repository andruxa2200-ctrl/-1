using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Викторина.Interfaces;

namespace Викторина.Models
{
    public class Methods
    {
        private static bool ValidateUser(User user, out string? errorMessage)
        {
            var context = new ValidationContext(user);
            var results = new List<ValidationResult>();

            if (Validator.TryValidateObject(user, context, results, true))
            {
                errorMessage = null;
                return true;
            }
            errorMessage = string.Join("\n", results.Select(r => r.ErrorMessage));
            return false;
        }

        public static void AddRegistration(ICrud db)
        {
            while (true)
            {
                try
                {
                    UI.Clear();
                    UI.Print("Регистрация");

                    var user = new User
                    {
                        FirstName = UI.ReadString("Введите Имя"),
                        LastName = UI.ReadString("Введите Фамилию"),
                        Email = UI.ReadString("Введите Email"),
                        Login = UI.ReadString("Введите Логин"),
                        Password = UI.ReadPassword("Придумайте Пароль")
                    };

                    if (!ValidateUser(user, out string? errorMessage))
                    {
                        UI.Error($"Ошибка валидации:\n{errorMessage}");
                        if (UI.ReadString("Попробовать снова? (y/n)").ToLower() != "y") return;
                        continue;
                    }

                    db.Add(user);
                    UI.Success($"\nУчастник {user.FirstName} {user.LastName} успешно зарегистрирован!");
                    UI.Print($"Дата регистрации: {user.RegistrationDate}");
                    break;
                }
                catch (Exception ex)
                {
                    UI.Error($"Ошибка при регистрации: {ex.Message}");
                    if (UI.ReadString("Попробовать снова? (y/n)").ToLower() != "y") return;
                }
            }
        }
    }
}

