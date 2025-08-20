using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class Exam
    {
        private string _title;
        private Course _course;
        private List<Question> _questions;
        private bool _isStarted;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public Course Course
        {
            get { return _course; }
            set { _course = value; }
        }

        public List<Question> Questions
        {
            get { return _questions; }
            set
            {
                if (value == null || value.Count == 0)
                {
                    Console.WriteLine("Invalid Questions");
                }
                _questions = value;
            }
        }

        public bool IsStarted
        {
            get { return _isStarted; }
            set { _isStarted = value; }
        }
        public Exam(string title, Course course)
        {
            _title = title;
            _course = course;
            _questions = new List<Question>();
            _isStarted = false;
        }

        public void StartExam()
        {
            if (_isStarted)
            {
                Console.WriteLine("Exam is already started.");
                return;
            }
            _isStarted = true;
            Console.WriteLine($"Exam '{_title}' has started.");
        }
        public void AddQuestion(Question question)
        {

            if (_isStarted)
            {
                Console.WriteLine("Cannot modify exam ");
                return;
            }
            if (question == null)
            {
                Console.WriteLine("Invalid Question");
                return;
            }
            int totalMarks = _questions.Sum(q => q.Marks) + question.Marks;
            if (totalMarks > _course.MaxDegree)
            {
                Console.WriteLine("Cannot add question");
                return;
            }

            _questions.Add(question);
        }

        public void RemoveQuestion(Question question)
        {
            if (question == null || !_questions.Contains(question))
            {
                Console.WriteLine("Question not found in the exam.");
                return;
            }
            _questions.Remove(question);
        }

        public void EditQuestion(Question question, string newText, int newMark)
        {
            if (question == null || !_questions.Contains(question))
            {
                Console.WriteLine(" Question not found in the exam.");
                return;
            }

            question.Text = newText;
            question.Marks = newMark;

            Console.WriteLine(" Question updated successfully.");
        }

        public int GradeExam(Student student)
        {
            if (!_isStarted)
            {
                Console.WriteLine("Exam has not started yet.");
                return 0;
            }

            int score = 0;

            Console.WriteLine($"--- Exam: {Title} ---");
            foreach (var q in _questions)
            {
                Console.WriteLine($"Question ({q.Marks} marks): {q.Text}");

                
                if (q is EssayQuestion)
                {
                    Console.Write("Your Answer: ");
                    string essayAnswer = Console.ReadLine();
                    q.CheckAnswer(essayAnswer); 
                    continue;
                }

                
                if (q is MultipleChoice mcq)
                {
                    for (int i = 0; i < mcq.Options.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {mcq.Options[i]}");
                    }
                }

                Console.Write("Your Answer: ");
                string answer = Console.ReadLine();

                if (q.CheckAnswer(answer))
                {
                    score += q.Marks;
                }
            }

            Console.WriteLine($"Exam Finished. Final Score = {score}/{_course.MaxDegree}");
            student.Scores[this] = score; 
            return score;
        }

        public void ShowReport(Student student)
        {
            if (!student.Scores.ContainsKey(this))
            {
                Console.WriteLine($"No score found for student '{student.Name}' in exam '{Title}'.");
                return;
            }

            int score = student.Scores[this];
            string status = score >= (_course.MaxDegree / 2) ? "Pass" : "Fail";

            Console.WriteLine("--- Exam Report ---");
            Console.WriteLine($"Exam Title : {Title}");
            Console.WriteLine($"Course     : {_course.Title}");
            Console.WriteLine($"Student    : {student.Name}");
            Console.WriteLine($"Score      : {score}/{_course.MaxDegree}");
            Console.WriteLine($"Status     : {status}");
        }


        public void CompareStudents(Student s1, Student s2)
        {
            bool hS1 = s1.Scores.ContainsKey(this);
            bool hS2 = s2.Scores.ContainsKey(this);

            if (!hS1 || !hS2)
            {
                Console.WriteLine("Both students must have taken this exam to compare.");
                return;
            }

            int score1 = s1.Scores[this];
            int score2 = s2.Scores[this];

            Console.WriteLine($"--- Comparison in Exam: {Title} ---");
            Console.WriteLine($"{s1.Name}: {score1}/{_course.MaxDegree}");
            Console.WriteLine($"{s2.Name}: {score2}/{_course.MaxDegree}");

            if (score1 > score2)
                Console.WriteLine($"{s1.Name} scored higher.");
            else if (score2 > score1)
                Console.WriteLine($"{s2.Name} scored higher.");
            else
                Console.WriteLine("Both students scored the same.");
        }



    }
}
