using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class Course
    {
        private string _Title;
        private string _Description;
        private int _maxDegree;

        public List<Exam> Exams { get; set; } = new List<Exam>();
        public List<Student> Students { get; set; } = new List<Student>();
        public List<instructor> Instructors { get; set; } = new List<instructor>();

        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        public int MaxDegree
        {
            get { return _maxDegree; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("invalid");
                }
                _maxDegree = value;
            }
        }

        public Course(string title, string description, int maxDegree)
        {
            _Title = title;
            _Description = description;
            MaxDegree = maxDegree;
        }

        public bool EnrollStudent(Student student)
        {
            if (student == null)
            {
                Console.WriteLine("Invalid student.");
                return false;
            }

            foreach (var s in Students)
            {
                if (s.Id == student.Id)
                {
                    Console.WriteLine("Student already enrolled in this course.");
                    return false;
                }
            }

            Students.Add(student);
            Console.WriteLine($"Student '{student.Name}' enrolled in course '{Title}'.");
            return true;
        }

        public bool AssignInstructor(instructor inst)
        {
            if (inst == null)
            {
                Console.WriteLine("Invalid instructor.");
                return false;
            }

            foreach (var t in Instructors)
            {
                if (t.Id == inst.Id)
                {
                    Console.WriteLine("Instructor already assigned to this course.");
                    return false;
                }
            }

            Instructors.Add(inst);
            Console.WriteLine($"Instructor '{inst.Name}' assigned to course '{Title}'.");
            return true;
        }
    }
}
