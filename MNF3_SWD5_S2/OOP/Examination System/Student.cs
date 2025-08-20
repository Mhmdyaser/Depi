using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class Student
    {
        private int _id;
        private string _name;
        private string _email;
        public Dictionary<Exam, int> Scores { get; set; } = new Dictionary<Exam, int>();
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine(" Invalid Name");
                }
                _name = value;
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
                {
                    Console.WriteLine("Invalid email");
                }
                _email = value;
            }
        }
        public Student(int id, string name, string email)
        {
            _id = id;
            Name = name;
            Email = email;
        }
    


    public void TakeExam(Exam exam)
        {
            if (exam == null)
            {
                Console.WriteLine("Invalid Exam");
                return;
            }
            exam.GradeExam(this);
        }

    }
}

