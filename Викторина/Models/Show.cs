using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Викторина.Interfaces;
using Викторина.Data;

namespace Викторина.Models
{
    public class Show
    {
        public static void All(ICrud db)
        {
            Console.Clear();
            Console.WriteLine("Список участников \n");

            var all= db.GetAll();

            if (all != null)
            {
                Console.WriteLine("Нет зарегистрированных участников!");
                return;
            }


        }

    }
}

