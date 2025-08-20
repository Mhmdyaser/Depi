using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class MultipleChoice : Question
    {
        public List<string> Options { get; set; } = new List<string>();
        public string CorrectAnswer { get; set; }

        public override bool CheckAnswer(string answer)
        {
            return answer.Equals(CorrectAnswer, StringComparison.OrdinalIgnoreCase);
        }
    
    public MultipleChoice(string text, int marks, List<string> options, string correctAnswer)
        {
            Text = text;
            Marks = marks;
            Options = options;
            CorrectAnswer = correctAnswer;
        }
    }
}
