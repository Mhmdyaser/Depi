using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class EssayQuestion: Question
    {
        public string CorrectAnswer { get; set; }
        public int WordLimit { get; set; }
        public override bool CheckAnswer(string answer)
        {
            if (string.IsNullOrWhiteSpace(answer))
            {
                Console.WriteLine("Answer cannot be empty.");
                return false;
            }

            if (answer.Length < WordLimit)
            {
                Console.WriteLine($"Your answer is too short");
                return false;
            }

            Console.WriteLine("Essay submitted. Instructor evaluate manually.");
            return false;
        }
        public EssayQuestion(string text, int marks, string correctAnswer, int wordLimit)
        {
            Text = text;
            Marks = marks;
            CorrectAnswer = correctAnswer;
            WordLimit = wordLimit;
        }
    }
}
