using System;
using Викторина.Interfaces;
using Викторина.Models;

namespace Викторина.Cabinet
{
    public class Settings
    {
        public static void ChangePassword(ICrud db, User user)
        {
            try
            {
                UI.Clear();
                UI.Print("Изменение паролья");

                string oldPassword = UI.ReadPassword("Введите старый пароль");

                if (user.Password != oldPassword)
                {
                    UI.Error("Неверный старый пароль!");
                    UI.WaitForKey();
                    return;
                }

                string newPassword = UI.ReadPassword("Введите новый пароль");
                string confirmPassword = UI.ReadPassword("Подтвердите новый пароль");

                if (newPassword != confirmPassword)
                {
                    UI.Error("Пароли не совпадают!");
                    UI.WaitForKey();
                    return;
                }

                user.Password = newPassword;
                db.Update(user);
                db.SaveChanges();

                UI.Success("Пароль успешно изменен!");
                UI.WaitForKey();
            }
            catch (Exception ex)
            {
                UI.Error($"Ошибка при смене пароля: {ex.Message}");
                UI.WaitForKey();
            }
        }
    }
}
