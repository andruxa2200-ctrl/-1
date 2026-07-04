using System.Linq;
using Викторина.Interfaces;

namespace Викторина.Cabinet
{
    public class Top
    {
        public static void ShowTop(ICrud db)
        {
            UI.Clear();
            UI.Print("Топ-10 участников\n");

            var allUsers = db.GetAll();

            if (allUsers == null || !allUsers.Any())
            {
                UI.Print("Нет зарегистрированных участников!");
                UI.WaitForKey();
                return;
            }

            var top10 = allUsers
                     .OrderByDescending(u => u.Score)
                     .Take(10)
                     .ToList();

            UI.Print(string.Format("{0,-5} | {1,-15} | {2,-15} | {3,-6}", "№", "Логин", "Имя", "Баллы"));
            UI.Print(new string('-', 50));

            int place = 1;
            foreach (var user in top10)
            {
                UI.Print(string.Format("{0,-5} | {1,-15} | {2,-15} | {3,-6}", place, user.Login, user.FirstName, user.Score));
                place++;
            }

            UI.WaitForKey();
        }
    }
}

