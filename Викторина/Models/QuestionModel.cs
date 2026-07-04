using System.Collections.Generic;

namespace Викторина.Models
{
    public class QuestionModel
    {
        public string Text { get; set; } = string.Empty;
        public List<string> Options { get; set; } = new List<string>();
        public int CorrectIndex { get; set; }
    }
}
