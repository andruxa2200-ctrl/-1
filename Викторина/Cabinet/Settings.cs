using System;
using System.Collections.Generic;
using System.Text;
using Викторина.Interfaces;
using Викторина.Models;

namespace Викторина.Cabinet
{
   public class Settings
    {
        public static void ChagaPassword(ICrud db, Registration user)
        {
            string oldPassword = Console.ReadLine()?.Trim() ?? string.Empty;

            if (user.Password != oldPassword)
            {
                return;
            }

            string newPassword = Console.ReadLine()?.Trim() ?? string.Empty;

            string confirmPassword = Console.ReadLine()?.Trim() ?? string.Empty;

            user.Password = newPassword;

            db.SaveChanges();
        }
    }
}
