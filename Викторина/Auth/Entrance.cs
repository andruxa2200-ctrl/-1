using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;        
using Викторина.Cabinet;
using Викторина.Data;
using Викторина.Interfaces;

namespace Викторина.Models
{
    public class Entrance
    {
        public static void Login(ICrud db)
        {  
            Console.Clear();
            Console.WriteLine("Вход в систему \n"); 

            Console.Write("Введите Login: ");
            string login = Console.ReadLine()?.Trim() ?? string.Empty;

            Console.Write("Введите password: ");
            string password = Console.ReadLine()?.Trim() ?? string.Empty;

            var user = db.GetAll().FirstOrDefault( x => x.Login == login);

            if(user == null) 
            {
                Console.WriteLine("Пользователь с таким Login не найден!");
             
                return;
                return;
            }
            if  (user.Password == password)
            {
                Console.WriteLine($"Вход выполнен! {user.FirstName}!");

                Profile.Show(db, user);

            }
            else
            {
                Console.WriteLine(" Неправильный пароль!");
              
            }

        }
      


    }
}
