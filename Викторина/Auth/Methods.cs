using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using Викторина.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;




namespace Викторина.Models
{
    public class Methods
    {
        private static bool ValidateContact(Registration registration, out string? errorMessage)
        {
            var context = new ValidationContext(registration);
            var results = new List<ValidationResult>();

            if (Validator.TryValidateObject(registration, context, results, true))
            {
                errorMessage = null;
                return true;
            }
            errorMessage = string.Join("\n", results.Select(r => r.ErrorMessage));
            return false;
        }
        public static void AddRegistration(ICrud db)
        {
            Console.Clear();
            Console.WriteLine("Регистрация на векторину:");

            Console.WriteLine("Введите Имя:");
            var firstName = Console.ReadLine()?.Trim();


            Console.WriteLine("Введите фамилию:");
            var lastName = Console.ReadLine()?.Trim();

            Console.WriteLine("Введите Email: ");
            var email = Console.ReadLine()?.Trim();

            Console.WriteLine("Введите логин");
            var Login = Console.ReadLine()?.Trim();

            Console.WriteLine("Введите пароль:");
            var password = Console.ReadLine()?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(email))
            {
                Console.WriteLine("Имя и Email нужно записать!");
                return;
            }
            var registration = new Registration 
            { 
                FirstName = firstName,
                LastName = lastName ?? string.Empty,
                Email = email, Password = password,
                Login = Login 
            };
            if (!ValidateContact(registration, out string? errorMessage))
            {
                Console.WriteLine($"\nОшибка:\n{errorMessage}");
              
                return;
            }
            db.Add(registration);
            Console.WriteLine($"\n Участник {firstName} {lastName}  успешно зарегистрирован!");
            Console.WriteLine($"\n Дата регистрации: {registration.RegistrationDate}");
            Console.WriteLine($" Время регистрации: {registration.RegistrationDate.ToShortTimeString()}");
        }
    }
}
