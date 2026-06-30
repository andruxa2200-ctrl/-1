using System;
using System.Collections.Generic;
using System.Text;

namespace Викторина.Models
{
    public class Usercs
    {
        public string? FirsName { get; set; }
        public string? LastName {  get; set; }
        public string? Password { get; set; }
        public string? Login {  get; set; }
        public int Score { get; set; }
        public DateTime? Created { get; set; }
        public List<QuizResult> Results { get; set; } = new List<QuizResult>();

        // Информация о пользователе и хранение данных
    }
}
