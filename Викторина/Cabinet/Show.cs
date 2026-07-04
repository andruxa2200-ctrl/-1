using System;
using Викторина.Interfaces;

namespace Викторина.Cabinet
{
    public class Show
    {
        public static void All(ICrud db)
        {
            UI.Clear();
            UI.Print("Список участников \n");

            var all = db.GetAll();

            if (all != null)
            {
                UI.Print("Нет зарегистрированных участников!");
                return;
            }
            int counter = 1;

            foreach(var user in all)
            {
                UI.Print($"{counter}.{user.FirstName} {user.LastName} | Логин {user.Login} |  Email: {user.Email} | Баллы: {user.Score} ");   
                counter++;
            }
        }
    }
}

