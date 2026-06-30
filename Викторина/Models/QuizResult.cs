using System;
using System.Collections.Generic;
using System.Text;

namespace Викторина.Models
{
    public class QuizResult
    {
        public string? Id { get; set; }
        public string? UserLogin { get; set; }
        public string? Topic { get; set; }
        public DateTime Date { get; set; }
        public int TotalQuestions { get; set; }
        public int CorrectAnswers { get; set; }
        public int Score { get; set; }
    }
}// Результаты викторин 
