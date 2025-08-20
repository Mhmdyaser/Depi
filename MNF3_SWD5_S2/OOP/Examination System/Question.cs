using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    abstract class Question
    {
        private string _text;
        private int _marks;

        public string Text
        {
            get { return _text; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Invalid Question Text");
                }
                _text = value;
            }
        }
        public int Marks
        {
            get { return _marks; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Invalid Marks");
                }
                _marks = value;
            }
        }
        public abstract bool CheckAnswer(string answer);

        
    }
}
