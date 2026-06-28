using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;        
using Викторина.Interfaces;
using Викторина.Data;

namespace Викторина.Models
{
    public class Entrance
    {
        public static void Login(ICrud db)
        {  
            Console.Clear();
            Console.WriteLine("Вход в систему \n");

            Console.Write("Введите Email: ");
            string login = Console.ReadLine()?.Trim() ?? string.Empty;

            Console.Write("Введите password: ");
            string password = Console.ReadLine()?.Trim() ?? string.Empty;

            var user = db.GetAll().FirstOrDefault( x => x.Email == login);

            if(user == null) 
            {
                Console.WriteLine("Пользователь с таким Email не найден!");
                return;
            }
            if  (user.Password == password)
            {
                Console.WriteLine($"Вход выполнен! {user.FirstName}!");
              
            }
            else
            {
                Console.WriteLine(" Неправильный пароль!");
            }

        }
      


    }
}
