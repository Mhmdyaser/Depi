using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class TrueFalse: Question
    {
        public bool CorrectAnswer { get; set; }
        public override bool CheckAnswer(string answer)
        {
            if (bool.TryParse(answer, out bool userAnswer))
            {
                return userAnswer == CorrectAnswer;
            }
            else
            {
                Console.WriteLine(" Please enter 'true' or 'false'.");
                return false;
            }
        }
        
        public TrueFalse(string text, int marks, bool correctAnswer)
        {
            Text = text;
            Marks = marks;
            CorrectAnswer = correctAnswer;
        }
    }
}
