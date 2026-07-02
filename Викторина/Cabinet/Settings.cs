using System;
using System.Collections.Generic;
using System.Text;
using Викторина.Interfaces;
using Викторина.Models;

namespace Викторина.Cabinet
{
    public class Settings
    {
        public static void ChangePassword(ICrud db, User user)
        {
            Console.Clear();
            Console.WriteLine("Изменить пороль");

            Console.Write("Введите старый пароль: ");
            string oldPassword = Console.ReadLine()?.Trim() ?? string.Empty;

            if (user.Password != oldPassword)
            {
                Console.WriteLine("Неверный старый пароль!");
                Console.ReadKey();
                return;
            }

            Console.Write("Введите новый пароль: ");
            string newPassword = Console.ReadLine()?.Trim() ?? string.Empty;

            Console.Write("Подтвердите новый пароль: ");
            string confirmPassword = Console.ReadLine()?.Trim() ?? string.Empty;

            if (newPassword != confirmPassword)
            {
                Console.WriteLine("Пароли не совпадают!");
                Console.ReadKey();
                return;
            }

            user.Password = newPassword;
            db.Update(user);

            Console.WriteLine("Пароль успешно изменен!");
            Console.ReadKey();

            user.Password = newPassword;

            db.SaveChanges();
        }
    }
}
