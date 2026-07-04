using System.Linq;
using Викторина.Interfaces;
using Викторина.Models;

namespace Викторина.Cabinet
{
    public class Results
    {
        public static void Show(ICrud db, User user)
        {
            UI.Clear();
            UI.Print("Мои результаты\n");

            if (user.Results == null || !user.Results.Any())
            {
                UI.Print("У вас пока нет результатов.");
                UI.Print("Пройдите викторину, чтобы получить результаты!");
                UI.WaitForKey();
                return;
            }

            foreach (var result in user.Results.OrderByDescending(r => r.Date))
            {
                UI.Print($"{result.Date:dd.MM.yyyy HH:mm} | {result.Topic} | Вопросов: {result.TotalQuestions} | Верно: {result.CorrectAnswers} | Баллы: {result.Score}");
            }

            UI.WaitForKey();
        }
    }
}


