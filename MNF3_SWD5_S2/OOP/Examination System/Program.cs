namespace Examination_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Course course = new Course("C# Basics", "Introduction to C# Programming", 100);

           
            instructor inst1 = new instructor(1, "Dr. Ahmed", "Programming");
            course.AssignInstructor(inst1);

         
            Student student1 = new Student(1, "Mohamed", "Mohamed@gmail.com");
            Student student2 = new Student(2, "Malak", "Malak@gmail.com");

            course.EnrollStudent(student1);
            course.EnrollStudent(student2);

          
            Exam exam = new Exam("C# Exam - Midterm", course);

            
            exam.AddQuestion(new MultipleChoice(
                "What is the size of int in C#?", 10,
                new List<string> { "2 bytes", "4 bytes", "8 bytes" }, "2"  ));

            exam.AddQuestion(new TrueFalse("C# is case sensitive?",5,true ));

            exam.AddQuestion(new EssayQuestion("Explain the difference between class and object.", 20, "Manual Evaluation", 10  ));

           
            exam.StartExam();

            
            Console.WriteLine($"\n--- {student1.Name} taking exam ---");
            student1.TakeExam(exam);

           
            Console.WriteLine($"\n--- {student2.Name} taking exam ---");
            student2.TakeExam(exam);

           
            exam.ShowReport(student1);
            exam.ShowReport(student2);

          
            exam.CompareStudents(student1, student2);

            Console.WriteLine("\n--- Program Finished ---");
        }
    }
}
